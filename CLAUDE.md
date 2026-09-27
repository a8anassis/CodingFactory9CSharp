# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository purpose

This is a C# learning/coursework repository ("CodingFactory9CSharp"). It is a single Visual Studio solution (`CodingFactory9CSharp.slnx`) containing ~40 small, independent console-app projects, each demonstrating one C# language feature or exercise (e.g. `IfCases`, `WhileApp`, `LinqApp`, `InterfacesApp`, `OperatorOverloading`, `RegExApp`), plus one real ASP.NET Core Razor Pages web app, `WebAppStarter9`.

Most projects are standalone and unrelated to each other — there is no shared library or cross-project dependency. When asked to work on "the app" without further context, check whether the request concerns `WebAppStarter9` (the evolving multi-page app) or one of the single-`Program.cs` exercise projects.

## Common commands

Build/run/test everything from the repo root, or `cd` into an individual project directory first.

```
dotnet build CodingFactory9CSharp.slnx        # build entire solution
dotnet build <ProjectName>                    # build a single project
dotnet run --project <ProjectName>            # run a single console exercise, e.g.:
dotnet run --project WebAppStarter9           # run the web app (see launchSettings.json for ports)
```

There are no test projects and no lint/format configuration in this repo currently.

Target framework across all projects: `net10.0`, with `Nullable` and `ImplicitUsings` enabled.

## WebAppStarter9 (the ASP.NET Core Razor Pages app)

- Standard Razor Pages structure under `Pages/`, with shared layout in `Pages/Shared/_Layout.cshtml`.
- `Pages/Students/` is the active feature area: `Insert.cshtml(.cs)` (create form), `ViewStudents.cshtml(.cs)` (list/filter by lastname query string), `Success.cshtml(.cs)` (post-insert confirmation, data passed via `TempData`).
- Domain types are split into `Model/` (plain entities, e.g. `City`) and `DTO/` (records used for page binding and display, e.g. `InsertStudentDTO`, `StudentReadOnlyDTO`). DTOs use C# record primary constructors with data-annotation validation attributes on the properties.
- There is currently **no database wired up** — `PageModel`s return hardcoded in-memory lists (see `GetAllStudents()` in `ViewStudentsModel`, `LoadCities()` in `InsertModel`). `SQLQuery1.sql` at the repo root defines a `StudentsAppSqlDB9` database schema (`Students` table) that the app is expected to grow into using — when adding persistence, this is the target schema, but no EF Core / ADO.NET data-access layer or connection string exists yet.
- Comments in `PageModel.OnPost()` methods marking `// Service` indicate where a service/business-logic layer is intended to be introduced later, separate from the page handler.

## Conventions observed in this repo

- Course content includes Greek-language sample data (e.g. student/city names) — preserve this when extending existing exercises rather than switching to English placeholders.
- Namespaces mirror project/folder names (e.g. `WebAppStarter9.Model`, `WebAppStarter9.DTO`, `WebAppStarter9.Pages.Students`).
