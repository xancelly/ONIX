   M S B A M L   `   `   `  ����?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ONIX.WindowsONIX.Windows  5   	   &     ONIX.Windows.AuthorizationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ONIX.Windows     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$
  OXIX��5	   	   $	��620��5
   	   $
��1080��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � Icon$( "/ONIX;component/Resources/logo.ico��5   	   .��5      � -   5        ��5   
   �� 5       �� ImageSource$. (/ONIX;component/Resources/background.png��6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��147* �6   �� 5      $
��454* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��5      $��Right=�5      $��Center=�5      $	��0,2q�5      .+�5       �� -   5         ��Name$ CloseButton��5       $��16��5!      $��16��5"      $��Right=�5$      $	��Top=�5%       &  "MaterialDesignFloatingActionButton#��[  5&      $��2q�5(      
�������
���������5'      Z� .��5+      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Close=�6*   $��14��5,   *   $��14��5-   *   5.      5/      � 51   
   $��1��6   $��2��52      ��53      �� 54      
 j� Stretch$
 UniformToFill=�6   .+�57      �� $	��500��6   $��Center=�58       �� CornerRadius$ 180,0,180,0��59      ���#181418$��	0,37,0,50q�5;      $��1��5<      5>      �� 5@      $ 
Horizontal=�6   $��2��5A      .+�5B      �� $	��490��6   $��Center=�5C      .+�5D      �� $	��300��6   $	��300��5E      $��Center=�5F      $��Center=�5G      $��Uniform=�5H      $(��"/ONIX;component/Resources/logo.PNG��5I      5J      �� 5L      $	��490��6   $��Center=�5M      .+�5N      �� $��40 85q�6!   .+�5O      �� $��Авторизация��6$   $��20q�5P   $   
������� �� TextAlignment$ Center=�5R   $   $��50(�5S   $   $2��,/Britanica Timetable;component/Fonts/#Neucha)�5T   $   �� 5U      $ 
Horizontal=�6%   $��20q�5V   %   $��Center=�5W   %   .+�5X        $
	 User=�66   $��40��5Y   6   $��40��5Z   6   
�������5[   6   �� 5\      -   5         ��Name$ 
LoginInput��5]   &   $
��10 0q�5\   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��5^   &   
�������$	��300��5`   &   $��40��5a   &   $��20(�5b   &   $��Bottom=�5c   &   $2��,/Britanica Timetable;component/Fonts/#Neucha)�5d   &   
������� �� 
CaretBrush
 ����� �� SelectionBrush
 �����5g   &   5h      �� 5j      $ 
Horizontal=�6%   $��20q�5k   %   $��Center=�5l   %   .+�5m        $
	 Lock=�66   $��40��5n   6   $��40��5o   6   
�������5p   6   G� 5q      -   5         G�Name$ PasswordInput��5v   *   $
��10 0q�5q   *   $ ********��5r   *   
�������$	��300��5t   *   $��40��5u   *   $��20(�5w   *   $��Bottom=�5x   *   $2��,/Britanica Timetable;component/Fonts/#Neucha)�5y   *   
������� G� 
CaretBrush
 ����� G� SelectionBrush
 �����5|   *   5}      �� 5      $��20q�6%   $��Center=�5�   %   .+�5�      �� -   5        $ LoginButton��5�   %   $	��150��5�   %   $��40��5�   %     MaterialDesignRaisedButton#��[ 5�   %   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5�   %   $��25(�5�   %   $��2q�5�   %   ���#ED3F3C���#ED3F3C
������� � ToolTip$ Вход��5�   %   $��Вход��5�   %   5�      5�      5�      5�      5�      5�      5�      5�      