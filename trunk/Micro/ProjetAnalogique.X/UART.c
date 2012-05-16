/**
 * \file UART.c
 * \brief Universal Asynchronous Receiver Transmitter
 * \author Xavier & Romain
 * \version 0.1
 * \date 02 avril 2012
 */

#include "UART.h"

char Tags[32];

/**
 * \fn void UART_Init ()
 * \brief Initialisation de l'UART
 */
void UART_Init()
{
    U2BRG = 0;

    U2MODE = 0;
    U2MODEbits.USIDL = 0;       // Continue module operation in Idle mode
    U2MODEbits.IREN = 0;        // IrDA encoder and decoder are disabled
    U2MODEbits.RTSMD = 0;       // UxRTS pin is in Flow Control mode (??)
    U2MODEbits.UEN = 0b00;      // Disabled RTS & CTS
    U2MODEbits.WAKE = 0;        // No wake-up enabled
    U2MODEbits.LPBACK = 0;      // Loopback mode diseabled
    U2MODEbits.ABAUD = 1;       // Baud rate measurement is disabled or completed
    U2MODEbits.RXINV = 0;       // UxRX Idle state is 1
    U2MODEbits.BRGH = 0;        // Standard Speed Mode
    U2MODEbits.PDSEL = 0b00;    // 8 bits, no parity
    U2MODEbits.STSEL = 0b0;     // 1 stop bit
    U2STA = 0;
    U2STAbits.UTXINV = 0;       // Idle state is '1'

    U2MODEbits.UARTEN = 1;

    IPC7bits.U2TXIP = 7;   //Set Uart TX Interrupt Priority
    IPC7bits.U2RXIP = 6;   //Set Uart RX Interrupt Priority

    U2STAbits.UTXEN = 1;    //Enable Transmit
    IEC1bits.U2TXIE = 0;    //Enable Transmit Interrupt
    IEC1bits.U2RXIE = 1;    //Enable Receive Interrupt
}

void UART_Send_char (char byte)
{
    while(U2STAbits.UTXBF);		//Attente place libre sur Buffer
    U2TXREG=byte;                       //Place l'octet et commence transmission
    while(!U2STAbits.TRMT);		//Attente fin de transmission
}

void UART_Send_string (char * string)
{
    int i=0;
    while (string[i]!=0)
    {
        UART_Send_char(string[i]);
        i++;
    }
}

void UART_Send_Log (char * log)
{
    #define CMD 0xA0
    UART_Send_char(CMD);
    UART_Send_string(log);
    UART_Send_char(0x00);
}

inline void fonction_U2RXInterrupt(void)
{
    static int i = 0;
    static int TagAdr;
    unsigned char rx = U2RXREG;
    if (rx & 0x80)      // Demande
    {
        if (rx & 0x40)  // Ecriture
        {
            if (!i)
            {
                UART_Send_Log("CMD");
                TagAdr = rx & 0x1F;
                Tags[TagAdr] = 0;
                i++;
            }
            else
            {
                UART_Send_Log("DATA");
                Tags[TagAdr] |= (rx & 0x0F) << (4*(i-1));
                i++;
                i%=5;
            }
        }
    }
}

void __attribute__((interrupt,no_auto_psv)) _U2RXInterrupt(void)
{
    _U2RXIF=0;
    fonction_U2RXInterrupt();
}

