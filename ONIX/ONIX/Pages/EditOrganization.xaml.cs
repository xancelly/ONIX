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
using ONIX.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ONIX.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditOrganization.xaml
    /// </summary>
    public partial class EditOrganization : Page
    {
        Organization CurrentOrganization = null;
        private readonly ToastViewModel ToastMessage;
        public EditOrganization(Organization organization)
        {
            InitializeComponent();
            ToastMessage = new ToastViewModel();
            var TypeList = AppData.Context.TypeOrganization.ToList();
            TypeList.Insert(0, new TypeOrganization
            {
                FullName = "Не выбрано",
            });
            TypeOrganizationComboBox.ItemsSource = TypeList;
            TypeOrganizationComboBox.SelectedIndex = 0;
            CurrentOrganization = organization;
            if (CurrentOrganization != null)
            {
                this.Title = "Редактирование контрагента";
                TypeOrganizationComboBox.SelectedItem = CurrentOrganization.TypeOrganization as TypeOrganization;
                NameInput.Text = CurrentOrganization.Name;
                ContactPersonInput.Text = CurrentOrganization.ContactPerson;
                INNInput.Text = CurrentOrganization.INN;
                KPPInput.Text = CurrentOrganization.KPP;
                OKPOInput.Text = CurrentOrganization.OKPO;
                PhoneNumberInput.Text = CurrentOrganization.PhoneNumber;
                EmailInput.Text = CurrentOrganization.Email;
                PhysicalAddressInput.Text = CurrentOrganization.PhysicalAddress;
                BusinessAddressInput.Text = CurrentOrganization.BusinessAddress;
                NameBankInput.Text = CurrentOrganization.BankAccount.Name;
                BIKInput.Text = CurrentOrganization.BankAccount.BIK;
                CorrespondentAccountInput.Text = CurrentOrganization.BankAccount.CorrespondentAccount;
                PaymentAccountInput.Text = CurrentOrganization.PaymentAccount;
            }
        }

        private void ContactPersonInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void INNInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void KPPInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void OKPOInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void PhoneNumberInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string AllowedCharacters = "0123456789+-()";
            if (!AllowedCharacters.Contains(e.Text[0]))
                e.Handled = true;
        }

        private void BIKInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void CorrespondentAccountInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void PaymentAccountInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public bool CheckContactPerson(string ContactPerson)
        {
            bool IsValid = true;
            foreach (var item in ContactPerson)
            {
                if (Char.IsDigit(item) || Char.IsSymbol(item))
                {
                    IsValid = false;
                }
            }
            return IsValid;
        }

        public bool CheckINN(string INN)
        {
            bool IsValid = true;
            foreach (var item in INN)
            {
                if (!Char.IsDigit(item))
                {
                    IsValid = false;
                }
            }
            return IsValid;
        }

        public bool CheckKPP(string KPP)
        {
            bool IsValid = true;
            foreach (var item in KPP)
            {
                if (!Char.IsDigit(item))
                {
                    IsValid = false;
                }
            }
            return IsValid;
        }

        public bool CheckOKPO(string OKPO)
        {
            bool IsValid = true;
            foreach (var item in OKPO)
            {
                if (!Char.IsDigit(item))
                {
                    IsValid = false;
                }
            }
            return IsValid;
        }

        public bool CheckEmail(string Email)
        {
            bool IsValid = true;
            if (!(new EmailAddressAttribute().IsValid(Email)))
            {
                IsValid = false;
            }
            return IsValid;
        }

        public bool CheckPhone(string Phone)
        {
            bool IsValid = true;
            string AllowedCharacters = "0123456789+-()";
            foreach (var item in Phone)
            {
                if (!AllowedCharacters.Contains(item))
                {
                    IsValid = false;
                }
            }
            return IsValid;
        }

        public bool CheckBIK(string BIK)
        {
            bool IsValid = true;
            foreach (var item in BIK)
            {
                if (!Char.IsDigit(item))
                {
                    IsValid = false;
                }
            }
            return IsValid;
        }

        public bool CheckPayment(string Payment)
        {
            bool IsValid = true;
            foreach (var item in Payment)
            {
                if (!Char.IsDigit(item))
                {
                    IsValid = false;
                }
            }
            return IsValid;
        }

        public bool CheckCorrespondent(string Correspondent)
        {
            bool IsValid = true;
            foreach (var item in Correspondent)
            {
                if (!Char.IsDigit(item))
                {
                    IsValid = false;
                }
            }
            return IsValid;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TypeOrganizationComboBox.SelectedIndex != 0)
                {
                    if (!String.IsNullOrWhiteSpace(NameInput.Text))
                    {
                        if (!String.IsNullOrWhiteSpace(ContactPersonInput.Text))
                        {
                            if (CheckContactPerson(ContactPersonInput.Text) == true)
                            {
                                if (!String.IsNullOrWhiteSpace(INNInput.Text))
                                {
                                    if (CheckINN(INNInput.Text) == true)
                                    {
                                        if (!String.IsNullOrWhiteSpace(KPPInput.Text))
                                        {
                                            if (CheckKPP(KPPInput.Text) == true)
                                            {
                                                if (!String.IsNullOrWhiteSpace(OKPOInput.Text))
                                                {
                                                    if (CheckOKPO(OKPOInput.Text) == true)
                                                    {
                                                        if (!String.IsNullOrWhiteSpace(PhoneNumberInput.Text))
                                                        {
                                                            if (CheckPhone(PhoneNumberInput.Text) == true)
                                                            {
                                                                if (!String.IsNullOrWhiteSpace(PhysicalAddressInput.Text))
                                                                {
                                                                    if (!String.IsNullOrWhiteSpace(BusinessAddressInput.Text))
                                                                    {
                                                                        if (!String.IsNullOrWhiteSpace(NameBankInput.Text))
                                                                        {
                                                                            if (!String.IsNullOrWhiteSpace(BIKInput.Text))
                                                                            {
                                                                                if (CheckBIK(BIKInput.Text) == true)
                                                                                {
                                                                                    if (!String.IsNullOrWhiteSpace(PaymentAccountInput.Text))
                                                                                    {
                                                                                        if (CheckPayment(PaymentAccountInput.Text) == true)
                                                                                        {
                                                                                            if (!String.IsNullOrWhiteSpace(CorrespondentAccountInput.Text))
                                                                                            {
                                                                                                if (CheckCorrespondent(CorrespondentAccountInput.Text) == true)
                                                                                                {
                                                                                                    if (CurrentOrganization == null)
                                                                                                    {
                                                                                                        BankAccount NewBankAccount = new BankAccount()
                                                                                                        {
                                                                                                            Name = NameBankInput.Text,
                                                                                                            BIK = BIKInput.Text,
                                                                                                            CorrespondentAccount = CorrespondentAccountInput.Text,
                                                                                                        };
                                                                                                        AppData.Context.BankAccount.Add(NewBankAccount);
                                                                                                        CurrentOrganization = new Organization()
                                                                                                        {
                                                                                                            TypeOrganization = TypeOrganizationComboBox.SelectedItem as TypeOrganization,
                                                                                                            BankAccount = NewBankAccount,
                                                                                                            Name = NameInput.Text,
                                                                                                            ContactPerson = ContactPersonInput.Text,
                                                                                                            INN = INNInput.Text,
                                                                                                            KPP = KPPInput.Text,
                                                                                                            OKPO = OKPOInput.Text,
                                                                                                            PhoneNumber = PhoneNumberInput.Text,
                                                                                                            Email = EmailInput.Text,
                                                                                                            PhysicalAddress = PhysicalAddressInput.Text,
                                                                                                            BusinessAddress = BusinessAddressInput.Text,
                                                                                                            PaymentAccount = PaymentAccountInput.Text,
                                                                                                        };
                                                                                                        AppData.Context.Organization.Add(CurrentOrganization);
                                                                                                        AppData.Context.SaveChanges();
                                                                                                        ToastMessage.ShowSuccess("Контрагент успешно добавлен!");
                                                                                                        NavigationService.GoBack();
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        CurrentOrganization.BankAccount.Name = NameBankInput.Text;
                                                                                                        CurrentOrganization.BankAccount.BIK = BIKInput.Text;
                                                                                                        CurrentOrganization.BankAccount.CorrespondentAccount = CorrespondentAccountInput.Text;
                                                                                                        CurrentOrganization.TypeOrganization = TypeOrganizationComboBox.SelectedItem as TypeOrganization;
                                                                                                        CurrentOrganization.Name = NameInput.Text;
                                                                                                        CurrentOrganization.ContactPerson = ContactPersonInput.Text;
                                                                                                        CurrentOrganization.INN = INNInput.Text;
                                                                                                        CurrentOrganization.KPP = KPPInput.Text;
                                                                                                        CurrentOrganization.OKPO = OKPOInput.Text;
                                                                                                        CurrentOrganization.PhoneNumber = PhoneNumberInput.Text;
                                                                                                        CurrentOrganization.Email = EmailInput.Text;
                                                                                                        CurrentOrganization.PhysicalAddress = PhysicalAddressInput.Text;
                                                                                                        CurrentOrganization.BusinessAddress = BusinessAddressInput.Text;
                                                                                                        CurrentOrganization.PaymentAccount = PaymentAccountInput.Text;
                                                                                                        AppData.Context.SaveChanges();
                                                                                                        ToastMessage.ShowSuccess("Контрагент успешно обновлён!");
                                                                                                        NavigationService.GoBack();
                                                                                                    } 
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    CorrespondentAccountInput.Focus();
                                                                                                    throw new Exception("Корреспондентский счёт введён некорректно.");
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                CorrespondentAccountInput.Focus();
                                                                                                throw new Exception("Корреспондентский счёт не введён.");
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            PaymentAccountInput.Focus();
                                                                                            throw new Exception("Расчётный счёт введён некорректно.");
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        PaymentAccountInput.Focus();
                                                                                        throw new Exception("Рассчётный счёт не введён.");
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    BIKInput.Focus();
                                                                                    throw new Exception("БИК введён некорректно.");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                BIKInput.Focus();
                                                                                throw new Exception("БИК не введён.");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            NameBankInput.Focus();
                                                                            throw new Exception("Наименование банка не введено.");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        BusinessAddressInput.Focus();
                                                                        throw new Exception("Юридический адрес не введён.");
                                                                        
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    PhysicalAddressInput.Focus();
                                                                    throw new Exception("Фактический адрес не введён.");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PhoneNumberInput.Focus();
                                                                throw new Exception("Номер телефона введён некорректно.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PhoneNumberInput.Focus();
                                                            throw new Exception("Номер телефона не введён.");  
                                                        }
                                                    }
                                                    else
                                                    {
                                                        OKPOInput.Focus();
                                                        throw new Exception("ОКПО введён некорректно.");
                                                    }
                                                }
                                                else
                                                {
                                                    OKPOInput.Focus();
                                                    throw new Exception("ОКПО не введён.");
                                                }
                                            }
                                            else
                                            {
                                                KPPInput.Focus();
                                                throw new Exception("КПП введён некорректно.");
                                            }
                                        }
                                        else
                                        {
                                            KPPInput.Focus();
                                            throw new Exception("КПП не введён.");
                                        }
                                    }
                                    else
                                    {
                                        INNInput.Focus();
                                        throw new Exception("ИНН введён некорректно.");
                                    }
                                }
                                else
                                {
                                    INNInput.Focus();
                                    throw new Exception("ИНН не введён.");
                                }
                            }
                            else
                            {
                                ContactPersonInput.Focus();
                                throw new Exception("Контактное лицо введено некорректно.");
                            }
                        }
                        else
                        {
                            ContactPersonInput.Focus();
                            throw new Exception("Контактное лицо не введено.");
                        }
                    }
                    else
                    {
                        NameInput.Focus();
                        throw new Exception("Наименование организации не введено.");
                    }
                }
                else
                {
                    TypeOrganizationComboBox.Focus();
                    throw new Exception("Тип организации не может быть не выбран.");
                }
            }
            catch (Exception ex)
            {
                ToastMessage.ShowError(ex.Message);
            }
        }
    }
}
