using System.ComponentModel.DataAnnotations;

namespace community_institute_API.DTOs
{
    public class Regester
    {
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumer { get; set; }
        //shloud add RGX here
        public string Passwroed { get; set; }

    }
}
