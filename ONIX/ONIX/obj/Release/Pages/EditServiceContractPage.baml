   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  (    "ONIX.Pages.EditServiceContractPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:ONIX.Pages     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� Title$I  CДобавление договора на обслуживание��.���  � RowDefinitions �� $	��160 ��� $��* ��� $	��100 �.+���  �� Orientation$ 
Horizontal=�.+��� $ Vertical=�.+��� $ 
Horizontal=�.+���    	TextStyle#��[  $!��Номер договора���� -    ��Name$ 
NumberText��#��[  �� $ 
Horizontal=�.+��� #��[  $��Дата договора��(  "System.Windows.Controls.DatePicker  -     Name$ 	DateInput��{�.  �� $ 
Horizontal=�.+��� #��[  $
��Auto��$.��(Даты проведения работ���� #��[  $��с��$
��Auto��  -   $ DateFromInput��$	��114���� #��[  $
��по��$
��Auto��  -   $ DateToInput��$	��114���� $ Vertical=�.+��� $ 
Horizontal=�.+��� #��[  $��Контрагент���� -    ��Name$ OrganizationComboBox�� �� DisplayMemberPath$ GetName���� -    ��Name$ AddOrganizationButton�� & "MaterialDesignFloatingActionButton#��[ $��40�����#00FF���#27a843$��40��.��'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��   Kind$	 Add=��� $ 
Horizontal=�.+��� #��[  $,��&Адрес оказания услуг���� -   	 ��Name$	 ServiceAddressInput��
 �� 	MaxLength$	
 255��&   System.Windows.Controls.DataGrid  -	     Name$ ServiceTable��$��1��$��Disabled=�   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Код услуги��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Service.Id+  $ Наименование��$ *  �� *Service.Name+  $ Ставка НДС, %��$ *  �� *Service.GetLastNDS+  $% Цена, руб. без НДС��$ *  �� *Service.GetLastPrice+  $ Количество��$ *  �� *Count+  $0 *Сумма услуги, руб. с НДС��$ *  �� *GetSumService+�� $ 
Horizontal=�$��Right=�$��Bottom=�$��1��$��	0,0,10,10q�.+��� -
   $ DeleteButton�� * &MaterialDesignFloatingActionMiniButton#��[ ���#00FF$��5q����#FF0000.��  $ Delete=�$��30��$��30���� -   $ 	AddButton��#��[ ���#00FF$��5q����#27a843.��  $	 Add=�$��30��$��30���� $ 
Horizontal=�$��2��$
��Left=�.+��� -   $ 
SaveButton��  
MainButton#��[ $��Сохранить��$
��Auto���� -   $ CancelButton��#��[ $��Отмена��$
��Auto���� $ Vertical=�$��2��$��Right=�.+��� $ 
Horizontal=�.+��� #��[  $��
Итого��$	��140���� -   $ TotalPriceText��#��[  $
��Auto���� $ 
Horizontal=�.+��� #��[  $!��В том числе НДС��$	��140���� -   $ TotalNDSText��#��[  $
��Auto��