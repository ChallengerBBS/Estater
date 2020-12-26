namespace WebAPI.Dtos
{
    using System.ComponentModel.DataAnnotations;
    public class CityDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression("^[A-Z]{1}[a-zA-z\\s]+", ErrorMessage="The city name should contain only letters, starting with a capital letter.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression("^[A-Z]{1}[a-zA-z\\s]+", ErrorMessage = "The country name should contain only letters, starting with a capital letter.")]
        public string Country { get; set; }
    }
}
