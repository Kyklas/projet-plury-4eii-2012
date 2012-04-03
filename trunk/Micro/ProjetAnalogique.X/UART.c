/**
 * \file UART.c
 * \brief Universal Asynchronous Receiver Transmitter
 * \author Xavier & Romain
 * \version 0.1
 * \date 02 avril 2012
 */

#include "UART.h"

/**
 * \fn void UART_Init ()
 * \brief Initialisation de l'UART
 */
void UART_Init()
{
    U2MODE = 0;
    U2MODEbits.USIDL = 0;   // Continue module operation in Idle mode
    U2MODEbits.IREN = 0;    // IrDA encoder and decoder are disabled
    U2MODEbits.RTSMD = 0;   // UxRTS pin is in Flow Control mode (??)
    U2MODEbits.UEN = 0b00;  // Disabled RTS & CTS
    U2MODEbits.WAKE = 0;    // No wake-up enabled
    U2MODEbits.LPBACK = 0;  // Loopback mode diseabled
    U2MODEbits.ABAUD = 0;   // Baud rate measurement is disabled or completed
    U2MODEbits.RXINV = 0;   // UxRX Idle state is ?1?
    U2MODEbits.BRGH = 0;    // Standard Speed Mode
    U2MODEbits.PDSEL = 

    U2MODEbits.UARTEN = 1;
}
