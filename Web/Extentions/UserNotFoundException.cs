using System;

namespace FacePlusPlus.Web.Extentions
{
    public class UserNotFoundException : InvalidOperationException
    {
        public UserNotFoundException(string username) : base($"account {username} not found")
        {
        }
    }
}