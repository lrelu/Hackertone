import paho.mqtt.client as mqtt
import time

def on_message(client, userdata, message):
    print("message receive ", str(message.payload.decode("utf-8")))
    print("message topic=", message.topic)
    print("message qos=", message.qos)
    print("message retain flag=", message.retain)


broker_address = "broker.mqttdashboard.com"
print("create new instance")
client = mqtt.Client()
client.on_message = on_message

print("conneting to broker")
client.connect(broke r_address, port=1883, keepalive=60)
client.loop_start()
print("subscribing to topic", "scada/kw/degree")
client.subscribe("scada/kw/degree")

try:
    while True:
        time.sleep(2)

except KeyboardInterrupt:
    print("Finished!")
    client.loop_stop()
    client.disconnect()