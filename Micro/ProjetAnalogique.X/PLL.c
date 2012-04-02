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
void PLL_Init()
{
    CLKDIV = 0;
    CLKDIVbits.DOZEN = 0; // Ratio Select bits : 1:1 => 32Mhz
    while (!OSCCONbits.LOCK);
}
