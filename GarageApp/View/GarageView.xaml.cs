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
using System.IO;
using GarageApp.Global;
using GarageApp.Data;
using System.Collections.ObjectModel;

namespace GarageApp.View
{
    /// <summary>
    /// Логика взаимодействия для GarageView.xaml
    /// </summary>
    public partial class GarageView : Window
    {
        private ObservableCollection<Units> _garageProperty { get; set; }
        private int _lastSelectedItemIndex { get; set; }
        public GarageView()
        {
            InitializeComponent();
            RefreshList();
            _lastSelectedItemIndex = -1;
        }

        private async void RefreshList()
        {
            _garageProperty = await ApiConnector.GetAll<Units>("Units");
            _garageProperty = new ObservableCollection<Units>(_garageProperty.Where(x => x.UserID == GlobalVariables.UserID));
            for (int i = 0; i < helixViewPort.Items.Count; i++)
                helixViewPort.Items.RemoveAt(i);
            garageListVIew.Items.Clear();
            var propertys = SceneCalculate();
            for (int i = 0; i < _garageProperty.Count; i++)
            {
                garageListVIew.Items.Add(_garageProperty[i].GetName());
                helixViewPort.Items.Add(UnitsController.CreateNewBox(_garageProperty[i].Width, _garageProperty[i].Height, _garageProperty[i].Length, propertys[i].startX, propertys[i].startY, _garageProperty[i].Height / 2));
            }

        }

        private void ReturnToLogin(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        private async void AddUnit(object sender, RoutedEventArgs e)
        {
            var unitWindow = new UnitWindow();
            var result = unitWindow.ShowDialog();
            if (result != null && result == true)
            {
                await DataSender.PostRequest(nameof(Units), unitWindow.untData);
                RefreshList();
            }
        }

        private async void EditUnit(object sender, RoutedEventArgs e)
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
                    await DataSender.DeleteRequest(nameof(Units), _garageProperty[garageListVIew.SelectedIndex].Id.Value);
                    await DataSender.PostRequest(nameof(Units), unitWindow.untData);
                    RefreshList();
                    garageListVIew.SelectedIndex = garageListVIew.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("Не выбран ни один элемент");
                return;
            };
        }

        private async void DeleteUnit(object sender, RoutedEventArgs e)
        {
            if (garageListVIew.SelectedIndex != -1)
            {
                var messageBox = MessageBox.Show("Вы точно хотите удалить выбранный юнит?", "Удаление", MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    await DataSender.DeleteRequest(nameof(Units), _garageProperty[garageListVIew.SelectedIndex].Id.Value);
                    helixViewPort.Items.RemoveAt(garageListVIew.SelectedIndex);
                    RefreshList();
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
            if (garageListVIew.SelectedIndex != -1)
            {
                var unitWindow = new UnitWindow();
                unitWindow.widthBox.Text = _garageProperty[garageListVIew.SelectedIndex].Width.ToString();
                unitWindow.lenghtBox.Text = _garageProperty[garageListVIew.SelectedIndex].Length.ToString();
                unitWindow.heightBox.Text = _garageProperty[garageListVIew.SelectedIndex].Height.ToString();
                var result = unitWindow.ShowDialog();
                if (result != null && result == true)
                {
                    _garageProperty[garageListVIew.SelectedIndex] = unitWindow.untData;
                    garagePlace.Width = unitWindow.untData.Width;
                    garagePlace.Length = unitWindow.untData.Length;
                }

            }
            else
            {
                MessageBox.Show("Не выбран ни один элемент");
                return;
            };
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

        private void ExportUnits(object sender, RoutedEventArgs e)
        {
            using (var tw = File.CreateText(@"C:\Users\User\Desktop\output.txt"))
            {
                for (int i = 0; i < helixViewPort.Items.Count; i++)
                {
                    var transform = ((BoxVisual3D)helixViewPort.Items[i]).GetTransform();
                    tw.WriteLine($"{transform.OffsetX}, {transform.OffsetY}, {transform.OffsetZ}, {transform.OffsetX + ((BoxVisual3D)helixViewPort.Items[i]).Width}, {transform.OffsetY + ((BoxVisual3D)helixViewPort.Items[i]).Height}, {transform.OffsetZ + ((BoxVisual3D)helixViewPort.Items[i]).Length}");
                }
            }
            using (var tw = File.CreateText(@"C:\Users\User\Desktop\outputsize.txt"))
            {
                for (int i = 0; i < helixViewPort.Items.Count; i++)
                {
                    var transform = ((BoxVisual3D)helixViewPort.Items[i]).GetTransform();
                    tw.WriteLine($"{((BoxVisual3D)helixViewPort.Items[i]).Width}, {((BoxVisual3D)helixViewPort.Items[i]).Height}, {((BoxVisual3D)helixViewPort.Items[i]).Length}");
                }
            }
               
        }

        private CalculateUnit[] SceneCalculate()
        {

            CalculateUnit[] units = new CalculateUnit[_garageProperty.Count];
            for (int i = 0;i < _garageProperty.Count; i++)
            {
                CalculateUnit unit = new CalculateUnit();
                unit.id = i+1;
                unit.width = (int)Math.Round(_garageProperty[i].Width);
                unit.height = (int)Math.Round(_garageProperty[i].Height);
                units[i] = unit;
            }

            int[,] comnate = new int[(int)Math.Round(garagePlace.Width), (int)Math.Round(garagePlace.Length)];

            if (units.Length > 1)
                for (int x = 0; x < units.Length; x++)
                {
                    if (x == 0)
                    {
                        units[x].startX = units[x].startX = 0;
                        units[x].startY = units[x].startY = 0;
                    }
                    else
                    {
                        units[x].startY = units[x - 1].endY;
                        units[x].startX = 0;
                    }

                }

            var maxUnitX = 0;
            var maxUnitY = 0;
            var maxEndPointX = 0;

            foreach (var unit in units)
            {
                maxEndPointX = maxEndPointX < unit.endX ? unit.endX : maxEndPointX;
                maxUnitX += unit.height;
                maxUnitY += unit.width;
            }

            var id = units.Length - 1;

            while ((int)Math.Round(garagePlace.Width) < maxUnitY)
            {
                maxUnitY -= units[id].width;
                units[id].startY = 0;
                units[id].startX = maxEndPointX;
                --id;
            }

            return units;
        }
    }
}
