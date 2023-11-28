using Spectre.Console;

namespace LibraryApp.Presentation {
    public class Style {
        public static void PrintError(string message) {
            AnsiConsole.MarkupLine("[red]{0}[/]", message);
        }

        public static void PrintGood(string message) {
            AnsiConsole.MarkupLine("[green]{0}[/]", message);
        }

        public static void PrintPrincipalMenu() {

        }

        public static void PrintTitle() {

        }

    }
    
}