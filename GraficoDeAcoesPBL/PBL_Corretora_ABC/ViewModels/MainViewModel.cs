using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Corretora_ABC.ViewModels
{
    public class MainViewModel
    {
        public LoadChartsCsvViewModel LoadChartsCsvViewModel { get; set; }

        public MainViewModel()
        {
            LoadChartsCsvViewModel = LoadChartsCsvViewModel.LoadViewModel();
        }
    }
}
