/**
 * \file PLL.c
 * \brief Gestion de PLL
 * \author Xavier & Romain
 * \version 0.1
 * \date 28 mars 2012
 */

#include "PLL.h"

/**
 * \fn void PLL_Init ()
 * \brief Initialisation de la PLL
 */
void PLL_Init ()
{
    OSCCON = 0;
    OSCCONbits.COSC = 0b010; // Primary Oscillator XT
    OSCCONbits.NOSC = 0b010; // Primary Oscillator XT

    CLKDIV = 0;
    CLKDIVbits.DOZEN = 0; // Ratio Select bits : 1:1 => 32Mhz

    while (OSCCONbits.OSWEN);

}
