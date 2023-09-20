using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Monogame3D.Exceptions;

namespace Monogame3D
{
    public sealed class Debug : IDisposable, IAsyncDisposable
    {
        private const string LogPath = "RunLog.log";
        private const string PreviousLogPath = "RunLog_previous.log";
        private const string ApplicationName = "Village Defender";

        private static Debug _instance;

        private readonly StreamWriter _writer;

        internal Debug()
        {
            if (_instance != null)
            {
                Debug.LogError(new DuplicateSingletonException());
                return;
            }

            var appDataPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/{ApplicationName}/";

            if (!Directory.Exists(appDataPath)) Directory.CreateDirectory(appDataPath);
            
            AttemptMovePreviousFile();

            // var logFile = File.Create(appDataPath + LogPath);
            _writer = new StreamWriter(appDataPath + LogPath, false)
            {
                NewLine = "\n",
                AutoFlush = true
            };

            _writer.WriteLine($"{ApplicationName}: Application opened at {DateTime.Now}\n");
        }

        private void AttemptMovePreviousFile()
        {
            var appDataPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/{ApplicationName}/";

            /*if (File.Exists(appDataPath + PreviousLogPath)) 
                File.Delete(appDataPath + PreviousLogPath);*/

            if (File.Exists(appDataPath + LogPath))
                File.Move(appDataPath + LogPath, appDataPath + PreviousLogPath, true);
        }

        ~Debug()
        {
            Dispose(false);
        }

        public static void Initialise() => _instance = new Debug();
        private static void CheckInstance() => _instance ??= new Debug();

#nullable enable
        private static string GetPrefix()
        {
            var stackTrace = new StackTrace(2);
            return $"{DateTime.Now}:{stackTrace.GetFrame(0)?.GetMethod()?.DeclaringType}";
        }
        
        public static void Log(object? message, int logLevel)
        {
            CheckInstance();

            var toLog = $"[{GetPrefix()}/INFO]: {message}\n";
#if DEBUG
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(toLog);
#endif

            _instance._writer.WriteLine(toLog);
        }

        public static void Log(object message)
        {
            CheckInstance();

            var toLog = $"[{GetPrefix()}/INFO]: {message}\n";
#if DEBUG
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(toLog);
#endif

            _instance._writer.WriteLine(toLog);
        }

        public static void LogWarning(object message)
        {
            CheckInstance();

            var toLog = $"[{GetPrefix()}/WARN]: {message}\n";
#if DEBUG
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(toLog);
#endif

            _instance._writer.WriteLine(toLog);
        }

        public static void LogError(object message)
        {
            CheckInstance();

            var stackTrace = new StackTrace(1);

            var toLog = $"[{GetPrefix()}/ERROR]: {message}\n{stackTrace}";
#if DEBUG
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Error.WriteLine(toLog);
#endif

            _instance._writer.WriteLine(toLog);
        }
#nullable restore

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                _writer?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private async ValueTask DisposeAsyncCore()
        {
            ReleaseUnmanagedResources();

            if (_writer != null) await _writer.DisposeAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();
            GC.SuppressFinalize(this);
        }
    }
}
