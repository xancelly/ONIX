   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  !    ONIX.Pages.EditOrganization   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  $localclr-namespace:ONIX.Pages  X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    N� Title$1  +Добавление контрагента��.��� .+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� $ Vertical=�.+��� $ 
Horizontal=�$��5q�.+���    	TextStyle#��[  $#��Тип организации���� -    ��Name$ TypeOrganizationComboBox�� �� DisplayMemberPath$ FullName���� $ 
Horizontal=�$��5q�.+��� #��[  $5��/Наименование организации���� -    ��Name$ 	NameInput�� �� 	MaxLength$	 100���� $ 
Horizontal=�$��5q�.+��� #��[  $#��Контактное лицо���� -   $ ContactPersonInput��$	 150���� $ 
Horizontal=�$��5q�.+��� #��[  $��ИНН��%  Xceed.Wpf.Toolkit.MaskedTextBox  -     Name$ INNInput��$ 10���� $ 
Horizontal=�$��5q�.+��� #��[  $��КПП��  -   $ KPPInput��$ 10���� $ 
Horizontal=�$��5q�.+��� #��[  $��ОКПО��  -   $ 	OKPOInput��$ 8���� $ 
Horizontal=�$��5q�.+��� #��[  $%��Телефонный номер���� -   $ PhoneNumberInput��$ 20���� $ 
Horizontal=�$��5q�.+��� #��[  $'��!Электронная почта���� -   $ 
EmailInput��$	 100���� $ Vertical=�.+��� $ 
Horizontal=�$��5q�.+��� #��[  $'��!Фактический адрес���� -	   $ PhysicalAddressInput��$	 255���� $ 
Horizontal=�$��5q�.+��� #��[  $'��!Юридический адрес���� -
   $ BusinessAddressInput��$	 255���� $-��'Банковские реквезиты��.���� $ Vertical=�.+��� $ 
Horizontal=�$��5q�.+��� #��[  $'��!Наимнование банка���� -   $ NameBankInput��$	 100���� $ 
Horizontal=�$��5q�.+��� #��[  $��БИК��  -   $ BIKInput��$ 9���� $ 
Horizontal=�$��5q�.+��� #��[  $1��+Корреспондентский счёт��  -   $ CorrespondentAccountInput��$ 20���� $ 
Horizontal=�$��5q�.+��� #��[  $!��Расчётный счёт��  -   $ PaymentAccountInput��$ 20���� $ 
Horizontal=�.+��� -    ��Name$ 
BackButton��  MaterialDesignIconButton#��[ $
��Left=����#00FF���#00FF���#00FF$	��Top=�$��5,5,0,0q�$��30��$��30��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=����#111111$��30��$��30���� -   $ 
SaveButton��#��[ $
��Left=����#00FF���#00FF���#00FF$	��Top=�$��5,5,0,0q�$��30��$��30��.��  $ ContentSave=����#111111$��30��$��30��