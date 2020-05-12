# NumberToWords
A small extensible library for .NET that converts numbers/currency into words representation with i18n capability.

[![Build Status](https://dev.azure.com/HenkaProgrammer/Number%20To%20Words/_apis/build/status/H.NumberToWords?branchName=master)](https://dev.azure.com/HenkaProgrammer/Number%20To%20Words/_build/latest?definitionId=3&branchName=master)

### Get Started
NumberToWords can be installed using the Nuget package manager or the `dotnet` CLI.

```
Install-Package H.NumberToWords
```
 
### Example
Should initialize the static Converter at application startup before usage.
```csharp
using NumberToWords;

// ...
Converter.Initialize();
// ...
```
Then you can use the static instance everywhere
```csharp
var number = 120.0;
var words = Converter.ConvertToWords(number);
```
### Documentation

Soon, Not ready yet.
