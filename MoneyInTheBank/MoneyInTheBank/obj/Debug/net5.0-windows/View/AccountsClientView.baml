   M S B A M L   `   `   `  ����I  EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel  5      9!clr-namespace:MoneyInTheBank.ViewMoneyInTheBank.View  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	      ,    &MoneyInTheBank.View.AccountsClientView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      /vm&clr-namespace:MoneyInTheBank.ViewModel  5      *vw!clr-namespace:MoneyInTheBank.View  5      <f4clr-namespace:PRBD_Framework;assembly=PRBD_Framework  5	      -   5        $  PRBD_Framework.UserControlBase   Name$	  win��5       � DataContext 5      6   0MoneyInTheBank.ViewModel.AccountsClientViewModel  5   
   -   5        vm��5   %   .��5      �  � RowDefinitions 5   
   �� 5      $	��12* �6   �� 5      $
��Auto �6   �� 5      $	��53* �6   .+�5   
     PRBD_Framework.MyDataGrid  -   5          Name$ clientsInternalAccounts��5   $   $��0��6   &   System.Windows.Controls.DataGrid   
IsReadOnly$
 True��6o      AutoGenerateColumns$ False��6�   $
��Auto=�6�   ��6E   �� *InternalAccounts+ �� SelectedItem 6�   �� *SelectedAccountToUpdate+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 IBAN��6%   	   SortDirection	 
Descending6Q   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   ��  �� Path$
 Iban�6Q     5      $
 Type��6%   
 63   �� $ Relation�  5      $ Balance��6%   
 66   �� $ Balance� �� StringFormat$ {0:C2}��  5      $ Floor��6%   
 64   �� $ 
LowerLimit�$ {0:C2}��4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Detail��6)      CellTemplate 5      �� 5      .R�5      �� $��Check detail��6%   ��6<   �� *CheckInternalAccountCommand+ �� ElementName$ vm����6|   �� 6�   5      5!      5#      � 5$   
   $��1��6    � ColumnDefinitions 5%      �� 5&      $
��Auto �6#   �� 5'      $
��Auto �6#   �� 5(      $
��Auto �6#   �� 5)      $
��Auto �6#   .+�5+      �� $��0��6   $
��Left=�6(   $��0,4,0,0q�6C   $
��Wrap=�6T   $'��!New access to an existing account��6h   $	��Top=�6�   �� 5,      -   5         ��Name$ allAccounts��5,      $��2��6-   $
��Left=�6�   $��Center=�6�   $	��199��6�   $��2��6�   $��40,0,0,0q�6�   ��6=   �� *OtherInternalAccounts+ 6k   �� *SelectedAccount+��5-      �� 5.      .R�5/      �� ��6$   �� *Iban+6<   50      52      �� 53      -   5        $ allRelations��53      $��3��6.   $
��Left=�6�   $��Center=�6�   $��99��6�   $��	270,0,0,0q�6�   ��6>   �� *	Relations+ 6`   �� *SelectedRelation+��54      �� 55      .R�56      �� ��6$   �� 67   57      59      �� 5:      $��3��6   $��403,1,-134,-1q�6L   ��6%   �� *AddRelationCommand+.��6c   Add Account6p   5;      � 5<   
   $��2��6    5=      �� 5>      $
��Auto �6#   �� 5?      $
��Auto �6#   �� 5@      $
��Auto �6#   .+�5B      �� $��0��6   $
��Save��6%   $
��Left=�6T   $	��Top=�6o   $	��118��6�   $��20��6�   ��64   �� *SaveCommand+6�   �� 5C      $��1��6   $��Cancel��6%   $
��Left=�6X   $	��Top=�6s   $	��118��6�   $��20��6�   ��66   �� *CancelCommand+6�   �� 5D      $��3��6   $��Delete��6%   $
��Left=�6Y   $	��Top=�6t   $	��118��6�   $��20��6�   ��66   �� *DeleteCommand+6�   5E      5F      5G      