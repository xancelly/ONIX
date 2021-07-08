using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using ONIX.Entities;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using ONIX.ViewModels;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditGoodPage.xaml
    /// </summary>
    public partial class EditGoodPage : Page
    {
        Good CurrentGood = null;
        byte[] SertificateIMG = null;
        byte[] TechnicalDataSheetPDF = null;
        byte[] InstructionPDF = null;
        bool ImageChanged = false;
        private readonly ToastViewModel ToastMessage;
        public EditGoodPage(Good good)
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            var CategoryList = AppData.Context.Category.ToList();
            CategoryList.Insert(0, new Category
            {
                Name = "Выберите категорию товара",
            });
            var ManufacturerList = AppData.Context.Manufacturer.ToList();
            ManufacturerList.Insert(0, new Manufacturer
            {
                Name = "Выберите производителя товара",
            });
            CategoryComboBox.ItemsSource = CategoryList;
            ManufacturerComboBox.ItemsSource = ManufacturerList;
            CategoryComboBox.SelectedIndex = 0;
            ManufacturerComboBox.SelectedIndex = 0;

            CurrentGood = good;
            if (CurrentGood != null && Properties.Settings.Default.State == "ShowState")
            {
                this.Title = "Просмотр товара";
                SaveButton.Visibility = Visibility.Collapsed;
                PrintButton.Visibility = Visibility.Visible;
                ShowGoodPanel.Visibility = Visibility.Visible;
                PreviewImage.Source = CurrentGood.GetImage;
                NameText.Text = CurrentGood.Name;
                if (String.IsNullOrWhiteSpace(CurrentGood.Description))
                {
                    DescriptionText.Text = $"Описание: отсутствует";
                }
                else
                {
                    DescriptionText.Text = $"Описание: {CurrentGood.Description}";
                }
                CountryText.Text = $"Страна производства: {CurrentGood.Manufacturer.Country.Name}";
                ManufacturerText.Text = $"Производитель: {CurrentGood.Manufacturer.Name}";
                CategoryText.Text = $"Категория: {CurrentGood.Category.Name}";
                if (CurrentGood.Sertificate == null)
                {
                    SertificatePanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    SertificatePanel.Visibility = Visibility.Visible;
                }
                if (CurrentGood.TechnicalDataSheet == null)
                {
                    TechnicalDataSheetPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    TechnicalDataSheetPanel.Visibility = Visibility.Visible;
                }
                if (CurrentGood.Instruction == null)
                {
                    InstructionPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    InstructionPanel.Visibility = Visibility.Visible;
                }
                PriceText.Text = $"Цена: {CurrentGood.GetLastPrice}";
                ParametrDataGrid.ItemsSource = AppData.Context.Parameter.Where(c => c.IdGood == CurrentGood.Id).ToList();
            }
            else if (CurrentGood != null && Properties.Settings.Default.State == "EditState")
            {
                this.Title = "Редактирование товара";
                CheckDocuments();
                EditGoodPanel.Visibility = Visibility.Visible;
                NameInput.Text = CurrentGood.Name;
                DescriptionInput.Text = CurrentGood.Description;
                CategoryComboBox.SelectedItem = CurrentGood.Category as Category;
                ManufacturerComboBox.SelectedItem = CurrentGood.Manufacturer as Manufacturer;
                PriceInput.Text = CurrentGood.GetLastPrice.ToString();
                NDSInput.Text = CurrentGood.GetLastNDS.ToString();
                EditPreviewImage.Source = CurrentGood.GetImage;

                UpdateData();
            }
            else
            {
                this.Title = "Добавление товара";
                EditGoodPanel.Visibility = Visibility.Visible;
                SertificateButton_1.Visibility = Visibility.Collapsed;
                SertificateButton_2.Visibility = Visibility.Collapsed;
                TechnicalDataSheetButton_1.Visibility = Visibility.Collapsed;
                TechnicalDataSheetButton_2.Visibility = Visibility.Collapsed;
                InstructionButton_1.Visibility = Visibility.Collapsed;
                InstructionButton_2.Visibility = Visibility.Collapsed;
                CurrentGood = new Good()
                {
                    Name = "UNKNOWN_GOOD",
                    PreviewImage = null,
                    IdCategory = 1,
                    IdManufacturer = 1,
                    IsDeleted = true,
                };
                AppData.Context.Good.Add(CurrentGood);
                AppData.Context.SaveChanges();
                EditPreviewImage.Source = CurrentGood.GetImage;
                UpdateData();
            }
        }

        public bool CheckPrice(string Price)
        {
            decimal PriceOut;
            bool IsValid = true;
            if (Decimal.TryParse(Price, out PriceOut) == false)
            {
                IsValid = false;
            }
            return IsValid;
        }

        public bool CheckNDS(string NDS)
        {
            int NDSOut;
            bool IsValid = true;
            if (Int32.TryParse(NDS, out NDSOut) == false)
            {
                IsValid = false;
            }
            return IsValid;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(NameInput.Text))
                {
                    if (CategoryComboBox.SelectedIndex != 0)
                    {
                        if (ManufacturerComboBox.SelectedIndex != 0)
                        {
                            if (!String.IsNullOrWhiteSpace(PriceInput.Text))
                            {
                                if (CheckPrice(PriceInput.Text) == true)
                                {
                                    if (!String.IsNullOrWhiteSpace(NDSInput.Text))
                                    {
                                        if (CheckNDS(NDSInput.Text) == true)
                                        {
                                            if (Properties.Settings.Default.State == "AddState")
                                            {
                                                GoodPrice NewGoodPrice = new GoodPrice()
                                                {
                                                    Price = Convert.ToDecimal(PriceInput.Text),
                                                    IdGood = CurrentGood.Id,
                                                    Date = DateTime.Now,
                                                };
                                                AppData.Context.GoodPrice.Add(NewGoodPrice);
                                                GoodNDS NewGoodNDS = new GoodNDS()
                                                {
                                                    NDS = Convert.ToInt32(NDSInput.Text),
                                                    IdGood = CurrentGood.Id,
                                                    Date = DateTime.Now,
                                                };
                                                AppData.Context.GoodNDS.Add(NewGoodNDS);
                                                CurrentGood.Name = NameInput.Text;
                                                CurrentGood.Description = DescriptionInput.Text;
                                                CurrentGood.Category = CategoryComboBox.SelectedItem as Category;
                                                CurrentGood.Manufacturer = ManufacturerComboBox.SelectedItem as Manufacturer;
                                                CurrentGood.IsDeleted = false;
                                                if (ImageChanged == true)
                                                {
                                                    CurrentGood.PreviewImage = ImageConverter((BitmapImage)EditPreviewImage.Source);
                                                }
                                                else
                                                {
                                                    CurrentGood.PreviewImage = null;
                                                } 
                                                AppData.Context.SaveChanges();
                                                ToastMessage.ShowSuccess("Товар успешно добавлен!");
                                                NavigationService.GoBack();
                                            }
                                            else if (Properties.Settings.Default.State == "EditState")
                                            {
                                                if (Convert.ToDecimal(PriceInput.Text) != CurrentGood.GetLastPrice)
                                                {
                                                    GoodPrice NewGoodPrice = new GoodPrice()
                                                    {
                                                        Price = Convert.ToDecimal(PriceInput.Text),
                                                        IdGood = CurrentGood.Id,
                                                        Date = DateTime.Now,
                                                    };
                                                    AppData.Context.GoodPrice.Add(NewGoodPrice);
                                                }
                                                if (Convert.ToInt32(NDSInput.Text) != CurrentGood.GetLastNDS)
                                                {
                                                    GoodNDS NewGoodNDS = new GoodNDS()
                                                    {
                                                        NDS = Convert.ToInt32(NDSInput.Text),
                                                        IdGood = CurrentGood.Id,
                                                        Date = DateTime.Now,
                                                    };
                                                    AppData.Context.GoodNDS.Add(NewGoodNDS);
                                                }
                                                CurrentGood.Name = NameInput.Text;
                                                CurrentGood.Description = DescriptionInput.Text;
                                                CurrentGood.Category = CategoryComboBox.SelectedItem as Category;
                                                CurrentGood.Manufacturer = ManufacturerComboBox.SelectedItem as Manufacturer;
                                                if (ImageChanged == true)
                                                {
                                                    CurrentGood.PreviewImage = ImageConverter((BitmapImage)EditPreviewImage.Source);
                                                }
                                                AppData.Context.SaveChanges();
                                                ToastMessage.ShowSuccess("Товар успешно изменён!");
                                                NavigationService.GoBack();
                                            }
                                        }
                                        else
                                        {
                                            NDSInput.Focus();
                                            throw new Exception("НДС введён некорректно.");
                                        } 
                                    }
                                    else
                                    {
                                        PriceInput.Focus();
                                        throw new Exception("НДС не введён.");
                                    } 
                                }
                                else
                                {
                                    PriceInput.Focus();
                                    throw new Exception("Цена введена некорректно.");
                                } 
                            }
                            else
                            {
                                PriceInput.Focus();
                                throw new Exception("Цена не введена.");
                            } 
                        }
                        else
                        {
                            ManufacturerComboBox.Focus();
                            throw new Exception("Производитель не может быть не выбран.");
                        } 
                    }
                    else
                    {
                        CategoryComboBox.Focus();
                        throw new Exception("Категория не может быть не выбрана.");
                    } 
                }
                else
                {
                    NameInput.Focus();
                    throw new Exception("Наименование товара не введено.");
                } 
            } catch(Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        public void UpdateData()
        {
            EditParametrDataGrid.ItemsSource = AppData.Context.Parameter.Where(c => c.IdGood == CurrentGood.Id).ToList();
        }

        public void CheckDocuments()
        {
            if (CurrentGood.Sertificate == null)
            {
                SertificateButton_1.Visibility = Visibility.Collapsed;
                SertificateButton_2.Visibility = Visibility.Collapsed;
            }
            else
            {
                SertificateButton_1.Visibility = Visibility.Visible;
                SertificateButton_2.Visibility = Visibility.Visible;
            }
            if (CurrentGood.TechnicalDataSheet == null)
            {
                TechnicalDataSheetButton_1.Visibility = Visibility.Collapsed;
                TechnicalDataSheetButton_2.Visibility = Visibility.Collapsed;
            }
            else
            {
                TechnicalDataSheetButton_1.Visibility = Visibility.Visible;
                TechnicalDataSheetButton_2.Visibility = Visibility.Visible;
            }
            if (CurrentGood.Instruction == null)
            {
                InstructionButton_1.Visibility = Visibility.Collapsed;
                InstructionButton_2.Visibility = Visibility.Collapsed;
            }
            else
            {
                InstructionButton_1.Visibility = Visibility.Visible;
                InstructionButton_2.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SertificateLink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Image | *.jpg; *.png";
                if (sfd.ShowDialog() == true)
                {
                    File.WriteAllBytes(sfd.FileName, CurrentGood.Sertificate);
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void TechnicalDataSheetLink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF | *.pdf;";
                if (sfd.ShowDialog() == true)
                {
                    File.WriteAllBytes(sfd.FileName, CurrentGood.TechnicalDataSheet);
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void InstructionLink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF | *.pdf;";
                if (sfd.ShowDialog() == true)
                {
                    File.WriteAllBytes(sfd.FileName, CurrentGood.Instruction);
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void SertificateSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Image | *.jpg; *.png";
                if (sfd.ShowDialog() == true)
                {
                    File.WriteAllBytes(sfd.FileName, CurrentGood.Sertificate);
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void TechnicalDataSheetSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF | *.pdf;";
                if (sfd.ShowDialog() == true)
                {
                    File.WriteAllBytes(sfd.FileName, CurrentGood.TechnicalDataSheet);
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void InstructionSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Image | *.jpg; *.png";
                if (sfd.ShowDialog() == true)
                {
                    File.WriteAllBytes(sfd.FileName, CurrentGood.Sertificate);
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void SertificateLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image | *.jpg; *.png;";
                if (ofd.ShowDialog() == true)
                {
                    SertificateIMG = File.ReadAllBytes(ofd.FileName);

                    CurrentGood.Sertificate = SertificateIMG;
                    AppData.Context.SaveChanges();
                    CheckDocuments();
                    ToastMessage.ShowSuccess("Сертификат соответствия успешно загружен!");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void TechnicalDataSheetLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PDF | *.pdf;";
                if (ofd.ShowDialog() == true)
                {
                    TechnicalDataSheetPDF = File.ReadAllBytes(ofd.FileName);

                    CurrentGood.TechnicalDataSheet = TechnicalDataSheetPDF;
                    AppData.Context.SaveChanges();
                    CheckDocuments();
                    ToastMessage.ShowSuccess("Технический паспорт успешно загружен!");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void InstructionLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PDF | *.pdf;";
                if (ofd.ShowDialog() == true)
                {
                    InstructionPDF = File.ReadAllBytes(ofd.FileName);
                    CurrentGood.Instruction = InstructionPDF;
                    AppData.Context.SaveChanges();
                    CheckDocuments();
                    ToastMessage.ShowSuccess("Инструкция по эксплуатации успешно загружена!");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void SertificateDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentGood.Sertificate != null)
                {
                    CurrentGood.Sertificate = null;
                    AppData.Context.SaveChanges();
                    CheckDocuments();
                    ToastMessage.ShowSuccess("Сертификат качества успешно удалён!");
                }
                else
                {
                    throw new Exception("Невозможно удалить сертификат качества!");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void TechnicalDataSheetDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentGood.TechnicalDataSheet != null)
                {
                    CurrentGood.TechnicalDataSheet = null;
                    AppData.Context.SaveChanges();
                    CheckDocuments();
                    ToastMessage.ShowSuccess("Технический паспорт успешно удалён!");
                }
                else
                {
                    throw new Exception("Невозможно удалить технический паспорт!");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void InstructionDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentGood.Instruction != null)
                {
                    CurrentGood.Instruction = null;
                    AppData.Context.SaveChanges();
                    CheckDocuments();
                    ToastMessage.ShowSuccess("Инструкция по эксплуатации успешно удалена!");
                }
                else
                {
                    throw new Exception("Невозможно удалить инструкцию по эксплуатации!");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxManager.ShowDialog("AddCategory", MessageBoxManager.Buttons.Save_Cancel, MessageBoxManager.Type.AddCategory);
                var CategoryList = AppData.Context.Category.ToList();
                CategoryList.Insert(0, new Category
                {
                    Name = "Выберите категорию товара",
                });
                CategoryComboBox.ItemsSource = CategoryList;
                CategoryComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void AddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxManager.ShowDialog("AddManufacturer", MessageBoxManager.Buttons.Save_Cancel, MessageBoxManager.Type.AddManufacturer);
                var ManufacturerList = AppData.Context.Manufacturer.ToList();
                ManufacturerList.Insert(0, new Manufacturer
                {
                    Name = "Выберите производителя товара",
                });
                ManufacturerComboBox.ItemsSource = ManufacturerList;
                ManufacturerComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.IdGood = CurrentGood.Id;
                MessageBoxManager.ShowDialog("AddParametr", MessageBoxManager.Buttons.Save_Cancel, MessageBoxManager.Type.AddParametr);
                UpdateData();
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
                Parameter CurrentParametr = EditParametrDataGrid.SelectedItem as Parameter;
                if (CurrentParametr != null)
                {
                    Properties.Settings.Default.IdParametr = CurrentParametr.Id;
                    MessageBoxManager.ShowDialog("AddParametr", MessageBoxManager.Buttons.Save_Cancel, MessageBoxManager.Type.AddParametr);
                    UpdateData();
                }
                else
                {
                    throw new Exception("Характеристика не выбрана. Выберите характеристику и повторите попытку.");
                }

            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Parameter CurrentParametr = EditParametrDataGrid.SelectedItem as Parameter;
                if (CurrentParametr != null)
                {
                    AppData.Context.Parameter.Remove(CurrentParametr);
                    AppData.Context.SaveChanges();
                    ToastMessage.ShowSuccess("Характеристика успешно удалена!");
                    UpdateData();
                }
                else
                {
                    throw new Exception("Характеристика не выбрана. Выберите характеристику и повторите попытку.");
                }

            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image | *.png;*.jpg";
                if (ofd.ShowDialog() == true)
                {
                    byte[] ImageBytes = File.ReadAllBytes(ofd.FileName);
                    EditPreviewImage.Source = GetImage(ImageBytes);
                    ImageChanged = true;
                }
            } catch(Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }

        }

        public BitmapImage GetImage(byte[] ImageBytes)
        {
            BitmapImage Image = new BitmapImage();
            using (MemoryStream Stream = new MemoryStream(ImageBytes))
            {
                Image.BeginInit();
                Image.UriSource = null;
                Image.CacheOption = BitmapCacheOption.OnLoad;
                Image.StreamSource = Stream;
                Image.EndInit();
            }
            return Image;
        }

        public Byte[] ImageConverter(BitmapImage Image)
        {
            BitmapEncoder ImageEncoder = new PngBitmapEncoder();
            ImageEncoder.Frames.Add(BitmapFrame.Create(Image));
            using (MemoryStream Stream = new MemoryStream())
            {
                ImageEncoder.Save(Stream);
                return Stream.ToArray();
            }
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(PrintGrid, "Товар");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            var TrashGood = AppData.Context.Good.Where(c => c.Name == "UNKNOWN_GOOD").ToList();
            if (TrashGood.Count > 0)
            {
                foreach (var item in TrashGood)
                {
                    var TrashParameters = AppData.Context.Parameter.Where(c => c.IdGood == item.Id).ToList();
                    AppData.Context.Parameter.RemoveRange(TrashParameters);
                    AppData.Context.Good.Remove(AppData.Context.Good.Where(c => c.Id == item.Id).FirstOrDefault());
                }
                AppData.Context.SaveChanges();
            }
        }
    }
}
