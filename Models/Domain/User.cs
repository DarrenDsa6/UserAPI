using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models.Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public long ContactNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public long Pincode { get; set; }

        [Required]
        public long AadhaarCard { get; set; }

        public int? BrokerId { get; set; }
    }
}
