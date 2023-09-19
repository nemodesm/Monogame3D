using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Engine.Exceptions;

namespace Engine
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

            if (File.Exists(appDataPath + LogPath))
            {
                File.Move(appDataPath + LogPath, appDataPath + PreviousLogPath, true);
            }

            // var logFile = File.Create(appDataPath + LogPath);
            _writer = new StreamWriter(appDataPath + LogPath, false)
            {
                NewLine = "\n",
                AutoFlush = true
            };

            _writer.WriteLine($"{ApplicationName}: Application opened at {DateTime.Now}");
        }

        ~Debug()
        {
            Dispose(false);
        }

        public static void Initialise() => _instance = new Debug();
        private static void CheckInstance() => _instance ??= new Debug();

        public static void Log(object message)
        {
            CheckInstance();

            var stackTrace = new StackTrace(1);

            var toLog = $"[{stackTrace.GetFrame(0)?.GetMethod()?.DeclaringType}/INFO]: {message}";

            _instance._writer.WriteLine(toLog);
        }

        public static void LogWarning(object message)
        {
            CheckInstance();

            var stackTrace = new StackTrace(1);

            var toLog = $"[{stackTrace.GetFrame(0)?.GetMethod()?.DeclaringType}/WARN]: {message}";

            _instance._writer.WriteLine(toLog);
        }

        public static void LogError(object message)
        {
            CheckInstance();

            var stackTrace = new StackTrace(1);

            var toLog = $"[{stackTrace.GetFrame(0)?.GetMethod()?.DeclaringType}/ERROR]: {message}\n{stackTrace}";

            _instance._writer.Write(toLog);
        }

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
