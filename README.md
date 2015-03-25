IS24RestApi
===========

A small library that accesses the [Immobilienscout24 Import/Export REST API](http://api.immobilienscout24.de/our-apis/import-export.html)
using [RestSharp](https://github.com/restsharp/RestSharp).

Getting Started
---------------

IS24RestApi is available as a [NuGet package](https://www.nuget.org/packages/IS24RestApi/).

The `ImportExportClient` class has CRUD methods for all resource types and the `SampleConsole` project shows a few uses. 
You need to acquire OAuth credentials beforehand by carrying out [these steps](http://api.immobilienscout24.de/get-started.html) and afterwards autorising your api key with an user account, for which there is a [tutorial](http://api.immobilienscout24.de/useful/tutorials-sdks-plugins/tutorial-customer-website.html#oAuth_by_our_playground))
and put the generated access token and access secret in the config.json file that's read from the current working directory at runtime (see the included config.example.json file).

The `AuthorizeAsync` method shows how to perform the OAuth authorization steps programmatically.

All API calls are carried out asynchronously and the paging call `GetAsync()` for `RealEstate` resources
uses [Reactive Extensions](http://rx.codeplex.com/) to return the real estate objects both lazily and asynchronously.

Regenerating API Types
----------------------

The classes in the Types.generated.cs file were generated from the XSD files provided by IS24
using [XmlSchemaClassGenerator](https://github.com/mganss/XmlSchemaClassGenerator). 
There are two PowerShell scripts in the xsd folder to automate this process. 
Open a Visual Studio command prompt and execute them with `powershell ...`. 
If you get a permissions error, open a PowerShell and type `Set-ExecutionPolicy Unrestricted` 
(more about this [here](http://technet.microsoft.com/en-us/library/ee176949.aspx)).

1. `DownloadSchemaFiles.ps1` downloads all .xsd files from [here](http://rest.immobilienscout24.de/restapi/api/offer/v1.0/?_wadl&_schema) 
and moves `messages*.xsd` to the includes folder.
2. `GenerateClasses.ps1` generates .cs files into the `generated` folder.

Contributing
------------

Pull requests to improve are welcome :)
