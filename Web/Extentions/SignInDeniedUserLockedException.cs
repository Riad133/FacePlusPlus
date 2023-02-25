using System;

namespace FacePlusPlus.Web.Extentions
{
    public class SignInDeniedUserLockedException : InvalidOperationException
    {
        public SignInDeniedUserLockedException(DateTimeOffset? userLockoutEnd) : base($"account is locked till {userLockoutEnd?.AddHours(6):h:mm:ss tt zz}")
        {
        }
    }
}