   M S B A M L   `   `   `  ����V  RТЫндекс Музыка, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ТЫндекс_МузыкаТЫндекс_Музыка  5   	   ,    &ТЫндекс_Музыка.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ТЫндекс_Музыка     5   	     � Title$  
MainWindow��5	   	   $	��347��6   $	��316��6)   .��5
      �  J� RenderTransformOrigin$ 0.494,0.491&�6    � RowDefinitions 5   
   �� 5      $	��32* �6   �� 5      $	��32* �6   �� 5      $
��117* �6   �� 5      $	��98* �6   �� 5      $	��53* �6    � ColumnDefinitions 5   
   �� 5      $	��52* �6   �� 5      $	��52* �6   �� 5      $	��52* �6   �� 5      $	��52* �6   �� 5      $	��52* �6   �� 5      $
��109* �6   .+�5   
   �� -   5         ,  (MaterialDesignRaisedSecondaryLightButton#��[  5      $��Открыть файлы��5      $��Center=�5      $��32��5      $��6��6   $��1��6-   6:   �� 5   
   -   5        #��[  5       $��История��5!      $��Center=�5"      $��6��6(   6<   �� 5#   
   -   5         ��Name$ 	ListMusic��5#      $��2��6P   $��6��6]   6q   r� 5$   
   -   5         r�Name$ mediaElement��5$       r� LoadedBehavior$ Manual=�6-   �� 5%   
   -   5        $��MusicSlider��5&       � Minimum$ 0Q�5'       � Maximum$ 0Q�5(      	 � Value$	 0Q�5)      $��3��6   $��5��6$   68   �� 5*   
   -   5        
 ��Name$
 Volume��5*       �� Orientation$ Vertical=�5+      $ 0Q�5,      $	 3Q�5.         MaterialDesignDiscreteSlider#��[ 5/       �� TickPlacement$
 Both=�51      $��2��6$   $��5��61   $��3��6A   $
��Left=�6R   $��47��6m   $ 0.5,0.5&�6x   $��
46,116,0,0q�6�    5-      �� *DiscreteVertical.Maximum+ �� TickFrequency 50      �� * DiscreteVertical.TickFrequency+z�52      V� 53      .~�54      ��  �� ScaleX$ 1Q�6%   �� 55      �� 56      T� 57      58      5:      �� 5;   
   -   5        $��	PlayPause��5<        MaterialDesignIconButton#��[ 5>      $��Center=�5?      $��Center=�5@      $��38��5A      $��32��5B      $��4��5C      $��2��5D      .��5E      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $
��Play��5E   &      Kind$
 Play=�62   $��40��6>   $��40��6J   $��Center=�6U   $��Center=�6p   5F      �� 5G   
   -	   5        #��[ 5H      $��Center=�5I      $��Center=�5J      $��40��5K      $��32��5L      $��4��5M      $��3��5N      .��5P        $ SkipNext=�6&   $��40��66   $��40��6B   $��Center=�6M   $��Center=�6j   5Q      �� 5R   
   -
   5        #��[ 5S      $��Center=�5T      $��Center=�5U      $��40��5V      $��32��5W      $��4��5X      $��1��5Y      .��5[        $ SkipBackward=�6&   $��40��6:   $��40��6F   $��Center=�6Q   $��Center=�6n   5\      �� 5]   
   -   5        #��[ 5^      $��Center=�5_      $��Center=�5`      $��40��5a      $��32��5b      $��4��5c      .��5e        $ Refresh=�6&   $��40��65   $��40��6A   $��Center=�6L   $��Center=�6i   5f      �� 5g   
   -   5        #��[ 5h      $��Center=�5i      $��Center=�5j      $��40��5k      $��32��5l      $��4��5m      $��4��5n      .��5p        $ ShuffleVariant=�6&   $��40��6<   $��40��6H   $��Center=�6S   $��Center=�6p   5q      �� 5r   
   -   5         ��Name$ Music_label��5r      $��Center=�6%   $��3��6I   $�� ��6Y   $
��Left=�6d   $��3��6   $��Center=�6�   $��89��6�   $��3��6�   $��14(�6�   5s      5t      