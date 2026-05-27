using System.ComponentModel.DataAnnotations;

namespace FetchFake_API.Models
{
    public class Geo
    {
        public string lat { get; set; }
        [Required]
        public string lng { get; set; }
    }
}
