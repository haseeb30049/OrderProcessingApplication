using System.ComponentModel.DataAnnotations;

namespace OrderProcessingApplication.DAL
{
    public class OrderData
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerType { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public double Discount { get; set; }

        [Required]
        [Phone]
        public double PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
