using LibraryApp.Business;

bool exit = false;

Console.WriteLine("Elige una opción:");
var option = Convert.ToInt32(Console.ReadLine());

while(!exit) {
    switch(option) {
        case 1:
            //Iniciar sesión
            break;
        case 2:
            //Crear cuenta
            break;
        case 3:
            Console.WriteLine("¡Hasta pronto!");
            exit = true;
            break;
        default:
            Console.WriteLine($"La opción {option} no está en el menú.");
            break;
    }
}   