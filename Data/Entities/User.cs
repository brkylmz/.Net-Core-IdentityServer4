using Microsoft.AspNetCore.Identity;

namespace _Net_Core_IdentityServer4.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
