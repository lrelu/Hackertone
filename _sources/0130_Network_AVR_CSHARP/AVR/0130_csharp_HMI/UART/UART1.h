﻿/*
 * UART1.h
 *
 * Created: 2019-01-30 오후 12:00:13
 *  Author: kccistc
 */ 


#ifndef UART1_H_
#define UART1_H_

void UART1_init(void);
void UART1_transmit(char data);
unsigned char UART1_receive(void);
void UART1_print_string(char *str);
void UART1_print_1_byte_number(uint8_t n);
void UART1_KW_protocol(char *str);

#endif /* UART1_H_ */