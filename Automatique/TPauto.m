clc;close all;clear all;

% Modèlisation analogique
%*************************

Constantes

% Equation électrique


Telec=L/R;
Num_elec=1/R;
Den_elec=[Telec,1];
Sys_elec=tf(Num_elec,Den_elec)

% Equation mécanique

m=0.1414; %Kg
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

Sys_Glo = Sys_elec * Sys_meca*Kc_Hall
nichols(Sys_Glo);
hold on;
Sys_Glo = 40*Sys_elec * Sys_meca*Kc_Hall*Cor_av 
nichols(Sys_Glo);
ngrid;
hold off;
axis([-360,0,-100,10]);   
%rltool(Sys_Glo);

%rltool(Sys_elec * Sys_meca*Kc_Hall);

stop

% Version Numérique
Felec = 1/(2*pi*Telec);
Te = 1/(Felec*24);

Sys_Hd = C2d(Sys_elec * Sys_meca*Kc_Hall,Te,'ZOH');

Sys_Hc = C2d(Cor_av,Te,'Tustin');

rltool(40*Sys_Hc * Sys_Hd);



