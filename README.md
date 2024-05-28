# BooksInventory

## Getting Started

Open solution file `BooksInventory.sln` using Visual Studio 2022. Make sure that `BooksInventory.Web` is set as startup project. Run the application.

## Database

The project is configured to use local SQL Server by default. You can update database connection string in `web.config` file inside `BooksInventory.Web` project. Since the database is created automatically when the application starts, user running the app should have the necessary rights.

## Technologies

* [ASP.NET Web Forms]([https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core](https://learn.microsoft.com/en-us/aspnet/web-forms/))
* [Entity Framework 6]([https://docs.microsoft.com/en-us/ef/core/](https://learn.microsoft.com/en-us/ef/ef6/))
* [MediatR](https://github.com/jbogard/MediatR)
* [MSTest, [FluentAssertions](https://fluentassertions.com/), [NSubstitute]([https://github.com/moq](https://nsubstitute.github.io/))
