using Microsoft.AspNetCore.Identity;

namespace SistemaCuentas.Identity.Data
{
    public class ApplicationIdentity:IdentityUser
    {
        public string FullName { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
    }
}
