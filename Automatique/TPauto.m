clc;close all;clear all;

% Mod�lisation analogique
%*************************

Constantes

% Equation �lectrique


Telec=L/R;
Num_elec=1/R;
Den_elec=[Telec,1];
disp('Equation Electrique');
Sys_elec=tf(Num_elec,Den_elec)

% Equation m�canique

Tmeca=sqrt(m/kx);
Num_meca=-ki/kx;
Den_meca=[-Tmeca^2 0 1];
disp('Equation M�canique');
Sys_meca=tf(Num_meca,Den_meca)

% Ajout d'un correcteur Avance de Phase

Tav = 1.2*Tmeca;

Cor_av=tf([Tav 1],[0.1*Tav 1])

% Syst�me
disp('Equation du Syst�me (Elec + Meca + Hall)');
Sys = Sys_elec * Sys_meca*Kc_Hall

nichols(Sys);
hold on;


disp('Equation du Syst�me Corrig�');
Sys_Corr = Sys*Cor_av 

nichols(Sys_Corr);
ngrid;
hold off;
title('Diagrammes de Black Syst�me et Syst�me Corrig�');
%axis([-360,0,-100,10]);  


%rltool(Sys);

figure;
rlocusplot(Sys);
axis([-400,100,-200,200]);
title('Syst�me Seul');

%rltool(Sys_Corr);

figure;
rlocusplot(Sys_Corr);
axis([-400,100,-200,200]);
title('Syst�me Corrig�');

return

% Version Num�rique
Felec = 1/(2*pi*Telec);
Te = 1/(Felec*24);

Sys_Hd = C2d(Sys_elec * Sys_meca*Kc_Hall,Te,'ZOH');

Sys_Hc = C2d(Cor_av,Te,'Tustin');

rltool(40*Sys_Hc * Sys_Hd);



