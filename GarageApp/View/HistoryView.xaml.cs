using GarageApp.Data;
using GarageApp.Global;
using GarageApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GarageApp.View
{
    /// <summary>
    /// Логика взаимодействия для HistoryView.xaml
    /// </summary>
    public partial class HistoryView : Window
    {
        List<History> history = new List<History>();
        public HistoryView()
        {
            InitializeComponent();
            Init();
        }

        private async void Init()
        {
            var list = await ApiConnector.GetAll<History>("Histories");
            history = list.Where(x => x.IdUser == GlobalVariables.UserID).ToList();

            foreach(var history in history)
            {
                HistoryList.Items.Add($"{history.IdUser} + {history.datePass}");
            }
        }
    }
}
