   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages      ONIX.Pages.EditGoodPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:ONIX.Pages     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� Title$#  Просмотр товара��.��� .+��� -    ��Name$ ShowGoodPanel��$��Disabled=�$
��Auto=�$y�	Collapsed=�.��� -    �Name$ 	PrintGrid��.+���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� -    ��Name$ PreviewImage��$+��%/ONIX;component/Resources/noimage.png��$	��350��$	��350��$��20q�$
��Left=��� $ Vertical=�.+��� -    ��Name$ NameText��   	TextStyle#��[  $	��550��$��80��$��25(�$
��Bold"�$
��Wrap=�$	��Top=�$��20q��� -   $ DescriptionText��#��[  $	��550��$
��Auto��$��17(�$
��Wrap=�$	��Top=�$��5q��� -   $ CountryText��#��[  $	��550��$
��Auto��$��17(�$
��Wrap=�$	��Top=�$��5q��� -   $ ManufacturerText��#��[  $	��550��$
��Auto��$��17(�$
��Wrap=�$	��Top=�$��5q��� -	   $ CategoryText��#��[  $	��550��$
��Auto��$��17(�$
��Wrap=�$	��Top=�$��5q��� -
    ��Name$ SertificatePanel��$ 
Horizontal=�.+��� -   $ SertificateText��#��[  $
��Auto��$
��Auto��$��17(�$,��&Сертификат качество:��$
��Wrap=�$	��Top=�$��20,5,5,5q��� #��[  $
��Auto��$
��Auto��$��17(�$
��Wrap=�$��	Underline{�$	��Top=�$��5q��� -    ��Name$ SertificateLink��.�Скачать�� -   $ TechnicalDataSheetPanel��$ 
Horizontal=�.+��� -   $ TechnicalDataSheetText��#��[  $
��Auto��$
��Auto��$,��&Технический паспорт:��$��17(�$
��Wrap=�$	��Top=�$��20,5,5,5q��� #��[  $
��Auto��$
��Auto��$��17(�$
��Wrap=�$��	Underline{�$	��Top=�$��5q��� -   $ TechnicalDataSheetLink��.�Скачать�� -   $ InstructionPanel��$ 
Horizontal=�.+��� -   $ InstructionText��#��[  $
��Auto��$
��Auto��$9��3Инструкция по эксплуатации:��$��17(�$
��Wrap=�$	��Top=�$��20,5,5,5q��� #��[  $
��Auto��$
��Auto��$��	Underline{�$��17(�$
��Wrap=�$	��Top=�$��5q��� -   $ InstructionLink��.�Скачать�� -   $ 	PriceText��#��[  $	��550��$
��Auto��$��17(�$
��Wrap=�$	��Top=�$��5q�&   System.Windows.Controls.DataGrid  -     Name$ ParametrDataGrid��	   AutoGenerateColumns	 .  
   CanUserAddRows
 .  $��20q�   
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$" Характеристика��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Значение��$ *  �� *Description+�� -   $ EditGoodPanel��$��Disabled=�$
��Auto=�$y�	Collapsed=�.��� .+��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $ Vertical=�$��Center=�$	��Top=�.+��� -   $ EditPreviewImage��$	��350��$	��350��$��20q��� -    ��Name$ AddPhotoButton��$��Добавить фото�����#111111���#111111�� $ Vertical=�.+��� -    ��Name$ 	NameInput��$	��550��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$2 ,Введите название товара��$
��Auto��$��25(� � ToolTip$# Название товара��$
��Bold"� �� TextWrapping$
 Wrap=�$	��Top=�$��20q� �� 	MaxLength$	 100���� -   $ DescriptionInput��$	��550��$2 ,Введите описание товара��$
��Auto��$��17(�$
 1000��$# Описание товара��$
 Wrap=�$	��Top=�$��5q��� $ 
Horizontal=�.+��� -    ��Name$ CategoryComboBox��$	��505��$% Категория товара��$��17(�$	��Top=�$��	20,20,5,5q� �� DisplayMemberPath$
 Name���� -   $ AddCategory��$��40�����#27a843$��40�� & "MaterialDesignFloatingActionButton#��[ ���#00FF.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�$��30��$��30���� $ 
Horizontal=�.+��� -   $ ManufacturerComboBox��$	��505��$��17(�$- 'Производитель товара��$	��Top=�$��20,5,5,5q�$
 Name���� -   $ AddManufacturer��$��40�����#27a843$��40��#��[ ���#00FF.��  $	 Add=�$��30��$��30���� $ 
Horizontal=�.+��� #��[  $��17(�$	��260��$,��&Сертификат качества:��$
��Wrap=�$	��Top=�$��20,5,5,5q��� -   $ SertificateButton_1��#��[  $��17(�$
��Auto��$
��Wrap=�$��	Underline{�$	��Top=��� -   $ SertificateSave��.�Скачать�� #��[  $��17(�$
��Auto��$
��Wrap=�$��	Underline{�$	��Top=��� -    $ SertificateLoad��.�Загрузить�� -!   $ SertificateButton_2��#��[  $��17(�$
��Auto��$
��Wrap=�$��	Underline{�$	��Top=��� -"   $ SertificateDelete��.�Удалить�� $ 
Horizontal=�.+��� #��[  $��17(�$,��&Технический паспорт:��$
��Wrap=�$	��260��$	��Top=�$��20,5,5,5q��� -#   $  TechnicalDataSheetButton_1��#��[  $��17(�$
��Auto��$
��Wrap=�$��	Underline{�$	��Top=��� -$   $ TechnicalDataSheetSave��.�Скачать�� #��[  $��17(�$
��Auto��$
��Wrap=�$��	Underline{�$	��Top=��� -%   $ TechnicalDataSheetLoad��.�Загрузить�� -&   $  TechnicalDataSheetButton_2��#��[  $��17(�$
��Auto��$
��Wrap=�$��	Underline{�$	��Top=��� -'   $ TechnicalDataSheetDelete��.�Удалить�� $ 
Horizontal=�.+��� #��[  $��17(�$9��3Инструкция по эксплуатации:��$	��260��$
��Wrap=�$	��Top=�$��20,5,5,5q��� -(   $ InstructionButton_1��#��[  $��17(�$
��Auto��$
��Wrap=�$��	Underline{�$	��Top=��� -)   $ InstructionSave��.�Скачать�� #��[  $��17(�$
��Auto��$
��Wrap=�$��	Underline{�$	��Top=��� -*   $ InstructionLoad��.�Загрузить�� -+   $ InstructionButton_2��#��[  $��17(�$
��Auto��$
��Wrap=�$��	Underline{�$	��Top=��� -,   $ InstructionDelete��.�Удалить�� --   $ 
PriceInput��$	��550��$
��Auto��$��17(�$ Цена товара��$
 Wrap=�$	��Top=�$��5q�$ Введите цену���� -.   $ NDSInput��$	��550��$
��Auto��$��17(�$ НДС товара��$
 Wrap=�$	��Top=�$��5q�$ Введите НДС��  -/   $ EditParametrDataGrid��	 .  
 .  $��20q� .    $" Характеристика��$ *  �� *Name+  $ Значение��$ *  �� *Description+�� $ 
Horizontal=�$��Right=�$��Center=�$��5,5,20,5q�.+��� -0   $ DeleteButton�� * &MaterialDesignFloatingActionMiniButton#��[ ���#00FF$��5q����#FF0000.��  $ Delete=�$��30��$��30���� -1   $ 
EditButton��#��[ ���#0099CC$��5q����#00FF.��  $
 Edit=�$��30��$��30���� -2   $ 	AddButton��#��[ ���#00FF$��5q����#27a843.��  $	 Add=�$��30��$��30���� $ 
Horizontal=�.+��� -3   $ 
BackButton��  MaterialDesignIconButton#��[ $
��Left=����#00FF���#00FF���#00FF$	��Top=�$��5,5,0,0q�$��30��$��30��.��  $ 	ArrowBack=����#111111$��30��$��30���� -4   $ 
SaveButton��#��[ $
��Left=����#00FF���#00FF���#00FF$	��Top=�$��5,5,0,0q�$��30��$��30��.��  $ ContentSave=����#111111$��30��$��30���� -5   $ PrintButton��#��[ $
��Left=����#00FF$y�	Collapsed=����#00FF���#00FF$	��Top=�$��5,5,0,0q�$��30��$��30��.��  $ Printer=����#111111$��30��$��30��