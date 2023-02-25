using System;

namespace FacePlusPlus.Web.Extentions
{
    public class AccessRequestedFromUnknownDeviceException : InvalidOperationException
    {
        public AccessRequestedFromUnknownDeviceException() : base("attempted access from unrecognized device")
        {
        }
    }
}