   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework  5   	   I EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel 5   	   #   MoneyInTheBank.View.LoginView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5   	   5vm&clr-namespace:MoneyInTheBank.ViewModel     5   	   -   5           PRBD_Framework.WindowBase   Name$  window��5   	    � Title$ Login��5
   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�5   F   $	��284��5   	   $	��411��6    � SizeToContent$ WidthAndHeight=�5   	   
����ح� J� Opacity$ 1Q�6?    +� FocusedElement 5   	   ��  �� ElementName$ txtEmail�� � DataContext 5      -  'MoneyInTheBank.ViewModel.LoginViewModel  5   
   -   5        vm��5      .��5      � $��10q�6   	 � ColumnDefinitions	 5   
   �� 5      $
��auto �6   �� 5      $��2* �6   
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $��20��6*   �� 5      $
��Auto �6   $��0��6*   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ label��5      $��Email��6   $	��Top=�6/   $��5q�6G   $��2��6S   $��10,48,216,0q�6g   $��4��6|   $��26��6�   �� 5   
   -   5         ��Name$ txtEmail��5       �� TextWrapping$
 Wrap=�6$   $	��Top=�68   $��2��5    k   $��
10,79,10,0q�6   $��4��6�   $��33��6�   ��6   �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5!   
   $��Password��6   $��4��6#   $	��Top=�60   $��5q�6H   $��2��6T   $��10,131,194,0q�6h   $��26��6~   G� 5"   
   -   5         G�Name$ txtPassword��5"      #   PRBD_Framework.PasswordHelper   Attach$
 True��5#      $��4��5%      $	��Top=�6#   $��2��6[   $��10,162,10,0q�6o   $��35��6�      Password 5$      �� *
Password+$ PropertyChanged=�5%   �   ]� 5&   
   $��2��6   $��Center=�6!   $��Center=�6<   $��1��6Y   $��0��6i   $��0��6t   ]� 5'   
   $��3��6   $��2��6!   $��	0,0,0,313q�65   $��2��6H   5(      �� 5)   
   -   5         ��Name$ 	btnCancel��5)      $��Cancel��6$   $��Center=�5*      $	��Top=�62   $	��146��6J    �� IsCancel$
 True��6V   $��1��5+   -   $��
0,279,0,50q�6=   $��4��6Q   $��34��6^   �� 5,   
   -   5        $ btnLogin��5,      $��Login��6#   $��Center=�5-      $	��Top=�62   $	��146��6J    �� 	IsDefault$
 True��6V   $��	0,225,0,0q�6g   $��4��5.   6   $��38��6C   $��1��6O   ��6   �� *LoginCommand+6O   �� 5/   
   $��Welcome!��6   $��Center=�6#   $��38��6@   $��0,13,0,0q�6L   $��2��6^   $	��Top=�6k   $	��120��6�   $��1��6�   $��25(�6�   $��3��6�   50      51      