using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examify.Domain.Entities.sys;

[Table("sys_user", Schema = "public")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column("first_name")]
    public string FirstName { get; set; } = default!;
    
    [Required]
    [StringLength(100)]
    [Column("last_name")]
    public string LastName { get; set; } = default!;
    
    [Required]
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = default!;
    
    [Required]
    [Column("password_hash")]
    public string PasswordHash { get; set; } = default!;
    
    [Column("is_admin")]
    public bool IsAdmin { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }
    
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    
    [Column("modified_date")]
    public DateTime? ModifiedDate { get; set; }
}