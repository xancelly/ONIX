   M S B A M L   `   `   `  ����?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	          ONIX.Pages.GoodPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:ONIX.Pages     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .s&clr-namespace:System;assembly=mscorlib  5	      X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5          N� Title$  Товары��5       � 	Resources 5         
OpenFilter �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  CloseFilter��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ 
FilterGrid��5   ,   .\�5        $ 0��6'   $ 30Q�5   '     5      $ 0:0:0.2��6'   $	 250Q�5   '   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ 
FilterGrid��5   ,   .\�5        $ 0��6'   $	 250Q�5   '     5      $ 0:0:0.1��6'   $ 30Q�5    '   5!      5"      5#       � Triggers 5&      :� 5'   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ OpenFilterButton��5(      .[�5)      �� #��[  6   5*      :� 5+   
   $ ButtonBase.Click��6   $ CloseFilterButton��5,      .[�5-      �� #��[ 6   5.      .��51      � 	 � ColumnDefinitions	 52   
   �� 53      $��* �6   �� 54      $��30 �6   
 � RowDefinitions
 56   
   �� 57      $��50 �6   �� 58      $��* �6   �� 59      $��40 �6   .+�5<   
   ��  �� Orientation$ 
Horizontal=�6   $��0��5=      $��0��5>      .+�5?      �� -   5         ��Name$ 
BackButton��5?      ���#111111$y�	Collapsed=�5B        MaterialDesignIconButton#��[ 5C      .��5D      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��6*   $��30��5E   *      Kind$ 	ArrowBack=�5F   *   5G      �� 5H      $��
Поиск��6     	TextStyle#��[ 5I      �� 5J      -   5         ��Name$ SearchTextBox��5J      5K      5L      �� 5N   
   -   5         ��Name$ GoodListView��5O      $��1��5N      $��0��5P      $��Disabled=�5R      ��5S      �� 5T      .R�5U      �� $ Vertical=�6!   $	��160��5V   !   $	��280��5W   !   $��5q�5X   !   .+�5Y      �� $��5q�6    $	��150��5Z       $	��150��5[       ��5\       �� *
GetImage+�� 5]      #��[ 6$   $
��Auto��5^   $   $��70��5_   $   $��12(�5`   $    �� TextAlignment$ Center=�5a   $   $
��Wrap=�5b   $   $��5q�5c   $   ��5d   $   �� *Name+�� 5e      #��[ 6$   $
��Auto��5f   $   $ Center=�5g   $   $
��Bold"�5h   $   $��30��5i   $   $��5q�5j   $   ��5k   $   �� *GetLastPrice+5l      5m      ��5o      �� 5p      .R�5q      �  � Orientation$ 
Horizontal=�6    5r      5t      �� 5v   
   $ 
Horizontal=�6   $
��Left=�5w      $��Center=�5x      $��2��5y      .+�5z      �� -   5         ��Name$ RecordsCountText��5~      $
��Auto��5z      $
��Auto��5{      $��12(�5|      #��[ 5}      5~      5      �� 5�   
   $ 
Horizontal=�6   $��Right=�5�      $��Bottom=�5�      $��1��5�      $��2��5�      $��	0,0,70,50q�5�      .+�5�      �� -   5        $ DeleteButton��5�       * &MaterialDesignFloatingActionMiniButton#��[ 5�      ���#00FF$��5q�5�      ���#FF0000.��5�        $ Delete=�6*   $��30��5�   *   $��30��5�   *   5�      �� 5�      -   5        $ 
EditButton��5�      #��[ 5�      ���#0099CC$��5q�5�      ���#00FF.��5�        $
 Edit=�6*   $��30��5�   *   $��30��5�   *   5�      �� 5�      -   5        $ 	AddButton��5�      #��[ 5�      ���#00FF$��5q�5�      ���#27a843.��5�        $	 Add=�6*   $��30��5�   *   $��30��5�   *   5�      5�      � 5�   
   -	   5         �Name$ 
FilterGrid��5�      $��30��5�      ���#EAEBEC$	��Top=�5�      $��0��5�      $��0��5�      $��Right=�5�      $��2��5�      $��3��5�       J� Effect 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�5�   #      Color$ 	LightGray��5�   #   .+�5�      �� .+�5�      �� 
�������$��1q�5�      ._�5�      � $	��545��6    J� RenderTransformOrigin$ 0.5,0.5&�5�      z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "   5�      .+�5�      �� $ Vertical=�6%   .+�5�      �� -
   5        $ OpenFilterButton��5�   %   $��50��5�   %   $��30��5�   %   $��Right=�5�   %   $��Center=�5�   %    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5�   %   $��2q�5�   %   ���#111111��5�   %   Z� ��5�   %   Z� .��5�   "     $ Filter=�6:   $��18��5�   :   $��18��5�   :   5�      �� 5�      -   5        $ CloseFilterButton��5�   %   $y�	Collapsed=�5�   %   $��50��5�   %   $��30��5�   %   $��Right=�5�   %   $��Center=�5�   %   #��[ 5�   %   ���#111111��5�   %   Z� ��5�   %   Z� .��5�   "     $ FilterMinus=�6:   $��18��5�   :   $��18��5�   :   5�      �� 5�      -   5         ��Name$ FilterFields��5�   )   $ Vertical=�5�   )   $y�	Collapsed=�5�   )   .+�5�   "   �� $��Категория��6,   #��[ 5�   ,   �� 5�   "   -   5         ��Name$ CategoryComboBox��5�   +    �� DisplayMemberPath$
 Name��5�   +   �� 5�   "   $ ��Производитель��6,   #��[ 5�   ,   �� 5�   "   -   5        $ ManufacturerComboBox��5�   +   $
 Name��5�   +   5�   +   �� 5�   "   $��Цена��6,   #��[ 5�   ,   �� 5�   "   $ 
Horizontal=�6-   .+�5�   &   �� -   5        $ PriceFromInput��5�   /   $	��114��5�   :    �� 	MaxLength$ 10��5�   :    � ToolTip$% Минимальная цена��5�   :   $
��Left=�5�   :   5�   :   �� 5�   &   -   5        $ PriceToInput��5�   /   $	��114��5�   :   $ 10��5   :   $' !Максимальная цена��5  :   $��Right=�5  :   5  :   5  #   �� 5  "   -   5        $ PriceListButton��5  )   $(��"Печать прайс-листа��5  )   ���#00FF  
MainButton#��[ 5	  )   $��15q�5
  )   5  )   �� 5  "   -   5        $ ClearButton��5  )   $��
Сброс��5  )   #��[ 5  )   ���#00FF$��15q�5  )   5     5     5     5     5     5     5     5     