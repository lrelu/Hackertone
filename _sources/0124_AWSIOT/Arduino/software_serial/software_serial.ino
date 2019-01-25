/*
  Software serial multple serial test

 Receives from the hardware serial, sends to software serial.
 Receives from software serial, sends to hardware serial.

 The circuit:
 * RX is digital pin 10 (connect to TX of other device)
 * TX is digital pin 11 (connect to RX of other device)

 Note:
 Not all pins on the Mega and Mega 2560 support change interrupts,
 so only the following can be used for RX:
 10, 11, 12, 13, 50, 51, 52, 53, 62, 63, 64, 65, 66, 67, 68, 69

 Not all pins on the Leonardo and Micro support change interrupts,
 so only the following can be used for RX:
 8, 9, 10, 11, 14 (MISO), 15 (SCK), 16 (MOSI).

 created back in the mists of time
 modified 25 May 2012
 by Tom Igoe
 based on Mikal Hart's example

 This example code is in the public domain.

 */
#include <SoftwareSerial.h>

SoftwareSerial mySerial(3, 2); // RX, TX
const int LED = 12;

void setup() {
  // Open serial communications and wait for port to open:
  Serial.begin(115200);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }

  // set the data rate for the SoftwareSerial port
  mySerial.begin(9600);

  // LED
  pinMode(LED, OUTPUT);
}

void loop() { // run over and over
  if (mySerial.available()) {
    //Serial.write(mySerial.read());
    char data = mySerial.read();
    Serial.write(data);

    //받은 값에서 LED제어
    //controlLED(data);
    if (data == 'Y')
      digitalWrite(LED, HIGH);
    else if (data == 'N')
      digitalWrite(LED, LOW); 
  }
  if (Serial.available()) {
    mySerial.write(Serial.read());
  }
}

void controlLED(char data){
  if (data == '|'){
    char temp = mySerial.read();
    temp = mySerial.read();
    Serial.write(temp);
    if (temp == 'Y')
      digitalWrite(LED, HIGH);
    else if (temp == 'N')
      digitalWrite(LED, LOW);
  }
}
