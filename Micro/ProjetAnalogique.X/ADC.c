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
    AD1CON2bits.PVCFG=0b00; // s�lection de la r�f�rence de tension : AVDD ???
    AD1CON3bits.ADCS=0b00000000; // s�lection de la fr�quence de conversion : TCY=TAD
    AD1CON1bits.SSRC=0b0000; // relancement manuel
    //AD1CON1bits.SSRC=0b0101; // s�lection de la s�quence �chantillonage/conversion : timer1 event
    AD1CON3bits.ADRC=0b0; // s�lection de la s�quence �chantillonage/conversion : horloge syst�me
    AD1CON1bits.FORM=0b00;// s�lection du format des r�sultats : d�cimal sans signe, justifi� � droite
    AD1CON2bits.SMPI=0b00000; // s�lection de la fr�quence des interruptions : interruption � la fin de chaque conversion

    AD1CON1bits.ASAM=0b1; // red�marrage auto de la conversion apr�s la fin de la pr�c�dente

    AD1CON1bits.ADON=0b1; // convertisseur lanc�
}

unsigned int ADC_Convert(int voie)
{
    unsigned int result;
    AD1CHSbits.CH0NB=voie; // s�lection de la voie � convertir (faudra faire des #define)
    AD1CHSbits.CH0SB=0b11101; // multiplieur d'entr�e : AVD ???

    AD1CON1bits.ADON=0b1;//module ADC lanc�
    
    AD1CON1bits.SAMP=0; // lancement de la conversion

    while(!AD1CON1bits.DONE) {}// attente de la fin de conversion
    result=ADC1BUF0; // si on ne laisse qu'une conversion se passer entre chaque v�rification, pas besoin d'aller plus loin que le buffer0
    return(result);
}

