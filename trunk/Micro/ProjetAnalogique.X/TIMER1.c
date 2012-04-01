/**
 * \file TIMER1.c
 * \brief TIMER
 * \author Xavier & Romain
 * \version 0.1
 * \date 1 avril 2012
 */

#include <TIMER.h>

void TIMER1_Init ()
{
    T1CON=0x00;
    TMR1=0x00; // reset du timer
    T1CONbits.TCS=0b0; // utilisation de l'horloge interne (fquartz+pll/2)  (16 MHz )
    T1CONbits.TCKPS=0b01; // prescaler par 8==> 2MHZ

    PR1=2000; // pour une période de 1KHz

    // réglage interruption pour générer evt pour adc ?
    // à priori, l'interruption est généré meme si pas utilisée, ça doit donc suffir pour faire l'evenement pour l'adc
    T1CONbits.TON=0b1; //timer1 lancé
}
