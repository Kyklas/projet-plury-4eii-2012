/**
 * \file IO.c
 * \brief Entrées Sorties
 * \author Xavier & Romain
 * \version 0.1
 * \date 28 mars 2012
 */

#include "IO.h"


void PORTIO_Init()
{
    TRISAbits.TRISA0 = 1; // PGEC
    TRISAbits.TRISA1 = 1; // PGED
//  TRISABITS.TRISA2 = 0; // OscO
//  TRISABITS.TRISA3 = 1; // OscI
    TRISAbits.TRISA4 = 0; // Mode 2
    // Mclr & Vcap : Réglage hardware


    TRISBbits.TRISB0 = 0; // Tx
    TRISBbits.TRISB1 = 1; // Rx
    TRISBbits.TRISB2 = 1; // Button

    TRISBbits.TRISB4 = 0; // MODE 1

    TRISBbits.TRISB7 = 0; // PWM
    TRISBbits.TRISB8 = 0; // SCL
    TRISBbits.TRISB9 = 1; // SDA
    TRISBbits.TRISB12 = 1; // Pot1/D
    TRISBbits.TRISB13 = 1; // Pot2/C
    TRISBbits.TRISB14 = 1; // Pot3/H2
    TRISBbits.TRISB15 = 1; // Pot4/H1
}
