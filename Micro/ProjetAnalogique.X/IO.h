/**
 * \file IO.h
 * \brief Entrées Sorties
 * \author Xavier & Romain
 * \version 0.1
 * \date 28 mars 2012
 */

#ifndef _PORTIO_H_
#define _PORTIO_H_

#include <p24FV32KA301.h>

#define MODE1 LATBbits.LATB4 //RB4
#define MODE2 LATAbits.LATA4 //RA4

/**
 * \fn void IO_Init ()
 * \brief Initialisation du E/S
 */
void IO_Init ();


#endif
