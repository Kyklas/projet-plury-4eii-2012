/**
 * \file UART.h
 * \brief Universal Asynchronous Receiver Transmitter
 * \author Xavier & Romain
 * \version 0.1
 * \date 02 avril 2012
 */

#ifndef _UART_H_
#define _UART_H_

#include <p24FV32KA301.h>

/**
 * \fn void UART_Init (int Baudrate)
 * \brief Initialisation de l'UART
 */
void UART_Init ();

/**
 * \fn void UART_Send_Log (char * log)
 * \brief Envoi un log
 * 
 * \param log log à envoyer
 */
void UART_Send_Log (char * log);

void fonction_U2RXInterrupt(void);

#endif
