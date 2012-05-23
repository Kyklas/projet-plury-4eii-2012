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

/**
 * \brief Variables de communication
 */
extern short Tags[32];
extern float FeedBacks[5];
#define ISNUMERIC Tags[0]
#define ISOFF Tags[6]
#define MESURE Tags[7]

#define Xk   FeedBacks[0]
#define Xk1  FeedBacks[1]
#define Yk1  FeedBacks[2]
#define GAININ FeedBacks[3]
#define GAINOUT FeedBacks[4]

#endif
