   M S B A M L   `   `   `  ����I  EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel  5      9!clr-namespace:MoneyInTheBank.ViewMoneyInTheBank.View  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	      $    MoneyInTheBank.View.ClientView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      /vm&clr-namespace:MoneyInTheBank.ViewModel  5      *vw!clr-namespace:MoneyInTheBank.View  5      <f4clr-namespace:PRBD_Framework;assembly=PRBD_Framework  5	      -   5        $  PRBD_Framework.UserControlBase   Name$	  win��5       � DataContext 5      .   (MoneyInTheBank.ViewModel.ClientViewModel  5   
   -   5        vm��5      .��5      �  � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $	��56* �6    � ColumnDefinitions 5   
   �� 5      $	��19* �6   �� 5      $
��163* �6   �� 5      $
��618* �6   .+�5   
   �� -   5         ��Name$ clientNumberLabel��5      $��1��6+   $��Client number��6;   $
��Left=�6S   $��Center=�6n   $��26��6�   $	��127��6�   �� 5    
   -   5        $ 
emailLabel��5       $��1��6$   $��Email��64   $
��Left=�6D   $��Center=�6_   $��26��6z   $��37��6�   $��1��6�   �� 5!   
   -   5        $ firstNamLabel��5!      $��1��6'   $��
First name��67   $
��Left=�6L   $��Center=�6g   $��2��6�   $��26��6�   $��79��6�   �� 5"   
   $��1��6   $��	Last name��6    $
��Left=�64   $��Center=�6O   $��3��6j   $��26��6w   $	��119��6�   �� 5#   
   $��1��6   $��Password��6    $
��Left=�63   $��Center=�6N   $��4��6i   $��25��6v   $��70��6�   �� 5$   
   $��1��6   $��Confirmed password��6    $
��Left=�6=   $��Center=�6X   $��5��6s   $��26��6�   $	��127��6�   �� 5&   
   $��2��6   $
��Left=�6$   $
��Wrap=�6d   $��Center=�6x   $	��400��6�   ��6?   �� *Client.ClientNumber+6�   �� 5(   
   -   5         ��Name$ 
emailInput��5(      $��2��6&   $
��Left=�67   $��1��6R    �� TextWrapping$
 Wrap=�6_   $��Center=�6�   $	��400��6�   $��25��6�   ��6s   �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5)   
   -   5        $ firstNameInput��5)      $��2��6*   $
��Left=�6;   $��2��6V   $
 Wrap=�6c   $��Center=�6�   $	��400��6�   $��25��6�   ��6w   �� *	FirstName+$ PropertyChanged=�6�   �� 5*   
   -   5        $ lastNameInput��5*      $��2��6)   $
��Left=�69   $��3��6T   $
 Wrap=�6a   $��Center=�6�   $	��400��6�   $��25��6�   ��6u   �� *
LastName+$ PropertyChanged=�6�   G� 5+   
   -	   5         G�Name$ passwordInput��5+      #  PRBD_Framework.PasswordHelper	   Attach$
	 True��5,      $��2��5.      $
��Left=�6&   $��4��6A   $��Center=�6N   $	��400��6i   $��25��6u   
   Password
 5-      �� *
Password+$ PropertyChanged=�5.   u   G� 5/   
   -
   5        $ passwordConfirmedInput��5/      $
	 True��50      $��2��52      $
��Left=�6&   $��5��6A   $��Center=�6N   $	��400��6i   $��25��6u   
 51      �� *ConfirmedPassword+$ PropertyChanged=�52   u   �� 55   
   $��2��6   $
��Save��6!   $
��Left=�6P   $��0,51,0,0q�6k   $��6��6}   $	��Top=�6�   $	��118��6�   $��20��6�   ��60   �� *SaveCommand+6�   �� 56   
   $��2��6   $��Cancel��6!   $
��Left=�6T   $��
141,51,0,0q�6o   $��6��6�   $	��Top=�6�   $	��118��6�   $��20��6�   ��62   �� *CancelCommand+6�   �� 57   
   $��2��6   $��Delete��6!   $
��Left=�6U   $��
282,51,0,0q�6p   $��6��6�   $	��Top=�6�   $	��118��6�   $��20��6�   ��62   �� *DeleteCommand+6�   58      59      