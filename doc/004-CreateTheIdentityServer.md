# Create the Identity Server

Duende IdentityServer is middleware that adds spec-compliant OpenID Connect and OAuth 2.0 endpoints
to an arbitrary ASP.NET Core host.

```
cd src\4-Security
dotnet new isinmem -n IdentityServer
```

An alternative that is longer but more educational, because you can inspect a basic IdentityServer
implementation, is:

```
cd src\4-Security
dotnet new isempty -n IdentityServer

cd IdentityServer
dotnet new isui
```

Don't forget to add the newly created project to the solution. If you used the alternative above,
execute in addition `cd ..` as a first step.

```
cd ..\..
dotnet sln add src\4-Security\IdentityServer
```