/**
 * \file ADC.h
 * \brief module numérique analogique
 * \author Xavier & Romain
 * \version 0.1
 * \date 29 mars 2012
 */

#ifndef _ADC_H_
#define _ADC_H_

#include <p24FV32KA301.h>

// définition des constantes de voies pour ADC_convert
#define POT1 0b1100
#define POT2 0b1011
#define POT3 0b1010
#define POT4 0b1001

/**
 * \fn void ADC_Init ()
 * \brief Initialisation du module ADC
 */
void ADC_Init ();

/**
 * \fn void ADC_Convert ()
 * \brief Lancement d'une conversion sur une voie
 * \parami[in] voie sur laquelle convertir
 * \return le résultat de la conversion
 *  */
unsigned int ADC_Convert(int voie);

#endif

