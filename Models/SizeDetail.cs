
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImage.Models
{
    public class SizeDetail
    {
        [Key]
        [DisplayName("id")]

        public int Size_id { get; set; }
        [Required]
        public string Size_Name { get; set; }
        [Required]
        public string Size_Discription { get; set; }
        [Required]
        public string Size_inches { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Size_Price { get; set; }
    }
}
