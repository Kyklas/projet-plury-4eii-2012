/**
 * \file IO.c
 * \brief Entrées Sorties
 * \author Xavier & Romain
 * \version 0.1
 * \date 28 mars 2012
 */

#include "IO.h"

void IO_Init()
{
    TRISABITS.TRISA0 = 1; // PGEC
    TRISABITS.TRISA1 = 1; // PGED
//  TRISABITS.TRISA2 = 0; // OscO
//  TRISABITS.TRISA3 = 1; // OscI
    TRISABITS.TRISA4 = 0; // Mode 2
    // Mclr & Vcap : Réglage hardware


    TRISBBITS.TRISB0 = 0; // Tx
    TRISBBITS.TRISB1 = 1; // Rx
    TRISBBITS.TRISB2 = 1; // Button

    TRISBBITS.TRISB4 = 0; // MODE 1

    TRISBBITS.TRISB7 = 0; // PWM
    TRISBBITS.TRISB8 = 0; // SCL
    TRISBBITS.TRISB9 = 1; // SDA
    TRISBBITS.TRISB12 = 1; // Pot1/D
    TRISBBITS.TRISB13 = 1; // Pot2/C
    TRISBBITS.TRISB14 = 1; // Pot3/H2
    TRISBBITS.TRISB15 = 1; // Pot4/H1
}
