using System;

namespace FacePlusPlus.Web.Extentions
{
    public class UserIdentityConfirmationUnavailableException : Exception
    {
        public UserIdentityConfirmationUnavailableException() : base( "user does not have any verified medium to confirm identity")
        {
            
        }
    }
}