using LibraryApp.Data;

namespace LibraryApp.Business {
    public class LogService {
        private readonly string _logFile;
        private readonly string _filePath = @"..\LibraryApp\Data\";
        private int _errorCount;

        public LogService() {
            _logFile = Path.Combine(_filePath, "errors.txt");
            _errorCount = 0;

            AppDomain.CurrentDomain.ProcessExit += EndProgram;
        }

        public void LogError (string message) {
            _errorCount++;
            string logMessage = $"ERROR {_errorCount}: {message}";
            File.AppendAllText(_logFile, logMessage + Environment.NewLine);
        }

        private void EndProgram(object? sender, EventArgs e) {
            if (File.Exists(_logFile)) {
                File.Delete(_logFile);
            }
        }

    }

}