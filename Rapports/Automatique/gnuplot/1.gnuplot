set table "Automatique/gnuplot/1.table"; set format "%.5f"
set samples 100; set parametric; plot [t=-1:4] -180/3.1415957*atan(0.00662*10**t)-180, 20*log10(abs(0.44641/sqrt(1+(0.00662*10**t)**2)))+20*log10(abs(-0.00089/(-1-(0.02023**2)*10**t)))+20*log10(abs(92.0))
