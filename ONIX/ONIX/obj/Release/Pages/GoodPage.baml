   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     ONIX.Pages.GoodPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:ONIX.Pages     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .s&clr-namespace:System;assembly=mscorlib  X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     N� Title$  Товары�� � 	Resources    
OpenFilter �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  CloseFilter��%�   &	        &	 s     �� .��U� $ (FrameworkElement.Width)�$ 
FilterGrid��.\�  $ 0��$ 30Q�  $ 0:0:0.2��$	 250Q��� .��U� $ (FrameworkElement.Width)�$ 
FilterGrid��.\�  $ 0��$	 250Q�  $ 0:0:0.1��$ 30Q� � Triggers :�  :� RoutedEvent$ ButtonBase.Click�� :� 
SourceName$ OpenFilterButton��.[��� #��[  :� $ ButtonBase.Click��$ CloseFilterButton��.[��� #��[ .��� 	 � ColumnDefinitions	 �� $��* ��� $��30 �
 � RowDefinitions
 �� $��50 ��� $��* ��� $��40 �.+���  �� Orientation$ 
Horizontal=�$��0��$��0��.+��� -    ��Name$ 
BackButton�����#111111$y�	Collapsed=�  MaterialDesignIconButton#��[ .��'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��   Kind$ 	ArrowBack=��� $��
Поиск��  	TextStyle#��[ �� -    ��Name$ SearchTextBox���� -    ��Name$ GoodListView��$��1��$��0��$��Disabled=����� .R��� $ Vertical=�$	��160��$	��280��$��5q�.+��� $��5q�$	��150��$	��150������ *
GetImage+�� #��[ $
��Auto��$��70��$��12(� �� TextAlignment$ Center=�$
��Wrap=�$��5q����� *Name+�� #��[ $
��Auto��$ Center=�$
��Bold"�$��30��$��5q����� *GetLastPrice+���� .R��  � Orientation$ 
Horizontal=��� $ 
Horizontal=�$
��Left=�$��Center=�$��2��.+��� -    ��Name$ RecordsCountText��$
��Auto��$
��Auto��$��12(�#��[ �� $ 
Horizontal=�$��Right=�$��Bottom=�$��1��$��2��$��	0,0,70,50q�.+��� -   $ DeleteButton�� * &MaterialDesignFloatingActionMiniButton#��[ ���#00FF$��5q����#FF0000.��  $ Delete=�$��30��$��30���� -   $ 
EditButton��#��[ ���#0099CC$��5q����#00FF.��  $
 Edit=�$��30��$��30���� -   $ 	AddButton��#��[ ���#00FF$��5q����#27a843.��  $	 Add=�$��30��$��30��� -	    �Name$ 
FilterGrid��$��30�����#EAEBEC$	��Top=�$��0��$��0��$��Right=�$��2��$��3�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 1Q�   ShadowDepth$ 1Q�   Color$ 	LightGray��.+��� .+��� 
�������$��1q�._�� $	��545�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� .+��� $ Vertical=�.+��� -
   $ OpenFilterButton��$��50��$��30��$��Right=�$��Center=� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $��2q����#111111��Z� ��Z� .��  $ Filter=�$��18��$��18���� -   $ CloseFilterButton��$y�	Collapsed=�$��50��$��30��$��Right=�$��Center=�#��[ ���#111111��Z� ��Z� .��  $ FilterMinus=�$��18��$��18���� -    ��Name$ FilterFields��$ Vertical=�$y�	Collapsed=�.+��� $��Категория��#��[ �� -    ��Name$ CategoryComboBox�� �� DisplayMemberPath$
 Name���� $ ��Производитель��#��[ �� -   $ ManufacturerComboBox��$
 Name���� $��Цена��#��[ �� $ 
Horizontal=�.+��� -   $ PriceFromInput��$	��114�� �� 	MaxLength$ 10�� � ToolTip$% Минимальная цена��$
��Left=��� -   $ PriceToInput��$	��114��$ 10��$' !Максимальная цена��$��Right=��� -   $ PriceListButton��$(��"Печать прайс-листа�����#00FF  
MainButton#��[ $��15q��� -   $ ClearButton��$��
Сброс��#��[ ���#00FF$��15q�