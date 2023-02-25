﻿﻿using System.ComponentModel;

  namespace FacePlusPlus.Application.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<T>(this T e)
        {
            var info = e.GetType().GetField(e.ToString());
            var attributes = (DescriptionAttribute[]) info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // ?? is equivalent to ?: of kotlin 
            return attributes[0]?.Description ?? e.ToString();
        }

       
    }
}