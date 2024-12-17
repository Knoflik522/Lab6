using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 120, ErrorMessage = "Вік має бути від 1 до 120 років.")]
        public int Age { get; set; }
    }
}
