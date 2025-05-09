using JBAPI.API.Features.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAPI.API.Features.Extension
{
    public static class Extensions
    {
        public static bool IsNull<T>(this T value)
        {
            return value == null ? true : false;
        }
    }
}
