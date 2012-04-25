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
    AD1CON1bits.SSRC = 0b0111;      // relancement auto
    AD1CON1bits.FORM = 0b00;        // sélection du format des résultats : décimal sans signe, justifié à droite
    AD1CON1bits.ASAM = 0b1;         // redémarrage auto de la conversion après la fin de la précédente
    AD1CON2bits.PVCFG = 0b00;       // sélection de la référence de tension : AVDD ==> 5v
    AD1CON2bits.SMPI = 0b00000;     // à revoir sélection de la fréquence des interruptions : interruption à la fin de chaque conversion
    AD1CON3bits.SAMC = 0b11111;
    AD1CON3bits.ADCS = 0b00111111;  // sélection de la fréquence de conversion : TCY=TAD
    AD1CON3bits.ADRC = 0b0;         // sélection de la séquence échantillonage/conversion : horloge système
    AD1CHSbits.CH0NB=0b0;           // voie négative, osef

    AD1CON1bits.ADON=0b1;           // convertisseur lancé

    AD1CON1 |= 0b10000000000;       // maintain to '1'
}

unsigned short ADC_Convert(int voie)
{
    AD1CHSbits.CH0SA=voie;          // multiplieur d'entrée : AVD ???
    while(!AD1CON1bits.DONE);       // attente de la fin de conversion
    AD1CON1bits.DONE=0;             // raz du bit au cas ou ça ne serait pas fait automatiquement
    return(ADC1BUF0);
}

