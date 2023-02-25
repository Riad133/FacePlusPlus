using System.Security.Authentication;

namespace FacePlusPlus.Web.Middleware
{
    public class InvalidCredentialsProvidedException : InvalidCredentialException
    {
        public InvalidCredentialsProvidedException() : base("invalid credentials")
        {
            
        }
    }
}