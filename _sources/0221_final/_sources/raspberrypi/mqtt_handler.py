# -*- coding: utf-8 -*-
import paho.mqtt.client as mqtt

class MQTT:
    broker = ""
    client = mqtt.Client()

    def __init__(self, broker):
        self.broker = broker
        return

    @classmethod
    def subscribe(cls):
        # publish할 주소와 포트번호 연결
        cls.client.connect(self.broker, port=1883, keepalive=60)
        cls.client.loop_start()

    @classmethod
    def publish(cls, topic, message):
        cls.client.publish(topic, message)

    @classmethod
    def cancel(cls):
        cls.client.loop_stop()
        cls.client.disconnect()

mqtt = mqtt_handler()
mqtt.subscribe()
mqtt.publish("message send")


