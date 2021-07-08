using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ONIX.Entities;
using ONIX.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using ToastNotifications.Messages.Core;
using ONIX.ViewModels;

namespace ONIX.Windows
{
    /// <summary>
    /// Логика взаимодействия для MessageBoxWindow.xaml
    /// </summary>
    public partial class MessageBoxWindow : Window
    {
        private readonly ToastViewModel ToastMessage;
        public string ReturnString
        {
            get; set;
        }

        public MessageBoxWindow(string Text, MessageBoxManager.Buttons buttons, MessageBoxManager.Type type)
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            var CountryList = AppData.Context.Country.ToList();
            CountryList.Insert(0, new Country
            {
                Name = "Выберите страну производства"
            });
            CountryComboBox.ItemsSource = CountryList;
            CountryComboBox.SelectedIndex = 0;

            this.Owner = App.Current.MainWindow;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            TextView.Text = Text;

            switch (buttons)
            {
                case MessageBoxManager.Buttons.Yes_No:
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.Visibility = Visibility.Visible;
                    break;
                case MessageBoxManager.Buttons.Save_Cancel:
                    SaveButton.Visibility = Visibility.Visible;
                    CancelButton.Visibility = Visibility.Visible;
                    break;
            }

            switch (type)
            {
                case MessageBoxManager.Type.Question:
                    MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.MessageQuestion;
                    MessageIcon.Foreground = new SolidColorBrush(Color.FromRgb(39, 168, 67));
                    break;
                case MessageBoxManager.Type.AddManufacturer:
                    TextView.Visibility = Visibility.Collapsed;
                    ManufacturerPanel.Visibility = Visibility.Visible;
                    MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AddCircle;
                    MessageIcon.Foreground = new SolidColorBrush(Color.FromRgb(39, 168, 67));
                    this.Width = 500;
                    this.Height = 300;
                    break;
                case MessageBoxManager.Type.AddCategory:
                    TextView.Visibility = Visibility.Collapsed;
                    CategoryPanel.Visibility = Visibility.Visible;
                    MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AddCircle;
                    MessageIcon.Foreground = new SolidColorBrush(Color.FromRgb(39, 168, 67));
                    this.Width = 500;
                    this.Height = 300;
                    break;
                case MessageBoxManager.Type.AddParametr:
                    TextView.Visibility = Visibility.Collapsed;
                    ParametrPanel.Visibility = Visibility.Visible;
                    MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AddCircle;
                    MessageIcon.Foreground = new SolidColorBrush(Color.FromRgb(39, 168, 67));
                    this.Width = 500;
                    this.Height = 300;
                    break;
                case MessageBoxManager.Type.AddTypeService:
                    TextView.Visibility = Visibility.Collapsed;
                    TypeServicePanel.Visibility = Visibility.Visible;
                    MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AddCircle;
                    MessageIcon.Foreground = new SolidColorBrush(Color.FromRgb(39, 168, 67));
                    this.Width = 500;
                    this.Height = 300;
                    break;
                case MessageBoxManager.Type.AddCount:
                    TextView.Visibility = Visibility.Collapsed;
                    CountPanel.Visibility = Visibility.Visible;
                    MessageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.AddCircle;
                    MessageIcon.Foreground = new SolidColorBrush(Color.FromRgb(39, 168, 67));
                    this.Width = 500;
                    this.Height = 200;
                    break;

            }

            if (Properties.Settings.Default.IdParametr != 0)
            {
                ParametrText.Text = "Редактирование характеристики";
                Parameter CurrentParametr = AppData.Context.Parameter.Where(c => c.Id == Properties.Settings.Default.IdParametr).FirstOrDefault();
                NameParametrInput.Text = CurrentParametr.Name;
                DescriptionParametrInput.Text = CurrentParametr.Description;
            }

            if (Properties.Settings.Default.IsGoodAdd == true)
            {
                CountText.Text = "Количество товара";
                CountText.ToolTip = "Количество товара";
            }
            else if (Properties.Settings.Default.IsServiceAdd == true)
            {
                CountText.Text = "Количество услуги";
                CountText.ToolTip = "Количество услуги";
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            ReturnString = "-1";
            Close();
        }

        DoubleAnimation anim;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.3));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void ReturnValue_Click(object sender, RoutedEventArgs e)
        {
            ReturnString = ((Button)sender).Uid.ToString();
            Close();
        }

        private void ReturnValue(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ManufacturerPanel.Visibility == Visibility.Visible)
                {
                    if (CountryComboBox.SelectedIndex != 0)
                    {
                        if (!String.IsNullOrWhiteSpace(NameManufacturerInput.Text))
                        {
                            if (AppData.Context.Manufacturer.Where(c => c.Name.ToLower() == NameManufacturerInput.Text.ToLower()).FirstOrDefault() == null)
                            {
                                Manufacturer NewManufacturer = new Manufacturer()
                                {
                                    Country = CountryComboBox.SelectedItem as Country,
                                    Name = NameManufacturerInput.Text,
                                };
                                AppData.Context.Manufacturer.Add(NewManufacturer);
                                AppData.Context.SaveChanges();
                                Close();
                                ToastMessage.ShowSuccess("Производитель успешно добавлен!");
                            }
                            else
                            {
                                throw new Exception("Производитель с таким наименованием уже существует.");
                            }
                        }
                        else
                        {
                            throw new Exception("Наименование производителя не указано.");
                        }
                    }
                    else
                    {
                        throw new Exception("Страна не выбрана!");
                    }
                }
                else if (CategoryPanel.Visibility == Visibility.Visible)
                {
                    if (!String.IsNullOrWhiteSpace(NameCategoryInput.Text))
                    {
                        if (AppData.Context.Manufacturer.Where(c => c.Name.ToLower() == NameCategoryInput.Text.ToLower()).FirstOrDefault() == null)
                        {
                            Category NewCategory = new Category()
                            {
                                Name = NameCategoryInput.Text,
                            };
                            AppData.Context.Category.Add(NewCategory);
                            AppData.Context.SaveChanges();
                            Close();
                            ToastMessage.ShowSuccess("Категория успешно добавлена!");
                        }
                        else
                        {
                            throw new Exception("Категория с таким наименованием уже существует.");
                        }
                    }
                    else
                    {
                        throw new Exception("Наименование категории не указано.");
                    }
                }
                else if (ParametrPanel.Visibility == Visibility.Visible)
                {
                    if (!String.IsNullOrWhiteSpace(NameParametrInput.Text))
                    {
                        if (!String.IsNullOrWhiteSpace(DescriptionParametrInput.Text))
                        {
                            if (Properties.Settings.Default.IdParametr == 0)
                            {
                                int GoodId = Properties.Settings.Default.IdGood;
                                Parameter NewParametr = new Parameter()
                                {
                                    Name = NameParametrInput.Text,
                                    Description = DescriptionParametrInput.Text,
                                    IdGood = GoodId,
                                };
                                AppData.Context.Parameter.Add(NewParametr);
                                AppData.Context.SaveChanges();
                                ToastMessage.ShowSuccess("Характеристика успешно добавлена!");
                                Close();
                            }
                            else
                            {
                                Parameter CurrentParametr = AppData.Context.Parameter.Where(c => c.Id == Properties.Settings.Default.IdParametr).FirstOrDefault();
                                CurrentParametr.Name = NameParametrInput.Text;
                                CurrentParametr.Description = DescriptionParametrInput.Text;
                                AppData.Context.SaveChanges();
                                ToastMessage.ShowSuccess("Параметр успешно изменён!");
                                Properties.Settings.Default.IdParametr = 0;
                                Close();
                            }

                        }
                        else
                        {
                            throw new Exception("Значение характеристики не указано.");
                        }
                    }
                    else
                    {
                        throw new Exception("Наименование характеристики не указано.");
                    }
                }
                else if (TypeServicePanel.Visibility == Visibility.Visible)
                {
                    if (!String.IsNullOrWhiteSpace(NameTypeServiceInput.Text))
                    {
                        if (AppData.Context.TypeService.Where(c => c.Name.ToLower() == NameTypeServiceInput.Text.ToLower()).FirstOrDefault() == null)
                        {
                            TypeService NewTypeService = new TypeService()
                            {
                                Name = NameTypeServiceInput.Text,
                            };
                            AppData.Context.TypeService.Add(NewTypeService);
                            AppData.Context.SaveChanges();
                            Close();
                            ToastMessage.ShowSuccess("Категория успешно добавлена!");
                        }
                        else
                        {
                            throw new Exception("Категория с таким наименованием уже существует.");
                        }
                    }
                    else
                    {
                        throw new Exception("Наименование категории не указано.");
                    }
                }
                else if (CountPanel.Visibility == Visibility.Visible)
                {
                    if (!String.IsNullOrEmpty(CountInput.Text))
                    {
                        if (CountCheck(CountInput.Text) == true)
                        {
                            Properties.Settings.Default.Count = Convert.ToInt32(CountInput.Text);
                            Close();
                        }
                        else
                        {
                            throw new Exception("Количество указано некорректно.");
                        }
                    }
                    else
                    {
                        throw new Exception("Количество не указано.");
                    } 
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }

        public bool CountCheck(string Count)
        {
            int CountOut;
            bool IsValid = true;
            if (Int32.TryParse(Count, out CountOut) == false)
            {
                IsValid = false;
            }
            return IsValid;
        }
    }
}
