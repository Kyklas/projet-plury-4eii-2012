clc;close all;clear all;

% Modèlisation analogique
%*************************

% Equation électrique

R=2.4; %Ohm
L=11.5e-3; %H
Telec=L/R;
Num_elec=1/R;
Den_elec=[Telec,1];
Sys_elec=tf(Num_elec,Den_elec)

% Equation mécanique

m=0.160; %Kg
ki=0.3; %N.A-1
kx=334; %N.m-1
Tmeca=sqrt(m/kx);
Num_meca=-ki/kx;
%Num_meca=-3.7e-3;
Den_meca=[-Tmeca^2 0 1];
%Den_meca=[-(27e-3^2) 0 1];
Sys_meca=tf(Num_meca,Den_meca)

% Modèle capteur effet Hall

Kc_Hall=92; 

% Ajout d'un correcteur Avance de Phase

Cor_av=tf([1.2*Tmeca 1],[1.2*0.1*Tmeca 1])



Sys_Glo = 40*Sys_elec * Sys_meca*Kc_Hall*Cor_av 
nichols(Sys_Glo);
ngrid;

%rltool(Sys_Glo);

%rltool(Sys_elec * Sys_meca*Kc_Hall);


% Version Numérique
Felec = 1/(2*pi*Telec);
Te = 1/(Felec*24);

Sys_Hd = C2d(Sys_elec * Sys_meca*Kc_Hall,Te,'ZOH');

Sys_Hc = C2d(Cor_av,Te,'Tustin');

rltool(40*Sys_Hc * Sys_Hd);



