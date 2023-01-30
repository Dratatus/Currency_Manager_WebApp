
# Currency Manager

Projekt strony internetowej z dostępem do walut pobieranych z API.
Użytkownik musi się zalogować/zarejestrować by móc korzystać ze strony.
Strona posiada stronę główną gdzie wyświetlane są dostępne waluty, profil użytkownika oraz konwerter walut gdzie można wybrać walutę sprzedawaną, kupowaną oraz ilość pieniędzy konwertowanych by sprawdzić kurs walut oraz ilość pieniędzy w kupionej walucie.


## Instalacja

- Wypakuj pliki projektu do wybranego katalogu.
- Otwórz terminal w katalogu CurrencyManager.WebApp.
- Zainstaluj narzędzie dotnet df za pomocą polecenia: 
``dotnet tool install --global dotnet-ef``
- Uruchom aplikację używając: ``dotnet run``

## Baza danych

Projekt został zaprojektowany tak by baza danych automatycznie utworzyła się w momencie uruchomienia projektu. W przypadku błędów związanych z utworzeniem bazy danych należy w  łańcuchu połączenia ustawić parametr ``Source`` na adres swojego lokalnego serwera. Łańcuch połącznia znajduje się w lokalizacji: ``Projekt_asp\CurrencyManager.Data\Configuration``  w pliku ``CurrencyManagerDbContext.cs``
## Perspektywa użytkownika

### Rejestracja

Dowolny użytkownik ma dostęp do strony ``https://localhost:7104/Login/Register`` na której w formularzu zostawia dane logowania: adres email i hasło. Użytkownik o haśle: ``1qazXSW@#premium`` będzie posiadał status ``Użytkownika Premium``.

![rejestracja](https://user-images.githubusercontent.com/92109490/215595928-751456fd-195f-4500-998d-3426229edfd9.png)

Po wysłaniu formularza w przypadku ustawienia poprawnych danych użytkownik jest przenoszony do strony głównej z wyświetlanymi dosępnymi walutami ``https://localhost:7104/Currency/Index``.


![homePage](https://user-images.githubusercontent.com/92109490/215595920-99003c67-3560-4861-a1c5-c3b3dd748ac1.png)


### Logowanie

Do strony z logowaniem: ``https://localhost:7104/login`` ma dostęp dowolny użytkownik. Należy podać adres email i hasło.

![Zrzut ekranu 2023-01-30 220631](https://user-images.githubusercontent.com/92109490/215595930-6ed66c2e-c069-430b-be2c-f2ae8b84bf03.png)

Po przesłaniu formularza w przypadku podania poprawnych danych logowania użytkownik jest przenoszony pod adres: ``https://localhost:7104/Currency/Index`` do strony głównej z wyświetlanymi dosępnymi walutami.


### Konwerter Walut

Po udanym logowaniu/rejestracji użytkownik posiada dostęp do zakładki ``Konwerter Walut`` po której kliknięciu zostaje przenoszony pod adres: ``https://localhost:7104/Converter/Converter``


![konwerter](https://user-images.githubusercontent.com/92109490/215595924-3bce8bf0-0dfa-4df7-8b29-cd52db235512.png)


W konwerterze należy wybrać walutę sprzedawaną, kupowaną oraz ilość wymienianych pieniędzy.
Po wybraniu opisanych opcji należy zatwierdzić wybór przyciskiem ``Konwertuj``, odczekać aż strona zwróći kurs, a następnie wyświetlić wynik konwersji walut za pomocą przycisku ``Wyświetl``



### Profil

Po udanym logowaniu/rejestracji użytkownik posiada dostęp do zakładki ``Profil`` po której kliknięciu zostaje przenoszony pod adres: ``https://localhost:7104/Profile/Profile``

![profile](https://user-images.githubusercontent.com/92109490/215595926-8a4a04bb-f0ce-469b-bfa8-45d2e435cc39.png)

Na stronie profilu użytkownik może zaktualizować/zmienić swoje dane personalne takie jak:
- Imię 
- Naziwsko
- Wiek
- Email
- Hasło
- Typ użytkownika

``Użytkownik premium`` oprócz możliwości zmian swoich danych personalnych, posiada również historię swojej ostanio dokonanej konwersji walut.
By zmienić Typ użytkownika ze standardowego na użytkownika premium należy zmienić hasło na: `1qazXSW@#premium`


![exchangeRateHistory](https://user-images.githubusercontent.com/92109490/215595932-db29798f-03a4-4492-ad13-79c6f20dd249.png)



## Testowi użytkownicy

Użytkownicy premium: 
- Email: premium@user.pl
- Hasło: 1qazXSW@#premium

Użytkownicy standardowi:
- Email: standard@user.pl
- Hasło: 1qazXSW@#
## Repozytoria

Projekt zawiera dwie implementacje Interfejsu ICurrencyProviderService dostarczającego waluty:

- ``ApiCurrencyProviderService`` - repozytorium produkcyjne - waluty pobierane z API
- ``HardcodedCurrencyProviderService`` - repozytorium testowe


oraz dwie implementacje Interfejsu IExchangeRateProviderService dostarczającego kursy wybranych walut: 

- ``ApiExchangeRatesProviderService`` - repozytorium produkcyjne - kursy pobierane z API
- ``HardcodedExchangeRatesProviderService`` - repozytorium testowe


Projekt domyślnie używa repozytoriów produkcyjnych. W przypadku błędów związanych z Api typu: ``Bad request`` należy zamknąć i ponownie uruchomić projekt. By zmienić repozytoria produkcyjne na repozytoria testowe należy w pliku Program.cs zmienić ``ApiCurrencyProviderService`` na ``HardcodedCurrencyProviderService`` oraz ``ApiExchangeRatesProviderService`` na ``HardcodedExchangeRatesProviderService`` 

![bindowanie](https://user-images.githubusercontent.com/92109490/215597318-8487a9bf-ab93-4213-a94a-d52bb9952d24.png)




## wymagania

- [ASP.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
- [SQL Server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads)
## Technologie

- C# 10.0
- NET.6.0
- Bootstrap 5.0
- MicrosoftEntityFrameworkCor.SqlServer 7.0.1
- RestSharp.Serializers.NewtonsoftJson 108.0.1
- Moq 4.18.4
- xunit 2.4.1
- xunit.runner.visualstudio 2.4.3
- Microsoft.VisualStudio.Web.CodeGeneration.Design
## Autor

- [@DanP412](https://github.com/DanP412)
