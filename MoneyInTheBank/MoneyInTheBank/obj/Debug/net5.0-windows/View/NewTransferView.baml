   M S B A M L   `   `   `  ����I  EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel  5      9!clr-namespace:MoneyInTheBank.ViewMoneyInTheBank.View  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	      )    #MoneyInTheBank.View.NewTransferView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      /vm&clr-namespace:MoneyInTheBank.ViewModel  5      *vw!clr-namespace:MoneyInTheBank.View  5      <f4clr-namespace:PRBD_Framework;assembly=PRBD_Framework  5	      -   5        $  PRBD_Framework.UserControlBase   Name$	  win��5       � DataContext 5      3   -MoneyInTheBank.ViewModel.NewTransferViewModel  5   
   -   5        vm��5   "   .��5      �  � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $��7* �6   �� 5      $	��56* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��21* �6   �� 5      $
��100* �6   �� 5      $	��76* �6   .+�5   
   �� -   5         ��Name$ sourceAccountLabel��5      $��1��6,   $
��From��6<   $
��Left=�6K   $��Center=�6f   $��26��6�   $��37��6�   �� 5    
   -   5        $ recipientAccountLabel��5       $��1��6/   $��To��6?   $
��Left=�6L   $��Center=�6g   $��1��6�   $��26��6�   $��22��6�   �� 5!   
   $��1��6   $��Amount��6    $
��Left=�61   $��Center=�6L   $��2��6g   $��26��6t   $��53��6�   �� 5"   
   $��1��6   $��Description��6    $
��Left=�66   $��Center=�6Q   $��3��6l   $��25��6y   $��70��6�   �� 5#   
   $��1��6   $��Action Date��6    $
��Left=�66   $��Center=�6Q   $��4��6l   $��26��6y   $��72��6�   �� 5$   
   $��1��6   $��Category��6    $
��Left=�63   $��Center=�6N   $��5��6i   $��26��6v   $��58��6�   �� 5&   
   -   5         ��Name$ allInternalAccounts��5&      $��2��61   $
��Left=�6�   $��Center=�6�   $��2��6�   $	��400��6�   ��6A   �� *AllInternalAccounts+ �� SelectedItem 6m   �� *CurrentInternalAccount+��5'      �� 5(      .R�5)      �� ��5*      `� 5+       �� StringFormat$ 	{0} - {1}��6+   .1�5,   "   ��  �� Path$
 Iban�6*   �� 5-   "   $ Description�6*   5.      50      51      53      �� 56   
   -   5        	 ��Name$	 recipientAccountIban��56      $��2��6z   $��Center=�6�   $��1��6�   $��22��6�   $��	0,0,136,0q�6�   ��60   �� $ RecipientIban�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   �� 57   
   $��2��6   $	��...��6!   $
��Left=�6S   $��	358,0,0,0q�6n   $��1��6�   $��Center=�6�   $��22��6�   $��40��6�   ��6/   �� *SelectRecipient+6�   �� 58   
   -   5        $	 amountInput��58      $��2��6'   $
��Left=�6Q   $��2��6l    �� TextWrapping$
 Wrap=�6y   $��Center=�6�   $	��400��6�   $��25��6�   ��6�   �� *Amount+$
 PropertyChanged=�6�   �� 59   
   -   5        $	 descriptionInput��59      $��2��6,   $
��Left=�6<   $��3��6W   $
 Wrap=�6d   $��Center=�6�   $	��400��6�   $��25��6�   ��6x   �� *Description+$
 PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  5;   
   -	   5          Name$ 
actionDate��5;      $��30��6)   $��2��6�   $
��Left=�6�   $��4��6�   $��2��6�   $	��398��6�   $	��Top=�6�   $��0,15,0,0q�6�      SelectedDate 65   �� *ActionDateTime+$
 PropertyChanged=�6  �� 5<   
   -
   5        $ category��5<       �� 
IsEditable$
 True��6%    �� IsTextSearchEnabled$
 True��67   $��2��6�   $
��Left=�6�   $��Center=�6�   $	��400��6�   $��5��6�   $��22��6  ��6R   �� *CategoryNames+ �� Text 6x   �� *CategoryName+ �� Mode$ TwoWay=���5=      �� 5>      .R�5?      �� ��6    �� 63   5@      5B      �� 5D   
   $��2��6   $��Transfer��6!   $
��Left=�6X   $��	41,51,0,0q�6s   $��6��6�   $	��Top=�6�   $	��118��6�   ��64   �� *TransferCommand+6�   �� 5E   
   $��2��6   $��Cancel��6!   $
��Left=�6T   $��
186,51,0,0q�6o   $��6��6�   $	��Top=�6�   $	��118��6�   ��62   �� *CancelCommand+6�   5F      5G      