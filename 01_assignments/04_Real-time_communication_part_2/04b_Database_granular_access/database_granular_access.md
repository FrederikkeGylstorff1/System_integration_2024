Adgang til MongoDB Database via MongoDB Shell (Terminal Client)
Trin til adgang
Åbn din terminal (f.eks. PowerShell, Command Prompt eller Terminal på Mac/Linux).

Skriv følgende kommando, og tryk på Enter:

mongo --username cannotReadAgeUser --password --authenticationDatabase dbGranulærAdngang
Erstat cannotReadAgeUser med brugernavnet for den bruger, du ønsker at logge ind som.

Indtast din adgangskode, når du bliver bedt om det, og tryk på Enter.

Hvis adgangen er vellykket, vil du blive logget ind på MongoDB-databasen, og du kan begynde at interagere med den via MongoDB Shell.

Adgangsroller
cannotReadAgeUser: Denne bruger har ikke adgang til at læse "age"-feltet i dokumenterne i samlingen. Denne adgangsbruger har tildelt rollen "cannotReadAgeRole".

readOnlyUser: Denne bruger har kun læsetilladelse til dokumenterne i samlingen. Denne adgangsbruger har tildelt rollen "readOnlyRole".

readWriteUser: Denne bruger har både læse- og skrivetilladelse til dokumenterne i samlingen. Denne adgangsbruger har tildelt rollen "readWriteRole".

kode til alle brugere er: password 