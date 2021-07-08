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
using ONIX.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using ONIX.ViewModels;
using Microsoft.Win32;
using ToastNotifications.Core;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для GoodPage.xaml
    /// </summary>
    public partial class GoodPage : Page
    {
        List<Good> GoodList = null;
        private readonly ToastViewModel ToastMessage;
        public GoodPage()
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            var CategoryList = AppData.Context.Category.ToList();
            CategoryList.Insert(0, new Category
            {
                Name = "Все"
            });
            var ManufacturerList = AppData.Context.Manufacturer.ToList();
            ManufacturerList.Insert(0, new Manufacturer
            {
                Name = "Все"
            });
            CategoryComboBox.ItemsSource = CategoryList;
            ManufacturerComboBox.ItemsSource = ManufacturerList;
            CategoryComboBox.SelectedIndex = 0;
            ManufacturerComboBox.SelectedIndex = 0;
            PriceFromInput.Text = "0";
            PriceToInput.Text = Convert.ToInt32(AppData.Context.GoodPrice.Max(c => c.Price)).ToString();

            if (Properties.Settings.Default.IsGoodAdd == true)
            {
                this.Title = "Выбор товара";
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

        public void UpdateData(string Search, string Category, string Manufacturer, string PriceFrom, string PriceTo)
        {
            GoodList = AppData.Context.Good.Where(c => c.IsDeleted == false).ToList();
            int TotalCount = GoodList.Count;

            if (!String.IsNullOrEmpty(Search) && !String.IsNullOrWhiteSpace(Search))
            {
                GoodList = GoodList.Where(c => c.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            if (Category != "Все")
            {
                GoodList = GoodList.Where(c => c.Category.Name == Category).ToList();
            }

            if (Manufacturer != "Все")
            {
                GoodList = GoodList.Where(c => c.Manufacturer.Name == Manufacturer).ToList();
            }

            if (!String.IsNullOrWhiteSpace(PriceFrom) && !String.IsNullOrWhiteSpace(PriceTo))
            {
                int PriceFromValue = Convert.ToInt32(PriceFrom);
                int PriceToValue = Convert.ToInt32(PriceTo);
                GoodList = GoodList.Where(c => c.GetLastPrice >= PriceFromValue && c.GetLastPrice <= PriceToValue).ToList();
            }

            int ViewCount = GoodList.Count;
            GoodListView.ItemsSource = GoodList;
            RecordsCountText.Text = $"{GoodList.Count} из {TotalCount}";
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text, ManufacturerComboBox.Text, PriceFromInput.Text, PriceToInput.Text);
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text, ManufacturerComboBox.Text, PriceFromInput.Text, PriceToInput.Text);
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, (CategoryComboBox.SelectedItem as Category).Name, ManufacturerComboBox.Text, PriceFromInput.Text, PriceToInput.Text);
        }

        private void ManufacturerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text, (ManufacturerComboBox.SelectedItem as Manufacturer).Name, PriceFromInput.Text, PriceToInput.Text);
        }

        private void PriceFromInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text, ManufacturerComboBox.Text, PriceFromInput.Text, PriceToInput.Text);
        }

        private void PriceToInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text, ManufacturerComboBox.Text, PriceFromInput.Text, PriceToInput.Text);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryComboBox.SelectedIndex = 0;
            ManufacturerComboBox.SelectedIndex = 0;
            PriceFromInput.Text = "0";
            PriceToInput.Text = Convert.ToInt32(AppData.Context.GoodPrice.Max(c => c.Price)).ToString();
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text, ManufacturerComboBox.Text, PriceFromInput.Text, PriceToInput.Text);
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.State = "AddState";
            NavigationService.Navigate(new EditGoodPage(null));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Good CurrentGood = GoodListView.SelectedItem as Good;
                if (CurrentGood != null)
                {
                    Properties.Settings.Default.State = "EditState";
                    NavigationService.Navigate(new EditGoodPage(CurrentGood));
                }
                else
                {
                    throw new Exception("Товар не выбран. Выберите товар и повторите попытку.");
                }
            }
            catch (Exception ex)
            {
                try
                {
                    ToastMessage.ShowError(ex.Message);
                } catch(Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                }

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Good CurrentGood = GoodListView.SelectedItem as Good;
                if (CurrentGood != null)
                {
                    if (MessageBoxManager.ShowDialog("Вы действительно хотите удалить данный товар?", MessageBoxManager.Buttons.Yes_No, MessageBoxManager.Type.Question) == "1")
                    {
                        CurrentGood.IsDeleted = true;
                        AppData.Context.SaveChanges();
                        ToastMessage.ShowSuccess("Товар успешно удалён из списка!");
                        Page_Loaded(null, null);
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

        private void GoodListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Good CurrentGood = GoodListView.SelectedItem as Good;
                if (CurrentGood != null)
                {
                    if (Properties.Settings.Default.IsGoodAdd == false)
                    {
                        Properties.Settings.Default.State = "ShowState";
                        NavigationService.Navigate(new EditGoodPage(CurrentGood));
                    }
                    else
                    {
                        Properties.Settings.Default.IdGood = CurrentGood.Id;
                        MessageBoxManager.ShowDialog("AddCount", MessageBoxManager.Buttons.Save_Cancel, MessageBoxManager.Type.AddCount);
                        if (Properties.Settings.Default.Count != 0)
                        {
                            SaleContractSpecification NewSpecification = new SaleContractSpecification()
                            {
                                IdGood = Properties.Settings.Default.IdGood,
                                IdSaleContract = Properties.Settings.Default.IdSaleContract,
                                Count = Properties.Settings.Default.Count,
                            };
                            AppData.Context.SaleContractSpecification.Add(NewSpecification);
                            AppData.Context.SaveChanges();
                            Properties.Settings.Default.IsGoodAdd = false;
                            Properties.Settings.Default.Count = 0;
                            NavigationService.GoBack();
                            ToastMessage.ShowSuccess("Товар успешно добавлен в спецификацию!");
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PriceFromInput.Text = "0";
            PriceToInput.Text = Convert.ToInt32(AppData.Context.GoodPrice.Max(c => c.Price)).ToString();
            UpdateData(SearchTextBox.Text, CategoryComboBox.Text, ManufacturerComboBox.Text, PriceFromInput.Text, PriceToInput.Text);
        }

        private void PriceListButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Word.Document wDoc = null;
                Word.Application wApp = new Word.Application();

                string src = "";
                src = $@"{Directory.GetCurrentDirectory().ToString()}\pricelistgood.docx";
                wDoc = wApp.Documents.Add(src);
                wDoc.Activate();


                string[,] GoodArray = new string[4,GoodList.Count];
                for (int i = 0; i < GoodList.Count; i++)
                {
                    Good good = GoodList[i];
                    GoodArray[0, i] = good.Name;
                    GoodArray[1, i] = good.Category.Name;
                    GoodArray[2, i] = good.Manufacturer.Name;
                    GoodArray[3, i] = good.GetLastPrice.ToString();
                }

                Word.Range NewRange = wDoc.Range();
                Word.Table NewTable = wDoc.Tables.Add(NewRange, GoodList.Count + 2, 4);
                NewTable.Borders.Enable = 1;

                NewTable.Rows[1].Cells[1].Merge(NewTable.Rows[1].Cells[4]);

                NewTable.Rows[1].Cells[1].Range.Text = "Товары";
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

                NewTable.Rows[2].Cells[3].Range.Text = "Производитель";
                NewTable.Rows[2].Cells[3].Range.Font.Name = "Montserrat";
                NewTable.Rows[2].Cells[3].Range.Font.Spacing = 6;
                NewTable.Rows[2].Cells[3].Range.Font.Size = 10;
                NewTable.Rows[2].Cells[3].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                NewTable.Rows[2].Cells[4].Range.Text = "Цена";
                NewTable.Rows[2].Cells[4].Range.Font.Name = "Montserrat";
                NewTable.Rows[2].Cells[4].Range.Font.Spacing = 6;
                NewTable.Rows[2].Cells[4].Range.Font.Size = 10;
                NewTable.Rows[2].Cells[4].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;


                NewTable.Rows[1].Cells[1].Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray80;
                for (int column = 0; column < NewTable.Columns.Count; column++)
                {
                    for (int row = 2; row < NewTable.Rows.Count; row++)
                    {
                        int rr = row + 1;
                        int cc = column + 1;
                        NewTable.Cell(rr, cc).Range.Text = GoodArray[column, row - 2];
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
                    ToastMessage.ShowSuccess("Файл успешно сохранен!");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }

        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
