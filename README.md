# Administrace zakázek
## Semestrální projekt do ITU
### zimní nemestr 2021
### Autoři
* David Mihola - xmihol00@fit.stud.vutbr.cz
* Marek Fiala - xfiala60@stud.fit.vutbr.cz
* Vítek Hnatovskyj - xhnato00@stud.fit.vutbr.cz

## Softwarové požadavky
1. .NET 5 SDK a .NET 5 Runtime, dostupné z https://dotnet.microsoft.com/download/dotnet/5.0,
2. SQL server, stačí verze Express, dostupné z https://www.microsoft.com/en-us/sql-server/sql-server-downloads.

## Návod pro lokální spuštění.
### Windows
1. Rozbalit zazipovaný archiv,
2. do programu Visual Studio 2019 nainstalovat vývojové balíky *.NET desktop development* a *APS.NET and web development*,
3. otevřít *Knihovna.sln* v programu Visual Studio 2019,
4. obnovit knihovny na straně klienta kliknutím pravým tlačítkem na soubor *Knihovna.WEB/libman.json* a vybrání možnosti *Restore Client-Side Libraries*  (Tento soubor obsahuje výčet použitých klientských knihoven.),
5. spustit ladění. (databáze by se měla vytvořit automaticky a automaticky by se pomocí ORM mělo vytvořit i její schéma a nahrát seed data. V případě, že se tak nestane, pokračujte bodem 3 a 4 v návodu pro Linux.)

### Linux
1. Rozbalit zazipovaný archiv,
2. otevřít adresář ve Visual Studio Code,
3. vytvořit prázdnou databázi,
4. nahradit hodnotu *"DB"* v *appsettings.json* za např. `Server=127.0.0.1;uid=uzivatel;Password=silne_heslo;Database=Knihovna;`,
5. obnovit knihovny na straně klienta dle návodu od Microsoft, dostupné z https://docs.microsoft.com/cs-cz/aspnet/core/client-side/libman/libman-cli?view=aspnetcore-6.0,
6. spustit ladění, konfigurace databáze opět proběhne pomocí ORM.

## Uživatelské účty
| Uživatelské jméno   |      Heslo      |
|:-------------------:|:---------------:|
| su                  | test            |
| admin               | admin           |
| u1                  | test            |
| u2                  | test            |
| u3                  | test            |
| u4                  | test            |
| u5                  | test            |
| u6                  | test            |
| u7                  | test            |
| u8                  | test            |
| u9                  | test            |
| u10                 | test            |

## Testování
Aplikace byla vyvíjena a testována na aktuálních verzích prohlížečů *Mozila Firefox*, *Opera* a *Google Chrome*.
