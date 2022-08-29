# Add project references

Blazor Server and Blazor WebAssembly reference Blazor Core, where the actual UI will reside.

```
dotnet add src\1-Blazor\ProgrammersWeek.TalkManager.BlazorServerApp reference src\1-Blazor\ProgrammersWeek.TalkManager.BlazorUi
dotnet add src\1-Blazor\ProgrammersWeek.TalkManager.BlazorWebAssemblyApp reference src\1-Blazor\ProgrammersWeek.TalkManager.BlazorUi
dotnet add src\2-Backend\ProgrammersWeek.TalkManager.WebApi reference src\2-Backend\ProgrammersWeek.TalkManager.DataAccess
```

UI, API, and Data Access reference a Shared library.

```
dotnet add src\1-Blazor\ProgrammersWeek.TalkManager.BlazorUi reference src\3-Shared\ProgrammersWeek.TalkManager.Shared
dotnet add src\2-Backend\ProgrammersWeek.TalkManager.WebApi reference src\3-Shared\ProgrammersWeek.TalkManager.Shared
dotnet add src\2-Backend\ProgrammersWeek.TalkManager.DataAccess reference src\3-Shared\ProgrammersWeek.TalkManager.Shared
```

Each unit test project references its corresponding project.

```
dotnet add test\ProgrammersWeek.TalkManager.BlazorUi.Tests reference src\1-Blazor\ProgrammersWeek.TalkManager.BlazorUi
dotnet add test\ProgrammersWeek.TalkManager.WebApi.Tests reference src\2-Backend\ProgrammersWeek.TalkManager.WebApi
dotnet add test\ProgrammersWeek.TalkManager.DataAccess.Tests reference src\2-Backend\ProgrammersWeek.TalkManager.DataAccess
```