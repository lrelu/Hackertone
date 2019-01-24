#include <Servo.h>

bool _isLED = false;
Servo _sv;
int _value = 90;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  //LED 초기설정
  pinMode(7, OUTPUT);
  digitalWrite(7,HIGH);

  //서보모터 초기설정
  _sv.attach(3);
  _sv.write(_value);
}

void loop() {
  // put your main code here, to run repeatedly:
  char data;
  if (Serial.available() > 0) {
    data = Serial.read();

    // 정제
    if (data == '1' || data == '0'){
      if (data == '1')
        _isLED = true;
      else
        _isLED = false;
    }

    if (data == 'R'){
      _value += 10;
      _sv.write(_value);
     }
     if (data == 'L'){
      _value -= 10;
      _sv.write(_value);
     }

     Serial.print("Data: ");
     Serial.println(data);
  }

  ControlLED();

  delay(100);
}

void ControlLED(){
  if (_isLED)
      digitalWrite(7, HIGH);
    else
      digitalWrite(7,LOW);
}
