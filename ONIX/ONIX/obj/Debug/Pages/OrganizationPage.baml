   M S B A M L   `   `   `  ����?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  5      !    ONIX.Pages.OrganizationPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      $localclr-namespace:ONIX.Pages  5      -   5          N� Title$  Контрагенты��5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��5      $��0��5      .+�5      �� $��
Поиск��6      	TextStyle#��[  5      �� 5      -   5         ��Name$ SearchTextBox��5      5      �� 5      -   5         ��Name$ ClearButton��5      $��
Сброс��5        
MainButton#��[ 5      $��5q�5      $��80��5      5       5!      �� 5$   
   $ 
Horizontal=�6   $
��Left=�5%      $��Center=�5&      $��2��5'      .+�5(      �� -   5         ��Name$ RecordsCountText��5,      $
��Auto��5(      $
��Auto��5)      $��12(�5*      #��[  5+      5,      5-      &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ OrganizationTable��5/      $��1��50         AutoGenerateColumns .     CanUserAddRows .  	   
IsReadOnly	 . 
   Columns
 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$5 /Наименование организации��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 56   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 57   %   �� *	GetName+  58      $# Контактное лицо��6%   $ * 59   %    5:   %   �� *ContactPerson+  5;      $! Номер телефона��6%   $ * 5<   %    5=   %   �� *PhoneNumber+  5>      $' !Электронная почта��6%   $ * 5?   %    5@   %   �� *Email+  5A      $' !Юридический адрес��6%   $ * 5B   %    5C   %   �� *BusinessAddress+  5D      $' !Фактический адрес��6%   $ * 5E   %    5F   %   �� *PhysicalAddress+  5G      $- 'Количество договоров��6%   $ * 5H   %    5I   %   �� *CountDocuments+5K      �� 5M   
   $ 
Horizontal=�6   $��Right=�5N      $��Bottom=�5O      $��1��5P      $��	0,0,20,20q�5Q      .+�5R      �� -   5        $ DeleteButton��5U       * &MaterialDesignFloatingActionMiniButton#��[ 5R      ���#00FF$��5q�5T      ���#FF0000.��5X      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Delete=�6*   $��30��5Y   *   $��30��5Z   *   5[      �� 5\      -   5        $ 
EditButton��5_      #��[ 5\      ���#0099CC$��5q�5^      ���#00FF.��5b        $
 Edit=�6*   $��30��5c   *   $��30��5d   *   5e      �� 5f      -   5        $ 	AddButton��5j      #��[ 5f      ���#00FF$��5q�5h      ���#27a843.��5l        $	 Add=�6*   $��30��5m   *   $��30��5n   *   5o      5p      5q      5r      