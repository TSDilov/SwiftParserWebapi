# SwiftParserWebapi

Task: Parser for Swift MT799

## Used technologies:

- .NET7 - https://learn.microsoft.com/en-us/dotnet/core/compatibility/7.0
- ASP.NET Caro Web API - https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio
- Ado.Net - https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-code-examples
- SQLite

## Description:

*A three-layer architecture for converting a Swift MT799 message file. There is Data Layer, Service Layer and Web Api. The Data Layer has the connection with SQLite and the model for the Swift Message. We have Repository patern with Insert Method which inserts the data when it is parsed from the Swift MT799 message. There is DbMigrator for the table creation and DbHelper for the connection with the base. Implementation of the parser is in the Service layer where it has Swift Parser Service.*

