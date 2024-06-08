using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImage.Models
{
    public class Order
    {
        [Key]
        [DisplayName("id")]
        public int Order_id { get; set; }
        [Required]
        public string user_id { get; set; }
        [ForeignKey("user_id")]
        public User user { get; set; }
        [Required]
        public int size_id { get; set; }
        [ForeignKey("size_id")]
        public virtual SizeDetail SizeDetail { get; set; }
        [Required]
        public string picture { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        // add order status
        [Required]
        public DateTime Added_at { get; } = DateTime.Now;

    }
}
