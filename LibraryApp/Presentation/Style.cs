using Microsoft.VisualBasic;
using Spectre.Console;

namespace LibraryApp.Presentation {

    public class Style {
        public void PrintInfo(string message) {
            AnsiConsole.MarkupLine("[aqua bold]" + message + "[/]");
        }

        public void PrintError(string message) {
            AnsiConsole.MarkupLine("[red]" + message + "[/]");
        }

        public void PrintSuccess(string message) {
            AnsiConsole.MarkupLine("[green]" + message + "[/]");
        }

        public void PrintBold(string message) {
            AnsiConsole.MarkupLine("[bold]" + message + "[/]");
        }

        public void PrintWarning(string message) {
            AnsiConsole.MarkupLine("[yellow]" + message + "[/]");
        }

        public void PrintOptionTitle(string message) {
            var optionTitle = new Panel("[green bold]" + message + "[/]")
                .Border(BoxBorder.Heavy)
                .BorderColor(Color.Green);
            AnsiConsole.Write(optionTitle);
        }

        public void PrintMenu(string message) {
            var menu = new Panel("[aqua bold]" + message + "[/]")
                .Border(BoxBorder.Heavy)
                .Header(new PanelHeader("[bold]MENÚ[/]"))
                .BorderColor(Color.Aqua)
                .Padding(new Padding(3, 1, 3, 1));
            AnsiConsole.Write(menu);
        }

    }
    
}