   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ONIX.WindowsONIX.Windows  &     ONIX.Windows.AuthorizationWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ONIX.Windows     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$
  OXIX��$	��620��$
��1080�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � Icon$( "/ONIX;component/Resources/logo.ico��.��� -   ����  �� ImageSource$. (/ONIX;component/Resources/background.png�� � RowDefinitions �� $��20 ��� $
��147* ��� $
��454* �.+���  �� Orientation$ 
Horizontal=�$��0��$��Right=�$��Center=�$	��0,2q�.+��� -    ��Name$ CloseButton��$��16��$��16��$��Right=�$	��Top=� &  "MaterialDesignFloatingActionButton#��[  $��2q�
�������
���������Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Close=�$��14��$��14��� $��1��$��2������ 
 j� Stretch$
 UniformToFill=�.+��� $	��500��$��Center=� �� CornerRadius$ 180,0,180,0�����#181418$��	0,37,0,50q�$��1���� $ 
Horizontal=�$��2��.+��� $	��490��$��Center=�.+��� $	��300��$	��300��$��Center=�$��Center=�$��Uniform=�$(��"/ONIX;component/Resources/logo.PNG���� $	��490��$��Center=�.+��� $��40 85q�.+��� $��Авторизация��$��20q�
������� �� TextAlignment$ Center=�$��50(�$2��,/Britanica Timetable;component/Fonts/#Neucha)��� $ 
Horizontal=�$��20q�$��Center=�.+�  $
	 User=�$��40��$��40��
��������� -    ��Name$ 
LoginInput��$
��10 0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��
�������$	��300��$��40��$��20(�$��Bottom=�$2��,/Britanica Timetable;component/Fonts/#Neucha)�
������� �� 
CaretBrush
 ����� �� SelectionBrush
 ������� $ 
Horizontal=�$��20q�$��Center=�.+�  $
	 Lock=�$��40��$��40��
�������G� -    G�Name$ PasswordInput��$
��10 0q�$ ********��
�������$	��300��$��40��$��20(�$��Bottom=�$2��,/Britanica Timetable;component/Fonts/#Neucha)�
������� G� 
CaretBrush
 ����� G� SelectionBrush
 ������� $��20q�$��Center=�.+��� -   $ LoginButton��$	��150��$��40��  MaterialDesignRaisedButton#��[ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��$��25(�$��2q����#ED3F3C���#ED3F3C
������� � ToolTip$ Вход��$��Вход��