   M S B A M L   `   `   `  ����  GermanyEuro2024_WPF3    -GermanyEuro2024_LuuQuangHoa.PlayerInformation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          N� 
Background
  ����  N� Title$ PlayerInformation��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� -   5        $��TbSearch��5      $
��Left=�6&    �� TextWrapping$
 Wrap=�6A   $��Center=�6U   $	��170��6p   $��26��6|   $��	105,0,0,0q�6�   �� 5      -   5        $��CbSearch��5   '   $��0��6   $
��Left=�67   $��Center=�6R   $��90��6m   $��26��6x   $��10,0,0,0q�6�   .@�5      �� -   5        $��CboxItemName��5       �� 
IsSelected$
 True��63   .��6E   	By Name6N   �� 5      -   5        $��CboxItemAchievement��5      .��6:   By Achievement6J   5      �� 5      -   5        $��	BtnSearch��5   %   $��0��6   $��Search��66   $
��Left=�6G   $��	280,0,0,0q�6b   $��Center=�6u   $��28��6�   $��70��6�   6�   �� 5      -   5        $��	SPanelAdd��5      $��1��6M    �� Orientation$ 
Horizontal=�6]   $��
104,0,57,0q�6v    � Cursor$
 Hand��6�   .+�5      �� -   5        $��ImageAdd��5      $��/Resource/Images/add.png��6(   $��34��6J   $��52��6V   �� 5      -	   5        $��TextBlockAdd��5      $��
Add Player��60   $��36��6B   $��24(�6N   $
��Bold"�6\   $	��216��6n   5       5"      &   System.Windows.Controls.DataGrid  5$   
   -
   5          Name$" DtgFootballPlayerInformation��5$      
���   �$
��Auto��6M   $	��400��6[   $��1��6k   $��10q�6x   	   AutoGenerateColumns$	 False��6�   
   CanUserAddRows$
 False��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&   
   ,  &System.Windows.Controls.DataGridColumn   Header$ 	Player ID��6      Width$ 1* 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *
PlayerID+6M     5'   
   $ Player Name��6   $ 2* 6Q    62   �� *
PlayerName+6Q     5(   
   $ Achievement��6   $ 3* 6R    62   �� *Achievement+   ElementStyle 5)      �� 5*       �� 
TargetType" ��6   .�5+      ��  �� Property � �� �� Value$
 Wrap=�65   5,      5.        5/   
   $ Date of Birth��6   $ 1* 6Q    64   �� *
Birthday+6Q     50   
   $ 
Team Title��6   $
 2.5* 6O    61   �� *	TeamTitle+6O   4  .System.Windows.Controls.DataGridTemplateColumn  51   
   $ Detail��6!   $ 1* 61      CellTemplate 52      �� 53      .R�54      �� -   5        $!��/Resource/Images/detail.png��54      $��30��6A   $��30��6L   $��5q�6X   $
 Hand��6�   
 � Tag 6c   �� *
PlayerID+6�   55      57      59      5=      5>      