   M S B A M L   `   `   `  ����O  KWeatherWindowsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WeatherWindowsClientWeatherWindowsClient  5   	   %    WeatherWindowsClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WeatherWindowsClient     5   	     � Title$  Weather��5   	   $	��450��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��Страна��6   $��0��6!   $��0��61   �� 5   
   $��Регион��6   $��0��6!   $��1��61   �� 5   
   $��
Город��6   $��0��6    $��2��60   �� 5   
   $��1��6   $��0��5       �� 
IsEditable$
 True��5      ��5      �� *	Countries+ �� SelectedItem 5      �� *SelectedContry+ �� Text 5      �� *CurrentCountry+�� 5   
   $��1��6   $��1��5       $
 True��5!      ��5"      �� *	Regions+ 5#      �� *SelectedRegion+ 5$      �� *CurrentRegion+�� 5%   
   $��1��6   $��2��5&      $
 True��5'      ��5(      �� *Cities+ 5)      �� *SelectedCity+ 5*      �� *CurrentCity+�� 5+   
   -   5        $��2��5+      $��3��6&   $!��Прогноз погоды��63   6L   �� 5,   
   $��2��6+   $��4��6?   ��6   �� *Status+6?   �� 5-   
   $��2��6   $��5��6'   ��64   �� *WeatherForTime+ �� View 5.      �� 5/      .P�50      ��  �� DisplayMemberBinding 6%   ��  �� Path$
 Time�.��6P   
Дата6V   �� 51       6%   �� $ Weather.Temp�.��6X   Температура6e   �� 52       6%   �� $
 Time�.��6P   
Цена6V   53      55      56      57      