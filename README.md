# Distribuirani sistem za akviziciju podataka za temperaturu i vlaznost vazduha

Aplikacija predstavlja uprosceni sistem za akviziciju podataka za temperaturu i vlaznost vazduha iz nekoliko meteoroloskih stanica.

Resenje se sastoji iz servera i dve klijentske aplikacije implementirane u WPF-u po ugledu na MVVM pattern.

Model podataka je uradjen u EntityFramework-u, i oslanja se na bazu koja sadrzi 3 tabele, tabelu RTU koja modeluje merni uredjaj. RTU poseduje svoj tip, tacnije podatak da li se radi o meracu temperature ili vlaznosti.
Tabelu lokacija koja predstavlja informaciju o geografskoj poziciji samog RTU-a. Tabelu Measurement koja predstavlja izmerenu vrednost u datom trenutku za konkretan RTU.

Klijentska aplikacija RTUManager sluzi za startovanje, odnosno stopiranje RTU-ova tj. prikupljanja merenja.

RTUViewer sluzi za prikaz podataka na koje se klijent subscribuje kao i prikaza generisanih reporta.
Reporti se generisu na serveru i salju klijentu, razlog za to jeste to sto server ima vecu moc i brze moze da izgenerise izvestaj od klijenta.

###Pokretanje

Resenje je uradjeno u okruzenju  Microsoft Visual Studio 2013. 
Pokrene se projekat RTUManager a zatim projekat RTUViewer.
