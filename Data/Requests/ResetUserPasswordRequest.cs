using System.ComponentModel.DataAnnotations;

namespace ClinicSistem_backend.Data.Requests
{
    public class ResetUserPasswordRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
