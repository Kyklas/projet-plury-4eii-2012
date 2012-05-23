clc;close all;clear all;

% Modèlisation analogique
%*************************

Constantes

% Equation électrique


Telec=L/R;
Num_elec=1/R;
Den_elec=[Telec,1];
disp('Equation Electrique');
Sys_elec=tf(Num_elec,Den_elec)

% Equation mécanique

Tmeca=sqrt(m/kx);
Num_meca=-ki/kx;
Den_meca=[-Tmeca^2 0 1];
disp('Equation Mécanique');
Sys_meca=tf(Num_meca,Den_meca)

% Ajout d'un correcteur Avance de Phase

Tav = 1.2*Tmeca;

Cor_av=tf([Tav 1],[0.1*Tav 1])

% Système

disp('Equation du Système (Elec + Meca + Hall)');
Sys = Sys_elec * Sys_meca*Kc_Hall

   nichols(Sys);
   hold on;
 
 disp('Equation du Système Corrigé');
 Sys_Corr = 33.6*Sys*Cor_av 
 
  nichols(Sys_Corr);
  ngrid;
  hold off;
% 
% title('Diagrammes de Black Système et Système Corrigé');
% axis([-360,0,-100,20]);  
% 
% 
% rltool(Sys);
% 
% figure;
% rlocusplot(Sys);
% axis([-400,100,-200,200]);
% title('Système Seul');
% 
% rltool(Sys_Corr);
% 
% figure;
% rlocusplot(Sys_Corr);
% axis([-400,100,-200,200]);
% title('Système Corrigé');
% 
%  return

% Version Numérique
Felec = 1/(2*pi*Telec);
Fav = 1/(2*pi*0.1*Tav);
Te = 1/(Felec*24);
Tavf = 1/(Fav*6);

Te = 1*10^-3;

 disp('Equation numérique du système');
Sys_d = C2d(Sys,Te,'ZOH')
 disp('Equation numérique du correcteur');
Correct_d = C2d(Cor_av,Te,'zoh')
rltool(Sys_d);
rltool(Sys_d * Correct_d);

bode(Cor_av)

%figure
%rlocusplot(24*Sys_d * Correct_d)
%figure
%rlocusplot(24 * Correct_d)

%%%%% Xavier Romain mercredi solex %%%%
gain = 1;
numz1=8.272;
numz0=-7.915;
denz1=1;
denz0=-0.9;
correcteur_micro = tf([numz1 numz0],[denz1 denz0],Te)
rltool(gain*Sys_d * correcteur_micro);

% gain mico 0.75

%%%% Test, correcteur numérique théorique, aprox arrière ( Zoh )

gain = 1;
numz1=10;
numz0=-9.776;
denz1=1;
denz0=-0.7756;
correcteur_micro = tf([numz1 numz0],[denz1 denz0],Te)
rltool(gain*Sys_d * correcteur_micro);

%%%% Test, déplacement du pole du correcteur, diminution du gain nécessaire

gain = 1;
numz1=10;
numz0=-9.776;
denz1=1;
denz0=-0.85;
correcteur_micro = tf([numz1 numz0],[denz1 denz0],Te)
rltool(gain*Sys_d * correcteur_micro);

%%%% Test, déplacement du pole du correcteur, gain equivalant au correcteur
%%%% mercredi du solex

gain = 1;
numz1=10;
numz0=-9.776;
denz1=1;
denz0=-0.93;
correcteur_micro = tf([numz1 numz0],[denz1 denz0],Te)
rltool(gain*Sys_d * correcteur_micro);

% gain 0.4

%%%%%%%%% Fin test numerique 1 %%%%%%%%%%


%%% Correcteur foh

gain = 1;
numz1=8.947;
numz0=-8.723;
denz1=1;
denz0=-0.7756;
correcteur_micro = tf([numz1 numz0],[denz1 denz0],Te);
rltool(gain*Sys_d * correcteur_micro);


%%% Correcteur foh,  déplacement du pole du correcteur

gain = 1;
numz1=8.947;
numz0=-8.723;
denz1=1;
denz0=-0.94;
correcteur_micro = tf([numz1 numz0],[denz1 denz0],Te);
rltool(gain*Sys_d * correcteur_micro);

