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
using GarageApp.Model;
using GarageApp.Data;

namespace GarageApp.View
{
    /// <summary>
    /// Логика взаимодействия для GarageView.xaml
    /// </summary>
    public partial class GarageView : Window
    {
        private Units _garageProperty { get; set; }
        private int _lastSelectedItemIndex { get; set; }
        public GarageView()
        {
            InitializeComponent();
            _garageProperty = new Units
            {
                Width = 500,
                Height = 300,
                Lenght = 300
            };
            _lastSelectedItemIndex = -1;
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
                garageListVIew.Items.Add(unitWindow.untData.GetName());
                helixViewPort.Items.Add(UnitsController.CreateNewBox(unitWindow.untData.Width, unitWindow.untData.Height, unitWindow.untData.Lenght, -20, -20, -20)); //todo: вместо -20 данные пахомуса
            }
        }

        private void EditUnit(object sender, RoutedEventArgs e)
        {
            if (garageListVIew.SelectedIndex != -1)
            {
                var unitWindow = new UnitWindow();
                unitWindow.widthBox.Text = ((BoxVisual3D)helixViewPort.Items[garageListVIew.SelectedIndex]).Width.ToString();
                unitWindow.lenghtBox.Text = ((BoxVisual3D)helixViewPort.Items[garageListVIew.SelectedIndex]).Length.ToString();
                unitWindow.heightBox.Text = ((BoxVisual3D)helixViewPort.Items[garageListVIew.SelectedIndex]).Height.ToString();
                var result = unitWindow.ShowDialog();
                if (result != null && result == true)
                {
                    helixViewPort.Items.RemoveAt(garageListVIew.SelectedIndex);
                    garageListVIew.Items.RemoveAt(garageListVIew.SelectedIndex);
                    helixViewPort.Items.Add(UnitsController.CreateNewBox(unitWindow.untData.Width, unitWindow.untData.Height, unitWindow.untData.Lenght, -20, -20, -20)); //todo: вместо -20 данные пахомуса
                    garageListVIew.Items.Add(unitWindow.untData.GetName());
                    garageListVIew.SelectedIndex = garageListVIew.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("Не выбран ни один элемент");
                return;
            };
        }

        private void DeleteUnit(object sender, RoutedEventArgs e)
        {
            if (garageListVIew.SelectedIndex != -1)
            {
                var messageBox = MessageBox.Show("Вы точно хотите удалить выбранный юнит?", "Удаление", MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    helixViewPort.Items.RemoveAt(garageListVIew.SelectedIndex);
                    garageListVIew.Items.RemoveAt(garageListVIew.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Не выбран ни один элемент");
                return;
            };
        }

        private void EditGarage(object sender, RoutedEventArgs e)
        {
            var unitWindow = new UnitWindow();
            unitWindow.widthBox.Text = _garageProperty.Width.ToString();
            unitWindow.lenghtBox.Text = _garageProperty.Lenght.ToString();
            unitWindow.heightBox.Text = _garageProperty.Height.ToString();
            var result = unitWindow.ShowDialog();
            if (result != null && result == true)
            {
                _garageProperty = unitWindow.untData;
                garagePlace.Width = unitWindow.untData.Width;
                garagePlace.Length = unitWindow.untData.Lenght;
            }
        }

        private void ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (garageListVIew.SelectedIndex != -1)
            {
                if (_lastSelectedItemIndex != -1)
                    ((BoxVisual3D)helixViewPort.Items[_lastSelectedItemIndex]).Fill = new BrushConverter().ConvertFromString("#FFD0D0D0") as Brush;
                ((BoxVisual3D)helixViewPort.Items[garageListVIew.SelectedIndex]).Fill = new BrushConverter().ConvertFromString("#FFF74D44") as Brush;
            }
            _lastSelectedItemIndex = garageListVIew.SelectedIndex;

        }
    }
}
