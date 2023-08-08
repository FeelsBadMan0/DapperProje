using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.App
{
    public class app
    {
        public static string ToSafeString(object value)
        {
            return value != null ? value.ToString() : string.Empty;
        }
    }
}