/**
 * \file PWM.h
 * \brief Gestion des OCs
 * \author Xavier & Romain
 * \version 0.1
 * \date 28 mars 2012
 */

#ifndef _PWM_H_
#define _PWM_H_

#include <p24FV32KA301.h>

/**
 * \fn void PWM_Init ()
 * \brief Initialisation du PWM
 */
void PWM_Init ();

/**
 * \fn void PWM_Init ()
 * \brief Initialisation du PWM
 *
 * \param DutyCycle Valeur du rapport cyclique
 */
void PWM_SetDutyCycle(char DutyCycle);

#endif
