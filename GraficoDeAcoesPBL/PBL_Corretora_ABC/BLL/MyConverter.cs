using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Corretora_ABC.BLL
{
    public class MyConverter : DecimalConverter
    {
        CultureInfo ci;
        public MyConverter()
        {
            ci = new CultureInfo(CultureInfo.CurrentCulture.LCID);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.NumberGroupSeparator = ",";
        }

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                    return null;
                return Convert.ToDecimal(text, ci);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
