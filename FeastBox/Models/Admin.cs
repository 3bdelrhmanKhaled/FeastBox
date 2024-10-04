using System.ComponentModel.DataAnnotations;

namespace FeastBox.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // يجب أن يكون هذا هو هاش كلمة المرور
    }
}
