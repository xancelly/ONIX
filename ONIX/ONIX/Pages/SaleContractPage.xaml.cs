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
using ONIX.Entities;
using ONIX.Pages;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls.Primitives;
using ONIX.ViewModels;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для SaleContractPage.xaml
    /// </summary>

    public partial class SaleContractPage : Page
    {
        List<SaleContract> SaleContractList = null;
        private readonly ToastViewModel ToastMessage;
        public SaleContractPage()
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            SaleContractList = AppData.Context.SaleContract.Where(c => c.IsDeleted == false).ToList();

            var StatusList = AppData.Context.Status.ToList();
            StatusList.Insert(0, new Status
            {
                Name = "Не важно"
            });
            var OrganizationList = AppData.Context.Organization.ToList();
            OrganizationList.Insert(0, new Organization
            {
                Name = "Не важно"
            });
            StatusComboBox.ItemsSource = StatusList;
            OrganizationComboBox.ItemsSource = OrganizationList;
            StatusComboBox.SelectedIndex = 0;
            OrganizationComboBox.SelectedIndex = 0;

            PriceFromInput.Text = "0";
            int MaxPrice = 0;
            foreach (var item in SaleContractList)
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

        public void UpdateData(string Search, string StatusContract, string OrganizationContract, string PriceFrom, string PriceTo, DateTime DateFrom, DateTime DateTo)
        {
            SaleContractList = AppData.Context.SaleContract.Where(c => c.IsDeleted == false).ToList();
            int TotalCount = SaleContractList.Count;

            if (!String.IsNullOrWhiteSpace(Search) && !String.IsNullOrEmpty(Search))
            {
                SaleContractList = SaleContractList.Where(c => c.Organization.GetName.ToLower().Contains(Search.ToLower()) || c.DeliveryAddress.ToLower().Contains(Search.ToLower())).ToList();
            }

            if (StatusComboBox.SelectedIndex != 0)
            {
                SaleContractList = SaleContractList.Where(c => c.Status.Name == StatusContract).ToList();
            }

            if (OrganizationComboBox.SelectedIndex != 0)
            {
                SaleContractList = SaleContractList.Where(c => c.Organization.Name == OrganizationContract).ToList();
            }

            if (!String.IsNullOrEmpty(PriceFrom) && !String.IsNullOrWhiteSpace(PriceFrom) && !String.IsNullOrEmpty(PriceTo) && !String.IsNullOrWhiteSpace(PriceTo))
            {
                decimal From = Convert.ToDecimal(PriceFrom);
                decimal To = Convert.ToDecimal(PriceTo);
                SaleContractList = SaleContractList.Where(c => c.GetSumWithNDS >= From && c.GetSumWithNDS <= To).ToList();
            }

            if (DateFrom != null && DateTo != null)
            {
                if (DateFrom < DateTo)
                {
                    SaleContractList = SaleContractList.Where(c => c.Date >= DateFrom && c.Date <= DateTo).ToList();
                }
            }
            int ViewCount = SaleContractList.Count;
            RecordsCountText.Text = $"{ViewCount} из {TotalCount}";
            SaleContractTable.ItemsSource = SaleContractList;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PriceFromInput.Text = "0";
            int MaxPrice = 0;
            foreach (var item in SaleContractList)
                if (item.GetSumWithNDS > MaxPrice)
                    MaxPrice = Convert.ToInt32(item.GetSumWithNDS);
            PriceToInput.Text = MaxPrice.ToString();
            UpdateData(SearchTextBox.Text, StatusComboBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, StatusComboBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, StatusComboBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, (StatusComboBox.SelectedItem as Status).Name, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void OrganizationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, StatusComboBox.Text, (OrganizationComboBox.SelectedItem as Organization).Name, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void PriceFromInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, StatusComboBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void PriceToInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, StatusComboBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
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
            StatusComboBox.SelectedIndex = 0;
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
                SaleContract CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
                if (CurrentSaleContract != null)
                {
                    if (MessageBoxManager.ShowDialog("Вы действительно хотите удалить данный договор купли-продажи?", MessageBoxManager.Buttons.Yes_No, MessageBoxManager.Type.Question) == "1")
                    {
                        CurrentSaleContract.IsDeleted = true;
                        AppData.Context.SaveChanges();
                        ToastMessage.ShowSuccess("Договор купли-продажи успешно удалён из списка!");
                        Page_Loaded(null, null);
                    }
                }
                else
                {
                    throw new Exception("Договор купли-продажи не выбран. Выберите договор купли-продажи и повторите попытку.");
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
                SaleContract CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
                if (CurrentSaleContract != null)
                {
                    NavigationService.Navigate(new EditSaleContractPage(CurrentSaleContract));
                }
                else
                {
                    throw new Exception("Договор купли-продажи не выбран. Выберите договор купли-продажи и повторите попытку.");
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
            NavigationService.Navigate(new EditSaleContractPage(null));
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

        private void PrintDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            var cm = ContextMenuService.GetContextMenu(sender as DependencyObject);
            if (cm == null)
            {
                return;
            }
            cm.Placement = PlacementMode.MousePoint;
            cm.PlacementTarget = sender as UIElement;
            cm.IsOpen = true;
        }

        private void PrintContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Word.Document wDoc = null;
                SaleContract CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
                if (CurrentSaleContract != null)
                {

                    Word.Application wApp = new Word.Application();

                    string src = "";
                    src = $@"{Directory.GetCurrentDirectory().ToString()}\salecontract.docx";

                    wDoc = wApp.Documents.Add(src);
                    wDoc.Activate();
                    Word.Bookmarks wMarks = wDoc.Bookmarks;

                    wMarks["Date"].Range.Text = $"{RuDateAndMoneyConverter.DateToTextLong(CurrentSaleContract.Date, "г.")}";
                    wMarks["BuyerOrganizationName"].Range.Text = $"{CurrentSaleContract.Organization.TypeOrganization.FullName.ToLower()} «{CurrentSaleContract.Organization.Name}»";
                    wMarks["BuyerOwner"].Range.Text = $"{CurrentSaleContract.Organization.ContactPerson}";
                    wMarks["BuyerWarehouse"].Range.Text = $"{CurrentSaleContract.DeliveryAddress}";
                    wMarks["BuyerBusinessAddress"].Range.Text = $"{CurrentSaleContract.Organization.BusinessAddress}";
                    wMarks["BuyerOrganizationNameSmall"].Range.Text = $"{CurrentSaleContract.Organization.TypeOrganization.Name} «{CurrentSaleContract.Organization.Name}»";
                    wMarks["BuyerBusinessAddressSmall"].Range.Text = $"{CurrentSaleContract.Organization.BusinessAddress}";
                    wMarks["BuyerINN"].Range.Text = $"{CurrentSaleContract.Organization.INN}";
                    wMarks["BuyerKPP"].Range.Text = $"{CurrentSaleContract.Organization.KPP}";
                    wMarks["BuyerBankName"].Range.Text = $"{CurrentSaleContract.Organization.BankAccount.Name}";
                    wMarks["BuyerPaymentAccount"].Range.Text = $"{CurrentSaleContract.Organization.PaymentAccount}";
                    wMarks["BuyerCorrespondentAccount"].Range.Text = $"{CurrentSaleContract.Organization.BankAccount.CorrespondentAccount}";
                    wMarks["BuyerBIK"].Range.Text = $"{CurrentSaleContract.Organization.BankAccount.BIK}";
                    wMarks["BuyerOKPO"].Range.Text = $"{CurrentSaleContract.Organization.OKPO}";
                    wMarks["BuyerPhoneNumber"].Range.Text = $"{CurrentSaleContract.Organization.PhoneNumber}";
                    wMarks["BuyerOrganizationNameSmall1"].Range.Text = $"{CurrentSaleContract.Organization.TypeOrganization.Name} «{CurrentSaleContract.Organization.Name}»";

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

        private void PrintSpecification_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Word.Document wDoc = null;
                SaleContract CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
                var CurrentSaleContractSpecification = AppData.Context.SaleContractSpecification.OrderBy(c => c.Id).Where(c => c.IdSaleContract == CurrentSaleContract.Id).FirstOrDefault();
                if (CurrentSaleContract != null)
                {

                    Word.Application wApp = new Word.Application();

                    string src = "";
                    src = $@"{Directory.GetCurrentDirectory().ToString()}\salespecification.docx";

                    wDoc = wApp.Documents.Add(src);
                    wDoc.Activate();

                    wApp.Selection.Find.Execute("GoodTable");
                    Word.Range NewRange = wApp.Selection.Range;

                    List<SaleContractSpecification> GoodList = AppData.Context.SaleContractSpecification.Where(c => c.IdSaleContract == CurrentSaleContract.Id).ToList();

                    string[,] GoodArray = new string[6, GoodList.Count];
                    for (int i = 0; i < GoodList.Count; i++)
                    {
                        SaleContractSpecification SCS = GoodList[i];
                        decimal Price = Math.Round(AppData.Context.GoodPrice.OrderByDescending(c => c.Date).Where(c => c.Date < CurrentSaleContract.Date && c.IdGood == SCS.Good.Id).Select(c => c.Price).FirstOrDefault(), 2);
                        decimal NDSGood = AppData.Context.GoodNDS.OrderByDescending(c => c.Date).Where(c => c.Date < CurrentSaleContract.Date && c.IdGood == SCS.Good.Id).Select(c => c.NDS).FirstOrDefault();
                        GoodArray[0, i] = (i + 1).ToString();
                        GoodArray[1, i] = SCS.Good.Name;
                        GoodArray[2, i] = SCS.Count.ToString();
                        GoodArray[3, i] = (Price + ((Price * NDSGood) / 100)).ToString();
                        GoodArray[4, i] = $"{NDSGood}%";
                        GoodArray[5, i] = (SCS.Count * (Price + ((Price * NDSGood) / 100))).ToString();
                    }
                    Word.Table NewTable = wDoc.Tables.Add(NewRange, GoodList.Count + 1, 6);
                    NewTable.Borders.Enable = 1;

                    //NewTable.Columns[1].PreferredWidth = wApp.PixelsToPoints(30f);

                    NewTable.Rows[1].Cells[1].Range.Text = "№";
                    NewTable.Rows[1].Cells[1].Range.Font.Size = 11;

                    NewTable.Rows[1].Cells[2].Range.Text = "Наименование";
                    NewTable.Rows[1].Cells[2].Range.Font.Size = 11;

                    NewTable.Rows[1].Cells[3].Range.Text = "Кол-во, шт.";
                    NewTable.Rows[1].Cells[3].Range.Font.Size = 11;

                    NewTable.Rows[1].Cells[4].Range.Text = "Цена, руб. с НДС";
                    NewTable.Rows[1].Cells[4].Range.Font.Size = 11;

                    NewTable.Rows[1].Cells[5].Range.Text = "Ставка НДС";
                    NewTable.Rows[1].Cells[5].Range.Font.Size = 11;

                    NewTable.Rows[1].Cells[6].Range.Text = "Сумма, руб. с НДС";
                    NewTable.Rows[1].Cells[6].Range.Font.Size = 11;

                    for (int column = 0; column < NewTable.Columns.Count; column++)
                    {
                        for (int row = 1; row < NewTable.Rows.Count; row++)
                        {
                            int rr = row + 1;
                            int cc = column + 1;
                            NewTable.Cell(rr, cc).Range.Text = GoodArray[column, row - 1];
                            NewTable.Cell(rr, cc).Range.Font.Size = 11;
                        }

                    }
                    object oMissing = System.Reflection.Missing.Value;
                    NewTable.Rows.Add(ref oMissing);
                    NewTable.Rows[NewTable.Rows.Count].Cells[1].Merge(NewTable.Rows[NewTable.Rows.Count].Cells[5]);
                    NewTable.Rows[NewTable.Rows.Count].Cells[1].Range.Text = "Итог";
                    NewTable.Rows[NewTable.Rows.Count].Cells[1].Range.Font.Size = 11;
                    NewTable.Rows[NewTable.Rows.Count].Cells[2].Range.Text = $"{Math.Round(CurrentSaleContract.GetSumWithNDS, 2)}";
                    NewTable.Rows[NewTable.Rows.Count].Cells[2].Range.Font.Size = 11;

                    decimal NDS = AppData.Context.GoodNDS.OrderByDescending(c => c.Date).Where(c => c.Date < CurrentSaleContract.Date && c.IdGood == CurrentSaleContractSpecification.Good.Id).Select(c => c.NDS).FirstOrDefault();

                    Word.Bookmarks wMarks = wDoc.Bookmarks;

                    wMarks["Number"].Range.Text = $"{CurrentSaleContractSpecification.Id}";
                    wMarks["DocumentNumber"].Range.Text = $"{CurrentSaleContract.Id}";
                    wMarks["DocumentDate"].Range.Text = $"{RuDateAndMoneyConverter.DateToTextLong(CurrentSaleContract.Date, "г.")}";
                    wMarks["TotalPrice"].Range.Text = $"{Math.Round(CurrentSaleContract.GetSumWithNDS, 2)}";
                    wMarks["NDS"].Range.Text = $"{NDS}";
                    wMarks["DocumentDateEnd"].Range.Text = $"{RuDateAndMoneyConverter.DateToTextLong(CurrentSaleContract.Date.AddMonths(1), "г.")}";
                    wMarks["BuyerOrganizationNameSmall"].Range.Text = $"{CurrentSaleContract.Organization.TypeOrganization.Name} «{CurrentSaleContract.Organization.Name}»";
                    wMarks["BuyerBusinessAddressSmall"].Range.Text = $"{CurrentSaleContract.Organization.BusinessAddress}";
                    wMarks["BuyerINN"].Range.Text = $"{CurrentSaleContract.Organization.INN}";
                    wMarks["BuyerKPP"].Range.Text = $"{CurrentSaleContract.Organization.KPP}";
                    wMarks["BuyerBankName"].Range.Text = $"{CurrentSaleContract.Organization.BankAccount.Name}";
                    wMarks["BuyerPaymentAccount"].Range.Text = $"{CurrentSaleContract.Organization.PaymentAccount}";
                    wMarks["BuyerCorrespondentAccount"].Range.Text = $"{CurrentSaleContract.Organization.BankAccount.CorrespondentAccount}";
                    wMarks["BuyerBIK"].Range.Text = $"{CurrentSaleContract.Organization.BankAccount.BIK}";
                    wMarks["BuyerOKPO"].Range.Text = $"{CurrentSaleContract.Organization.OKPO}";
                    wMarks["BuyerPhoneNumber"].Range.Text = $"{CurrentSaleContract.Organization.PhoneNumber}";

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

        private void PrintInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaleContract CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
                if (CurrentSaleContract != null)
                {
                    var CurrentExpenceInvoice = AppData.Context.ExpenceInvoice.Where(c => c.IdSaleContract == CurrentSaleContract.Id).FirstOrDefault();
                    if (CurrentExpenceInvoice == null)
                    {
                        ExpenceInvoice NewExpenceInvoice = new ExpenceInvoice()
                        {
                            Date = DateTime.Now,
                            IdSaleContract = CurrentSaleContract.Id,
                            IdEmployee = Properties.Settings.Default.IdEmployee,
                        };
                        AppData.Context.ExpenceInvoice.Add(NewExpenceInvoice);
                        var CurrentSaleContractSpecification = AppData.Context.SaleContractSpecification.Where(c => c.IdSaleContract == CurrentSaleContract.Id).ToList();
                        foreach (var item in CurrentSaleContractSpecification)
                        {
                            ExpenceInvoiceSpecification NewExpenceInvoiceSpcification = new ExpenceInvoiceSpecification()
                            {
                                IdExpenceInvoice = NewExpenceInvoice.Id,
                                IdGood = item.IdGood,
                                Count = item.Count,
                            };
                            AppData.Context.ExpenceInvoiceSpecification.Add(NewExpenceInvoiceSpcification);
                        }
                        AppData.Context.SaveChanges();
                    }
                    Word.Document wDoc = null;
                    Word.Application wApp = new Word.Application();

                    string src = "";
                    src = $@"{Directory.GetCurrentDirectory().ToString()}\expenceinvoice.docx";

                    wDoc = wApp.Documents.Add(src);
                    wDoc.Activate();

                    wApp.Selection.Find.Execute("[tb]");
                    Word.Range NewRange = wApp.Selection.Range;

                    List<ExpenceInvoiceSpecification> GoodList = AppData.Context.ExpenceInvoiceSpecification.Where(c => c.IdExpenceInvoice == CurrentExpenceInvoice.Id).ToList();

                    string[,] GoodArray = new string[6, GoodList.Count];
                    int GoodCount = 0;
                    for (int i = 0; i < GoodList.Count; i++)
                    {
                        ExpenceInvoiceSpecification EIS = GoodList[i];
                        decimal Price = Math.Round(AppData.Context.GoodPrice.OrderByDescending(c => c.Date).Where(c => c.Date < CurrentSaleContract.Date && c.IdGood == EIS.Good.Id).Select(c => c.Price).FirstOrDefault(), 2);
                        decimal NDSGood = AppData.Context.GoodNDS.OrderByDescending(c => c.Date).Where(c => c.Date < CurrentSaleContract.Date && c.IdGood == EIS.Good.Id).Select(c => c.NDS).FirstOrDefault();
                        GoodCount = i + 1;
                        GoodArray[0, i] = (i + 1).ToString();
                        GoodArray[1, i] = EIS.Good.Name;
                        GoodArray[2, i] = EIS.Count.ToString();
                        GoodArray[3, i] = Price.ToString();
                        GoodArray[4, i] = $"{NDSGood}%";
                        GoodArray[5, i] = (EIS.Count * Price).ToString();
                    }
                    Word.Table NewTable = wDoc.Tables.Add(NewRange, GoodList.Count + 1, 6);
                    NewTable.Borders.Enable = 1;

                    NewTable.Rows[1].Cells[1].Range.Text = "№ п/п";
                    NewTable.Rows[1].Cells[1].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[2].Range.Text = "Наименование";
                    NewTable.Rows[1].Cells[2].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[3].Range.Text = "Кол-во, шт.";
                    NewTable.Rows[1].Cells[3].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[4].Range.Text = "Цена, руб.";
                    NewTable.Rows[1].Cells[4].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[5].Range.Text = "Ставка НДС";
                    NewTable.Rows[1].Cells[5].Range.Font.Size = 10;

                    NewTable.Rows[1].Cells[6].Range.Text = "Сумма, руб.";
                    NewTable.Rows[1].Cells[6].Range.Font.Size = 10;

                    for (int column = 0; column < NewTable.Columns.Count; column++)
                    {
                        for (int row = 1; row < NewTable.Rows.Count; row++)
                        {
                            int rr = row + 1;
                            int cc = column + 1;
                            NewTable.Cell(rr, cc).Range.Text = GoodArray[column, row - 1];
                            NewTable.Cell(rr, cc).Range.Font.Size = 11;
                        }
                    }

                    object oMissing = System.Reflection.Missing.Value;
                    NewTable.Rows.Add(ref oMissing);
                    NewTable.Rows.Add(ref oMissing);
                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[1].Merge(NewTable.Rows[NewTable.Rows.Count - 1].Cells[5]);
                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[1].Range.Text = $"В том числе НДС: ";
                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[1].Range.Font.Size = 10;
                    NewTable.Rows[NewTable.Rows.Count - 1].Cells[2].Range.Text = $"{Math.Round(CurrentSaleContract.GetSumNDS, 2)}";

                    NewTable.Rows[NewTable.Rows.Count].Cells[1].Merge(NewTable.Rows[NewTable.Rows.Count].Cells[5]);
                    NewTable.Rows[NewTable.Rows.Count].Cells[1].Range.Text = $"Итого: ";
                    NewTable.Rows[NewTable.Rows.Count].Cells[1].Range.Font.Size = 10;
                    NewTable.Rows[NewTable.Rows.Count].Cells[2].Range.Text = $"{Math.Round(CurrentSaleContract.GetSumWithNDS, 2)}";

                    Word.Bookmarks wMarks = wDoc.Bookmarks;

                    wMarks["Number"].Range.Text = $"{CurrentExpenceInvoice.Id}";
                    wMarks["Day"].Range.Text = $"{CurrentExpenceInvoice.Date.Day}";
                    wMarks["Month"].Range.Text = $"{RuDateAndMoneyConverter.MonthName(CurrentExpenceInvoice.Date.Month, TextCase.Genitive)}";
                    wMarks["Year"].Range.Text = $"{CurrentExpenceInvoice.Date.Year}";
                    wMarks["OrganizationName"].Range.Text = $"{CurrentSaleContract.Organization.TypeOrganization.Name} «{CurrentSaleContract.Organization.Name}»";
                    wMarks["INNKPP"].Range.Text = $"{CurrentSaleContract.Organization.INN}/{CurrentSaleContract.Organization.KPP}";
                    wMarks["PhoneNumber"].Range.Text = $"{CurrentSaleContract.Organization.PhoneNumber}";
                    wMarks["BusinessAddress"].Range.Text = $"{CurrentSaleContract.Organization.BusinessAddress}";
                    wMarks["DocumentNumber"].Range.Text = $"{CurrentSaleContract.Id}";
                    wMarks["DocumentDay"].Range.Text = $"{CurrentSaleContract.Date.Day}";
                    wMarks["DocumentMonth"].Range.Text = $"{RuDateAndMoneyConverter.MonthName(CurrentSaleContract.Date.Month, TextCase.Genitive)}";
                    wMarks["DocumentYear"].Range.Text = $"{CurrentSaleContract.Date.Year}";
                    wMarks["GoodCount"].Range.Text = $"{RuDateAndMoneyConverter.NumeralsToTxt(GoodCount, TextCase.Nominative, true, true)}";
                    wMarks["SumRub"].Range.Text = $"{RuDateAndMoneyConverter.CurrencyToTxt(Convert.ToDouble(CurrentSaleContract.GetSumWithoutNDS), true)}";
                    wMarks["NDSRub"].Range.Text = $"{RuDateAndMoneyConverter.CurrencyToTxt(Convert.ToDouble(CurrentSaleContract.GetSumNDS), true)}";

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
            } catch(Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void SaleContractTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaleContract CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
            if (CurrentSaleContract != null)
            {
                if (CurrentSaleContract.Status.Name == "Завершён")
                {
                    PrintInvoice.Visibility = Visibility.Visible;
                }
                else
                {
                    PrintInvoice.Visibility = Visibility.Collapsed;
                } 
            }
        }

        private void DateFromInput_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, StatusComboBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void DateToInput_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, StatusComboBox.Text, OrganizationComboBox.Text, PriceFromInput.Text, PriceToInput.Text, Convert.ToDateTime(DateFromInput.SelectedDate), Convert.ToDateTime(DateToInput.SelectedDate));
        }

        private void SaleContractTable_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
            var cm = ContextMenuService.GetContextMenu(sender as DependencyObject);
            cm.Visibility = Visibility.Collapsed;
            if (CurrentSaleContract != null && CurrentSaleContract.Status.Name != "Завершён" && Properties.Settings.Default.IdRole != 1)
            {
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

        private void DraftStatus_Click(object sender, RoutedEventArgs e)
        {
            var CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
            if (CurrentSaleContract != null)
            {
                CurrentSaleContract.Status = AppData.Context.Status.Where(c => c.Name == "Черновик").FirstOrDefault();
                AppData.Context.SaveChanges();
                ToastMessage.ShowSuccess("Статус договора купли-продажи успешно изменён!");
                SaleContractTable.SelectedItem = null;
                Page_Loaded(null, null);
            }
        }

        private void ProcessStatus_Click(object sender, RoutedEventArgs e)
        {
            var CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
            if (CurrentSaleContract != null)
            {
                CurrentSaleContract.Status = AppData.Context.Status.Where(c => c.Name == "В обработке").FirstOrDefault();
                AppData.Context.SaveChanges();
                ToastMessage.ShowSuccess("Статус договора купли-продажи успешно изменён!");
                SaleContractTable.SelectedItem = null;
                Page_Loaded(null, null);
            }
        }

        private void ComplitedStatus_Click(object sender, RoutedEventArgs e)
        {
            var CurrentSaleContract = SaleContractTable.SelectedItem as SaleContract;
            if (CurrentSaleContract != null)
            {
                CurrentSaleContract.Status = AppData.Context.Status.Where(c => c.Name == "Завершён").FirstOrDefault();
                AppData.Context.SaveChanges();
                ToastMessage.ShowSuccess("Статус договора купли-продажи успешно изменён!");
                SaleContractTable.SelectedItem = null;
                Page_Loaded(null, null);
            }
        }
    }
}
