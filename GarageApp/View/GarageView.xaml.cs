using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GarageApp.Controllers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace GarageApp.View
{
    /// <summary>
    /// Логика взаимодействия для GarageView.xaml
    /// </summary>
    public partial class GarageView : Window
    {
        public GarageView()
        {
            InitializeComponent();
        }
       

        private void ReturnToLogin(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        private void AddUnit(object sender, RoutedEventArgs e)
        {
            var unitWindow = new UnitWindow();
            var result = unitWindow.ShowDialog();
            if (result != null && result == true)
            {
                helixViewPort.Items.Add(UnitsController.CreateNewBox(unitWindow.untData.Width, unitWindow.untData.Height, unitWindow.untData.Lenght, -20, -20, -20)); //todo: вместо -20 данные пахомуса
            }
        }

        private void EditUnit(object sender, RoutedEventArgs e)
        {
            var unitWindow = new UnitWindow();
            unitWindow.widthBox.Text = 111.ToString();
            unitWindow.lenghtBox.Text = 222.ToString();
            unitWindow.heightBox.Text = 333.ToString();
            unitWindow.ShowDialog();
        }

        private void DeleteUnit(object sender, RoutedEventArgs e)
        {
            var messageBox =  MessageBox.Show("Вы точно хотите удалить выбранный юнит?", "Удаление",  MessageBoxButton.YesNo);
            if (messageBox == MessageBoxResult.Yes)
            {
               var a = GarageApp.Controllers.UnitsController.CreateNewBox(1,1,1,1,1,1);
            }
        }
    }
}
