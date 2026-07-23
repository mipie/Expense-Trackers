using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class User
{
    public int Id { get; set; }

    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(50)]
    public required string LastName { get; set; }
    
    [MaxLength(50)]
    public string PasswordHash { get; set; }

    [EmailAddress]
    public required string Email { get; set; }


}