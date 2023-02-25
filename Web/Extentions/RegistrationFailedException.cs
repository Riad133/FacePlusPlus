using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FacePlusPlus.Web.Extentions
{
    public class RegistrationFailedException : Exception
    {
        public List<IdentityError> Details { get; }

        public RegistrationFailedException(List<IdentityError> details) : base(
            "Failed to complete registration. Please contact support")
        {
            Details = details;
        }
    }
}