using System;
using System.Diagnostics;
using System.IO;

namespace MonoGame3D;

public static class Debug
{
    public enum LogLevel
    {
        Log = 1,
        Info = 2,
        Warn = 3,
        Error = 4
    }

    private const string LogPath = "RunLog.log";
    private const string PreviousLogPath = "RunLog_previous.log";
    private const string ApplicationName = "Village Defender";

    private static readonly StreamWriter Writer;
    private static readonly string _appDataPath;

    static Debug()
    {
        _appDataPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/{ApplicationName}/";

        if (!Directory.Exists(_appDataPath)) Directory.CreateDirectory(_appDataPath);
            
        AttemptMovePreviousFile();

        // var logFile = File.Create(appDataPath + LogPath);
        Writer = new StreamWriter(_appDataPath + LogPath, false)
        {
            NewLine = "\n",
            AutoFlush = true
        };

        Log($"{ApplicationName}: Application opened at {GetTimeStamp()} on {GetDateFormat()}", 0);
    }

    private static void AttemptMovePreviousFile()
    {
        if (File.Exists(_appDataPath + LogPath))
            File.Move(_appDataPath + LogPath, _appDataPath + PreviousLogPath, true);
    }

    private static string GetDateFormat()
    {
        var date = DateTime.Now;
        return $"{date.Day}-{date.Month}-{date.Year}";
    }

    private static string GetTimeStamp()
    {
        var time = DateTime.Now;
        return $"{time.Hour:00}:{time.Minute:00}:{time.Second:00}";
    }

    private static string GetPrefix()
    {
        var stackTrace = new StackTrace(2);
        return $"{GetTimeStamp()}:{stackTrace.GetFrame(0)?.GetMethod()?.DeclaringType}";
    }
    
    public static void Log(object? message, LogLevel logLevel)
    {
        var toLog = logLevel == 0
            ? $"{message}\n"
            : $"[{GetPrefix()}/{logLevel}]: {message}\n{(logLevel == LogLevel.Error ?
                new StackTrace(1) : "")}";
        
#if DEBUG
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(toLog);
#endif

        Writer.WriteLine(toLog);
    }
    
    public static void Log(object? message)
    {
        var toLog = $"[{GetPrefix()}/INFO]: {message}\n";
#if DEBUG
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(toLog);
#endif

        Writer.WriteLine(toLog);
    }

    public static void LogWarning(object? message)
    {
        var toLog = $"[{GetPrefix()}/WARN]: {message}\n";
#if DEBUG
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(toLog);
#endif

        Writer.WriteLine(toLog);
    }

    public static void LogError(object? message)
    {
        var stackTrace = new StackTrace(1);

        var toLog = $"[{GetPrefix()}/ERROR]: {message}\n{stackTrace}";
#if DEBUG
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Error.WriteLine(toLog);
#endif

        Writer.WriteLine(toLog);
    }
}