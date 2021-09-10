using System.ComponentModel.DataAnnotations;

namespace Marketplace.Api.Requests
{
    public class CreateUserRequest
    {
        [Required]
        public string Username { get; set; }
    }
}
