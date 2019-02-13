/*
 * UART0.h
 *
 * Created: 2019-01-30 오후 12:58:50
 *  Author: kccistc
 */ 


#ifndef UART0_H_
#define UART0_H_

void UART0_init(void);
void UART0_transmit(char data);
unsigned char UART0_receive(void);
void UART0_print_string(char *str);
void UART0_print_1_byte_number(uint8_t n);
void UART0_KW_protocol(char *str);

#endif /* UART0_H_ */