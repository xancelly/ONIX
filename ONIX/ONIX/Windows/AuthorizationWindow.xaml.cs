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
using ONIX.ViewModels;
using ONIX.Entities;
using System.Security.Cryptography;

namespace ONIX.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private readonly ToastViewModel ToastMessage;
        public AuthorizationWindow()
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(LoginInput.Text))
                {
                    if (!String.IsNullOrWhiteSpace(PasswordInput.Password))
                    {
                        string Password = GetHash(PasswordInput.Password);
                        var CurrentEmployee = AppData.Context.Employee.Where(c => c.Login == LoginInput.Text && c.Password == Password && c.IsDeleted == false).FirstOrDefault();
                        if (CurrentEmployee != null)
                        {
                            Properties.Settings.Default.IdEmployee = CurrentEmployee.Id;
                            Properties.Settings.Default.IdRole = CurrentEmployee.Role.Id;
                            MainWindow NewPage = new MainWindow();
                            NewPage.Show();
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Пользователя с такими данными не существует.");
                        }
                    }
                    else
                    {
                        PasswordInput.Focus();
                        throw new Exception("Пароль не введён.");
                    }
                }
                else
                {
                    LoginInput.Focus();
                    throw new Exception("Логин не введён.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
