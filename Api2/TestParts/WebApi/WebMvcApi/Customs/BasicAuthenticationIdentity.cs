using System.Security.Principal;

namespace WebMvcApi.Customs
{
    public class BasicAuthenticationIdentity:GenericIdentity
    {
        public string Password { get; set; }
        public BasicAuthenticationIdentity(string name,string password) : base(name, "Basic")
        {
            this.Password = password;
        }
    }
}