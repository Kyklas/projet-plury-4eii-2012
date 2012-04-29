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
    // Clear Initial
    OC1CON1 = 0; 
    OC1CON2 = 0;
    
    OC1CON1bits.OCTSEL = 0b111; // Fcy Clock
    OC1R = 0x007F; // Duty Cycle : 0.5
    OC1RS = 0x00FF; // Periode 62kHz
    OC1CON2bits.SYNCSEL = 0b11111;
    OC1CON1bits.OCM = 0b110; // Mode Edge Align
}

/**
 * \fn void PWM_Init ()
 * \brief Initialisation du PWM
 *
 * \param DutyCycle Valeur du rapport cyclique
 */
void PWM_SetDutyCycle(unsigned char DutyCycle) 
{
    OC1R = DutyCycle;
}
