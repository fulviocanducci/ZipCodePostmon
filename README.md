# ZipCodePostmon

_Baseado na API Postmon:_ https://api.postmon.com.br

[![Build Status](https://travis-ci.org/fulviocanducci/ZipCodePostmon.svg?branch=master)](https://travis-ci.org/fulviocanducci/ZipCodePostmon)
[![Version](https://img.shields.io/nuget/v/Canducci.ZipCodePostmon.svg?style=plastic&label=version)](https://www.nuget.org/packages/Canducci.ZipCodePostmon/)
[![NuGet](https://img.shields.io/nuget/dt/Canducci.ZipCodePostmon.svg)](https://www.nuget.org/packages/Canducci.ZipCodePostmon/)

### Instala��o:

##### Packager Manager

```csharp
PM> Install-Package Canducci.ZipCodePostmon
```

##### .NET CLI

```csharp
> dotnet add package Canducci.ZipCodePostmon
```

##### Paket CLI

```csharp
> paket add Canducci.ZipCodePostmon
```

___

### Como Usar?

Depois da instala��o do Pacote, declare o seu `namespace`:

```csharp
using Canducci.ZipCodePostmon;
```

ap�s a declara��o do `namespace` utilize da seguinte forma:

```csharp
string value = "01414000";
if (ZipCodeNumber.TryParse(value, out ZipCodeNumber number))
{
    ZipCode model = await ZipCodeResult.FindAsync(number);
}
```