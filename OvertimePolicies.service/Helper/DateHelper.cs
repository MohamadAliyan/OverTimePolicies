using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvertimePolicies.Service.Helper
{
    public static class DateHelper {
        private static readonly PersianCalendar pc = new PersianCalendar();
        public static DateTime ConverToGregorianDate(this string persianDateStr)
    {
        try
        {
            var parts = persianDateStr.Split('/');
            
            return pc.ToDateTime(
                Convert.ToInt32(parts[0]),
                Convert.ToInt32(parts[1]),
                Convert.ToInt32(parts[2]),
                0,  0, 0, 0);
              
        }
        catch
        {
        }

        return DateTime.Now;
    }
}
}
