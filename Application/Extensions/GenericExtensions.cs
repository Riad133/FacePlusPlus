using System;

#nullable enable
namespace FacePlusPlus.Application.Extensions
{
    public static class GenericExtensions
    {
        public static bool HasNoValue(this object? item)
        {
            if (item == null || item == default)
            {
                if (item is string s) return string.IsNullOrEmpty(s);
                if (item is Guid) return Equals(item, Guid.Empty);
                if (item is DateTime time) return time == new DateTime();
                return true;
            }

            return false;
        }

        public static bool HasValue(this object? item)
        {
            if (item != null && item != default)
            {
                if (item is string s) return !string.IsNullOrEmpty(s);
                if (item is Guid) return !Equals(item, Guid.Empty);
                if (item is DateTime time) return time > new DateTime();
                return true;
            }

            return false;
        }
    }
}