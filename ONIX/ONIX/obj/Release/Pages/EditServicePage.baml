   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages       ONIX.Pages.EditServicePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:ONIX.Pages     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$'  !Добавление услуги��.��� .+��� -    ��Name$ ShowServicePanel��$��Disabled=�$
��Auto=�$��Center=�$y�	Collapsed=�.��� -    �Name$ 	PrintGrid��.+���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� -    ��Name$ PreviewImage��$+��%/ONIX;component/Resources/noimage.png��$	��350��$	��350��$��20q�$
��Left=��� $ Vertical=�.+��� -    ��Name$ NameText��   	TextStyle#��[  $	��550��$��80��$��25(�$
��Bold"�$
��Wrap=�$	��Top=�$��20q��� -   $ DescriptionText��#��[  $	��550��$
��Auto��$��17(�$
��Wrap=�$	��Top=�$��5q��� -   $ TypeServiceText��#��[  $	��550��$
��Auto��$��17(�$
��Wrap=�$	��Top=�$��5q��� -   $ 	PriceText��#��[  $	��550��$
��Auto��$��17(�$
��Wrap=�$	��Top=�$��5q��� -   $ EditServicePanel��$��Disabled=�$
��Auto=�$��Center=�$y�	Collapsed=�.��� .+��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $ Vertical=�$��Center=�$	��Top=�.+��� -	   $ EditPreviewImage��$	��350��$	��350��$��20q��� -
    ��Name$ AddPhotoButton��$��Добавить фото�����#111111���#111111�� $ Vertical=�.+��� -    ��Name$ 	NameInput��$	��550��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$2 ,Введите название услуги��$
��Auto��$��25(�	 � ToolTip$#	 Название услуги��$
��Bold"�
 �� TextWrapping$

 Wrap=�$	��Top=�$��20q� �� 	MaxLength$	 100���� -   $ DescriptionInput��$	��550��$2 ,Введите описание услуги��$
��Auto��$��17(�$
 1000��$#	 Описание услуги��$

 Wrap=�$	��Top=�$��5q��� $ 
Horizontal=�$��	15,20,5,5q�.+��� -    ��Name$ TypeServiceComboBox��$	��505��$%	 Категория услуги��$��17(�$	��Top=� �� DisplayMemberPath$
 Name���� -   $ AddTypService��$��40�����#27a843$��40�� & "MaterialDesignFloatingActionButton#��[ ���#00FF.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�$��30��$��30���� -   $ 
PriceInput��$	��550��$
��Auto��$��17(�$	 Цена товара��$

 Wrap=�$	��Top=�$��5q�$ Введите цену���� -   $ NDSInput��$	��550��$
��Auto��$��17(�$	 НДС товара��$

 Wrap=�$	��Top=�$��5q�$ Введите НДС���� $ 
Horizontal=�.+��� -   $ 
BackButton��  MaterialDesignIconButton#��[ $
��Left=����#00FF���#00FF���#00FF$	��Top=�$��5,5,0,0q�$��30��$��30��.��  $ 	ArrowBack=����#111111$��30��$��30���� -   $ 
SaveButton��#��[ $
��Left=����#00FF���#00FF���#00FF$	��Top=�$��5,5,0,0q�$��30��$��30��.��  $ ContentSave=����#111111$��30��$��30���� -   $ PrintButton��#��[ $
��Left=����#00FF$y�	Collapsed=����#00FF���#00FF$	��Top=�$��5,5,0,0q�$��30��$��30��.��  $ Printer=����#111111$��30��$��30��