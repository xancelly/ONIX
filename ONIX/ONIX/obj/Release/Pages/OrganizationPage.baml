   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  !    ONIX.Pages.OrganizationPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  $localclr-namespace:ONIX.Pages  -     N� Title$  Контрагенты��.���  � RowDefinitions �� $��50 ��� $��* ��� $��30 �.+���  �� Orientation$ 
Horizontal=�$��0��$��0��.+��� $��
Поиск��   	TextStyle#��[  �� -    ��Name$ SearchTextBox���� -    ��Name$ ClearButton��$��
Сброс��  
MainButton#��[ $��5q�$��80���� $ 
Horizontal=�$
��Left=�$��Center=�$��2��.+��� -    ��Name$ RecordsCountText��$
��Auto��$
��Auto��$��12(�#��[  &   System.Windows.Controls.DataGrid  -     Name$ OrganizationTable��$��1��   AutoGenerateColumns .     CanUserAddRows .  	   
IsReadOnly	 . 
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$5 /Наименование организации��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	GetName+  $# Контактное лицо��$ *  �� *ContactPerson+  $! Номер телефона��$ *  �� *PhoneNumber+  $' !Электронная почта��$ *  �� *Email+  $' !Юридический адрес��$ *  �� *BusinessAddress+  $' !Фактический адрес��$ *  �� *PhysicalAddress+  $- 'Количество договоров��$ *  �� *CountDocuments+�� $ 
Horizontal=�$��Right=�$��Bottom=�$��1��$��	0,0,20,20q�.+��� -   $ DeleteButton�� * &MaterialDesignFloatingActionMiniButton#��[ ���#00FF$��5q����#FF0000.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Delete=�$��30��$��30���� -   $ 
EditButton��#��[ ���#0099CC$��5q����#00FF.��  $
 Edit=�$��30��$��30���� -   $ 	AddButton��#��[ ���#00FF$��5q����#27a843.��  $	 Add=�$��30��$��30��