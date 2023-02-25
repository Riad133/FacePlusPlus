﻿using System;

 namespace FacePlusPlus.Web.Extentions
{
    public class CredentialAlreadyTakenException : Exception
    {
        public CredentialAlreadyTakenException() : base("phone number/ email already taken")
        {
            
        }
    }
}