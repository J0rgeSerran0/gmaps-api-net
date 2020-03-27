# Google Maps API for .NET

## Introduction
> This is a forked project from the original one, from Eric Newton [@ericnewton76](https://github.com/ericnewton76/)

The forked project is a .NET library for interacting with the Google Maps API suite.

- Original project: [gmaps-api-net](https://github.com/ericnewton76/gmaps-api-net) 
- NuGet package: [gmaps-api-net](https://www.nuget.org/packages/gmaps-api-net)
- Original README file: [ORIGINAL_README.md](ORIGINAL_README.md)

## Why this project has been forked
I was using the NuGet package of **gmaps-api-net** in one project. I needed upgrade my project into .NET Core 3.1, but I had problems with the original NuGet package when I tried upgrade my project into .NET Core 3.1.

The problem was that the original library was built for .NET Standard 1.3.

As you know, you can use the .NET Standard 1.3 packages into your .NET Core 1.0 apps, but not for .NET Core 3.

> For more details about this, please check the [official information from Microsoft](https://docs.microsoft.com/es-es/dotnet/standard/net-standard)

In the other side, there was not updates for **gmaps-api-net** from February 2019, so I decided fork the project and upgrade it to use it with .NET Core 3.1.

> For more details about the original project, read the official documentation about the library [here](ORIGINAL_README.md) :wink:
