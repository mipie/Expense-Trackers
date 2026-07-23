using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(50)]
    public required string LastName { get; set; }

    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;

    [EmailAddress]
    [MaxLength(100)]
    public required string Email { get; set; }
    
    public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;


}