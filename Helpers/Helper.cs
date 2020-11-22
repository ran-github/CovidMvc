using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CovidMvc.Helpers
{
    public class Helper
    {
        public static DateTime GetDateFromInt(int dtValue)
        {
            var dt = DateTime.MinValue;
            try
            {
                dt = DateTime.ParseExact(dtValue.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt.Date;
        }

        public static int GetIntFromDate(DateTime dtValue)
        {
            return int.Parse(dtValue.ToString("yyyyMMdd"));
        }
    }
}
