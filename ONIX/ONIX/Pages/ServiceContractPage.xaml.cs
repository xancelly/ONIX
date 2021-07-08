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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using Word = Microsoft.Office.Interop.Word;
using ONIX.Entities;
using System.IO;
using Microsoft.Win32;
using ONIX.ViewModels;
using System.Windows.Controls.Primitives;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceContractPage.xaml
    /// </summary>
    public partial class ServiceContractPage : Page
    {
        List<ServiceContract> ServiceContractList = null;
        private readonly ToastViewModel ToastMessage;
        public ServiceContractPage()
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            ServiceContractList = AppData.Context.ServiceContract.Where(c => c.IsDeleted == false).ToList();

            var OrganizationList = AppData.Context.Organization.ToList();
            OrganizationList.Insert(0, new Organization
            {
                Name = "Не важно"
            });
            OrganizationComboBox.ItemsSource = OrganizationList;
            OrganizationComboBox.SelectedIndex = 0;
            PriceFromInput.Text = "0";
            int MaxPrice = 0;
            foreach (var item in ServiceContractList)
                if (item.GetSumWithNDS > MaxPrice)
                    MaxPrice = Convert.ToInt32(item.GetSumWithNDS);
            PriceToInput.Text = MaxPrice.ToString();

            if (Properties.Settings.Default.IdRole == 1)
            {
                AddButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
                PrintDocumentButton.Visibility = Visibility.Collapsed;
            }
        }

        public void UpdateData(string Search, string OrganizationContract, string PriceFrom, string PriceTo, DateTime DateFrom, DateTime DateTo)
        {
            ServiceContractList = AppData.Context.ServiceContract.Where(c => c.IsDeleted == false).ToList();
            int TotalCount = ServiceContractList.Count;

            if (!String.IsNullOrWhiteSpace(Search) && !String.IsNullOrEmpty(Search))
            {
                ServiceContractList = ServiceContractList.Where(c => c.Organization.GetName.ToLower().Contains(Search.ToLower())).ToList();
            }

            if (OrganizationComboBox.SelectedIndex != 0)
            {
                ServiceContractList = ServiceContractList.Where(c => c.Organization.Name == OrganizationContract).ToList();
            }

            if (!String.IsNullOrEmpty(PriceFrom) && !String.IsNullOrWhiteSpace(PriceFrom) && !String.IsNullOrEmpty(PriceTo) && !String.IsNullOrWhiteSpace(PriceTo))
            {
                decimal From = Convert.ToDecimal(PriceFrom);
                decimal To = Convert.ToDecimal(PriceTo);
                ServiceContractList = ServiceContractList.Where(c => c.GetSumWithNDS >= From && c.GetSumWithNDS <= To).ToList();
            }

            if (DateFrom != null && DateTo != null)
            {
                if (DateFrom < DateTo)
                {
                    ServiceContractList = ServiceContractList.Where(c => c.Date >= DateFrom && c.Date <= DateTo).ToList();
                }
            }
            int ViewCount = ServiceContractList.Count;
            RecordsCountText.Text = $"{ViewCount} из {TotalCount}";
            ServiceContractTable.ItemsSource = ServiceContractList;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int MaxPrice = 0;
            foreach (var item in ServiceContractList)
                if (item.GetSumWithNDS > MaxPrice)
                    MaxPrice = Convert.ToInt32(item.GetSumWithNDS);
            PriceToInput.Text = MaxPrice.ToString();
            UpdateData(SearchTextBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void OrganizationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, (OrganizationComboBox.SelectedItem as Organization).Name, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void PriceFromInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void PriceToInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void PriceFromInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void PriceToInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
            OrganizationComboBox.SelectedIndex = 0;
            PriceFromInput.Text = "0";
            int MaxPrice = 0;
            foreach (var item in AppData.Context.SaleContract.Where(c => c.IsDeleted == false))
                if (item.GetSumWithNDS > MaxPrice)
                    MaxPrice = Convert.ToInt32(item.GetSumWithNDS);
            PriceToInput.Text = MaxPrice.ToString();
            DateFromInput.SelectedDate = null;
            DateToInput.SelectedDate = null;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceContract CurrentServiceContract = ServiceContractTable.SelectedItem as ServiceContract;
                if (CurrentServiceContract != null)
                {
                    if (MessageBoxManager.ShowDialog("Вы действительно хотите удалить данный договор на обслуживание?", MessageBoxManager.Buttons.Yes_No, MessageBoxManager.Type.Question) == "1")
                    {
                        CurrentServiceContract.IsDeleted = true;
                        AppData.Context.SaveChanges();
                        ToastMessage.ShowSuccess("Договор на обслуживание успешно удалён из списка!");
                        Page_Loaded(null, null);
                    }
                }
                else
                {
                    throw new Exception("Договор на обслуживание не выбран. Выберите договор на обслуживание и повторите попытку.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceContract CurrentServiceContract = ServiceContractTable.SelectedItem as ServiceContract;
                if (CurrentServiceContract != null)
                {
                    NavigationService.Navigate(new EditServiceContractPage(CurrentServiceContract));
                }
                else
                {
                    throw new Exception("Договор на обслуживание не выбран. Выберите договор на обслуживание и повторите попытку.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.State = "AddState";
            NavigationService.Navigate(new EditServiceContractPage(null));
        }

        private void OpenFilterButton_Click(object sender, RoutedEventArgs e)
        {
            CloseFilterButton.Visibility = Visibility.Visible;
            OpenFilterButton.Visibility = Visibility.Collapsed;
            FilterFields.Visibility = Visibility.Visible;
        }

        private void CloseFilterButton_Click(object sender, RoutedEventArgs e)
        {
            CloseFilterButton.Visibility = Visibility.Collapsed;
            OpenFilterButton.Visibility = Visibility.Visible;
            FilterFields.Visibility = Visibility.Collapsed;
        }

        private void DateFromInput_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void DateToInput_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void PrintDocument_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Word.Document wDoc = null;
                ServiceContract CurrentServiceContract = ServiceContractTable.SelectedItem as ServiceContract;
                if (CurrentServiceContract != null)
                {

                    Word.Application wApp = new Word.Application();

                    string src = "";
                    src = $@"{Directory.GetCurrentDirectory().ToString()}\servicecontract.docx";

                    wDoc = wApp.Documents.Add(src);
                    wDoc.Activate();
                    Word.Bookmarks wMarks = wDoc.Bookmarks;

                    wMarks["Number"].Range.Text = $"{CurrentServiceContract.Id}";
                    wMarks["Date"].Range.Text = $"{RuDateAndMoneyConverter.DateToTextLong(CurrentServiceContract.Date, "г.")}";
                    wMarks["OrganizationName"].Range.Text = $"{CurrentServiceContract.Organization.TypeOrganization.FullName} «{CurrentServiceContract.Organization.Name}»";
                    wMarks["ContactPerson"].Range.Text = $"{CurrentServiceContract.Organization.ContactPerson}";
                    wMarks["ServiceList"].Range.Text = $"{CurrentServiceContract.GetService}";
                    wMarks["ServiceAddress"].Range.Text = $"{CurrentServiceContract.ServiceAddress}";
                    wMarks["DateStart"].Range.Text = $"{RuDateAndMoneyConverter.DateToTextLong(CurrentServiceContract.DateStart, "г.")}";
                    wMarks["DateEnd"].Range.Text = $"{RuDateAndMoneyConverter.DateToTextLong(CurrentServiceContract.DateEnd, "г.")}";
                    wMarks["TotalPrice"].Range.Text = $"{CurrentServiceContract.GetSumWithNDS}";
                    wMarks["OrganizationName1"].Range.Text = $"{CurrentServiceContract.Organization.TypeOrganization.Name} «{CurrentServiceContract.Organization.Name}»";
                    wMarks["BusinessAddress"].Range.Text = $"{CurrentServiceContract.Organization.BusinessAddress}";
                    wMarks["PhysicalAddress"].Range.Text = $"{CurrentServiceContract.Organization.PhysicalAddress}";
                    wMarks["INN"].Range.Text = $"{CurrentServiceContract.Organization.INN}";
                    wMarks["KPP"].Range.Text = $"{CurrentServiceContract.Organization.KPP}";
                    wMarks["BankName"].Range.Text = $"{CurrentServiceContract.Organization.BankAccount.Name}";
                    wMarks["PaymentAccount"].Range.Text = $"{CurrentServiceContract.Organization.PaymentAccount}";
                    wMarks["CorrespondentAccount"].Range.Text = $"{CurrentServiceContract.Organization.BankAccount.CorrespondentAccount}";
                    wMarks["BIK"].Range.Text = $"{CurrentServiceContract.Organization.BankAccount.BIK}";

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Word Document | *.docx";
                    if (sfd.ShowDialog() == true)
                    {
                        wDoc.SaveAs2($"{sfd.FileName}");
                        wApp.Visible = true;
                        wDoc.Close();
                        wDoc = null;
                        wApp.Quit();
                        ToastMessage.ShowSuccess("Файл успешно сохранён!");
                    }
                }
                else
                {
                    wDoc = null;
                    throw new Exception("Договор не выбран. Выберите договор и повторите попытку.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void PrintSpecification_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Word.Document wDoc = null;
                ServiceContract CurrentServiceContract = ServiceContractTable.SelectedItem as ServiceContract;
                var CurrentServiceContractSpecification = AppData.Context.ServiceContractSpecification.OrderBy(c => c.Id).Where(c => c.IdServiceContract == CurrentServiceContract.Id).FirstOrDefault();
                if (CurrentServiceContract != null)
                {

                    Word.Application wApp = new Word.Application();

                    string src = "";
                    src = $@"{Directory.GetCurrentDirectory().ToString()}\servicespecification.docx";

                    wDoc = wApp.Documents.Add(src);
                    wDoc.Activate();

                    wApp.Selection.Find.Execute("ServiceTable");
                    Word.Range NewRange = wApp.Selection.Range;

                    List<ServiceContractSpecification> ServiceList = AppData.Context.ServiceContractSpecification.Where(c => c.IdServiceContract == CurrentServiceContract.Id).ToList();

                    string[,] ServiceArray = new string[8, ServiceList.Count];
                    for (int i = 0; i < ServiceList.Count; i++)
                    {
                        ServiceContractSpecification SCS = ServiceList[i];
                        decimal Price = Math.Round(AppData.Context.ServicePrice.OrderByDescending(c => c.Date).Where(c => c.Date < CurrentServiceContract.Date && c.IdService == SCS.Service.Id).Select(c => c.Price).FirstOrDefault(), 2);
                        decimal NDSService = AppData.Context.ServiceNDS.OrderByDescending(c => c.Date).Where(c => c.Date < CurrentServiceContract.Date && c.IdService == SCS.Service.Id).Select(c => c.NDS).FirstOrDefault();
                        ServiceArray[0, i] = (i + 1).ToString();
                        ServiceArray[1, i] = SCS.Service.Name;
                        ServiceArray[2, i] = SCS.Count.ToString();
                        ServiceArray[3, i] = NDSService.ToString();
                        ServiceArray[4, i] = Price.ToString();
                        ServiceArray[5, i] = (Price + (Price * NDSService / 100)).ToString();
                        ServiceArray[6, i] = (Price * SCS.Count).ToString();
                        ServiceArray[7, i] = (SCS.Count * (Price + (Price * NDSService / 100))).ToString();
                    }
                    Word.Table NewTable = wDoc.Tables.Add(NewRange, ServiceList.Count + 1, 8);
                    NewTable.Borders.Enable = 1;

                    //NewTable.Columns[1].PreferredWidth = wApp.PixelsToPoints(30f);

                    NewTable.Rows[1].Cells[1].Range.Text = "№";
                    NewTable.Rows[1].Cells[1].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[2].Range.Text = "Наименование услуи";
                    NewTable.Rows[1].Cells[2].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[3].Range.Text = "Кол-во, шт.";
                    NewTable.Rows[1].Cells[3].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[4].Range.Text = "Ставка НДС";
                    NewTable.Rows[1].Cells[4].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[5].Range.Text = "Цена за единицу (без учета НДС), руб.";
                    NewTable.Rows[1].Cells[5].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[6].Range.Text = "Цена за единицу (с учетом НДС), руб.";
                    NewTable.Rows[1].Cells[6].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[7].Range.Text = "Общая стоимость (без учета НДС), руб.";
                    NewTable.Rows[1].Cells[7].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[8].Range.Text = "Общая стоимость (с учетом НДС), руб.";
                    NewTable.Rows[1].Cells[8].Range.Font.Size = 10;

                    for (int column = 0; column < NewTable.Columns.Count; column++)
                    {
                        for (int row = 1; row < NewTable.Rows.Count; row++)
                        {
                            int rr = row + 1;
                            int cc = column + 1;
                            NewTable.Cell(rr, cc).Range.Text = ServiceArray[column, row - 1];
                            NewTable.Cell(rr, cc).Range.Font.Size = 10;
                        }

                    }
                    object oMissing = System.Reflection.Missing.Value;
                    NewTable.Rows.Add(ref oMissing);
                    NewTable.Rows.Add(ref oMissing);

                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[1].Merge(NewTable.Rows[NewTable.Rows.Count - 1].Cells[6]);
                    NewTable.Rows[NewTable.Rows.Count].Cells[1].Merge(NewTable.Rows[NewTable.Rows.Count].Cells[6]);

                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[1].Range.Font.Size = 10;
                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[1].Range.Text = "Итог";
                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[2].Range.Font.Size = 10;
                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[2].Range.Text = $"{Math.Round(CurrentServiceContract.GetSumWithoutNDS, 2)}";
                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[3].Range.Font.Size = 10;
                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[3].Range.Text = $"{Math.Round(CurrentServiceContract.GetSumWithNDS, 2)}";

                    NewTable.Rows[NewTable.Rows.Count].Cells[1].Range.Font.Size = 10;
                    NewTable.Rows[NewTable.Rows.Count].Cells[1].Range.Text = "в том числе НДС";
                    NewTable.Rows[NewTable.Rows.Count].Cells[2].Range.Font.Size = 10;
                    NewTable.Rows[NewTable.Rows.Count].Cells[2].Range.Text = $"0,00";
                    NewTable.Rows[NewTable.Rows.Count].Cells[3].Range.Font.Size = 10;
                    NewTable.Rows[NewTable.Rows.Count].Cells[3].Range.Text = $"{Math.Round(CurrentServiceContract.GetSumNDS, 2)}";

                    Word.Bookmarks wMarks = wDoc.Bookmarks;

                    wMarks["Number"].Range.Text = $"{CurrentServiceContractSpecification.Id}";
                    wMarks["Date"].Range.Text = $"{RuDateAndMoneyConverter.DateToTextLong(CurrentServiceContract.Date, "г.")}";
                    wMarks["NumberDocument"].Range.Text = $"{CurrentServiceContract.Id}";
                    wMarks["DateDocument"].Range.Text = $"{RuDateAndMoneyConverter.DateToTextLong(CurrentServiceContract.Date, "г.")}";
                    wMarks["OrganizationName"].Range.Text = $"{CurrentServiceContract.Organization.TypeOrganization.FullName} «{CurrentServiceContract.Organization.Name}»";
                    wMarks["OrganizationName1"].Range.Text = $"{CurrentServiceContract.Organization.TypeOrganization.Name} «{CurrentServiceContract.Organization.Name}»";
                    wMarks["ContactPerson"].Range.Text = $"{CurrentServiceContract.Organization.ContactPerson}";
                    wMarks["ContactPerson1"].Range.Text = $"{CurrentServiceContract.Organization.ContactPerson}";

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Word Document | *.docx";
                    if (sfd.ShowDialog() == true)
                    {
                        wDoc.SaveAs2($"{sfd.FileName}");
                        wApp.Visible = true;
                        wDoc.Close();
                        wDoc = null;
                        wApp.Quit();
                        ToastMessage.ShowSuccess("Файл успешно сохранен!");
                    }
                }
                else
                {
                    wDoc = null;
                    throw new Exception("Договор не выбран. Выберите договор и повторите попытку.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void PrintContract_Click(object sender, RoutedEventArgs e)
        {
            var cm = ContextMenuService.GetContextMenu(sender as DependencyObject);
            cm.Visibility = Visibility.Visible;
            if (cm == null)
            {
                return;
            }
            cm.Placement = PlacementMode.MousePoint;
            cm.PlacementTarget = sender as UIElement;
            cm.IsOpen = true;
        }
    }
}
