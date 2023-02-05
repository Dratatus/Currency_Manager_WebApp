
# Currency Manager

A project of website with access to currencies retrieved from an API. Users must log in/register to use the website.
The website has a home page where available currencies are displayed. From the homepage, users can go to their profile page or the currency converter, where they can select the currency to sell/buy and the amount of money to exchange to check the currency rate and the amount of money in the purchased currency.


## installation

- Extract the project files into a chosen directory.
- Open the terminal in the CurrencyManager.WebApp directory.
- Install the dotnet ef tool using the command: 
``dotnet tool install --global dotnet-ef``
- Run the application using: ``dotnet run``

## Database

The project was designed so that the database would automatically be created when the project is started. In case of errors related to creating the database, the ``Source`` parameter must be set to the address of your local server in the connection string. The connection string is located at ``Projekt_asp\CurrencyManager.Data\Configuration`` in the file ``CurrencyManagerDbContext.cs``.

## User Perspective

### Register

Any user has access to the page ``https://localhost:7104/Login/Register`` where they can enter their registration details in a form, such as email address and a password. A user with the password ``1qazXSW@#premium`` will have the status of ``Premium User``.

![rejestracja](https://user-images.githubusercontent.com/92109490/215595928-751456fd-195f-4500-998d-3426229edfd9.png)

After submitting the form, if the data entered is correct, the user is redirected to the main page displaying available currencies at ``https://localhost:7104/Currency/Index``.


![homePage](https://user-images.githubusercontent.com/92109490/215595920-99003c67-3560-4861-a1c5-c3b3dd748ac1.png)


### Login

Access to the login page: ``https://localhost:7104/login`` is available to any user where they must enter their email address and password

![Zrzut ekranu 2023-01-30 220631](https://user-images.githubusercontent.com/92109490/215595930-6ed66c2e-c069-430b-be2c-f2ae8b84bf03.png)

After submitting the form with the correct login details, the user is redirected to the main page at ``https://localhost:7104/Currency/Index`` displaying the available currencies.


### Converter

After successful login / registration, the user has access to the ``Currency Converter`` tab, which, when clicked, is redirected to the address: ``https://localhost:7104/Converter/Converter``


![konwerter](https://user-images.githubusercontent.com/92109490/215595924-3bce8bf0-0dfa-4df7-8b29-cd52db235512.png)


In the converter, you must select the currency being sold, purchased, and the amount of money to be exchanged.
Once the options have been selected, confirm your selection with the "Convert" button, wait for the page to return the rate, and then display the result of the currency conversion with the "Display" button.



### Profile

After successful login / registration, the user has access to the tab "Profile" which, when clicked, will be redirected to the address: "https://localhost:7104/Profile/Profile"

![profile](https://user-images.githubusercontent.com/92109490/215595926-8a4a04bb-f0ce-469b-bfa8-45d2e435cc39.png)

On the profile page, the user can update/change their personal data such as:
- First Name
- Last Name
- Age
- Email
- Password
- User Type

``User premium`` in addition to the ability to change their personal data, also has a history of their last currency conversion.
To change the user type from standard to premium, change the password to: `1qazXSW@#premium`


![exchangeRateHistory](https://user-images.githubusercontent.com/92109490/215595932-db29798f-03a4-4492-ad13-79c6f20dd249.png)



## Test users

User premium: 
- Email: premium@user.pl
- Hasło: 1qazXSW@#premium

User standard:
- Email: standard@user.pl
- Hasło: 1qazXSW@#
## Repositories

This project contains two implementations of the ICurrencyProviderService interface providing currencies:

- ``ApiCurrencyProviderService`` - production repository - currencies retrieved from API
- ``HardcodedCurrencyProviderService`` - test repository


and two implementations of the IExchangeRateProviderService interface providing rates of selected currencies:

- ``ApiExchangeRatesProviderService`` - production repository - rates downloaded from an API
- ``HardcodedExchangeRatesProviderService`` - test repository


By default, the project uses production repositories. In case of errors related to Api, such as: ``Bad request``, it is necessary to close and restart the project. To change the production repositories to the test repositories, it is necessary to change the ``ApiCurrencyProviderService`` to ``HardcodedCurrencyProviderService`` and the ``ApiExchangeRatesProviderService`` to ``HardcodedExchangeRatesProviderService`` in the Program.cs file.

![bindowanie](https://user-images.githubusercontent.com/92109490/215597318-8487a9bf-ab93-4213-a94a-d52bb9952d24.png)




## requirements

- [ASP.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
- [SQL Server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads)

## technologies

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
