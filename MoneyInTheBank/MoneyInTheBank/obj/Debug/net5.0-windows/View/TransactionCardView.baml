   M S B A M L   `   `   `  ����I  EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel  5      9!clr-namespace:MoneyInTheBank.ViewMoneyInTheBank.View  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	      -    'MoneyInTheBank.View.TransactionCardView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      /vm&clr-namespace:MoneyInTheBank.ViewModel  5      *vw!clr-namespace:MoneyInTheBank.View  5      <f4clr-namespace:PRBD_Framework;assembly=PRBD_Framework  5	      .��5      �� 
�������$��1q�6    ._�5   
   � $	��800��6      Transaction#��[  6     � ColumnDefinitions  5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5       �� $��Transaction��6   $��Center=�6*   $��Center=�6G   $��12(�6b   $��26��6p   $��70��6|   �� 5!      $��0��6   $��1��6$   $��Creation date��61   $
��Left=�6I   $��10,0,0,0q�6d   $��Center=�6v   $��24��6�   $��82��6�   �� 5"      $��2��6   $��Action date��6!   $��Center=�67   $��Center=�6T   $��26��6o   $��72��6{   �� 5#      $��0��6   $��3��6$   $��
Created by��61   $
��Left=�6F   $��10,0,0,0q�6a   $��Center=�6s   $��26��6�   $��68��6�   �� 5$      $��0��6   $��4��6$   $
��From��61   $
��Left=�6@   $��10,0,0,0q�6[   $��Center=�6m   $��26��6�   $��37��6�   �� 5%      $��0��6   $��5��6$   $��To��61   $
��Left=�6>   $��10,0,0,0q�6Y   $��Center=�6k   $��26��6�   $��22��6�   �� 5&      $��0��6   $��6��6$   $��Description��61   $
��Left=�6G   $��10,0,0,0q�6b   $��Center=�6t   $��26��6�   $��77��6�   �� 5'      $��0��6   $��7��6$   $��Category��61   $
��Left=�6D   $��10,0,0,0q�6_   $��Center=�6q   $��26��6�   $��58��6�   �� 5)      $��1��6   $��WrapWithOverflow=�6(   $��12(�6x   
���   � �� TextAlignment$
 Left=�6�   $��Center=�6�    �� Padding$ 5q�6�   $��26��6�   $��2��6�   $��	0,0,196,0q�6�   ��6H   ��  �� Path$ Transaction.TransactionId�6�   �� 5*      $��1��6   $��1��6(   $��WrapWithOverflow=�65   $��WordEllipsis=�6U   $
��Bold"�6�   $��10(�6�   
���   �$
 Left=�6�   $��Center=�6�   $ 5q�6  $��24��6  $��2��6   $��	0,0,196,0q�64  ��6r   �� $" Transaction.CreationDateTime�64  �� 5+      $��1��6   $��2��6(   $��WrapWithOverflow=�65   $��WordEllipsis=�6U   $
��Bold"�6�   $��10(�6�   
���   �$
 Left=�6�   $��Center=�6�   $ 5q�6  $��24��6  $��2��6  $��	0,0,196,0q�62  ��6r   �� $  Transaction.ActionDateTime�62  �� 5,      $��1��6   $��3��6(   $��WrapWithOverflow=�65   $��WordEllipsis=�6U   $
��Bold"�6r   $��10(�6�   
���   �$
 Left=�6�   $��Center=�6�   $ 5q�6�   $��24��6�   $��2��6�   $��	0,0,196,0q�6  ��5-      `� 5.       �� StringFormat$ {0} {1}��6#   .1�5/      �� $% Transaction.Principal.FirstName�6"   �� 50      $$ Transaction.Principal.LastName�6"   51      53      �� 54      $��1��6   $��4��6(   $��WrapWithOverflow=�65   $��WordEllipsis=�6U   $
��Bold"�6q   $��10(�6�   
���   �$
 Left=�6�   $��Center=�6�   $ 5q�6�   $��24��6�   $��2��6�   $��	0,0,196,0q�6   ��55      `� 56      $ 	{0} ({1})��6#   .1�57      �� $$ Transaction.Source.Description�6"   �� 58      $ Transaction.Source.Iban�6"   59      5;      �� 5<      $��1��6   $��5��6(   $��WrapWithOverflow=�65   $��WordEllipsis=�6U   $
��Bold"�6q   $��10(�6�   
���   �$
 Left=�6�   $��Center=�6�   $ 5q�6�   $��24��6�   $��2��6�   $��	0,0,196,0q�6   ��5=      `� 5>      $ 	{0} ({1})��6#   .1�5?      �� $' !Transaction.Recipient.Description�6"   �� 5@      $  Transaction.Recipient.Iban�6"   5A      5C      �� 5F      $��1��6   $��6��6(   $��WrapWithOverflow=�65   $��WordEllipsis=�6U   $
��Bold"�6�   $��10(�6�   
���   �$
 Left=�6�   $��Center=�6�   $ 5q�6  $��24��6  $��2��6  $��	0,0,196,0q�6/  ��6r   �� $ Transaction.Description�6/  �� 5G      -   5         ��Name$ transactionCategory��5G      $��1��65   $��7��6E   $
��Left=�6�   $��Center=�6�   $	��155��6�   $��2��6�   $��22��6�   ��6S   �� *
Categories+ �� SelectedItem 6v   �� *SelectedCategory+��5H      �� 5I      .R�5J      �� ��6$   �� *Name+6<   5K      5M      �� 5O      $��3��6   $��1��6(   $��WrapWithOverflow=�65   $��WordEllipsis=�6U     BalanceStyle#��[ 6�   $��10(�6�   $
 Left=�6�   $��Center=�6  $ 5q�6,  $��20��68  $��	29,0,22,0q�6D  ��6q   �� *AmountToDisplay+ �� 	Converter ?   9MoneyInTheBank.View.CurrencyToStringWithPlusSignConverter  6D  �� 5P      $��3��6   $��2��6(   $��WrapWithOverflow=�65   $��WordEllipsis=�6U   #��[ 6�   $��10(�6�  $
 Left=�6�  $��Center=�6�  $ 5q�6�  $��20��6�  $��	29,0,22,0q�6�  ��6q   �� *TemporaryBalance+   y�6�   �� $# Transaction.TransactionStatus�%   MoneyInTheBank.ViewModel.Status	   NOT_EXECUTED
 �� ConverterParameter#
 Z	  3   -MoneyInTheBank.View.EnumToNotVisibleConverter  6�  �� 5Q      $��2��6   $��1��6$   $��Amount��61   $
��Left=�6B   $��0,6,0,0q�6]   $	��Top=�6n   $��26��6�   $��54��6�   �� 5R      $��2��6   $��2��6$   $��Temporary balance��61   $
��Left=�6�   $��0,6,0,0q�6  $	��Top=�6  $��26��6+  $	��114��67  y�6M   �� $# Transaction.TransactionStatus�#
 Z	    67  �� 5T      $��8��6   $��1��6%   $��WrapWithOverflow=�65   $��WordEllipsis=�6U   $��10(�6�  $
 Left=�6�  $	��Top=�6�  $ 5q�6�  $��25��6�  
���  ��$
��Bold"�6�  $��2��6  ��6r   �� $  InternalAccount.LowerLimit� �� ElementName$ vm��$K EREFUSED Because it would have given a balance below the floor: {0:C2}��y�6  �� $# Transaction.TransactionStatus�   REFUSED#
 Z  +  %PRBD_Framework.EnumToVisibleConverter  6  � 5V      $��8��6   $��1��6    y�60   �� $# Transaction.TransactionStatus�#
 Z	      5W      �� 5X      $
��Auto �6'   �� 5Y      $
��Auto �6'   .+�5[      �� $��8��6   $��1��6)   $��WrapWithOverflow=�69   $��WordEllipsis=�6Y   $D��>This transaction is foreseen in the future. You may cancel it.��6v   $��10(�6�   $
 Left=�6�   $	��Top=�6�   $ 5q�6�   $��25��6  
����  �$
��Bold"�6%  $��2��67  �� 5\      $��1��6   $��Cancel��6)   $��321,1,-102,1q�6g   ��6:   �� *CancelTransactionCommand+6g   5^      5_      5`      5c      