using System;

namespace FacePlusPlus.Web.Extentions
{
    public class RequestedToAccessProtectedResourceWithoutSignInException : Exception
    {
        public RequestedToAccessProtectedResourceWithoutSignInException() : base(
            "user tried to access protected resource without signing in")
        {
        }
    }
}