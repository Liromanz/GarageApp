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
    /// Логика взаимодействия для UnitWindow.xaml
    /// </summary>
    public partial class UnitWindow : Window
    {
        public Units untData { get; set; }
        public UnitWindow()
        {
            InitializeComponent();
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            var message = Validation();
            if (message != "")
            {
                MessageBox.Show(message);
                return;
            }

            untData = new Units
            {
                Width = Convert.ToInt32(widthBox.Text),
                Height = Convert.ToInt32(heightBox.Text),
                Lenght = Convert.ToInt32(lenghtBox.Text)
            };
            
            DialogResult = true;
            Close();
        }
        private string Validation()
        {
            if (widthBox.Text == "" || heightBox.Text == "" || lenghtBox.Text == "")
                return "Не все поля заполнены";
            if (!Double.TryParse(widthBox.Text, out _) || !Double.TryParse(heightBox.Text, out _) || !Double.TryParse(lenghtBox.Text, out _))
                return  "Не все поля являются числами";
            return "";
        }
    }
}
