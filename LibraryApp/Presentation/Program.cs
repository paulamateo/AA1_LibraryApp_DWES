using LibraryApp.Business;
using LibraryApp.Presentation;

bool exit = false;
Menu.DisplayTitle();

while(!exit) {
    try {
        Menu.DisplayPrincipalMenu();
        Console.WriteLine("Elige una opción:");
        var option = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        switch(option) {
            case 1:
                Menu.Login();
                break;
            case 2: 
                Menu.SignUp();
                break;
            case 3:
                Console.WriteLine("¡Hasta pronto!");
                exit = true;
                break;
            default:
                Style.PrintError($"La opción {option} no está en el menú.");
                break;
        }
    }catch (FormatException) {
        Style.PrintError($"Error de formato. Debes introducir un carácter válido.\n");
    }
}   