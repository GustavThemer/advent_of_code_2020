using System;

namespace Infrastructure.Extensions
{
    public static class ObjectExtension
    {
        public static TEnum ParseEnum<TEnum>(this object value) where TEnum : Enum
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value as string ?? string.Empty, true);
        }
    }
}