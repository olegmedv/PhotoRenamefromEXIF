   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Photo Rename from EXIF��5   	   $	��450��6(   $��834.667��65    � Icon$ Martz90-Circle-Camera.ico��6\   .��5
      �� $��5q�6   .+�5   
   ]� ��. $��5,5,0,0q�6)   .+�5      �� -   5        $��lblFolderInput��5      $��Input folder:��6*   6D   �� 5      -   5        $��btnOpenFolderInput��5      $��       ...       ��6/   $��Right=�6K   $��5,0,0,0q�6b   6�   �� 5      -   5        $��txbFolderInput��5      $��10,0,0,0q�6,   $��Center=�6>   5      ]� 5   
   ��. $��5,5,0,0q�6)   .+�5      �� -   5        $��lblFolderOutput��5      $��Output folder:��6+   6F   �� 5      -   5        $��btnOpenFolderOutput��5      $��       ...       ��60   $��Right=�6L   $��5,0,0,0q�6c   6t   �� 5      -   5        $��txbFolderOutput��5      $��Center=�6-   6Q   5      �� 5   
   $��Folder options��6   $��Stretch=�6+   $��Stretch=�6P   .��5      ]� ��. .+�5      �� -   5         ��Name$ chbMakeFolders��5      $��Make folders��63    d� 	IsChecked$
 TrueY�6J   $��Center=�6[   $��5,0,0,0q�6�   �� 5      -	   5        $ chbMakeFoldersYear��5      $
��Year��67   $
 TrueY�6F   $��10,0,0,0q�6W   $��Center=�6i   �� 5      -
   5        $ chbMakeFoldersMonth��5      $��Month��68   $
 TrueY�6H   $��10,0,0,0q�6Y   $��Center=�6k   �� 5      -   5        $ chbMakeFoldersDay��5      $	��Day��66   $
 TrueY�6D   $��10,0,0,0q�6U   $��Center=�6g   �� 5      $��16��6   $	��Top=�6+   $��5��6C   $	��5,0q�6M   �� 5      -   5        $ chbDeleteOriginal��5      $��Delete original��66   $��0,0,0,0q�6P   $��Center=�6a   �� 5      $��16��6   $	��Top=�6+   $��5��6C   $	��5,0q�6M   �� 5      -   5        $ chbRenameOriginal��5      $��Rename original��66   $��0,0,0,0q�6P   $��Center=�6a   6|   5       5!      ]� 5"   
   ��. $��5,5,0,0q�6)   .+�5#      �� -   5        $��	BtnRename��5#      $��Rename��6&   $��Right=�67   $��5,0,0,0q�6N   $��26��6w   $��58��6�   6�   � 5$      -   5         �Name$ pBar1��5$      $��Center=�6)   5%      � 5'   
   -   5         �Name$ 	GridLists��5'       � ColumnDefinitions 5(      �� 5)      $��* �6#   �� 5*      $
��Auto �6#   �� 5+      $��* �6#    � RowDefinitions 5-      �� 5.      $
��Auto �6    �� 5/      �� 50      $
��Auto �6    �� 51      $��50 �6    .+�53      �� $��1��6   $��2��6+    �� ShowsPreview .  $��4��6Q   $��Center=�6[   $��Stretch=�6x   �� 54      -   5        	 ��Name$	 lblCountInput��54      $��Count: 0��6+   $��0��6>   $��0��6N   �� 55      -   5        $	 lblCountOutput��55      $��Count: 0��6,   $��2��6?   $��0��6O   �� 56      -   5        
 ��Name$
 ListViewInput��56      $
��Auto��6.   $
��Auto��6<   $��0��6I   $��1��6Y   $��Stretch=�6f   $��Stretch=�6�   6�   �� 57      -   5        $
 ListViewOutput��57      $
��Auto��6/   $
��Auto��6=   $��2��6J   $��1��6Z   $��Stretch=�6g   $��Stretch=�6�   6�   �� 58      $��3��6   $��3��6/    .  $��4��6Q   $��Stretch=�6[   �� 59      -   5        $	 lblCountFailed��59      $��	Failed: 0��6,   $��0��6@   $��2��6P   �� 5:      -   5        $
 ListViewFailed��5:      $
��Auto��6/   $
��Auto��6=   $��3��6J   $��3��6^   $��Stretch=�6k   $��Stretch=�6�   5;      5>      5B      