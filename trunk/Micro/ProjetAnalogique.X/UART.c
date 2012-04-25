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
void UART_Init(int Baudrate)
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
    U2MODEbits.PDSEL = 0b00; // 8 bits, no parity
    U2MODEbits.STSEL = 0b0; // 1 stop bit
    U2STA = 0;

    U2BRG=((16000000/Baudrate)/16) - 1;   //Set Baudrate

    IPC7bits.U2TXIP2 = 1;   //Set Uart TX Interrupt Priority
    IPC7bits.U2TXIP1 = 0;
    IPC7bits.U2TXIP0 = 0;
    IPC7bits.U2RXIP2 = 1;   //Set Uart RX Interrupt Priority
    IPC7bits.U2RXIP1 = 0;
    IPC7bits.U2RXIP0 = 0;

    U2STAbits.UTXEN = 1;    //Enable Transmit
    IEC1bits.U2TXIE = 1;    //Enable Transmit Interrupt
    IEC1bits.U2RXIE = 1;    //Enable Receive Interrupt

    U2MODEbits.UARTEN = 1;
}

void UART_Send (char byte)
{
    while(U2STAbits.UTXBF);		//Attente place libre sur Buffer
    U2TXREG=byte;                   //Place l'octet et commence transmission
    while(!U2STAbits.TRMT);		//Attente fin de transmission
}

void fonction_U2RXInterrupt(void)
{

}


void __attribute__((interrupt,no_auto_psv)) _U2RXInterrupt(void)
{
    fonction_U2RXInterrupt();
    _U2RXIF=0;
}

