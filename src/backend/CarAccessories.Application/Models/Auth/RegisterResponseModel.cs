namespace CarAccessories.Application.Models.Auth;

public class RegisterResponseModel
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = default!;
    public string Message { get; set; } = "Registration successful";
}