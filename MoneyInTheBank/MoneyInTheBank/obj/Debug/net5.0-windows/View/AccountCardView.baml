   M S B A M L   `   `   `  ����I  EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel  5      9!clr-namespace:MoneyInTheBank.ViewMoneyInTheBank.View  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	      )    #MoneyInTheBank.View.AccountCardView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      /vm&clr-namespace:MoneyInTheBank.ViewModel  5      *vw!clr-namespace:MoneyInTheBank.View  5      <f4clr-namespace:PRBD_Framework;assembly=PRBD_Framework  5	      .��5      ��   �� Orientation$  Vertical=�6   
����ح�.+�5   
   �� $��WrapWithOverflow=�6   $��17(�6J   
���   �$��0��6k    �� TextAlignment$ Center=�6x   $��
AR DESTINE)�6�   ��64   �� *Iban+6�   �� 5   
   $��WrapWithOverflow=�6   $��WordEllipsis=�64   $��10(�6o   
���   �$��1��6�   $ Center=�6�   $��Center=�6�    �� Padding$ 5q�6�   ��6Q   �� *Description+6�   �� 5   
   $��WrapWithOverflow=�6   $��14(�6e   
���   �$��2��6�   $ Center=�6�   ��64   �� *Type+ �� StringFormat$ 	Type: {0}��6�   �� 5   
   $��WrapWithOverflow=�6   $��14(�6�      BalanceStyle#��[  6�   $��2��6�   $ Center=�6�   ��64   �� *	Balance+ �� 	Converter ?   9MoneyInTheBank.View.CurrencyToStringWithPlusSignConverter  6�   �� 5   
   $��WrapWithOverflow=�6   $��14(�6k   
���   �$��2��6�   $ Center=�6�   ��64   �� *
Relation+$ Access: {0}��6�   �� 5   
   $��WrapWithOverflow=�6   $��14(�6o   
���   �$��2��6�   $ Center=�6�   ��64   �� *
LowerLimit+$ Floor: {0:C2}��6�   � 5   
    � ColumnDefinitions 5      �� 5      $��5* �6#   �� 5      $��5* �6#   .+�5      �� -   5         ��Name$ statementBtn��5   %   $��0��6   $��	Statement��6�   ��6;   �� *	Statement+ �� ElementName$ vm����6i   �� 6�   �� 5      -   5        $ transferBtn��5   %   $��1��6   $��Transfer��6�   ��6:   �� *NewTransfer+$ vm����6j   �� 6�   5      5      5       