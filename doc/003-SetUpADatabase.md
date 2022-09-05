# Set up a database

## Create the instance or configure the connection string

A connection string to a SQL Server database is already set up in the `appsettings.json` of the
Web API project, which is the one that deals with the data.  That file can be found here:
`src/2-Backend/ProgrammersWeek.TalkManager.WebApi/appsettings.json`.

Before you can run the solution, you have to choose one of these two options:
1. Update that connection string to the details of a database you have access to. If you don't,
you'll get an exception because Entity Framework (EF) Core won't be able to find the
pre-configured database.
2. Create an instance to match the existing connection string.  I'm using a LocalDB instance,
which is a trimmed-down version of a full-blown SQL Server database, and it's ideal for
development.

If you choose option #2, make sure you have the _Data storage and processing_ workload selected
in you Visual Studio instalation (open _Visual Studio Installer_, select _Modify_ and check the
installed workloads).  Then open a command prompt and execute:

```
sqllocaldb c PW2022 -s
```

That will create a new LocalDB instance with the name `PW2022`, and it will start it.  You can now
start the solution.

For your reference, you can list all your LocalDB instances with this command:

```
sqllocaldb i
```

If you decide you don't need the new instance anymore, you can delete it with these commands:

```
sqllocaldb p PW2022 -i
sqllocaldb d PW2022
```

## Have EF Core create the database

The migrations are already created.  You need to ask EF Core to execute them on the SQL Server
instance.

Set the `ProgrammersWeek.TalkManager.WebApi` project as the **Startup Project**.  That's how
EF Core knows where to find the connection string that has been registered in the `ISeervices`
collection.

Then, open the _Package Manager Console_, set `ProgrammersWeek.TalkManager.DataAccess` as the
**default project** in the drop-down menu, and execute:

`Update-Database`

Verify in the _SQL Server Object Explorer_ that you have a new database called `TalkManager.Db`,
and that you have data in it.