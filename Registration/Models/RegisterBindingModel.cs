using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Registration.Models
{
    public class RegisterBindingModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int ProvinceId { get; set; }
    }
}
