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

    IPC7bits.U2RXIP = 1;   //Set Uart RX Interrupt Priority

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

void UART_Send_Tab (char * tab, int size)
{
    int i;
    for (i=0; i<size ; i++)
        UART_Send_char(tab[i]);
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
    static unsigned char RXbuffer[4];
    char TXbuffer[5];

    unsigned char rx = U2RXREG;
    if (rx & 0x80)      // Demande
    {
        if (rx & 0x40)  // Ecriture
        {
            TagAdr = rx & 0x1F;
            i = 0;
        }
        else            // Lecture
        {
            TagAdr = rx & 0x1F;
            TXbuffer[0] = 0x80 | TagAdr;
            TXbuffer[1] = (Tags[TagAdr] >> 12) & 0x0F;
            TXbuffer[2] = (Tags[TagAdr] >> 8) & 0x0F;
            TXbuffer[3] = (Tags[TagAdr] >> 4) & 0x0F;
            TXbuffer[4] = (Tags[TagAdr]) & 0x0F;
            UART_Send_Tab (TXbuffer, 5);
            UART_Send_Log("Read : finish");
        }
    }
    else    // Donnée
    {
        RXbuffer[i++] = rx;
        if (i == 4)
        {
            Tags[TagAdr] = 0;
            Tags[TagAdr] = (short)((short)(((RXbuffer[0] & 0x0F)<<12))|(short)(((RXbuffer[1] & 0x0F)<<8))|(short)(((RXbuffer[2] & 0x0F)<<4))|(short)(RXbuffer[3] & 0x0F));
            UART_Send_Log("Write : finish");
        }
    }
}

void __attribute__((interrupt,no_auto_psv)) _U2RXInterrupt(void)
{
    fonction_U2RXInterrupt();
    _U2RXIF=0;
}

