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
    /// Логика взаимодействия для EditServiceContractPage.xaml
    /// </summary>
    public partial class EditServiceContractPage : Page
    {
        private readonly ToastViewModel ToastMessage;
        List<ServiceContractSpecification> CurrentSpecification = null;
        ServiceContract CurrentServiceContract = null;
        public EditServiceContractPage(ServiceContract Contract)
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
            CurrentServiceContract = Contract;
            if (CurrentServiceContract != null)
            {
                this.Title = "Редактирование договора на обслуживание";
                NumberText.Text = CurrentServiceContract.Id.ToString();
                DateInput.SelectedDate = CurrentServiceContract.Date;
                ServiceAddressInput.Text = CurrentServiceContract.ServiceAddress;
                DateFromInput.SelectedDate = CurrentServiceContract.DateStart;
                DateToInput.SelectedDate = CurrentServiceContract.DateEnd;
                OrganizationComboBox.SelectedItem = CurrentServiceContract.Organization as Organization;
                CurrentSpecification = AppData.Context.ServiceContractSpecification.Where(c => c.IdServiceContract == CurrentServiceContract.Id).ToList();
                ServiceTable.ItemsSource = CurrentSpecification;
            }
            else
            {
                CurrentServiceContract = new ServiceContract()
                {
                    IdEmployee = 1,
                    IdOrganization = 1,
                    DateStart = DateTime.Today,
                    DateEnd = DateTime.Today,
                    Date = DateTime.Today,
                    ServiceAddress = "UNKNOWN_CONTRACT",
                    IsDeleted = true,
                };
                AppData.Context.ServiceContract.Add(CurrentServiceContract);
                AppData.Context.SaveChanges();
                NumberText.Text = CurrentServiceContract.Id.ToString();
                DateInput.SelectedDate = DateTime.Today;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentService = ServiceTable.SelectedItem as ServiceContractSpecification;
                if (CurrentService != null)
                {
                    if (MessageBoxManager.ShowDialog("Вы действительно хотите удалить данную услугу из договора?", MessageBoxManager.Buttons.Yes_No, MessageBoxManager.Type.Question) == "1")
                    {
                        AppData.Context.ServiceContractSpecification.Remove(CurrentService);
                        AppData.Context.SaveChanges();
                        ToastMessage.ShowSuccess("Услуга успешно удалена из договора!");
                        Page_Loaded(null, null);
                    }
                }
                else
                {
                    throw new Exception("Услуга не выбрана. Выберите услугу и повторите попытку.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IsServiceAdd = true;
            Properties.Settings.Default.IdServiceContract = CurrentServiceContract.Id;
            NavigationService.Navigate(new ServicePage());
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
            CurrentSpecification = AppData.Context.ServiceContractSpecification.Where(c => c.IdServiceContract == CurrentServiceContract.Id).ToList();
            ServiceTable.ItemsSource = CurrentSpecification;
            TotalPriceText.Text = Math.Round(CurrentServiceContract.GetSumWithNDS, 2).ToString();
            TotalNDSText.Text = Math.Round(CurrentServiceContract.GetSumNDS, 2).ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(ServiceAddressInput.Text))
                {
                    if (ServiceAddressInput.Text.Length > 5)
                    {
                        if (DateFromInput.SelectedDate != null)
                        {
                            if (DateToInput.SelectedDate != null)
                            {
                                if (DateFromInput.SelectedDate < DateToInput.SelectedDate)
                                {
                                    if (OrganizationComboBox.SelectedIndex != 0)
                                    {
                                        CurrentSpecification = AppData.Context.ServiceContractSpecification.Where(c => c.IdServiceContract == CurrentServiceContract.Id).ToList();
                                        if (CurrentSpecification.Count > 0)
                                        {
                                            if (Properties.Settings.Default.State == "AddState")
                                            {
                                                CurrentServiceContract.Date = DateTime.Now;
                                                CurrentServiceContract.IdEmployee = Properties.Settings.Default.IdEmployee;
                                                CurrentServiceContract.IsDeleted = false;
                                            }
                                            CurrentServiceContract.ServiceAddress = ServiceAddressInput.Text;
                                            CurrentServiceContract.Organization = OrganizationComboBox.SelectedItem as Organization;
                                            CurrentServiceContract.DateStart = Convert.ToDateTime(DateFromInput.SelectedDate);
                                            CurrentServiceContract.DateEnd = Convert.ToDateTime(DateToInput.SelectedDate);
                                            AppData.Context.SaveChanges();
                                            NavigationService.GoBack();
                                            if (Properties.Settings.Default.State == "AddState")
                                            {
                                                ToastMessage.ShowSuccess("Договор на обслуживание успешно добавлен!");
                                            }
                                            else
                                            {
                                                ToastMessage.ShowSuccess("Договор на обслуживание успешно изменён!");
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception("В договор на обслуживание должена быть добавлена минимум 1 услуга.");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Контрагент не выбран.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("Дата начала оказания услуг не может быть позже даты окончания оказания услуг.");
                                }
                            }
                            else
                            {
                                DateToInput.Focus();
                                throw new Exception("Дата оканчания оказания услуг не введена.");
                            }
                        }
                        else
                        {
                            DateFromInput.Focus();
                            throw new Exception("Дата начала оказания услуг не введена.");
                        }
                    }
                    else
                    {
                        throw new Exception("Адрес оказания услуг слишком короткий.");
                    }
                }
                else
                {
                    ServiceAddressInput.Focus();
                    throw new Exception("Адрес оказания услуг не введён.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void AddOrganizationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditOrganization(null));
        }
    }
}
