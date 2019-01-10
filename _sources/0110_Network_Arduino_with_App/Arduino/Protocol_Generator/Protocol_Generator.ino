// 날자, 온도, 습도, 조도, 거리 
// 프로토콜 구조 (!온도|습도|조도|거리@)
// 예: 23|20|9|5

// 센서값
int temperature, huminity, bright, distance;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // 센서에서 온도, 습도, 조도, 거리 읽기
  GetSensor();

  // 시리얼 출력
  //SerialPrint_Protocol();

  // Json으로 출력
  SerialPrint_Json();

  // 1초에 한번씩 센서값을 출력
  delay(1000);
}

void GetSensor(){
  temperature = random(20, 25);
  huminity = random(5, 30);
  bright = random(7, 10);
  distance = random(0, 100);
}

void SerialPrint_Protocol(){
  Serial.print(temperature); Serial.print("|");
  Serial.print(huminity); Serial.print("|");
  Serial.print(bright); Serial.print("|");
  Serial.println(distance);
}

void SerialPrint_Json(){
  Serial.print("{");
  Serial.print("temperature:"); Serial.print(temperature);Serial.print(",");
  Serial.print("huminity:"); Serial.print(huminity);Serial.print(",");
  Serial.print("bright:"); Serial.print(bright);Serial.print(",");
  Serial.print("distance:"); Serial.print(distance);
  Serial.println("}");
}
