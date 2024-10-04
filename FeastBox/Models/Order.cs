using System;
using System.Collections.Generic; // تأكد من تضمين هذه المكتبة
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeastBox.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        // استخدم nullable إذا كان UserId يمكن أن يكون فارغًا
        public string? UserId { get; set; }

        // علاقة مع نموذج AppUser
        public AppUser User { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required] // تأكد من أن CustomerId مطلوب
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
