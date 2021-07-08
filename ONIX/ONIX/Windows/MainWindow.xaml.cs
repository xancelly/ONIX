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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ONIX.Pages;
using MaterialDesignThemes.Wpf;
using ONIX.Windows;
using ONIX.Entities;
using System.Diagnostics;

namespace ONIX
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
            if (Properties.Settings.Default.IdRole == 1)
            {
                OraganizationItem.Visibility = Visibility.Collapsed;
                SaleContractItem.Visibility = Visibility.Collapsed;
                ServiceContractItem.Visibility = Visibility.Collapsed;
            }
            var CurrentEmployee = AppData.Context.Employee.Where(c => c.Id == Properties.Settings.Default.IdEmployee).FirstOrDefault();
            EmployeeNameText.Text = $"{CurrentEmployee.LastName} {CurrentEmployee.FirstName}";
        }

        private void OpenMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CloseMenuButton.Visibility = Visibility.Visible;
            OpenMenuButton.Visibility = Visibility.Collapsed;
        }

        private void CloseMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CloseMenuButton.Visibility = Visibility.Collapsed;
            OpenMenuButton.Visibility = Visibility.Visible;
        }

        private void MenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "HomeItem":
                    if (MenuGrid.Width == 300)
                    {
                        this.HideMenuButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    MainFrame.Navigate(new MainPage());
                    break;
                case "GoodItem":
                    if (MenuGrid.Width == 300)
                    {
                        this.HideMenuButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    MainFrame.Navigate(new GoodPage());
                    break;
                case "ServiceItem":
                    if (MenuGrid.Width == 300)
                    {
                        this.HideMenuButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    MainFrame.Navigate(new ServicePage());
                    break;
                case "OraganizationItem":
                    if (MenuGrid.Width == 300)
                    {
                        this.HideMenuButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    MainFrame.Navigate(new OrganizationPage());
                    break;
                case "SaleContractItem":
                    if (MenuGrid.Width == 300)
                    {
                        this.HideMenuButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    MainFrame.Navigate(new SaleContractPage());
                    break;
                case "ServiceContractItem":
                    if (MenuGrid.Width == 300)
                    {
                        this.HideMenuButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    MainFrame.Navigate(new ServiceContractPage());
                    break;
            }
            int Index = MenuListView.SelectedIndex;
            MenuMoveCursor(Index);
        }

        private void MenuMoveCursor(int Index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            CursorGrid.Margin = new Thickness(0, (155 + (60 * Index)), 0, 0);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void WindowMaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }

        }

        private void WindowMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void HideMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CloseMenuButton.Visibility = Visibility.Collapsed;
            OpenMenuButton.Visibility = Visibility.Visible;
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow NewWindow = new AuthorizationWindow();
            NewWindow.Show();
            this.Close();
            Properties.Settings.Default.State = "";
            Properties.Settings.Default.IdGood = 0;
            Properties.Settings.Default.IdParametr = 0;
            Properties.Settings.Default.IdEmployee = 0;
            Properties.Settings.Default.IdRole = 0;
            Properties.Settings.Default.Count = 0;
            Properties.Settings.Default.IdSaleContract = 0;
            Properties.Settings.Default.IdService = 0;
            Properties.Settings.Default.IdServiceContract = 0;
            Properties.Settings.Default.IsGoodAdd = false;
            Properties.Settings.Default.IsServiceAdd = false;
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("AboutProgram.chm");
        }
    }
}
