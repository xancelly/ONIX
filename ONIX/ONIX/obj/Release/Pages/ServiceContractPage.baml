   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  $    ONIX.Pages.ServiceContractPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:ONIX.Pages     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� Title$4  .Договоры на обслуживание�� � 	Resources    
OpenFilter �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  CloseFilter��%�   &	        &	 s     �� .��U� $ (FrameworkElement.Width)�$ 
FilterGrid��.\�  $ 0��$ 30Q�  $ 0:0:0.2��$	 250Q��� .��U� $ (FrameworkElement.Width)�$ 
FilterGrid��.\�  $ 0��$	 250Q�  $ 0:0:0.1��$ 30Q� � Triggers :�  :� RoutedEvent$ ButtonBase.Click�� :� 
SourceName$ OpenFilterButton��.[��� #��[  :� $ ButtonBase.Click��$ CloseFilterButton��.[��� #��[ .��� 	 � ColumnDefinitions	 �� $��* ��� $��30 �
 � RowDefinitions
 �� $��50 ��� $��* ��� $��40 �.+���  �� Orientation$ 
Horizontal=�$��0��$��0��.+��� $��
Поиск��  	TextStyle#��[ �� -    ��Name$ SearchTextBox���� $ 
Horizontal=�$
��Left=�$��Center=�$��2��.+��� -    ��Name$ RecordsCountText��$
��Auto��$
��Auto��$��12(�#��[ &   System.Windows.Controls.DataGrid  -     Name$ ServiceContractTable��$��1��   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 №��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Дата��$ *  �� *Date+  $3 -Ответственный сотрудник��$ *  �� *GetEmployee+  $ Организация��$ *  �� *GetOrganization+  $# Сумма, руб. с НДС��$ *  �� *GetSumWithNDS+�� $ 
Horizontal=�$��Right=�$��Bottom=�$��1��$��	0,0,20,20q�.+��� -    ��Name$ PrintDocumentButton�� * &MaterialDesignFloatingActionMiniButton#��[ ���#00FF$��5q����	#FFFFB400.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Printer=�$��30��$��30�� � ContextMenu �� .@�m� -    m�Name$ PrintDocument��$A��;Печать договора на обслуживание��m� -   $ PrintSpecification��$]��WПечать спецификации к договору на обслуживание���� -   $ DeleteButton��#��[ ���#00FF$��5q����#FF0000.��  $ Delete=�$��30��$��30���� -	   $ 
EditButton��#��[ ���#0099CC$��5q����#00FF.��  $
 Edit=�$��30��$��30���� -
   $ 	AddButton��#��[ ���#00FF$��5q����#27a843.��  $	 Add=�$��30��$��30��� -    �Name$ 
FilterGrid��$��30�����#EAEBEC$	��Top=�$��0��$��0��$��Right=�$��2��$��3�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 1Q�   ShadowDepth$ 1Q�   Color$ 	LightGray��.+��� .+��� 
�������$��1q�._�� $	��545�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� .+��� $ Vertical=�.+��� -   $ OpenFilterButton��$��50��$��30��$��Right=�$��Center=� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $��2q����#111111��Z� ��Z� .��  $ Filter=�$��18��$��18���� -   $ CloseFilterButton��$y�	Collapsed=�$��50��$��30��$��Right=�$��Center=�#��[ ���#111111��Z� ��Z� .��  $ FilterMinus=�$��18��$��18���� -     ��Name$  FilterFields��$ Vertical=�$y�	Collapsed=�.+��� $��Контрагент��#��[ �� -   ! ��Name$! OrganizationComboBox��" �� DisplayMemberPath$
" Name���� $!��Сумма договора��#��[ �� $ 
Horizontal=�.+��� -   $ PriceFromInput��$	��114��# �� 	MaxLength$# 10��$ � ToolTip$%$ Минимальная цена��$
��Left=��� -   $ PriceToInput��$	��114��$# 10��$'$ !Максимальная цена��$��Right=��� $��Период��#��[ �� $ 
Horizontal=�.+�(	  "System.Windows.Controls.DatePicker	  -   % 	 Name$% DateFromInput��$	��114��$$ Период с��	  -   $% DateToInput��$	��114��$$ Период по���� -   $ ClearButton��$��
Сброс��  
MainButton#��[ ���#00FF$��15q��� $ 
Horizontal=�$��2��$��Right=�