   M S B A M L   `   `   `  ���� ?  ;ONIX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ONIX.Pages
ONIX.Pages  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf     ONIX.Pages.MainPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:ONIX.Pages     DWpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� Title$5  /Деятельность организации��.��� .+�� -    �Name$ 
ReportGrid�� � RowDefinitions �� $	��200 ��� $��* �.+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+�#  MaterialDesignThemes.Wpf.Card  $��5q�$	��170��$	��325������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFD89B65�� � Offset$ 1Q�� $ #ED3F3C��.���� $ Vertical=�.+���    	TextStyle#��[  $#��Выбор диапазона��$
��Auto�����	#DDF9F9F9$��25(�$
��Auto���� $ 
Horizontal=�.+��� #��[  $��Период с��$��80�����	#DDF9F9F9$
��Auto��(  "System.Windows.Controls.DatePicker  -     Name$ DateFrom���� $ 
Horizontal=�.+��� #��[  $��Период по��$��80�����	#DDF9F9F9$
��Auto��  -   $ DateTo��  $��5q�$	��170��$	��325������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFD89B65��$ 1Q�� $ #ED3F3C��.���� $ Vertical=�.+��� #��[  $��Общая прибыль��$
��Auto�����	#DDF9F9F9$��25(�$
��Auto���� $ 
Horizontal=�.+��� -   	 ��Name$	 TotalProfitText��#��[  $
��Auto�����	#DDF9F9F9$��25(�$
��Auto���� #��[  $%��Данные актуальны��$
��Auto�����	#DDF9F9F9$
��Auto��  $��5q�$	��170��$	��325������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFD89B65��$ 1Q�� $ #ED3F3C��.���� $ Vertical=�.+��� #��[  $(��"Прибыль по товарам��$
��Auto�����	#DDF9F9F9$��25(�$
��Auto���� $ 
Horizontal=�.+��� -   $	 GoodProfitText��#��[  $
��Auto�����	#DDF9F9F9$��25(�$
��Auto���� #��[  $%��Данные актуальны��$
��Auto�����	#DDF9F9F9$
��Auto���� $ 
Horizontal=�$��1��.+��� $ Vertical=�.+��� #��[  $]��WКоличество успешных сделок по продажам товаров��$
��Auto��$
��Auto��$��Center=�#  LiveCharts.Wpf.CartesianChart  -   
  Name$
 CartesianChartDiagram��$	��700��$	��290��$
��Left=�&   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=��� $ Vertical=�.+��� #��[  $4��.Самые продаваемые товары��$
��Auto��$
��Auto��$��Center=�  LiveCharts.Wpf.PieChart  -     Name$ PieChartDiagram��$
 None=�$	��290��$	��290�� � ContextMenu �� .@�m� -	    m�Name$ TopThreeItem��$4��.Топ 3 продаваемых товаров��m� -
   $ TopFiveItem��$4��.Топ 5 продаваемых товаров��m� -   $ 
TopTenItem��$5��/Топ 10 продаваемых товаров��