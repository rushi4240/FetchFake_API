using System.ComponentModel.DataAnnotations;

namespace FetchFake_API.Models
{
    public class Company
    {
        public string name { get; set; }
        [Required]
        public string catchPhrase { get; set; }
        [Required]
        public string bs { get; set; }
    }
}
