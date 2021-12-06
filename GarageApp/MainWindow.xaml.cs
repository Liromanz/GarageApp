﻿using GarageApp.Data;
using GarageApp.Model;
using GarageApp.View;
using System.Windows;

namespace GarageApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoginManager(object sender, RoutedEventArgs e)
        {
            var isValid = await DataSender.AuthRequest(nameof(Users), new Users { Password = passBox.Password, Login = loginBox.Text, Id = null });
            if (isValid)
            {
                Application.Current.MainWindow = new GarageView();
                Application.Current.MainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вы ввели неверные данные");
            }
        }
        private void RegistationManager(object sender, RoutedEventArgs e)
        {
            DataSender.PostRequest(nameof(Users), new Users { Password = passBox.Password, Login = loginBox.Text, Id = null });
        }
    }
}
