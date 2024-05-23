

Efter man har dokumenteret kildekoden med xml, kan man i en termial af rod projektet køre følgende kommando:   

 billed 1.

Denne kommando kører en fil ved navn config_file der er blevet oprettet i roden af vores projekt. Her er en uddybende forklaring af hvad de 3 forkelige filer gør: 

PROJECT_NAME = "PaymentService3": Dette sætter navnet på dit projekt til "PaymentService3". Når Doxygen genererer dokumentationen, bruger den dette navn som overskrift for din dokumentation side og som en del af stien til outputfilerne.
INPUT = C:/Users/frede/source/repos/PaymentService3/PaymentService3/Controllers:
Dette angiver stien til kildefilerne, som Doxygen skal analysere for at generere dokumentationen. I dette tilfælde er stien angivet som en absolut sti til mappen "Controllers" i dit projekt. Doxygen vil analysere alle kildefiler i denne mappe og dens undermapper for at generere dokumentation.
OUTPUT_DIRECTORY = docs: Dette angiver stien til mappen, hvor den genererede dokumentation skal gemmes. I dette tilfælde er mappenavnet angivet som "docs", hvilket betyder, at den genererede dokumentation vil blive gemt i en mappe kaldet "docs" i samme mappe som Doxyfile (konfigurationsfilen).

Så den samlede betydning af denne kode er, at den konfigurerer Doxygen til at generere dokumentation for projektet "PaymentService3" ved at analysere kildefilerne i "Controllers" -mappen og gemme den genererede dokumentation i en mappe kaldet "docs".

billed 2.

Herefter kan man gå til docs mappen og åbne index.html filen der vil indeholde en detaljeret beskrivelse af koden i Controllers mappen, der er beskrevet med xml kommentar. 
