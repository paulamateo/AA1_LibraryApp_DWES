namespace LibraryApp.Models;

public class User {
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int? PhoneNumber { get; set; }
    public int userNumber = 1;
    public string userAccountNumber { get; }
    //historial de préstamos

    public User(string name, string lastname, string email, string password, int phoneNumber) {
        Name = name;
        Lastname = lastname;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        userAccountNumber = userNumber.ToString();
        userNumber++;
        //historial de préstamos
    }

}