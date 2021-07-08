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
using ONIX.ViewModels;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditSaleContractPage.xaml
    /// </summary>
    public partial class EditSaleContractPage : Page
    {
        private readonly ToastViewModel ToastMessage;
        List<SaleContractSpecification> CurrentSpecification = null;
        SaleContract CurrentSaleContract = null;

        public EditSaleContractPage(SaleContract Contract)
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            var OrganizationList = AppData.Context.Organization.Where(c => c.IsDeleted == false).ToList();
            OrganizationList.Insert(0, new Organization
            {
                Name = "Не выбрано"
            });
            OrganizationComboBox.ItemsSource = OrganizationList;
            OrganizationComboBox.SelectedIndex = 0;
            CurrentSaleContract = Contract;
            if (CurrentSaleContract != null)
            {
                this.Title = "Редактирование договора купли-продажи";
                NumberText.Text = CurrentSaleContract.Id.ToString();
                DateInput.SelectedDate = CurrentSaleContract.Date;
                DeliveryAddressInput.Text = CurrentSaleContract.DeliveryAddress;
                OrganizationComboBox.SelectedItem = CurrentSaleContract.Organization as Organization;
                CurrentSpecification = AppData.Context.SaleContractSpecification.Where(c => c.IdSaleContract == CurrentSaleContract.Id).ToList();
                GoodTable.ItemsSource = CurrentSpecification;
                if (CurrentSaleContract.Status.Name == "Завершён")
                {
                    AddButton.Visibility = Visibility.Collapsed;
                    DeleteButton.Visibility = Visibility.Collapsed;
                    SaveButton.Visibility = Visibility.Collapsed;
                    CancelButton.Content = "Назад";
                }
            }
            else
            {
                CurrentSaleContract = new SaleContract()
                {
                    IdEmployee = 1,
                    IdOrganization = 1,
                    IdStatus = 1,
                    Date = DateTime.Today,
                    DeliveryAddress = "UNKNOWN_CONTRACT",
                    IsDeleted = true,
                };
                AppData.Context.SaleContract.Add(CurrentSaleContract);
                AppData.Context.SaveChanges();
                NumberText.Text = CurrentSaleContract.Id.ToString();
                DateInput.SelectedDate = DateTime.Today;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentGood = GoodTable.SelectedItem as SaleContractSpecification;
                if (CurrentGood != null)
                {
                    if (MessageBoxManager.ShowDialog("Вы действительно хотите удалить данный товар из договора?", MessageBoxManager.Buttons.Yes_No, MessageBoxManager.Type.Question) == "1")
                    {
                        AppData.Context.SaleContractSpecification.Remove(CurrentGood);
                        AppData.Context.SaveChanges();
                        ToastMessage.ShowSuccess("Товар успешно удалён из договора!");
                        Page_Loaded(null, null);
                    }
                }
                else
                {
                    throw new Exception("Товар не выбран. Выберите товар и повторите попытку.");
                } 
            } catch(Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IsGoodAdd = true;
            Properties.Settings.Default.IdSaleContract = CurrentSaleContract.Id;
            NavigationService.Navigate(new GoodPage());
        }

        private void AddOrganization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditOrganization(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var OrganizationList = AppData.Context.Organization.Where(c => c.IsDeleted == false).ToList();
            OrganizationList.Insert(0, new Organization
            {
                Name = "Не выбрано"
            });
            OrganizationComboBox.ItemsSource = OrganizationList;
            CurrentSpecification = AppData.Context.SaleContractSpecification.Where(c => c.IdSaleContract == CurrentSaleContract.Id).ToList();
            GoodTable.ItemsSource = CurrentSpecification;
            TotalPriceText.Text = Math.Round(CurrentSaleContract.GetSumWithNDS, 2).ToString();
            TotalNDSText.Text = Math.Round(CurrentSaleContract.GetSumNDS, 2).ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(DeliveryAddressInput.Text))
                {
                    if (DeliveryAddressInput.Text.Length > 5)
                    {
                        if (OrganizationComboBox.SelectedIndex != 0)
                        {
                            CurrentSpecification = AppData.Context.SaleContractSpecification.Where(c => c.IdSaleContract == CurrentSaleContract.Id).ToList();
                            if (CurrentSpecification.Count > 0)
                            {
                                if (Properties.Settings.Default.State == "AddState")
                                {
                                    CurrentSaleContract.Date = DateTime.Now;
                                    CurrentSaleContract.IdEmployee = Properties.Settings.Default.IdEmployee;
                                    CurrentSaleContract.IdStatus = 2;
                                    CurrentSaleContract.IsDeleted = false;
                                }
                                CurrentSaleContract.DeliveryAddress = DeliveryAddressInput.Text;
                                CurrentSaleContract.Organization = OrganizationComboBox.SelectedItem as Organization;
                                AppData.Context.SaveChanges();
                                NavigationService.GoBack();
                                if (Properties.Settings.Default.State == "AddState")
                                {
                                    ToastMessage.ShowSuccess("Договор купли-продажи успешно добавлен!");
                                }
                                else
                                {
                                    ToastMessage.ShowSuccess("Договор купли-продажи успешно изменён!");
                                }
                            }
                            else
                            {
                                throw new Exception("В договор купли-продаже должен быть добавлен минимум 1 товар.");
                            }
                        }
                        else
                        {
                            throw new Exception("Контрагент не выбран.");
                        }
                    }
                    else
                    {
                        throw new Exception("Адрес доставки слишком короткий.");
                    }
                }
                else
                {
                    DeliveryAddressInput.Focus();
                    throw new Exception("Адрес доставки не введён.");
                } 
            } catch(Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void AddOraganizationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditOrganization(null));
        }
    }
}
