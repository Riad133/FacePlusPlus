using System;

namespace FacePlusPlus.Web.Extentions
{
    public class DeviceAccessExpiredException : InvalidOperationException
    {
        public DeviceAccessExpiredException() : base("this device is no longer valid")
        {
            
        }
    }
}