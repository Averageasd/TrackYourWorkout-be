using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TrackYourWorkout.DTOs
{
    /// <summary>
    /// DTO class that contains login input fields
    /// </summary>
    public class LoginDTO
    {
        [Required(ErrorMessage = "User name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Password is required" )]
        public string? Password { get; set; }
    }
}
