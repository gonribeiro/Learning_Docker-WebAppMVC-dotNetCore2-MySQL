using PBL_Corretora_ABC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Corretora_ABC.Repository
{
    public class FileCsvRepository
    {
        private static List<FileCsvModel> fileCsvs = new List<FileCsvModel>();

        internal void Add(List<FileCsvModel> fileCsvList)
        {
            fileCsvs.AddRange(fileCsvList);
        }

        internal void Remove(FileCsvModel fileCsv)
        {
            fileCsvs.Remove(fileCsv);
        }

        internal void RemoveAll(List<FileCsvModel> fileCsv)
        {
            fileCsvs = new List<FileCsvModel>();
        }

        internal List<FileCsvModel> SearchAll()
        {
            return fileCsvs;
        }

    }
}
