   M S B A M L   `   `   `  ����?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  5      (    "ONIX.Pages.EditServiceContractPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:ONIX.Pages     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$I  CДобавление договора на обслуживание��5      .��5      �  � RowDefinitions 5   
   �� 5      $	��160 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      ��    	TextStyle#��[  6    $!��Номер договора��5       �� 5      -   5         ��Name$ 
NumberText��5       #��[  5       5       5      �� 5      $ 
Horizontal=�6   .+�5      �� #��[  6    $��Дата договора��5       (  "System.Windows.Controls.DatePicker  5       -   5          Name$ 	DateInput��5    !   {�.  5!   !   5"      �� 5#      $ 
Horizontal=�6   .+�5$      �� #��[  6    $
��Auto��5%       $.��(Даты проведения работ��5&       �� 5'      #��[  6    $��с��5(       $
��Auto��5)         5*      -   5        $ DateFromInput��5*   !   $	��114��5+   !   �� 5,      #��[  6    $
��по��5-       $
��Auto��5.         5/      -   5        $ DateToInput��5/   !   $	��114��50   !   51      52      �� 53      $ Vertical=�6   .+�54      �� $ 
Horizontal=�6   .+�55      �� #��[  6    $��Контрагент��56       �� 57      -   5         ��Name$ OrganizationComboBox��57       �� DisplayMemberPath$ GetName��58      �� 59      -   5         ��Name$ AddOrganizationButton��5<       & "MaterialDesignFloatingActionButton#��[ 59      $��40��5:      ���#00FF���#27a843$��40��5?      .��5@      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��62   $��30��5A   2      Kind$	 Add=�5B   2   5C      5D      �� 5F      $ 
Horizontal=�6   .+�5G      �� #��[  6    $,��&Адрес оказания услуг��5H       �� 5I      -   5        	 ��Name$	 ServiceAddressInput��5I      
 �� 	MaxLength$	
 255��5J      5K      5L      5M      &   System.Windows.Controls.DataGrid  5O   
   -	   5          Name$ ServiceTable��5O      $��1��5P      $��Disabled=�5Q         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5V      ,  &System.Windows.Controls.DataGridColumn   Header$ Код услуги��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5X   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5W   %   �� *
Service.Id+5X   %     5Y      $ Наименование��6%   $ * 5[   %    5Z   %   �� *Service.Name+5[   %     5\      $ Ставка НДС, %��6%   $ * 5^   %    5]   %   �� *Service.GetLastNDS+5^   %     5_      $% Цена, руб. без НДС��6%   $ * 5a   %    5`   %   �� *Service.GetLastPrice+5a   %     5b      $ Количество��6%   $ * 5d   %    5c   %   �� *Count+5d   %     5e      $0 *Сумма услуги, руб. с НДС��6%   $ * 5g   %    5f   %   �� *GetSumService+5g   %   5i      �� 5k   
   $ 
Horizontal=�6   $��Right=�5l      $��Bottom=�5m      $��1��5n      $��	0,0,10,10q�5o      .+�5p      �� -
   5        $ DeleteButton��5s       * &MaterialDesignFloatingActionMiniButton#��[ 5p      ���#00FF$��5q�5r      ���#FF0000.��5v        $ Delete=�6*   $��30��5w   *   $��30��5x   *   5y      �� 5z      -   5        $ 	AddButton��5~      #��[ 5z      ���#00FF$��5q�5|      ���#27a843.��5�        $	 Add=�6*   $��30��5�   *   $��30��5�   *   5�      5�      �� 5�   
   $ 
Horizontal=�6   $��2��5�      $
��Left=�5�      .+�5�      �� -   5        $ 
SaveButton��5�        
MainButton#��[ 5�      $��Сохранить��5�      $
��Auto��5�      5�      �� 5�      -   5        $ CancelButton��5�      #��[ 5�      $��Отмена��5�      $
��Auto��5�      5�      5�      �� 5�   
   $ Vertical=�6   $��2��5�      $��Right=�5�      .+�5�      �� $ 
Horizontal=�6   .+�5�      �� #��[  6   $��
Итого��5�      $	��140��5�      �� 5�      -   5        $ TotalPriceText��5�      #��[  5�      $
��Auto��5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� #��[  6   $!��В том числе НДС��5�      $	��140��5�      �� 5�      -   5        $ TotalNDSText��5�      #��[  5�      $
��Auto��5�      5�      5�      5�      5�      