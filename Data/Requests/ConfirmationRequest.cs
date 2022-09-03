using System.ComponentModel.DataAnnotations;

namespace ClinicSistem_backend.Data.Requests
{
    public class ConfirmationRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ConfirmationCode { get; set; }
    }
}
