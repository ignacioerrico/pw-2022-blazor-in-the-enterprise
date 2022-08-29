# Create a new solution

The solution was created from the command line with the following commands.

## Create directory structure

```
mkdir src\1-Blazor
mkdir src\2-Backend
mkdir src\3-Shared
mkdir test
```

## Create new projects

The solution supports a dual Blazor Server/Blazor WebAssembly app.  We want to
potentially support either hosting model.

```
cd src\1-Blazor

dotnet new blazorserver --name ProgrammersWeek.TalkManager.BlazorServerApp
dotnet new blazorwasm --name ProgrammersWeek.TalkManager.BlazorWebAssemblyApp
dotnet new razorclasslib --name ProgrammersWeek.TalkManager.BlazorUi

cd ..\2-Backend

dotnet new webapi --name ProgrammersWeek.TalkManager.WebApi
dotnet new classlib --name ProgrammersWeek.TalkManager.DataAccess

cd ..\3-Shared

dotnet new classlib --name ProgrammersWeek.TalkManager.Shared
```

xUnit unit test projects.

```
cd ..\..\test

dotnet new xunit --name ProgrammersWeek.TalkManager.BlazorUi.Tests
dotnet new xunit --name ProgrammersWeek.TalkManager.WebApi.Tests
dotnet new xunit --name ProgrammersWeek.TalkManager.DataAccess.Tests
```

## Create the solution

Create a new solution and add all the projects to it.

```
cd ..

dotnet new sln --name ProgrammersWeek.TalkManager

dotnet sln ProgrammersWeek.TalkManager.sln add src\1-Blazor\ProgrammersWeek.TalkManager.BlazorWebAssemblyApp src\1-Blazor\ProgrammersWeek.TalkManager.BlazorServerApp src\1-Blazor\ProgrammersWeek.TalkManager.BlazorUi src\2-Backend\ProgrammersWeek.TalkManager.WebApi src\2-Backend\ProgrammersWeek.TalkManager.DataAccess src\3-Shared\ProgrammersWeek.TalkManager.Shared test\ProgrammersWeek.TalkManager.BlazorUi.Tests test\ProgrammersWeek.TalkManager.WebApi.Tests test\ProgrammersWeek.TalkManager.DataAccess.Tests
```

Add a `.gitignore` file.

```
dotnet new gitignore
```