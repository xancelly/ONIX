   M S B A M L   `   `   `  ����?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  5      $    ONIX.Pages.ServiceContractPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:ONIX.Pages     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$4  .Договоры на обслуживание��5       � 	Resources 5         
OpenFilter �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  CloseFilter��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ 
FilterGrid��5   ,   .\�5        $ 0��6'   $ 30Q�5   '     5      $ 0:0:0.2��6'   $	 250Q�5   '   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ 
FilterGrid��5   ,   .\�5        $ 0��6'   $	 250Q�5   '     5      $ 0:0:0.1��6'   $ 30Q�5   '   5      5       5!       � Triggers 5$      :� 5%   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ OpenFilterButton��5&      .[�5'      �� #��[  6   5(      :� 5)   
   $ ButtonBase.Click��6   $ CloseFilterButton��5*      .[�5+      �� #��[ 6   5,      .��5/      � 	 � ColumnDefinitions	 50   
   �� 51      $��* �6   �� 52      $��30 �6   
 � RowDefinitions
 54   
   �� 55      $��50 �6   �� 56      $��* �6   �� 57      $��40 �6   .+�5:   
   ��  �� Orientation$ 
Horizontal=�6   $��0��5;      $��0��5<      .+�5=      �� $��
Поиск��6     	TextStyle#��[ 5>      �� 5?      -   5         ��Name$ SearchTextBox��5?      5@      5A      �� 5D   
   $ 
Horizontal=�6   $
��Left=�5E      $��Center=�5F      $��2��5G      .+�5H      �� -   5         ��Name$ RecordsCountText��5L      $
��Auto��5H      $
��Auto��5I      $��12(�5J      #��[ 5K      5L      5M      &   System.Windows.Controls.DataGrid  5O   
   -   5          Name$ ServiceContractTable��5O      $��1��5P         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$	 №��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5V   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5W   %   �� *Id+  5X      $ Дата��6%   $ * 5Y   %    5Z   %   �� *Date+  5[      $3 -Ответственный сотрудник��6%   $ * 5\   %    5]   %   �� *GetEmployee+  5^      $ Организация��6%   $ * 5_   %    5`   %   �� *GetOrganization+  5a      $# Сумма, руб. с НДС��6%   $ * 5b   %    5c   %   �� *GetSumWithNDS+5e      �� 5g   
   $ 
Horizontal=�6   $��Right=�5h      $��Bottom=�5i      $��1��5j      $��	0,0,20,20q�5k      .+�5l      �� -   5         ��Name$ PrintDocumentButton��5o       * &MaterialDesignFloatingActionMiniButton#��[ 5l      ���#00FF$��5q�5n      ���	#FFFFB400.��5r      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Printer=�6*   $��30��5s   *   $��30��5t   *    � ContextMenu 5u      �� 5v      .@�5w      m� -   5         m�Name$ PrintDocument��5x   #   $A��;Печать договора на обслуживание��5w   #   5y   #   m� 5z      -   5        $ PrintSpecification��5{   #   $]��WПечать спецификации к договору на обслуживание��5z   #   5|   #   5}      5      �� 5�      -   5        $ DeleteButton��5�      #��[ 5�      ���#00FF$��5q�5�      ���#FF0000.��5�        $ Delete=�6*   $��30��5�   *   $��30��5�   *   5�      �� 5�      -	   5        $ 
EditButton��5�      #��[ 5�      ���#0099CC$��5q�5�      ���#00FF.��5�        $
 Edit=�6*   $��30��5�   *   $��30��5�   *   5�      �� 5�      -
   5        $ 	AddButton��5�      #��[ 5�      ���#00FF$��5q�5�      ���#27a843.��5�        $	 Add=�6*   $��30��5�   *   $��30��5�   *   5�      5�      � 5�   
   -   5         �Name$ 
FilterGrid��5�      $��30��5�      ���#EAEBEC$	��Top=�5�      $��0��5�      $��0��5�      $��Right=�5�      $��2��5�      $��3��5�       J� Effect 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�5�   #      Color$ 	LightGray��5�   #   .+�5�      �� .+�5�      �� 
�������$��1q�5�      ._�5�      � $	��545��6    J� RenderTransformOrigin$ 0.5,0.5&�5�      z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "   5�      .+�5�      �� $ Vertical=�6%   .+�5�      �� -   5        $ OpenFilterButton��5�   %   $��50��5�   %   $��30��5�   %   $��Right=�5�   %   $��Center=�5�   %    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5�   %   $��2q�5�   %   ���#111111��5�   %   Z� ��5�   %   Z� .��5�   "     $ Filter=�6:   $��18��5�   :   $��18��5�   :   5�      �� 5�      -   5        $ CloseFilterButton��5�   %   $y�	Collapsed=�5�   %   $��50��5�   %   $��30��5�   %   $��Right=�5�   %   $��Center=�5�   %   #��[ 5�   %   ���#111111��5�   %   Z� ��5�   %   Z� .��5�   "     $ FilterMinus=�6:   $��18��5�   :   $��18��5�   :   5�      �� 5�      -   5          ��Name$  FilterFields��5�   )   $ Vertical=�5�   )   $y�	Collapsed=�5�   )   .+�5�   "   �� $��Контрагент��6,   #��[ 5�   ,   �� 5�   "   -   5        ! ��Name$! OrganizationComboBox��5�   +   " �� DisplayMemberPath$
" Name��5�   +   5�   +   �� 5�   "   $!��Сумма договора��6,   #��[ 5�   ,   �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� -   5        $ PriceFromInput��5�   /   $	��114��5�   /   # �� 	MaxLength$# 10��5�   /   $ � ToolTip$%$ Минимальная цена��5�   /   $
��Left=�5�   /   5�   /   �� 5�   &   -   5        $ PriceToInput��5�   /   $	��114��5�   /   $# 10��5�   /   $'$ !Максимальная цена��5�   /   $��Right=�5�   /   5�   /   5�   #   �� 5�   "   $��Период��6,   #��[ 5�   ,   �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   (	  "System.Windows.Controls.DatePicker	  -   5        % 	 Name$% DateFromInput��5�   2   $	��114��5�   2   $$ Период с��5�   2   5�   2   	  5   &   -   5        $% DateToInput��5   2   $	��114��5  2   $$ Период по��5  2   5  2   5  #   �� 5  "   -   5        $ ClearButton��5  )   $��
Сброс��5  )     
MainButton#��[ 5  )   ���#00FF$��15q�5
  )   5     5     5     5     5     5     �� 5  
   $ 
Horizontal=�6   $��2��5     $��Right=�5     5     5     