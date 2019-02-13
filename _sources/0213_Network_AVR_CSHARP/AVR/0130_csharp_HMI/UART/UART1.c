/*
 * UART1.c
 *
 * Created: 2019-01-30 오후 12:00:02
 *  Author: kccistc
 */ 
#include <avr/io.h>

#define STX 0x02
#define ETX 0x03

void UART1_init(void)
{
	UBRR1H = 0x00;
	UBRR1L = 207;				// 9,600 보율로 설정

	UCSR1A |= _BV(U2X1);		// 2배속 모드
	UCSR1C |= 0x06;				// 비동기, 8비트 데이터, 패리티없음, 1비트 정지 비트 모드

	UCSR1B |= _BV(RXEN1);		// 송수신가능
	UCSR1B |= _BV(TXEN1);
}

void UART1_transmit(char data)
{
	while( !(UCSR1A & (1 << UDRE1)) );		// 송신 가능 대기
	UDR1 = data;
}

unsigned char UART1_receive(void)
{
	while ( !(UCSR1A & (1 << RXC1)) );		// 데이터 수신 대기
	return UDR1;
}

void UART1_print_string(char *str)
{
	for(int i = 0; str[i]; i++)				// '\0'문자를 만날때까지 반복
		UART1_transmit(str[i]);				// 바이트 단위 출력
}

void UART1_print_1_byte_number(uint8_t n)
{
	char numString[4] = "0";
	int i, index = 0;

	if (n > 0)
	{
		// 문자열 변환
		for (i=0; n != 0; i++)
		{
			numString[i] = n % 10 + '0';
			n = n /10;
		}

		numString[i] = '\0';
		index = i - 1;
	}

	for (i = index; i >= 0; i--)				// 변환된 문자열을 역순으로 출력
		UART1_transmit(numString[i]);
}

void UART1_KW_protocol(char *str)
{
	// 프로토콜 STX[01]Payload[01]ETX[01]
	UART1_transmit(STX);

	UART1_print_string(str);

	UART1_transmit(ETX);
}