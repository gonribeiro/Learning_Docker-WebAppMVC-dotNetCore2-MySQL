using LiveCharts;
using LiveCharts.Wpf;
using PBL_Corretora_ABC.BLL;
using PBL_Corretora_ABC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PBL_Corretora_ABC.ViewModels
{
    public class LoadChartsCsvViewModel : Prism.Mvvm.BindableBase
    {
        private readonly FileCsvModel dto;
        private readonly FileCsvManager fileCsvManager;
        
        public string LoadFilePath => "C:\\Temp\\MGLU3.SA.csv";
        public ObservableCollection<FileCsvModel> FileCsvs { get; set; }
        public SeriesCollection ChartPriceValues { get; set; }
        public string[] ChartDates { get; set; }
        public Func<double, string> YFormatter { get; set; }

        #region Constructors
        public LoadChartsCsvViewModel()
        {
            dto = new FileCsvModel();
            fileCsvManager = new FileCsvManager();
            FileCsvs = new ObservableCollection<FileCsvModel>();
        }
        #endregion

        public static LoadChartsCsvViewModel LoadViewModel(Action<Task> onLoaded = null)
        {
            LoadChartsCsvViewModel viewModel = new LoadChartsCsvViewModel();

            viewModel.Load().ContinueWith(t => onLoaded?.Invoke(t));

            return viewModel;
        }

        public async Task Load()
        {
            FileCsvs.Clear();

            var importer = new FileCsvManager();
            var fileCsv = importer.ReadFileCsv(LoadFilePath);

            if (fileCsvManager.Add(fileCsv))
            {
                FileCsvs.AddRange(fileCsv);
            }

            var closePrice = fileCsv.Select(a => a.ClosePrice).ToList();
            var dateArray = fileCsv.Select(a => a.Date).ToArray();
            
            await LoadChart(closePrice, dateArray);
        }

        public async Task<bool> LoadChart(List<decimal> closePriceList, string[] dateArray)
        {
            ChartPriceValues = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "ClosePrice",
                    Values = new ChartValues<decimal>(closePriceList),
                    PointGeometry = null
                },
            };

            ChartDates = dateArray;
            YFormatter = value => value.ToString("C");

            return true;
        }
    }
}
