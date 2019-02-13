/*
 * 0130_csharp_HMI.c
 *
 * Created: 2019-02-13 오전 10:24:59
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

// 통신상태 확인 flag
volatile unsigned char _isCon = 0;
volatile unsigned char _conAlarm = 0;
volatile unsigned char _wait = 0;

ISR(INT0_vect)
{
	_state = (_state + 1) % 4;
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
	DDRA |= 0xFF;			// LED 포트 A의 모든핀을 출력으로 설정
	DDRC |= 0x02;			// LED 포트 C의 C1핀을 출력으로 설정

	DDRD &= ~0x01;			// 버튼 포트 D의 1개핀만 입력으로 설정
	PORTD |= 0x01;			// 버튼 포트 D의 PD0은 내부 풀업 저항을 사용하도록 설정
}

void INIT_INT0(void)
{
	EIMSK |= (1 << INT0);			// INT0 인터럽트 활성화
	EICRA |= (1 << ISC01);			// 하강 에지에서 인터럽트 발생
	sei();							// 전역적으로 인터럽트 허용
}

void ConAlarm(void)
{
	// 연결이 되지 있지 않으면 알람 램프를 끄고 이후 로직 실행하지 않음
	if (_isCon == 0)
	{
		PORTC = 0x00;
		return;
	}

	// 1초 간격으로 램프 점멸
	if (_conAlarm <= 10)
		PORTC = 0x02;
	else
		PORTC = 0x00;

	_conAlarm = (_conAlarm >= 20) ? 0 : _conAlarm + 1;
}

void ConCheck(void)
{
	// 연결 메세지가 안오고 3초가 지났을 경우, 연결 끊김으로 설정
	if (_wait > 30)
		_isCon = 0;

	_wait = (_wait >= 1000) ? 50 : _wait + 1;
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
		// PC와 연결이 되었을 경우, 시동 램프를 점멸
		ConAlarm();

		// C#에서 데이터가 왔을경우
		if (_protocol)
		{
			// 통신 연결 메세지를 받았을 경우 
			if (_queue[1] == 0x54)
				_isCon = 1;
			else if (_queue[1] == 0x46)		// 통신 중단 메세지를 받았을 경우
				_isCon = 0;
			else if (_queue[1] == 0x4E)		// 램프 변경 메세지를 받았을 경우
				_state = (_state + 1) % 4;
			else if (_queue[1] == 0x41)		// A 램프 변경 메세지를 받았을 경우
				_state = 1;
			else if (_queue[1] == 0x42)		// B 램프 변경 메세지를 받았을 경우
				_state = 2;
			else if (_queue[1] == 0x43)		// C 램프 변경 메세지를 받았을 경우
				_state = 3;

			_protocol = 0;
			_wait = 0;
		}

		// 버튼이 눌렀을때 LED 켜기 (풀업저항이기 때문에 LOW가 왔을때 처리)
		// if ((PIND & 0x01) >> 0 == 0){
		// 인터럽트로 처리
		if (_state == 0){
			PORTA = 0x00;
			UART0_KW_protocol("0");
		}else if (_state == 1){
			PORTA = 0x01;
			UART0_KW_protocol("1");
		}else if (_state == 2){
			PORTA = 0x08;
			UART0_KW_protocol("2");
		}else if (_state == 3){
			PORTA = 0x40;
			UART0_KW_protocol("3");
		}

		//연결설정 체크
		ConCheck();
		_delay_ms(100);
    }

	return 0;
}

