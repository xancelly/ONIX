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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using Microsoft.Win32;
using ONIX.ViewModels;
using System.IO;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditServicePage.xaml
    /// </summary>
    public partial class EditServicePage : Page
    {
        Service CurrentService = null;
        bool ImageChanged = false;
        private readonly ToastViewModel ToastMessage;
        public EditServicePage(Service service)
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            var TypeServiceList = AppData.Context.TypeService.ToList();
            TypeServiceList.Insert(0, new TypeService
            {
                Name = "Выберите категорию услуги",
            });
            TypeServiceComboBox.ItemsSource = TypeServiceList;
            TypeServiceComboBox.SelectedIndex = 0;
            CurrentService = service;
            if (CurrentService != null && Properties.Settings.Default.State == "ShowState")
            {
                this.Title = "Просмотр услуги";
                SaveButton.Visibility = Visibility.Collapsed;
                PrintButton.Visibility = Visibility.Visible;
                ShowServicePanel.Visibility = Visibility.Visible;
                PreviewImage.Source = CurrentService.GetImage;
                NameText.Text = CurrentService.Name;
                if (String.IsNullOrWhiteSpace(CurrentService.Description))
                {
                    DescriptionText.Text = $"Описание: отсутствует";
                }
                else
                {
                    DescriptionText.Text = $"Описание: {CurrentService.Description}";
                }
                TypeServiceText.Text = $"Категория: {CurrentService.TypeService.Name}";
                PriceText.Text = $"Цена: {CurrentService.GetLastPrice}";
            }
            else if (CurrentService != null && Properties.Settings.Default.State == "EditState")
            {
                this.Title = "Редактирование услуги";
                EditServicePanel.Visibility = Visibility.Visible;
                NameInput.Text = CurrentService.Name;
                DescriptionInput.Text = CurrentService.Description;
                TypeServiceComboBox.SelectedItem = CurrentService.TypeService as TypeService;
                PriceInput.Text = CurrentService.GetLastPrice.ToString();
                NDSInput.Text = CurrentService.GetLastNDS.ToString();
                EditPreviewImage.Source = CurrentService.GetImage;
                
            }
            else
            {
                BitmapImage Image = new BitmapImage();
                Image.BeginInit();
                Image.UriSource = new Uri(@"/ONIX;component/Resources/noimage.png", UriKind.Relative);
                Image.EndInit();
                EditPreviewImage.Source = Image;
                EditServicePanel.Visibility = Visibility.Visible;
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(NameInput.Text))
                {
                    if (TypeServiceComboBox.SelectedIndex != 0)
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
                                            CurrentService = new Service()
                                            {
                                                Name = NameInput.Text,
                                                Description = DescriptionInput.Text,
                                                TypeService = TypeServiceComboBox.SelectedItem as TypeService,
                                                IsDeleted = false,
                                            };
                                            AppData.Context.Service.Add(CurrentService);
                                            ServicePrice NewServicePrice = new ServicePrice()
                                            {
                                                Price = Convert.ToDecimal(PriceInput.Text),
                                                IdService = CurrentService.Id,
                                                Date = DateTime.Now,
                                            };
                                            AppData.Context.ServicePrice.Add(NewServicePrice);
                                            ServiceNDS NewServiceNDS = new ServiceNDS()
                                            {
                                                NDS = Convert.ToInt32(NDSInput.Text),
                                                IdService = CurrentService.Id,
                                                Date = DateTime.Now,
                                            };
                                            AppData.Context.ServiceNDS.Add(NewServiceNDS);
                                            if (ImageChanged == true)
                                            {
                                                CurrentService.PreviewImage = ImageConverter((BitmapImage)EditPreviewImage.Source);
                                            }
                                            else
                                            {
                                                CurrentService.PreviewImage = null;
                                            }
                                            AppData.Context.SaveChanges();
                                            ToastMessage.ShowSuccess("Услуга успешно добавлена!");
                                            NavigationService.GoBack();
                                        }
                                        else if (Properties.Settings.Default.State == "EditState")
                                        {
                                            if (Convert.ToDecimal(PriceInput.Text) != CurrentService.GetLastPrice)
                                            {
                                                ServicePrice NewServicePrice = new ServicePrice()
                                                {
                                                    Price = Convert.ToDecimal(PriceInput.Text),
                                                    IdService = CurrentService.Id,
                                                    Date = DateTime.Now,
                                                };
                                                AppData.Context.ServicePrice.Add(NewServicePrice);
                                            }
                                            if (Convert.ToInt32(NDSInput.Text) != CurrentService.GetLastNDS)
                                            {
                                                ServiceNDS NewServiceNDS = new ServiceNDS()
                                                {
                                                    NDS = Convert.ToInt32(NDSInput.Text),
                                                    IdService = CurrentService.Id,
                                                    Date = DateTime.Now,
                                                };
                                                AppData.Context.ServiceNDS.Add(NewServiceNDS);
                                            }
                                            CurrentService.Name = NameInput.Text;
                                            CurrentService.Description = DescriptionInput.Text;
                                            CurrentService.TypeService = TypeServiceComboBox.SelectedItem as TypeService;
                                            if (ImageChanged == true)
                                            {
                                                CurrentService.PreviewImage = ImageConverter((BitmapImage)EditPreviewImage.Source);
                                            }
                                            AppData.Context.SaveChanges();
                                            ToastMessage.ShowSuccess("Услуга успешно изменена!");
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
                        TypeServiceComboBox.Focus();
                        throw new Exception("Категория не может быть не выбрана.");
                    }
                }
                else
                {
                    NameInput.Focus();
                    throw new Exception("Наименование услуги не введено.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
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
                    printDialog.PrintVisual(PrintGrid, "Услуга");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void AddTypService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxManager.ShowDialog("AddTypeService", MessageBoxManager.Buttons.Save_Cancel, MessageBoxManager.Type.AddTypeService);
                var TypeSericeList = AppData.Context.TypeService.ToList();
                TypeSericeList.Insert(0, new TypeService
                {
                    Name = "Выберите категорию услуги",
                });
                TypeServiceComboBox.ItemsSource = TypeSericeList;
                TypeServiceComboBox.SelectedIndex = 0;
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
            }
            catch (Exception ex)
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
    }
}
