using Spectre.Console;

namespace LibraryApp.Presentation {
    public class Style {
        public static void PrintError(string message) {
            AnsiConsole.MarkupLine("[red]" + message + "[/]");
        }
        
        public static void PrintSuccess(string message) {
            AnsiConsole.MarkupLine("[green]" + message + "[/]");
        }

        public static void PrintTitle(string message) {
            var info = new Panel("[blue]" + message + "[/]")
                .BorderColor(Color.Blue)
                .RoundedBorder();
            AnsiConsole.Write(info);
        }

        public static void PrintOptionTitle(string message) {
            var info = new Panel("[fuchsia]" + message + "[/]")
                .BorderColor(Color.Fuchsia)
                .RoundedBorder();
            AnsiConsole.Write(info);
        }

        public static void PrintMenu(string message) {
            var menu = new Panel("[bold]" + message + "[/]")
                .Border(BoxBorder.Heavy)
                .Header(new PanelHeader("[bold]MENÚ[/]"))
                .Padding(new Padding(3, 1, 3, 1));
            AnsiConsole.Write(menu);
        }

    }
    
}