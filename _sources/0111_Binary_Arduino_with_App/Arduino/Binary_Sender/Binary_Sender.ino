// 바이너리 센더
// 프로토콜 정의
// STX(8비트)|Key|Length|Data(payload)|Tail(CRC16)
// 확인하기 위해서 우선 STX는 ASCII @ (0x40)로 한다
// Tail도 시리얼 모니터에서 확인하기 위해 \ (0x5C)로 함
// KEY = 0x7E

void setup() {
  Serial.begin(9600);
}

void loop() {
  // 바이너리 출력 테스트
  // Data
  int[] data = {11,22};
  Serial.write(0x40);     // STL
  Serial.write(0x7E);     // KEY
  Serial.write(0x0F);     // Data Size 16
  Serial.write('@');
  //Serial.write(
  Serial.println();
  delay(1000);
}
