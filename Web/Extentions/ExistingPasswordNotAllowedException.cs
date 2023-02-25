﻿using System;

 namespace FacePlusPlus.Web.Extentions
{
    public class ExistingPasswordNotAllowedException : Exception
    {
        public ExistingPasswordNotAllowedException(): base("New PIN must not be same as any of your last 6 PINs")
        {
            
        }
    }
}