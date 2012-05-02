/**
 * \file ADC.c
 * \brief ADC
 * \author Xavier & Romain
 * \version 0.1
 * \date 29 mars 2012
 */

#include "ADC.h"

/**
 * \fn void ADC_Init ()
 * \brief Initialisation du module ADC
 */
void ADC_Init()
{
    // configuration du sens des e/s faites dans io_init
    AD1CON1bits.SSRC = 0b0111;      // passage d'échantillonage à conversion sur
                                    // évènement du timer 1
    AD1CON1bits.FORM = 0b00;        // sélection du format des résultats :
                                    // décimal sans signe, justifié à droite
    AD1CON1bits.ASAM = 0b1;         // redémarrage auto de l'échantillonage
                                    // après la fin de la conversion précédente
    AD1CON2bits.PVCFG = 0b00;       // sélection de la référence de tension
                                    // AVDD ==> 5v
    AD1CON2bits.SMPI = 0b00000;     // interruption non utilisée
    AD1CON3bits.ADCS = 0b00111111;  // fréquence de l'horloge de conversion
                                    // : 64TCY=TAD=32µs
    AD1CON3bits.SAMC = 0b11111;     // période d'échantillonnage : 31TAD :992µs
    AD1CON3bits.ADRC = 0b0;         // sélection de la séquence échantillonage-
                                    // conversion : horloge système
    AD1CHSbits.CH0NB=0b0;           // voie B, non utilisée
    AD1CON1bits.ADON=0b1;           // convertisseur lancé
    AD1CON1 |= 0b10000000000;       // maintain to '1'
}

unsigned short ADC_Convert(int voie)
{
    AD1CHSbits.CH0SA=voie;          // multiplieur d'entrée : VDD (5v)
    while(!AD1CON1bits.DONE);       // attente de la fin de conversion
    AD1CON1bits.DONE=0;             // RAZ du flag
    return(ADC1BUF0);
}

