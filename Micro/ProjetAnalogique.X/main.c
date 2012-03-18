/* 
 * File:   main.c
 * Author: Romain
 *
 * Created on 12 mars 2012, 17:52
 */

#include <stdio.h>
#include <stdlib.h>
#include <p24FV32KA301.h>

// Bits de configuration
_FBS(BWRP_OFF & BSS_OFF);
_FGS(GWRP_OFF & GSS0_OFF);
_FOSCSEL(FNOSC_PRI & SOSCSRC_ANA & LPRCSEL_LP & IESO_OFF);
_FOSC(POSCMOD_HS & OSCIOFNC_OFF & POSCFREQ_HS & SOSCSEL_SOSCLP & FCKSM_CSDCMD);
_FWDT(FWDTEN_OFF);
_FPOR(BOREN_BOR3 & LVRCFG_OFF & PWRTEN_OFF & I2C1SEL_PRI & BORV_V30 & MCLRE_ON);
_FICD(ICS_PGx2); // DEBUG_ON


/*
 * main
 */
int main(void)
{
    int i,j,k;
    TRISBbits.TRISB7 = 0;
    LATBbits.LATB7 = 1;
    while(1)
    {
       for(i=0;i<32000;i++)
       {
       }
       LATBbits.LATB7=!LATBbits.LATB7;

    }
    return (EXIT_SUCCESS);
}

