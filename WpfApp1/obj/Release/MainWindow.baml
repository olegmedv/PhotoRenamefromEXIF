   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1      WpfApp1.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp1     -     � Title$  Photo Rename from EXIF��$	��450��$��834.667�� � Icon$ Martz90-Circle-Camera.ico��.���� $��5q�.+�]� ��. $��5,5,0,0q�.+��� -   $��lblFolderInput��$��Input folder:���� -   $��btnOpenFolderInput��$��       ...       ��$��Right=�$��5,0,0,0q��� -   $��txbFolderInput��$��10,0,0,0q�$��Center=�]� ��. $��5,5,0,0q�.+��� -   $��lblFolderOutput��$��Output folder:���� -   $��btnOpenFolderOutput��$��       ...       ��$��Right=�$��5,0,0,0q��� -   $��txbFolderOutput��$��Center=��� $��Folder options��$��Stretch=�$��Stretch=�.��]� ��. .+��� -    ��Name$ chbMakeFolders��$��Make folders�� d� 	IsChecked$
 TrueY�$��Center=�$��5,0,0,0q��� -	   $ chbMakeFoldersYear��$
��Year��$
 TrueY�$��10,0,0,0q�$��Center=��� -
   $ chbMakeFoldersMonth��$��Month��$
 TrueY�$��10,0,0,0q�$��Center=��� -   $ chbMakeFoldersDay��$	��Day��$
 TrueY�$��10,0,0,0q�$��Center=��� $��16��$	��Top=�$��5��$	��5,0q��� -   $ chbDeleteOriginal��$��Delete original��$��0,0,0,0q�$��Center=��� $��16��$	��Top=�$��5��$	��5,0q��� -   $ chbRenameOriginal��$��Rename original��$��0,0,0,0q�$��Center=�]� ��. $��5,5,0,0q�.+��� -   $��	BtnRename��$��Rename��$��Right=�$��5,0,0,0q�$��26��$��58��� -    �Name$ pBar1��$��Center=�� -    �Name$ 	GridLists�� � ColumnDefinitions �� $��* ��� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� �� $
��Auto ��� $��50 �.+��� $��1��$��2�� �� ShowsPreview .  $��4��$��Center=�$��Stretch=��� -   	 ��Name$	 lblCountInput��$��Count: 0��$��0��$��0���� -   $	 lblCountOutput��$��Count: 0��$��2��$��0���� -   
 ��Name$
 ListViewInput��$
��Auto��$
��Auto��$��0��$��1��$��Stretch=�$��Stretch=��� -   $
 ListViewOutput��$
��Auto��$
��Auto��$��2��$��1��$��Stretch=�$��Stretch=��� $��3��$��3�� .  $��4��$��Stretch=��� -   $	 lblCountFailed��$��	Failed: 0��$��0��$��2���� -   $
 ListViewFailed��$
��Auto��$
��Auto��$��3��$��3��$��Stretch=�$��Stretch=�