namespace WebApi.Validators.Users;

using System.ComponentModel.DataAnnotations;

public class UpdateRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [EmailAddress]
    public string? Email { get; set; }
}