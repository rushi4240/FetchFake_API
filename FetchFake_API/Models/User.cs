using System.ComponentModel.DataAnnotations;

namespace FetchFake_API.Models
{
    public class User
    {

        public int id { get; set; }
        public string name { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public Address address { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string website { get; set; }
        [Required]
        public Company company { get; set; }
    }




}
