using CsvHelper;
using CsvHelper.TypeConversion;
using PBL_Corretora_ABC.FileBuilder;
using PBL_Corretora_ABC.Models;
using PBL_Corretora_ABC.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
namespace PBL_Corretora_ABC.BLL
{
    public class FileCsvManager
    {
        private readonly FileCsvRepository fileCsvRepository;
        private readonly ITypeConverter _csvDecimalConverter;
        public FileCsvManager()
        {
            fileCsvRepository = new FileCsvRepository();
            _csvDecimalConverter = new MyConverter();
        }

        public bool Add(List<FileCsvModel> fileCsvList)
        {
            fileCsvRepository.Add(fileCsvList);
            return true;
        }

        public bool RemoveAll()
        {
            var fileCsv = fileCsvRepository.SearchAll();
            if (fileCsv != null)
            {
                fileCsvRepository.RemoveAll(fileCsv);
                return true;
            }
            return false;
        }

        public List<FileCsvModel> ReadFileCsv(string filePath)
        {
            var list = new List<FileCsvBuilder>();
            var result = new List<FileCsvModel>();

            using (var csv = new CsvReader(System.IO.File.OpenText(filePath)))
            {
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                    list.Add(convertToCsvHelperDto(csv));
            }

            return list.ToList().ConvertAll(a => ItemToFileHelperDto(a));
        }
        public FileCsvBuilder convertToCsvHelperDto(CsvReader csv)
        {
            var result = new FileCsvBuilder();

            var date = ReadString(ref result.Date, result, csv, "Date", true);
            var openPrice = ReadDecimal(ref result.OpenPrice, result, csv, "Open", true);
            var highPrice = ReadDecimal(ref result.HighPrice, result, csv, "High", true);
            var lowPrice = ReadDecimal(ref result.LowPrice, result, csv, "Low", true);
            var closePrice = ReadDecimal(ref result.ClosePrice, result, csv, "Close", true);
            var adjClosePrice = ReadDecimal(ref result.AdjClosePrice, result, csv, "Adj Close", true);
            var volume = ReadDecimal(ref result.Volume, result, csv, "Volume", true);

            return result;
        }

        private string ReadString(ref string result, FileCsvBuilder row, CsvReader csv, string columnName, bool isMandatoryColumn = true, bool isMandatoryValue = false)
        {
            if (!csv.TryGetField<string>(columnName, out result))
            {
                CheckForColumnAndAddError(row, csv, "text", columnName, isMandatoryColumn, isMandatoryValue);
                result = string.Empty;
                return result;
            }

            return result;
        }

        private decimal ReadDecimal(ref decimal result, FileCsvBuilder row, CsvReader csv, string columnName, bool isMandatoryColumn = true, bool isMandatoryValue = false)
        {
            if (!csv.TryGetField<decimal>(columnName, _csvDecimalConverter, out decimal value))
            {
                CheckForColumnAndAddError(row, csv, "number", columnName, isMandatoryColumn, isMandatoryValue);
                result = 0m;
                return result;
            }

            result = value;
            return value;
        }

        private void CheckForColumnAndAddError(FileCsvBuilder row, CsvReader csv, string columnType, string columnName, bool isMandatoryColumn, bool isMandatoryValue)
        {
            if (!isMandatoryColumn && !isMandatoryValue)
                return;

            if (!csv.Context.HeaderRecord.Contains(columnName))
            {
                if (isMandatoryColumn || isMandatoryValue)
                    AddError(row, $"Mandatory {columnType} column '{columnName}' missing");
            }
            else
            {
                if (isMandatoryValue)
                    AddError(row, $"Mandatory {columnType} filed '{columnName}' not set");
            }
        }

        private void AddError(FileCsvBuilder item, string errorMsg)
        {
            if (string.IsNullOrWhiteSpace(errorMsg))
                return;
            if (item.ErrorList == null)
                item.ErrorList = new List<string>();
            if (!item.ErrorList.Any(a => a.Equals(errorMsg)))
                item.ErrorList.Add(errorMsg);
        }


        #region Converter
        public FileCsvModel ItemToFileHelperDto(FileCsvBuilder item)
        {
            return new FileCsvModel()
            {
                Date = item.Date,
                OpenPrice = item.OpenPrice,
                HighPrice = item.HighPrice,
                LowPrice = item.LowPrice,
                ClosePrice = item.ClosePrice,
                AdjClosePrice = item.AdjClosePrice,
                Volume = item.Volume,
            };
        }
        #endregion
    }
}
