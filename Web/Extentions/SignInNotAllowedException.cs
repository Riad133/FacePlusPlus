using System;

namespace FacePlusPlus.Web.Extentions
{
    public class SignInNotAllowedException : Exception
    {
        public SignInNotAllowedException(string details) : base("sign in not allowed")
        {
        }
    }
}