/*
 * UART0.c
 *
 * Created: 2019-01-30 오후 12:00:02
 *  Author: kccistc
 */ 
#include <avr/io.h>

#define STX 0x02
#define ETX 0x03

void UART0_init(void)
{
	UBRR0H = 0x00;
	UBRR0L = 207;				// 9,600 보율로 설정

	UCSR0A |= _BV(U2X0);		// 2배속 모드
	UCSR0C |= 0x06;				// 비동기, 8비트 데이터, 패리티없음, 1비트 정지 비트 모드

	UCSR0B |= _BV(RXEN0);		// 송수신가능
	UCSR0B |= _BV(TXEN0);

	// 수신 인터럽트 셋팅
	UCSR0B |= (1 << RXCIE0);
}

void UART0_transmit(char data)
{
	while( !(UCSR0A & (1 << UDRE0)) );		// 송신 가능 대기
	UDR0 = data;
}

unsigned char UART0_receive(void)
{
	while ( !(UCSR0A & (1 << RXC0)) );		// 데이터 수신 대기
	return UDR0;
}

void UART0_print_string(char *str)
{
	for(int i = 0; str[i]; i++)				// '\0'문자를 만날때까지 반복
		UART0_transmit(str[i]);				// 바이트 단위 출력
}

void UART0_print_1_byte_number(uint8_t n)
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
		UART0_transmit(numString[i]);
}

void UART0_KW_protocol(char *str)
{
	// 프로토콜 STX[01]Payload[01]ETX[01]
	UART0_transmit(STX);

	UART0_print_string(str);
	
	UART0_transmit(ETX);
}