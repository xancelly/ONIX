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
using ONIX.Entities;
using ONIX.Pages;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using ONIX.ViewModels;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrganizationPage.xaml
    /// </summary>
    public partial class OrganizationPage : Page
    {
        private readonly ToastViewModel ToastMessage;
        public OrganizationPage()
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();

            if (Properties.Settings.Default.IdRole == 1)
            {
                AddButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }
        }

        public void UpdateData(string Search)
        {
            var OrganizationList = AppData.Context.Organization.Where(c => c.IsDeleted == false).ToList();
            int TotalCount = OrganizationList.Count;

            if (!String.IsNullOrWhiteSpace(Search) && !String.IsNullOrEmpty(Search))
            {
                OrganizationList = OrganizationList.Where(c => c.Name.ToLower().Contains(Search.ToLower()) || c.ContactPerson.ToLower().Contains(Search.ToLower()) || c.PhoneNumber.ToLower().Contains(Search.ToLower()) || c.Email.ToLower().Contains(Search.ToLower()) || c.PhysicalAddress.ToLower().Contains(Search.ToLower()) || c.BusinessAddress.ToLower().Contains(Search.ToLower())).ToList();
            }

            int ViewCount = OrganizationList.Count;
            RecordsCountText.Text = $"{ViewCount} из {TotalCount}";
            OrganizationTable.ItemsSource = OrganizationList;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateData(SearchTextBox.Text);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text);
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditOrganization(null));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Organization CurrentOrganization = OrganizationTable.SelectedItem as Organization;
                if (CurrentOrganization != null)
                {
                    NavigationService.Navigate(new EditOrganization(CurrentOrganization));
                }
                else
                {
                    throw new Exception("Контрагент не выбран. Выберите контрагента и повторите попытку.");
                }
            } catch(Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Organization CurrentOrganization = OrganizationTable.SelectedItem as Organization;
                if (CurrentOrganization != null)
                {
                    if (MessageBoxManager.ShowDialog("Вы действительно хотите удалить данного контрагента?", MessageBoxManager.Buttons.Yes_No, MessageBoxManager.Type.Question) == "1")
                    {
                        CurrentOrganization.IsDeleted = true;
                        AppData.Context.SaveChanges();
                        ToastMessage.ShowSuccess("Контрагент успешно удалён из списка!");
                        UpdateData(SearchTextBox.Text);
                    }
                }
                else
                {
                    throw new Exception("Контрагент не выбран. Выберите контрагента и повторите попытку.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }
    }
}
