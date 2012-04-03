/**
 * \file TIMER1.h
 * \brief module timer
 * \author Xavier & Romain
 * \version 0.1
 * \date 1 avril 2012
 */

#ifndef _TIMER1_H_
#define _TIMER1_H_

#include <p24FV32KA301.h>

/**
 * \fn void TIMER1_Init ()
 * \brief Initialisation du module Timer1
 */
void TIMER1_Init ();

void Timer1_Interrupt(void);

#endif
