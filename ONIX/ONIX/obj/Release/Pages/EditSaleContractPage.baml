   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  %    ONIX.Pages.EditSaleContractPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:ONIX.Pages     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� Title$E  ?Добавление договора купли-продажи��.���  � RowDefinitions �� $	��120 ��� $��* ��� $	��100 �.+���  �� Orientation$ 
Horizontal=�.+��� $ Vertical=�.+��� $ 
Horizontal=�.+���    	TextStyle#��[  $!��Номер договора���� -    ��Name$ 
NumberText��#��[  �� $ 
Horizontal=�.+��� #��[  $��Дата договора��(  "System.Windows.Controls.DatePicker  -     Name$ 	DateInput��{�.  �� $ Vertical=�.+��� $ 
Horizontal=�.+��� #��[  $��Контрагент���� -    ��Name$ OrganizationComboBox�� �� DisplayMemberPath$ GetName���� -    ��Name$ AddOraganizationButton�� & "MaterialDesignFloatingActionButton#��[ $��40�����#00FF���#27a843$��40��.��'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��   Kind$	 Add=��� $ 
Horizontal=�.+��� #��[  $!��Адрес доставки���� -   	 ��Name$	 DeliveryAddressInput��
 �� 	MaxLength$	
 255��&   System.Windows.Controls.DataGrid  -     Name$ 	GoodTable��$��1��$��Disabled=�   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Код товара��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Good.Id+  $ Наименование��$ *  �� *	Good.Name+  $ Ставка НДС, %��$ *  �� *Good.GetLastNDS+  $% Цена, руб. без НДС��$ *  �� *Good.GetLastPrice+  $ Количество��$ *  �� *Count+  $0 *Сумма товара, руб. с НДС��$ *  �� *
GetSumGood+�� $ 
Horizontal=�$��Right=�$��Bottom=�$��1��$��	0,0,10,10q�.+��� -   $ DeleteButton�� * &MaterialDesignFloatingActionMiniButton#��[ ���#00FF$��5q����#FF0000.��  $ Delete=�$��30��$��30���� -	   $ 	AddButton��#��[ ���#00FF$��5q����#27a843.��  $	 Add=�$��30��$��30���� $ 
Horizontal=�$��2��$
��Left=�.+��� -
   $ 
SaveButton��  
MainButton#��[ $��Сохранить��$
��Auto���� -   $ CancelButton��#��[ $��Отмена��$
��Auto���� $ Vertical=�$��2��$��Right=�.+��� $ 
Horizontal=�.+��� #��[  $��
Итого��$	��140���� -   $ TotalPriceText��#��[  $
��Auto���� $ 
Horizontal=�.+��� #��[  $!��В том числе НДС��$	��140���� -   $ TotalNDSText��#��[  $
��Auto��