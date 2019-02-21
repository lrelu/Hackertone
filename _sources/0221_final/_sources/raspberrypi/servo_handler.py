import RPi.GPIO as GPIO
import time

class servo_handler:
    setup = False
    running = False

    mqtt = mqtt_handler.MQTT("broker.mqttdashboard.com")

    #loopPerSecond = 1000
    #servoPerSecond = 100

    #loopCount = 0

    def __init__(self):
        return

    def setup(self):
        self.setup = True
        self.running = True

        self.mqtt.subscribe()
        time.sleep(1)
        self.mqtt.publish("connect robot arm")
        return

    def loop(self):
        if not self.setup:
            return

        while self.running:



            time.sleep(0.01)
        return


servo = servo_handler()
servo.setup()
servo.loop()
