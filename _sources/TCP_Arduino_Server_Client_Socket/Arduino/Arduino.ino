/*
 Name:		Arduino.ino
 Created:	2019-01-17 오후 2:13:58
 Author:	kccistc
*/

// the setup function runs once when you press reset or power the board
#include <SoftwareSerial.h>
#define BT_RXD 2 
#define BT_TXD 3 
SoftwareSerial ESP_wifi(BT_RXD, BT_TXD);

void setup() {
	Serial.begin(9600);
	
	pinMode(7, OUTPUT);
	digitalWrite(7, HIGH);

	ESP_wifi.begin(9600);
	ESP_wifi.setTimeout(5000);
	delay(1000);
}

// the loop function runs over and over again until power down or reset
void loop() {
	if (Serial.available()) {
		ESP_wifi.write(Serial.read());
	}
	if (ESP_wifi.available()) {
		Serial.write(ESP_wifi.read());
	}
}
