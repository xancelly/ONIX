   M S B A M L   `   `   `  ����?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  5      %    ONIX.Pages.EditSaleContractPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:ONIX.Pages     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$E  ?Добавление договора купли-продажи��5      .��5      �  � RowDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      ��    	TextStyle#��[  6    $!��Номер договора��5       �� 5      -   5         ��Name$ 
NumberText��5       #��[  5       5       5      �� 5      $ 
Horizontal=�6   .+�5      �� #��[  6    $��Дата договора��5       (  "System.Windows.Controls.DatePicker  5       -   5          Name$ 	DateInput��5    !   {�.  5!   !   5"      5#      �� 5$      $ Vertical=�6   .+�5%      �� $ 
Horizontal=�6   .+�5&      �� #��[  6    $��Контрагент��5'       �� 5(      -   5         ��Name$ OrganizationComboBox��5(       �� DisplayMemberPath$ GetName��5)      �� 5*      -   5         ��Name$ AddOraganizationButton��5-       & "MaterialDesignFloatingActionButton#��[ 5*      $��40��5+      ���#00FF���#27a843$��40��50      .��51      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��62   $��30��52   2      Kind$	 Add=�53   2   54      55      �� 57      $ 
Horizontal=�6   .+�58      �� #��[  6    $!��Адрес доставки��59       �� 5:      -   5        	 ��Name$	 DeliveryAddressInput��5:      
 �� 	MaxLength$	
 255��5;      5<      5=      5>      &   System.Windows.Controls.DataGrid  5@   
   -   5          Name$ 	GoodTable��5@      $��1��5A      $��Disabled=�5B         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ Код товара��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5I   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5H   %   �� *	Good.Id+5I   %     5J      $ Наименование��6%   $ * 5L   %    5K   %   �� *	Good.Name+5L   %     5M      $ Ставка НДС, %��6%   $ * 5O   %    5N   %   �� *Good.GetLastNDS+5O   %     5P      $% Цена, руб. без НДС��6%   $ * 5R   %    5Q   %   �� *Good.GetLastPrice+5R   %     5S      $ Количество��6%   $ * 5U   %    5T   %   �� *Count+5U   %     5V      $0 *Сумма товара, руб. с НДС��6%   $ * 5X   %    5W   %   �� *
GetSumGood+5X   %   5Z      �� 5\   
   $ 
Horizontal=�6   $��Right=�5]      $��Bottom=�5^      $��1��5_      $��	0,0,10,10q�5`      .+�5a      �� -   5        $ DeleteButton��5d       * &MaterialDesignFloatingActionMiniButton#��[ 5a      ���#00FF$��5q�5c      ���#FF0000.��5g        $ Delete=�6*   $��30��5h   *   $��30��5i   *   5j      �� 5k      -	   5        $ 	AddButton��5o      #��[ 5k      ���#00FF$��5q�5m      ���#27a843.��5q        $	 Add=�6*   $��30��5r   *   $��30��5s   *   5t      5u      �� 5w   
   $ 
Horizontal=�6   $��2��5x      $
��Left=�5y      .+�5z      �� -
   5        $ 
SaveButton��5}        
MainButton#��[ 5z      $��Сохранить��5{      $
��Auto��5|      5~      �� 5      -   5        $ CancelButton��5�      #��[ 5      $��Отмена��5�      $
��Auto��5�      5�      5�      �� 5�   
   $ Vertical=�6   $��2��5�      $��Right=�5�      .+�5�      �� $ 
Horizontal=�6   .+�5�      �� #��[  6   $��
Итого��5�      $	��140��5�      �� 5�      -   5        $ TotalPriceText��5�      #��[  5�      $
��Auto��5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� #��[  6   $!��В том числе НДС��5�      $	��140��5�      �� 5�      -   5        $ TotalNDSText��5�      #��[  5�      $
��Auto��5�      5�      5�      5�      5�      