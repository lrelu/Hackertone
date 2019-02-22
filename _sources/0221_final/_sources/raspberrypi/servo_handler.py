import RPi.GPIO as GPIO
import paho.mqtt.client as mqtt
import time


class RES:
    mamager = 0
    people = 0

    def __init__(self):
        return


class MQTT:
    client = mqtt.Client()

    def __init__(self):
        return

    @staticmethod
    def on_message(client, userdata, message):
        print("message receive ", str(message.payload.decode("utf-8")))
        print("message topic=", message.topic)
        #print("message qos=", message.qos)
        #print("message retain flag=", message.retain)

        if message.topic == "hackathon/raspbian/people":
            RES.people = int(message.payload.decode("utf-8"))

    @classmethod
    def subscribe(cls):
        cls.client.connect("broker.mqttdashboard.com", port=1883, keepalive=60)
        cls.client.on_message = cls.on_message
        cls.client.loop_start()
        cls.client.subscribe("hackathon/raspbian/#")

    @classmethod
    def publish(cls, message):
        cls.client.publish("hackathon/raspbian/robot/state", message)

    @classmethod
    def cancel(cls):
        cls.client.loop_stop()
        cls.client.disconnect()


class servoHandler:
    setup = False
    running = False

    mqtt = MQTT()

    #loopPerSecond = 1000
    #servoPerSecond = 100

    #loopCount = 0

    sv2_motion = [10, 7.5]
    sv3_motion = [7.5, 10]
    sv4_motion = [7.5, 10]
    sv5_motion = [7.5, 12]

    def __init__(self):
        GPIO.setmode(GPIO.BCM)
        GPIO.setup(2, GPIO.OUT)  # trunk
        GPIO.setup(3, GPIO.OUT)  # shoulder
        GPIO.setup(4, GPIO.OUT)  # elbow
        GPIO.setup(5, GPIO.OUT)  # wrist

        self.sv2 = GPIO.PWM(2, 50)
        self.sv3 = GPIO.PWM(3, 50)
        self.sv4 = GPIO.PWM(4, 50)
        self.sv5 = GPIO.PWM(5, 50)

        return

    def setup(self):
        self.setup = True
        self.running = True

        self.mqtt.subscribe()
        time.sleep(1)
        self.mqtt.publish("connect robot arm")

        GPIO.setmode(GPIO.BCM)
        GPIO.setup(2, GPIO.OUT)  # elbow
        GPIO.setup(3, GPIO.OUT)  # shoulder
        GPIO.setup(4, GPIO.OUT)  # trunk
        GPIO.setup(5, GPIO.OUT)  # wrist

        GPIO.setup(21, GPIO.IN)  # emergency stop

        self.sv2 = GPIO.PWM(2, 50)
        self.sv3 = GPIO.PWM(3, 50)
        self.sv4 = GPIO.PWM(4, 50)
        self.sv5 = GPIO.PWM(5, 50)

        self.sv2.start(7.5)
        self.sv3.start(7.5)
        self.sv4.start(7.5)
        self.sv5.start(7.5)

        return

    def loop(self):
        if not self.setup:
            return

        try:
            while self.running:

                if RES.people > 0 and RES.mamager == 0:
                    time.sleep(0.01)
                    continue

                for i in range(0, len(self.sv2_motion)):
                    prev2, prev3, prev4, prev5 = 0, 0, 0, 0

                    # JOG move
                    for k in range(0, 10):

                        temp2 = (self.sv2_motion[i] - self.sv2_motion[i - 1]) / 10.0
                        temp3 = (self.sv3_motion[i] - self.sv3_motion[i - 1]) / 10.0
                        temp4 = (self.sv4_motion[i] - self.sv4_motion[i - 1]) / 10.0
                        temp5 = (self.sv5_motion[i] - self.sv5_motion[i - 1]) / 10.0

                        prev2 = (k == 0) and self.sv2_motion[i - 1] + temp2 or prev2 + temp2
                        prev3 = (k == 0) and self.sv3_motion[i - 1] + temp3 or prev3 + temp3
                        prev4 = (k == 0) and self.sv4_motion[i - 1] + temp4 or prev4 + temp4
                        prev5 = (k == 0) and self.sv5_motion[i - 1] + temp5 or prev5 + temp5

                        self.sv2.ChangeDutyCycle(prev4)  # elbow
                        self.sv3.ChangeDutyCycle(prev4)  # shoulder
                        self.sv4.ChangeDutyCycle(prev4)  # trunk
                        self.sv5.ChangeDutyCycle(prev5)  # wrist

                        # wait for servo dwell time
                        time.sleep(0.1)

                    # wait for next move
                    time.sleep(1)

                time.sleep(0.01)

        except KeyboardInterrupt:
            print("Finished!")
            self.mqtt.cancel()


servo = servoHandler()
servo.setup()
servo.loop()