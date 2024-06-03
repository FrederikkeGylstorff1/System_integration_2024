Oprtelse af forbnidelse til mongodb:

For at du kan oprette forbindsle til de forskelige bruger skal du bruge mongodb’s komandoverktøj mongosh, derfor skal du først sørge for at mongodb shell er instaleret, dette kan man downloade fra ders offisiele hjemmeside. Du skal bare følge dette link: https://www.mongodb.com/try/download/shell
Her efter kan det være man manuelt skal tilføje stien til bin mappen i systemmiljøvariabler PATH. 
Her under ses de foeklige bruger der er oprettet i mongodb atlas.
Usernames og Passwords:
  - no_access_user / noaccesspassword
  - read_only_user / readonlypassword
  - read_write_user / readwritepassword
Her er en guide til hvordan man kan forbinde til mongodb database med de 3 forskelige bruger:

1.	Test af no_access_user
Forbind til MongoDB:
Åbn en terminal og kør følgende kommando:
Mongosh "mongodb+srv://no_access_user:noaccesspassword@cluster0.oy8yfgw.mongodb.net/your_database"
Forsøg at læse data:
Prøv at udføre en simpel læseforespørgsel:
-	Use userAdress
-	db.Adresses.find()
du skal forvente følgende resultat:
Brugeren no_access_user bør få adgangsfejl eller ingen data tilbage.

2.	Test af read_only_user
Forbind til MongoDB:
Åbn en terminal og kør følgende kommando:
Mongosh "mongodb+srv://read_only_user:readonlypassword@cluster0.oy8yfgw.mongodb.net/your_database"
Forsøg at læse data:
Prøv at udføre en simpel læseforespørgsel:
-	use userAdress
-	db. Adresses.find()
Forsøg at skrive data:
db. Adresses.insert({ name: "Test User", address: { street: "Test Street", city: "Test City", postalCode: "0000", country: "Denmark" } })
Forventet resultat:
Brugeren read_only_user bør kunne læse data men ikke skrive data. Skriveoperationen skal mislykkes med en adgangsfejl.

3.	Test af read_write_user
Mongosh ”mongodb+srv://read_write_user:readwritepassword@cluster0.oy8yfgw.mongodb.net/your_database”
Forsøg at læse data:
Prøv at udføre en simpel læseforespørgsel:
-	use userAdress
-	db. Adresses.find()
Forsøg at skrive data:
db.Adresses.insert({ name: "Test User", address: { street: "Test Street", city: "Test City", postalCode: "0000", country: "Denmark" } })
Prøv at opdatere et dokument:
db.Adresses.update({ name: "Test User" }, { $set: { address: { street: "Updated Street", city: "Updated City", postalCode: "1111", country: "Denmark" } } })
Forsøg at slette data:
Prøv at slette et dokument:
db.Adresses.remove({ name: "Test User" })
Forventet resultat:
Brugeren read_write_user bør kunne læse, indsætte, opdatere og slette data.