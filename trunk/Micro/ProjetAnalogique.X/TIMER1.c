/**
 * \file TIMER1.c
 * \brief TIMER
 * \author Xavier & Romain
 * \version 0.1
 * \date 1 avril 2012
 */

#include "TIMER.h"
#include "ADC.h"
#include "PWM.h"
#include "IO.h"

unsigned int resultat=0;

void TIMER1_Init ()
{
    T1CON=0x00;
    TMR1=0x00; // reset du timer

    T1CONbits.TCS=0b0; // utilisation de l'horloge interne (Fcy)  (16 MHz)
    T1CONbits.TCKPS=0b11; // prescaler par 256 ==> Fcy/256 = 62,5 khz

    PR1=62; // pour une période de timer1 : 1ms
    //PR1=20; // pour une période de timer1 : 0.3ms

    // réglage interruption pour générer evt pour adc
    IPC0bits.T1IP = 0x01;       //Setup Timer1 interrupt for desired priority level
    // (This example assigns level 1 priority)
    IFS0bits.T1IF = 0;          //Clear the Timer1 interrupt status flag
    IEC0bits.T1IE = 1;          //Enable Timer1 interrupts
    // à priori, l'interruption est généré meme si pas utilisée, ça doit donc suffir pour faire l'evenement pour l'adc
    T1CONbits.TON=0b1;      //timer1 lancé
}

short const Vref = 1450; //1.77 * 4096.0 / 5.0;
void fonction_T1Interrupt(void)
{
    short Mesure;
    unsigned char DutyCycle;
// Conditionnement du signal
    Mesure = Vref - (0xFFF - ADC_Convert(POT1)); // Ajout de l'inverseur pour avance de phase
    if (Mesure > 2047) Mesure = 2047;
// Pilotage de la PWM
    if (Mesure < 0)
    {
        DutyCycle = (unsigned char) ((- Mesure) >> 3);
        MODE1 = 0;
        MODE2 = 1;
    }
    else
    {
        DutyCycle = (unsigned char) (Mesure >> 3);
        MODE1 = 1;
        MODE2 = 0;
    }
    PWM_SetDutyCycle(DutyCycle);
}

void __attribute__((interrupt,no_auto_psv)) _T1Interrupt(void)
//void _ISRFAST _T1Interrupt(void)
{
    fonction_T1Interrupt();
    IFS0bits.T1IF = 0; //Reset Timer1 interrupt flag and Return from ISR
}
