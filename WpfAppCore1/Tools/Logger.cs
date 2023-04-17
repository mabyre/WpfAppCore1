using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Tools.Logger
{
    public enum Severity
    {
        Verbose,
        Trace,
        Information,
        Warning,
        Error,
        Critical
    }

    public static class Logger
    {
        public static Action<string> WriteMessage;

        public static Severity LogLevel { get; set; } = Severity.Warning;

        public static void LogMessage( Severity s, string component, string msg )
        {
            if ( s < LogLevel )
                return;

            var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
            WriteMessage( outputMsg );
        }
    }

    public class FileLogger
    {
        private readonly string logPath;
        public FileLogger( string path )
        {
            logPath = path;
            Logger.WriteMessage += LogMessage;
        }

        public void DetachLog() => Logger.WriteMessage -= LogMessage;
        
        // make sure this can't throw.
        private void LogMessage( string msg )
        {
            try
            {
                using ( var log = File.AppendText( logPath ) )
                {
                    log.WriteLine( msg );
                    log.Flush();
                }
            }
            catch ( Exception )
            {
                // Hmm. We caught an exception while
                // logging. We can't really log the
                // problem (since it's the log that's failing).
                // So, while normally, catching an exception
                // and doing nothing isn't wise, it's really the
                // only reasonable option here.
            }
        }
    }
    public static class LoggingMethods
    {
        public static void LogToConsole( string message )
        {
            // To see this message on a Console :
            // Right click on Project choose "Properties",
            // in "Application" tab,
            // change "Output Type" to "Console Application,
            // and while running a window console open to display the message
            //
            Console.WriteLine( message );
            //Console.Error.WriteLine( message );
        }

        public static void LogToTrace( string message )
        {
            // This message will appear in Output
            Trace.WriteLine( message );
        }
    }
}
