using Microsoft.AspNetCore.Identity;

namespace Fundzo.Api.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
    }
}