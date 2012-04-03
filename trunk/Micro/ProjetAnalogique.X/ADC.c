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
    AD1CON1bits.SSRC = 0b0111; // relancement auto
    //AD1CON1bits.SSRC = 0b0000;     // relancement manuel
    //AD1CON1bits.SSRC=0b0101;     // sélection de la séquence échantillonage/conversion : timer1 event
    AD1CON1bits.FORM = 0b00;       // sélection du format des résultats : décimal sans signe, justifié à droite
    AD1CON1bits.ASAM = 0b1;         // redémarrage auto de la conversion après la fin de la précédente
    AD1CON2bits.PVCFG = 0b00;      // sélection de la référence de tension : AVDD ==> 5v
    AD1CON2bits.SMPI = 0b00000;    // à revoir sélection de la fréquence des interruptions : interruption à la fin de chaque conversion
    AD1CON3bits.SAMC = 0b11111;
    AD1CON3bits.ADCS = 0b00111111; // sélection de la fréquence de conversion : TCY=TAD
    AD1CON3bits.ADRC = 0b0;        // sélection de la séquence échantillonage/conversion : horloge système
    AD1CHSbits.CH0NB=0b0; // voie négative, osef
    
    //AD1CON1bits.SAMP = 1; // lancement de la conversion

    ADC1BUF0=0;
    ADC1BUF1=0;
    ADC1BUF2=0;
    ADC1BUF3=0;
    ADC1BUF4=0;
    ADC1BUF5=0;
    ADC1BUF6=0;
    ADC1BUF7=0;
    ADC1BUF8=0;
    ADC1BUF9=0;
    ADC1BUF10=0;
    ADC1BUF11=0;
    ADC1BUF12=0;
    ADC1BUF13=0;
    ADC1BUF14=0;
    ADC1BUF15=0;
    ADC1BUF16=0;
    ADC1BUF17=0;

    AD1CON1 |= 0b10000000000;
    AD1CON1bits.ADON=0b1; // convertisseur lancé


}

unsigned int ADC_Convert(int voie)
{
    unsigned int result;
    //AD1CHSbits.CH0SB=voie; // multiplieur d'entrée : AVD ???
   // AD1CON1bits.SAMP=0; // lancement de la conversion
    while(!AD1CON1bits.DONE);// attente de la fin de conversion
    AD1CON1bits.DONE=0; //raz du bit au cas ou ça ne serait pas fait automatiquement

    //AD1CON1bits.SAMP=1; // lancement de la conversion
    result=ADC1BUF0; // si on ne laisse qu'une conversion se passer entre chaque vérification, pas besoin d'aller plus loin que le buffer0
    return(result);
}

