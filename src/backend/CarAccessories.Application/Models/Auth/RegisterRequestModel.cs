namespace CarAccessories.Application.Models.Auth;

public class RegisterRequestModel
{
    public string UserName { get; set; }
    public string? FullName { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
}