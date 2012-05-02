/* 
 * File:   main.c
 * Author: Romain
 *
 * Created on 12 mars 2012, 17:52
 */

#include <stdio.h>
#include <stdlib.h>
#include <p24FV32KA301.h>
#include "IO.h"
#include "PLL.h"
#include "PWM.h"
#include "ADC.h"
#include "TIMER1.h"

#ifdef _ISR
    #undef _ISR
    #define _ISR __attribute__((interrupt, auto_psv))
#endif

#ifdef _ISRFAST
    #undef _ISRFAST
    #define _ISRFAST __attribute__((interrupt, shadow, auto_psv))
#endif

// Bits de configuration
_FBS(BWRP_OFF & BSS_OFF);
_FGS(GWRP_OFF & GSS0_OFF);
_FOSCSEL(FNOSC_PRIPLL & SOSCSRC_DIG & LPRCSEL_LP & IESO_OFF);
_FOSC(POSCMOD_HS & OSCIOFNC_OFF & POSCFREQ_HS & SOSCSEL_SOSCLP & FCKSM_CSDCMD);
_FWDT(FWDTEN_OFF);
_FPOR(BOREN_BOR3 & LVRCFG_OFF & PWRTEN_OFF & I2C1SEL_PRI & BORV_V30 & MCLRE_ON);
_FICD(ICS_PGx2); // DEBUG_ON

int main(void)
{
    // Initialisation des différents modules
    PLL_Init();
    IO_Init();
    PWM_Init();
    ADC_Init();
    TIMER1_Init();

    while(1);
    return (EXIT_SUCCESS);
}

