   M S B A M L   `   `   `  ����D  @Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Interface	Interface  5      $    Interface.BasicInformationView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -	ViewModelclr-namespace:Interface     5        � DataContext  5	      "   Interface.CharacterViewModel  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��	Character��6   $��0��6%   $��0��65   �� 5   
   $��1��6=   $��7��6M   $��0��6a   ��6   �� *Name+ �� Mode$ OneWayToSource=�6a   �� 5    
   $��Align.��6   $��0��6"   $��1��62   �� 5!   
   $��1��6<   $��1��6L   ��6   �� *	Alignment+$ OneWay=�6L   �� 5"   
   $
��Race��6   $��2��6    $��1��60   �� 5#   
   $��3��6P   $��1��6`   ��6   ��  �� Path$ CharacterModel.Race.Name�$ OneWay=�6`   �� 5$   
   $��Class��6   $��4��6!   $��1��61   �� 5%   
   $��5��6Q   $��1��6a   ��6   �� $ CharacterModel.Class.Name�$ OneWay=�6a   �� 5&   
   $��Level��6   $��6��6!   $��1��61   �� 5'   
   $��7��6L   $��1��6\   ��6   �� $ CharacterModel.Level�$ OneWay=�6\   �� 5(   
   $	��Sex��6   $��0��6   $��2��6/   �� 5)   
   $��1��6O   $��2��6_   ��6   �� $ CharacterModel.Sex.Name�$ OneWay=�6_   �� 5*   
   $	��Age��6   $��2��6   $��2��6/   �� 5+   
   $��3��6J   $��2��6Z   ��6   �� $ CharacterModel.Age�$ OneWay=�6Z   �� 5,   
   $	��Ht.��6   $��0��6   $��3��6/   �� 5-   
   $��1��69   $��3��6I   ��6   �� *Height+$ OneWay=�6I   �� 5.   
   $	��Wt.��6   $��2��6   $��3��6/   �� 5/   
   $��3��6M   $��3��6]   ��6   �� $ CharacterModel.Weight�$ OneWay=�6]   �� 50   
   $��Reaction adjustment��6   $��0��6/   $��4��6?   �� 51   
   $��1��6^   $��4��6n   ��6   �� $, &CharacterModel.MaximumNumberOfHenchmen�$ OneWay=�6n   52      53      