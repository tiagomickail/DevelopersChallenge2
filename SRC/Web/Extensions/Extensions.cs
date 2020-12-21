using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Converter;
using Web.Entities;

namespace Web.Extensions
{
    public static class Extensions
    {
        public static DateTime OfxDateToDateTime(this string date)
        {
            return DateTime.ParseExact(date, "yyyyMMddHHmmss'['zz':EST]'", CultureInfo.InvariantCulture);
        }

        public static OfxFile MemoryStreamToOfxFile(this MemoryStream ms, string fileName = "")
        {
            return OfxConverter.Convert(ms, fileName);
        }

    }
}
