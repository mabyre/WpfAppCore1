# WPF .NET Core ToolKit
This Toolkit let you rapidly add a new small test by adding a new UserControl and connect it to a new button on main window.

Like this:

<img style="margin: 10px" src="Images/2023-04-12_11h06_53.png" alt="WPF .NET Core Toolkit" />

## UserControl1
- Use Logger Tool

## UserControl2 
- Demonstrate the use of ***Dependency Property***
- Show Style.Triggers

## UserControlLog
- .NET Core 6.0 way of produce Logs using .NET Core standard ***ILogger*** and ***ILoggerFactory***

## UseAppSettings
- Read application configuration in ***appsettings.json*** file

## Tools/Logger
Loggin is a more tough subject than we can think, especially since log4net has become a gas factory.

### Personal logger
It could be intresting to have it's own logger system at a time where everyone says to do not reinvent the wheel, while doing it.
Sometimes I could found ***log4net*** diffcult to install and configure.

Log message into severals, file, console, trace, windows easily add your own method.
Manage level of severity.

It's an exemple of using delegate function System.Action<T>

```csharp
    public static Action<string> WriteMessage;
```

Configuration is done in control after InitializeComponent : 

```csharp
    Logger.WriteMessage += LoggingMethods.LogToConsole; 
    Logger.WriteMessage += LoggingMethods.LogToTrace;
    Logger.LogLevel = Severity.Verbose; // by default set to Warning
```

- path to the log file :
	- WpfAppCore1\bin\Debug\netcoreapp3.1\log.txt

The use of this component have been demonstrated in a Blazor project: [MyBlazorServerApp](https://github.com/mabyre/MyBlazorServerApp)

#### ToDo
- complete logfile name with the date of the day
- make user to specify log file path

## Back to basics of Logs
While I'm working on new apps, log is style a tricky subject. 
If I want to enhance my personnal logger I'll have some work. 
I saw something like adjust log level in appsettings could make you see internal core library messages and this is cool.

### Reference
- [StackOverflow - How to log to a file without using third party logger in .Net Core?](https://stackoverflow.com/questions/40073743/how-to-log-to-a-file-without-using-third-party-logger-in-net-core)
- [closed issue](https://github.com/aspnet/Logging/issues/441)
- [Logging in C# and .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/logging)
- [Logging and global error handling in .NET 7 WPF applications](https://blog.elmah.io/logging-and-global-error-handling-in-net-7-wpf-applications/)
- [Logging in .NET Core and ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/)
    - This is one for .NET Core particulary [Non-host console app](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1#non-host-console-app) har to find

While I'm working on loggin features I found intresting to make logs in the ***.NET Core standard way***.

This is the aim of UserControlLog plus some little things like add ***Program.cs*** file in the project

```xaml
    <PackageReference Include="Microsoft.Extensions.Hosting" Version="8.0.0-preview.2.23128.3" />
    <PackageReference Include="Microsoft.Extensions.Logging" Version="8.0.0-preview.2.23128.3" />
```

## Add an appsettings.json file
I'm very surprise that default template WPF application are NOT with an an appsettings.json file ?!
While WPF application create by TemplateSutio had one.

So add by hand an appsettings.json

### Reference
- [LearnMicrosoft - Configuration in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)
- [StackOverflow - C# ConfigurationManager in .NET Core](https://stackoverflow.com/questions/71104843/c-sharp-configurationmanager-in-net-core)

The aim of adding an ***appsettings.json*** is to configure Log level.

## Create Style

> :warning: Trying to create Style in <Application.Resources> create an exception in MainWindow InitializeComponent();
>
> Style must be created in ***<Window.Resources>***

[Learn Microsoft - How to create a style for a control (WPF .NET)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/how-to-create-apply-style)




