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
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using Microsoft.Win32;
using ONIX.ViewModels;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        List<Service> ServiceList = null;
        private readonly ToastViewModel ToastMessage;
        public ServicePage()
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            var CategoryList = AppData.Context.TypeService.ToList();
            CategoryList.Insert(0, new TypeService
            {
                Name = "Все"
            });
            CategoryComboBox.ItemsSource = CategoryList;
            CategoryComboBox.SelectedIndex = 0;

            if (Properties.Settings.Default.IsServiceAdd == true)
            {
                this.Title = "Выбор услуги";
                BackButton.Visibility = Visibility.Visible;
                AddButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
                PriceListButton.Visibility = Visibility.Collapsed;
            }

            if (Properties.Settings.Default.IdRole == 2)
            {
                AddButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }
            else if (Properties.Settings.Default.IdRole == 1)
            {
                PriceListButton.Visibility = Visibility.Collapsed;
            }
        }

        public void UpdateData(string Search, string Category)
        {
            ServiceList = AppData.Context.Service.Where(c => c.IsDeleted == false).ToList();
            int TotalCount = ServiceList.Count;

            if (!String.IsNullOrEmpty(Search) && !String.IsNullOrWhiteSpace(Search))
            {
                ServiceList = ServiceList.Where(c => c.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            if (Category != "Все")
            {
                ServiceList = ServiceList.Where(c => c.TypeService.Name == Category).ToList();
            }

            int ViewCount = ServiceList.Count;
            RecordsCountText.Text = $"{ViewCount} из {TotalCount}";
            ServiceListView.ItemsSource = ServiceList;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text);
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text);
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, (CategoryComboBox.SelectedItem as TypeService).Name);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service CurrentService = ServiceListView.SelectedItem as Service;
                if (CurrentService != null)
                {
                    if (MessageBoxManager.ShowDialog("Вы действительно хотите удалить данную услугу?", MessageBoxManager.Buttons.Yes_No, MessageBoxManager.Type.Question) == "1")
                    {
                        CurrentService.IsDeleted = true;
                        AppData.Context.SaveChanges();
                        ToastMessage.ShowSuccess("Услуга успешно удалена из списка!");
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service CurrentService = ServiceListView.SelectedItem as Service;
                if (CurrentService != null)
                {
                    Properties.Settings.Default.State = "EditState";
                    NavigationService.Navigate(new EditServicePage(CurrentService));
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
            Properties.Settings.Default.State = "AddState";
            NavigationService.Navigate(new EditServicePage(null));
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

        private void PriceListButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Word.Document wDoc = null;
                Word.Application wApp = new Word.Application();

                string src = "";
                src = $@"{Directory.GetCurrentDirectory().ToString()}\pricelistservice.docx";
                wDoc = wApp.Documents.Add(src);
                wDoc.Activate();


                string[,] ServiceArray = new string[3, ServiceList.Count];
                for (int i = 0; i < ServiceList.Count; i++)
                {
                    Service service = ServiceList[i];
                    ServiceArray[0, i] = service.Name;
                    ServiceArray[1, i] = service.TypeService.Name;
                    ServiceArray[2, i] = service.GetLastPrice.ToString();
                }

                Word.Range NewRange = wDoc.Range();
                Word.Table NewTable = wDoc.Tables.Add(NewRange, ServiceList.Count + 2, 3);
                NewTable.Borders.Enable = 1;

                NewTable.Rows[1].Cells[1].Merge(NewTable.Rows[1].Cells[3]);

                NewTable.Rows[1].Cells[1].Range.Text = "Услуги";
                NewTable.Rows[1].Cells[1].Range.Font.Name = "Montserrat";
                NewTable.Rows[1].Cells[1].Range.Font.Spacing = 6;
                NewTable.Rows[1].Cells[1].Range.Font.Size = 16;
                NewTable.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                NewTable.Rows[2].Cells[1].Range.Text = "Наименование";
                NewTable.Rows[2].Cells[1].Range.Font.Name = "Montserrat";
                NewTable.Rows[2].Cells[1].Range.Font.Spacing = 6;
                NewTable.Rows[2].Cells[1].Range.Font.Size = 10;
                NewTable.Rows[2].Cells[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                NewTable.Rows[2].Cells[2].Range.Text = "Категория";
                NewTable.Rows[2].Cells[2].Range.Font.Name = "Montserrat";
                NewTable.Rows[2].Cells[2].Range.Font.Spacing = 6;
                NewTable.Rows[2].Cells[2].Range.Font.Size = 10;
                NewTable.Rows[2].Cells[2].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                NewTable.Rows[2].Cells[3].Range.Text = "Цена";
                NewTable.Rows[2].Cells[3].Range.Font.Name = "Montserrat";
                NewTable.Rows[2].Cells[3].Range.Font.Spacing = 6;
                NewTable.Rows[2].Cells[3].Range.Font.Size = 10;
                NewTable.Rows[2].Cells[3].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                NewTable.Rows[1].Cells[1].Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray80;

                for (int column = 0; column < NewTable.Columns.Count; column++)
                {
                    for (int row = 2; row < NewTable.Rows.Count; row++)
                    {
                        int rr = row + 1;
                        int cc = column + 1;
                        NewTable.Cell(rr, cc).Range.Text = ServiceArray[column, row - 2];
                        NewTable.Cell(rr, cc).Range.Font.Name = "Montserrat";
                        NewTable.Cell(rr, cc).Range.Font.Size = 8;
                        NewTable.Cell(rr, cc).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                }


                Word.Bookmarks wMarks = wDoc.Bookmarks;

                wMarks["Date"].Range.Text = DateTime.Now.ToString("dd.MM.yyyy");

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
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
            CategoryComboBox.SelectedIndex = 0;
            Page_Loaded(null, null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text);
        }

        private void ServiceListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Service CurrentService = ServiceListView.SelectedItem as Service;
                if (CurrentService != null)
                {
                    if (Properties.Settings.Default.IsServiceAdd == false)
                    {
                        Properties.Settings.Default.State = "ShowState";
                        NavigationService.Navigate(new EditServicePage(CurrentService));
                    }
                    else
                    {
                        Properties.Settings.Default.IdService = CurrentService.Id;
                        MessageBoxManager.ShowDialog("AddCount", MessageBoxManager.Buttons.Save_Cancel, MessageBoxManager.Type.AddCount);
                        if (Properties.Settings.Default.Count != 0)
                        {
                            ServiceContractSpecification NewSpecification = new ServiceContractSpecification()
                            {
                                IdService = Properties.Settings.Default.IdService,
                                IdServiceContract = Properties.Settings.Default.IdServiceContract,
                                Count = Properties.Settings.Default.Count,
                            };
                            AppData.Context.ServiceContractSpecification.Add(NewSpecification);
                            AppData.Context.SaveChanges();
                            Properties.Settings.Default.IsServiceAdd = false;
                            Properties.Settings.Default.Count = 0;
                            NavigationService.GoBack();
                            ToastMessage.ShowSuccess("Услуга успешно добавлена в спецификацию!");
                        }
                    }
                }
                else
                {
                    throw new Exception("Товар не выбран. Выберите товар и повторите попытку.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
