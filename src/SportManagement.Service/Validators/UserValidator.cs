using SportManagement.Service.DTOs.Users;
using System.Text.RegularExpressions;

namespace SportManagement.Service.Validators;

public class UserValidator
{
    public static void ValidateUser(UserForCreationDto user)
    {
        //  Name leangth Validation
        if (user.UserName.Length < 3 || user.UserName.Length > 20)
            throw new ArgumentException("Username must be between 3 and 20 characters long.");
        // Email format Validation
        if (string.IsNullOrWhiteSpace(user.Email) || !Regex.IsMatch(user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Invalid email format.");
        // Password Length Validation
        if (string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters long.");
        // Password Format Validation
        if (!Regex.IsMatch(user.Password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            throw new ArgumentException("Password must contain at least one uppercase letter, one number, and one special character.");

       

    }

}
