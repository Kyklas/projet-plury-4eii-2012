/**
 * \file PWM.c
 * \brief Gestion des OCs
 * \author Xavier & Romain
 * \version 0.1
 * \date 28 mars 2012
 */

#include "PWM.h"

/**
 * \fn void PWM_Init ()
 * \brief Initialisation du PWM
 */
void PWM_Init()
{
// Clear initial counters
    OC1CON1 = 0; 
    OC1CON2 = 0;
// Synchronize on Fcy Clock
    OC1CON1bits.OCTSEL = 0b111;
// Duty cycle of 50% period 31kHz
    OC1R = 0x00FF;
    OC1RS = 0x01FF;
// Synchronize on itself with Edge Align mode
    OC1CON2bits.SYNCSEL = 0b11111;
    OC1CON1bits.OCM = 0b110;
}

/**
 * \fn void PWM_SetDutyCycle(unsigned char DutyCycle)
 * \brief Modification du rapport cyclique
 *
 * \param DutyCycle Valeur du rapport cyclique
 */
void PWM_SetDutyCycle(unsigned short DutyCycle)
{
    OC1R = DutyCycle & 0x01FF;
}

/**
 * \fn void PWM_SetFreq(unsigned short Freq)
 * \brief Modification de la fr�quence
 *
 * \param Freq Fr�quence
 */
void PWM_SetFreq(unsigned short Freq)
{
    OC1R = Freq >> 1;
    OC1RS = Freq;
}