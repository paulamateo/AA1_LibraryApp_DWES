using LibraryApp.Data;

namespace LibraryApp.Business {
    public class LogService : ILogService {
        private readonly string _logFile;
        private int _errorCount;

        public LogService() {
            _logFile = Path.Combine(@"..\Data\", "errors.txt");
            _errorCount = 0;

            AppDomain.CurrentDomain.ProcessExit += EndProgram;
        }

        public void LogError (string message) {
            try {
                _errorCount++;
                string logMessage = $"ERROR {_errorCount}: {message}";
                File.AppendAllText(_logFile, logMessage + Environment.NewLine);
            }catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private void EndProgram(object sender, EventArgs e) {
            try {
                File.Delete(_logFile);
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }

}