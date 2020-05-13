# NumberToWords
[![Build Status](https://dev.azure.com/HenkaProgrammer/Number%20To%20Words/_apis/build/status/H.NumberToWords?branchName=master)](https://dev.azure.com/HenkaProgrammer/Number%20To%20Words/_build/latest?definitionId=3&branchName=master) [![Maintainability](https://api.codeclimate.com/v1/badges/353313c6df087bbc006f/maintainability)](https://codeclimate.com/github/Henka-Programmer/NumberToWords/maintainability) [![NuGet](https://img.shields.io/nuget/v/H.NumberToWords.svg)](https://nuget.org/packages/H.NumberToWords)

A small extensible library for .NET that converts numbers/currency into words representation with i18n capability.

### Get Started
NumberToWords can be installed using the Nuget package manager or the `dotnet` CLI.

```
Install-Package H.NumberToWords
```

### Example
Should initialize the static Converter at application startup before usage.
```csharp
// ...
NumberToWords.Converter.Initialize();
// ...
```
Then you can use the static instance everywhere
```csharp
var number = 120.0;
var words = NumberToWords.Converter.ConvertToWords(number);
```
You can provide extra options such as language and currency.
```csharp
var number = 22365.0;
NumberToWords.Converter.ConvertToWords(number, options =>
{
    options.CurrencyCode = "USD"; // currency ISO 4217 code.
    options.LanguageCode = "en";  // words language ISO 639-1 code.
    options.LetterCase = NumberToWords.LetterCase.Lowercase; // character casing, lower, upper, title, sintence 
    options.WordSeparator = " "; // words separator by default space
});
```
or you can use a specific language converter
```csharp
using NumberToWords.Language;

// ...
var englishConverter = new EnglishNumberToWordsConverter();
var number = 120.0;
var words = englishConverter.ConvertToWords(number);
```
### Documentation

Soon, Not ready yet.
