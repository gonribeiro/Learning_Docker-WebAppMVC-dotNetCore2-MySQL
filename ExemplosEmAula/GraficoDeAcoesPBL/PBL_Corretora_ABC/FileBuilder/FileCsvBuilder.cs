using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Corretora_ABC.FileBuilder
{
    [IgnoreFirst(1)]
    [IgnoreEmptyLines()]
    [DelimitedRecord(",")]
    public class FileCsvBuilder
    {
        [FieldTrim(TrimMode.Both)]
        public string Date;
        [FieldTrim(TrimMode.Both)]
        public decimal OpenPrice;
        [FieldTrim(TrimMode.Both)]
        public decimal HighPrice;
        [FieldTrim(TrimMode.Both)]
        public decimal LowPrice;
        [FieldTrim(TrimMode.Both)]
        public decimal ClosePrice;
        [FieldTrim(TrimMode.Both)]
        public decimal AdjClosePrice;
        [FieldTrim(TrimMode.Both)]
        public decimal Volume;
        [FieldHidden]
        public List<string> ErrorList;
    }
}
