# WPF .NET Core ToolKit
This Toolkit let you rapidly add a new test by adding a new UserControl and connect it to a new button on main window.

## UserControl1
- Use Logger Tool

## UserControl2 
- Demonstrate the use of Dependency Property
- Show Style.Triggers

## Tools/Logger
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

