   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ONIX.WindowsONIX.Windows  #    ONIX.Windows.MessageBoxWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ONIX.Windows     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  MessageBoxWindow��$	��150��$	��450�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency . ��Z�  � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� .����  g� FillBehavior$ HoldEnd=� g� AutoReverse .  .��W�  �� TargetProperty$ Opacity�	 W� From$	 0X�	
 W� To$
 1X� g� Duration$ 0:0:0.3D�.��� .+�� -    �Name$
 Body�� � RowDefinitions �� $��* ��� $
��Auto �.+��� $	��0.5q����#EAEBEC �� CornerRadius$ 20��$��2�����#111111��  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ MessageIcon��$��30,20,0,0.2q�$��70��$��70���� -    ��Name$ TextView��$
��Wrap=�$
��Text��$��10,20,0,0.2q�$��18(����#111111$
��Left=�$	��330����Z� �� -    ��Name$ ManufacturerPanel��$ Vertical=�$y�	Collapsed=�$��10,20,0,0.2q�.+���    	TextStyle#��[  $5��/Добавление производителя�� �� TextAlignment$ Center=��� -    ��Name$ CountryComboBox��$	��300�� � ToolTip$+ %Страна производства�� �� DisplayMemberPath$
 Name���� -    ��Name$ NameManufacturerInput��$	��300��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$H BВведите наименование производителя�� �� 	MaxLength$ 50��$9 3Наименование производителя���� -   $ CategoryPanel��$ Vertical=�$y�	Collapsed=�$��10,20,0,0.2q�.+��� #��[  $:��4Добавление категории товара���� -   $ NameCategoryInput��$	��300��$@ :Введите наименование категории��$ 50��$1 +Наименование категории���� -	   $ 
CountPanel��$ Vertical=�$y�	Collapsed=�$��10,20,0,0.2q�.+��� -
   $ 	CountText��#��[  �� -   $ 
CountInput��$	��300��$) #Введите количество��$ 50���� -   $ TypeServicePanel��$ Vertical=�$y�	Collapsed=�$��10,20,0,0.2q�.+��� #��[  $:��4Добавление категории услуги���� -   $ NameTypeServiceInput��$	��300��$@ :Введите наименование категории��$ 50��$1 +Наименование категории���� -   $ ParametrPanel��$ Vertical=�$y�	Collapsed=�$��10,20,0,0.2q�.+��� -   $ ParametrText��#��[  $7��1Добавление характеристики��$ Center=��� -   $ NameParametrInput��$	��300��$J DВведите наименование характеристики��$ 50��$; 5Наименование характеристики���� -   $ DescriptionParametrInput��$	��300��$B <Введите значение характеристики��$	 100��$3 -Значение характеристики���� $ 
Horizontal=�$��1��$��Center=�$��Center=�.+��� -    ��Name$ 
SaveButton��  
MainButton#��[ $��Сохранить��$y�	Collapsed=�$	��120��$��30��$��
10,0,10,10q����#27a843���#EAEBEC���#00FF�� -   $ 	YesButton��$
��Да��#��[ $y�	Collapsed=�$	��100��$��30��$��
10,0,10,10q����#27a843���#EAEBEC
 J� Uid$ 1�����#00FF�� -   $ NoButton��$��Нет��$y�	Collapsed=�$	��100��$��30��#��[ ���#27a843���#EAEBEC$��
10,0,10,10q�$��Right=�$ 0�����#00FF�� -   $ CancelButton��$��Отмена��$y�	Collapsed=�#��[ $	��120��$��30��$��
10,0,10,10q����#27a843���#EAEBEC���#00FF