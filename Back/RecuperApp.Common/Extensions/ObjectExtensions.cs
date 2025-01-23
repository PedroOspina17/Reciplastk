using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecuperApp.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
