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
    TMR1=0x00;          // reset du timer

    T1CONbits.TCS=0b0;      // utilisation de l'horloge interne (Fcy)  (16 MHz)
    T1CONbits.TCKPS=0b11;   // prescaler par 256 ==> Fcy/256 = 62,5 khz

    PR1=62;                 // pour une période de timer1 : 1ms
    //PR1=20;               // pour une période de timer1 : 0.3ms

    // réglage interruption pour générer l'événement pour ADC
    IPC0bits.T1IP = 0x01;   // Priorité de l'interruption
    IFS0bits.T1IF = 0;      // Clear Interrupt Flag
    IEC0bits.T1IE = 1;      // Autorisation de l'interruption Timer1
    T1CONbits.TON=0b1;      // Timer1 lancé
}


// Tension d'offset
#define DEF_VREF 1524
const short Vref = DEF_VREF;        // 1.77 * 4096.0 / 5.0;

void fonction_T1Interrupt(void)
{
    short Mesure;
    unsigned char DutyCycle;
// ==========================================
// Conditionnement du signal
// ==========================================
    // Ajout de l'inverseur pour avance de phase
    short ADC;
    ADC  = ADC_Convert(POT1);
    Mesure = Vref - ADC;
    if (Mesure > 511)
        Mesure = 511;
    if (Mesure < -1023)
        Mesure = -1023;

// ==========================================
// Pilotage de la PWM
// ==========================================
    if (Mesure < 0)
    {
        DutyCycle = (unsigned char) ((- Mesure) >> 2);
        MODE1 = 1;
        MODE2 = 0;
    }
    else
    {
        DutyCycle = (unsigned char) (Mesure >> 1);
        MODE1 = 0;
        MODE2 = 1;
    }
    PWM_SetDutyCycle(DutyCycle);
}


// Initialisation pour le premier calcule
long input0;
        long input1;
long output0;
        long output1;

void fonction_T1Interrupt_num(void)
{
    unsigned char DutyCycle;
// ==========================================
// Conditionnement du signal
// ==========================================
    // Ajout de l'inverseur pour avance de phase
    short ADC;
	
	// Acquisition
    ADC  = ADC_Convert(POT2);
	// recalage par rapport à la l'offset.
	// recalage inverse par rapport à l'analogique car l'entré est inversé.
    input0 = (long)(ADC-Vref);
	// calcule du correcteur avec un gain de 8 avec 3 dans le différentiel gaintotal 24
	// Y(z)=0.279Y(z)z-1 + 6.083*X(z) - 5.362X(z)z-1    Correcteur avec Te = 0.004   <==========================/!\
	//	9/32    	195/32		172/32      Valeurs vérifier avec matlab
	
	// Pour augmenter le gain, réduire le décalage pour les calculs d'input, passé à 4 ou 3.
	// Cela est équivalant a doublé l'éntré mais permet de garder la même précision.
	
	#define GAIN 0  // Normalement à 5 équivalant au correcteur normal, 4 : double l'éntrée, 3 : quadruple l'entrée
	//output0 = (9*output1)>>5+(195*input0-172*input1)>>GAIN;
        output0 = 
	// la sortie output bien que en long(32bits), peut être représenté en short(16bits), cela pour ne pas saturer les calculs
	// un décalage de 8 donne bien une représentation sur un char
	
	
	// Y(z)=0.7268Y(z)z-1 + 8.705*X(z) - 8.432X(z)z-1    Correcteur avec Te = 0.001   <==========================/!\
	//		47/64			279/32		270/32      Valeurs vérifier avec matlab
	// Il est possible que ce calcul dépasse la représentation short
	
	//#define GAIN 5  // Normalement à 5 équivalant au correcteur normal, 4 : double l'éntrée, 3 : quadruple l'entrée
	//output[0] = (47*output[1])>>6+(279*input[0]-270*input[1])>>GAIN;
	 
	/*
    if (output[0] > 511)
        output[0] = 511;
    if (output[0] < -1023)
        output[0] = -1023;
	*/
	
// ==========================================
// Pilotage de la PWM
// ==========================================
    if (output0 < 0)
    {
        DutyCycle = (unsigned char) ((- output0) >> 8);
        MODE1 = 1;
        MODE2 = 0;
    }
    else
    {
        DutyCycle = (unsigned char) (output0 >> 8);
        MODE1 = 0;
        MODE2 = 1;
    }
    PWM_SetDutyCycle(DutyCycle);

    	// veillissement des données
	input1 = input0 ;
	output1 = output0 ;
}

void __attribute__((interrupt,no_auto_psv)) _T1Interrupt(void)
{
    fonction_T1Interrupt_num();
    IFS0bits.T1IF = 0; //Reset Timer1 interrupt flag and Return from ISR
}
