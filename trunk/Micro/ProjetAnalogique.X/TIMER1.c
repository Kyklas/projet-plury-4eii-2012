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
    T1CONbits.TCKPS=0b11; // prescaler par 8==> 2MHZ
    T1CONbits.TCS=0b0; // utilisation de l'horloge interne (fquartz+pll/2)  (16 MHz )
  

    PR1=20000; // pour une période de 1KHz
    //PR1=20000; // pour une période de 1Hz

    // réglage interruption pour générer evt pour adc ?
    IPC0bits.T1IP = 0x01; //Setup Timer1 interrupt for desired priority level
    // (This example assigns level 1 priority)
    IFS0bits.T1IF = 0; //Clear the Timer1 interrupt status flag
    IEC0bits.T1IE = 1; //Enable Timer1 interrupts
    // à priori, l'interruption est généré meme si pas utilisée, ça doit donc suffir pour faire l'evenement pour l'adc
    T1CONbits.TON=0b1; //timer1 lancé
}
