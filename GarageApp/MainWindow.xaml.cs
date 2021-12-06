using GarageApp.Data;
using GarageApp.Global;
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
            if (!string.IsNullOrWhiteSpace(loginBox.Text) && !string.IsNullOrWhiteSpace(passBox.Password) && loginBox.Text.Length !<= 30 && passBox.Password.Length !<= 30)
            {
                Users isValid = await ApiConnector.GetUser<object>(nameof(Users), new Users { Password = passBox.Password, Login = loginBox.Text, Id = null });
                if (isValid !=null && isValid.Id !=null)
                {
                    GarageView garageView = new GarageView();
                    GlobalVariables.UserID = isValid.Id.Value;
                    Application.Current.MainWindow = new GarageView();
                   
                    Application.Current.MainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели неверные данные");
                }
            }
            else
                MessageBox.Show("Вы ввели неверные данные");
        }
        private void RegistationManager(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(loginBox.Text) && !string.IsNullOrWhiteSpace(passBox.Password) && loginBox.Text.Length !<= 30 && passBox.Password.Length !<= 30)
                DataSender.PostRequest(nameof(Users), new Users { Password = passBox.Password, Login = loginBox.Text, Id = null });
            else
                MessageBox.Show("Вы ввели неверные данные");
        }
    }
}
