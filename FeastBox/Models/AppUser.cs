using Microsoft.AspNetCore.Identity;

namespace FeastBox.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }
    }
}
