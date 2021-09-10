using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Api.Requests
{
    public class CreateOfferRequest
    {
        [Required]
        public byte categoryId { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string location { get; set; }

        [Required]
        public string pictureUrl { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public string title { get; set; }

    }
}
