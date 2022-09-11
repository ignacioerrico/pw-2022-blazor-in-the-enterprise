# Add ASN.NET Core Identity

Right click on the `IdentityServer` project -> Add -> New Scaffolded Item -> Identity (on the left) -> Identity
- You may choose to override any files you want to customize.  For my presentation I will use the defaults.
- Add a Data Context and (optionally) a User class.

Bear in mind that the scaffolder is not perfect and may add things, especially to the `Program.cs` file, that
cause the solution to not build.

**IMPORTANT**
- The scaffolder adds a call to `AddDefaultIdentity()` which, among other things, configures authentication to
use cookies, and that's not what we want.  We also want to integrate IdentityServer with the user management
from ASP.NET Core Identity.

That's what I'll do in the next commit.  I just created this commit for you to be able to see the changes I made
to the scaffolded items.

Do note that I did update the connection string in `appsettings.json` to use the LocalDB instance I'd created
previously.