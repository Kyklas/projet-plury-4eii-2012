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
#include "UART.h"

void TIMER1_Init ()
{
    T1CON=0x00;
    TMR1=0x00;          // reset du timer

    T1CONbits.TCS=0b0;      // utilisation de l'horloge interne (Fcy)  (16 MHz)
    T1CONbits.TCKPS=0b11;   // prescaler par 256 ==> Fcy/256 = 62,5 khz

    PR1=62;                 // pour une période de timer1 : 1ms
    //PR1=248;               // pour une période de timer1 : 4ms

    // réglage interruption pour générer l'événement pour ADC
    IPC0bits.T1IP = 2;   // Priorité de l'interruption
    IFS0bits.T1IF = 0;      // Clear Interrupt Flag
    IEC0bits.T1IE = 1;      // Autorisation de l'interruption Timer1
    T1CONbits.TON=0b1;      // Timer1 lancé
}


// Tension d'offset
#define DEF_VREF 1524
const short Vref = DEF_VREF;        // 1.77 * 4096.0 / 5.0;

inline void fonctionAnalog_T1Interrupt(void)
{
    short Mesure;
    unsigned short DutyCycle;
// ==========================================
// Conditionnement du signal
// ==========================================
    // Ajout de l'inverseur pour avance de phase
    short ADC;
    ADC  = ADC_Convert(POT1);
    Mesure = Vref - ADC;
    // Protection
    if (Mesure > 950 || Mesure < -700)
        goto protection;
    if (Mesure > 408)
        Mesure = 408;
    if (Mesure < -408)
        Mesure = -408; // limitation PWM à 80%

// ==========================================
// Pilotage de la PWM
// ==========================================
    if (Mesure < 0)
    {
        DutyCycle = - Mesure;
        MODE1 = 0;
        MODE2 = 1;
    }
    else
    {
        DutyCycle = Mesure;
        MODE1 = 1;
        MODE2 = 0;
    }
    PWM_SetDutyCycle(DutyCycle);
    return;

    protection :
    PWM_SetDutyCycle(0);
    return;
}


// Initialisation pour le premier calcule
float input[2] = {0};
float output[2] = {0};

inline void fonctionNumerique_T1Interrupt(void)
{
    short ADC, DutyCycle;
    ADC  = ADC_Convert(POT1);
    input[0] = (float)(Vref - ADC);
    output[0] = 8.272*input[0] - 7.917*input[1] + 0.2*output[1];
    output[0]*=4.5;

    // Veillessement des variables
    input[1] = input[0];
    output[1] = output[0];

    if (input[0] > 950 || input[0] < -700)
        goto protection;
    if (output[0] > 408)
        output[0] = 408;
    if (output[0] < -408)
        output[0] = -408;  //limitation a 80% de la PWM

// ==========================================
// Pilotage de la PWM
// ==========================================
    if (output[0] < 0)
    {
        DutyCycle = - output[0];
        MODE1 = 0;
        MODE2 = 1;
    }
    else
    {
        DutyCycle = output[0];
        MODE1 = 1;
        MODE2 = 0;
    }
    PWM_SetDutyCycle(DutyCycle);
    return;

    protection :
    PWM_SetDutyCycle(0);
    return;

}

void __attribute__((interrupt,no_auto_psv)) _T1Interrupt(void)
{
    if (ISNUMERIC)
    {
        fonctionNumerique_T1Interrupt();
    }
    else
    {
        fonctionAnalog_T1Interrupt();
    }

    IFS0bits.T1IF = 0; //Reset Timer1 interrupt flag and Return from ISR
}
