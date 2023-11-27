

Console.WriteLine("Elige una opción:");
var option = Convert.ToInt32(Console.ReadLine());

bool exit = false;

while(!exit) {
    switch(option) {
        case 1:
            //Iniciar sesión
            Menu.Login();
            Menu.DisplaySecondMenu()
            break;
        case 2:
            Menu.SignUp();
            
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