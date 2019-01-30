/*
 * 0130_csharp_HMI.c
 *
 * Created: 2019-01-30 오전 11:24:59
 * Author : kccistc
 */ 

#define F_CPU 16000000L
#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include "UART/UART0.h"

// 인터럽트 사용
// 현재 LED 상태
volatile int _state = 0;
volatile char _queue[256];
volatile int _protocol = 0;
volatile int _buffer = 0;

ISR(INT0_vect)
{
	_state = (_state + 1) % 2;
}

ISR(USART0_RX_vect)
{
	_queue[_buffer] = UDR0;

	if (_queue[_buffer] == 0x03)
	{
		_protocol = 1;
		_buffer = 0;
	}else{
		_buffer++;
	}	
}

void INIT_PORT(void)
{
	DDRA |= 0x01;			// LED 포트 A의 1개핀만 출력으로 설정

	DDRD &= ~0x01;			// 버튼 포트 D의 1개핀만 입력으로 설정
	PORTD |= 0x01;			// 버튼 포트 D의 PD0은 내부 풀업 저항을 사용하도록 설정
}

void INIT_INT0(void)
{
	EIMSK |= (1 << INT0);			// INT0 인터럽트 활성화
	EICRA |= (1 << ISC01);			// 하강 에지에서 인터럽트 발생
	sei();							// 전역적으로 인터럽트 허용
}

int main(void)
{
	// 포트 설정
	INIT_PORT();
	// 버튼 인터럽트 설정
	INIT_INT0();
	// UART 통신 설정
	UART0_init();

    /* Replace with your application code */
    while (1) 
    {
		// C#에서 데이터가 왔을경우
		if (_protocol)
		{
			if (_queue[1] == 0x54)
				_state = 1;
			else if (_queue[1] == 0x46)
				_state = 0;

			_protocol = 0;
		}

		// 버튼이 눌렀을때 LED 켜기 (풀업저항이기 때문에 LOW가 왔을때 처리)
		// if ((PIND & 0x01) >> 0 == 0){
		// 인터럽트로 처리
		if (_state == 1){
			PORTA = 0x01;
			UART0_KW_protocol("T");
		}else{
			PORTA = 0x00;
			UART0_KW_protocol("F");
		}

		_delay_ms(100);
    }

	return 0;
}

