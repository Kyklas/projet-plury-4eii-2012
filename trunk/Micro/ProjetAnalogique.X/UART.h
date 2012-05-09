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
 * \fn void UART_Send_char (char byte)
 * \brief Envoi un caract�re
 * 
 * \param byte Caract�re � envoyer
 */
void UART_Send_char (char byte);

/**
 * \fn void UART_Send_string (char * string)
 * \brief Envoi une chaine de caract�res
 *
 * \param string Chaine de caract�re � envoyer
 */
void UART_Send_string (char * string);

void fonction_U2RXInterrupt(void);

#endif
