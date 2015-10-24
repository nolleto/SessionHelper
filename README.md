# SessionHelper
Get and set typed objects in Session.

## Installation

You can install by [NuGet Maneger](https://www.nuget.org/packages/SessionHelper/) or by [BuGet Console] by the command `PM> Install-Package SessionHelper`.

## Using

You can create in your project an class with all your variables in Session like this:

```
using SessionHelper;
using SessionHelper.Models;

public static class SessionVariables
{
    public static SessionProperty<string> UserName = Session.CreateProperty<string>("UserName");
    public static SessionProperty<UserClass> User = Session.CreateProperty<UserClass>("User");
}
```

So you can access your Sessions variables in all your project:

```
public void DoIt() 
{
  SessionVariables.UserName.Set("Bruno");
  var name1 = SessionVariables.UserName.Get(); //Bruno
  
  SessionVariables.UserName.Reset();
  var name2 = SessionVariables.UserName.Get(); //null
  var name3 = SessionVariables.UserName.GetOrDefault("Sr. Awesome"); //Sr. Awesome
}
```
