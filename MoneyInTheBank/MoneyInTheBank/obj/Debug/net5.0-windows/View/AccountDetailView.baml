   M S B A M L   `   `   `  ����I  EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel  5      9!clr-namespace:MoneyInTheBank.ViewMoneyInTheBank.View  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	      +    %MoneyInTheBank.View.AccountDetailView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      /vm&clr-namespace:MoneyInTheBank.ViewModel  5      *vw!clr-namespace:MoneyInTheBank.View  5      <f4clr-namespace:PRBD_Framework;assembly=PRBD_Framework  5	        � DataContext  5      5   /MoneyInTheBank.ViewModel.AccountDetailViewModel  5   
   -   5        vm��5   $   .��5      �  � RowDefinitions 5   
   �� 5      $	��38* �6   �� 5      $
��187* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   
������� � ColumnDefinitions 5      �� 5      $
��201* �6#   �� 5      $
��337* �6#   �� 5      $
��262* �6#   .+�5      � $��0��6    5      �� 5      $	��30* �6$   �� 5       $	��30* �6$   �� 5!      $	��30* �6$   �� 5"      $	��50* �6$   .+�5$      �� $��0��6   $��Future transactions��6+   $
��Left=�6r   $��10,0,0,0q�6�   $��Center=�6�    d� 	IsChecked 6I   �� *FutureTransactions+6�   �� 5%      $��Past transactions��6   $
��Left=�6^   $��10,0,0,0q�6y   $��Center=�6�   $��1��6�    67   �� *PastTransactions+6�   �� 5&      $��Refused transactions��6   $
��Left=�6d   $��27,0,0,0q�6   $��Center=�6�   $��2��6�    6:   �� *RefusedTransactions+6�   � 5'      $��3��6    5(      �� 5)      $
��142* �6+   �� 5*      $	��59* �6+   .+�5,      �� $
��Left=�6    $��27,0,0,0q�6;   $
��Wrap=�6M   $��Period��6a   $��Center=�6o   $��0��6�   �� 5-      -   5         ��Name$ timePeriods��5-      $
��Left=�6�   $��Center=�6�   $	��120��6�   $��2��6�   $��71,0,0,0q�6�   ��64   �� *TimePeriods+ �� SelectedItem 6X   �� *SelectedTimePeriod+��5.      �� 5/      .R�50   "   �� ��6,   �� 6?   51      53      54      55      � 56      $��1��6    57      �� 58      $
��Auto �6$   �� 59      $	��10* �6$   .+�5;      �� $��0��6   $
��Left=�6)   $��14,0,0,0q�6D   $
��Wrap=�6V   $��Category��6j   $��Center=�6z   � 5<      $��1��6    5=      �� 5>      $
��Auto �6(   �� 5?      $
��Auto �6(   .+�5B      �� -   5         ��Name$ listViewCategories��5B      $��0��6:   
������  �� SelectionMode$ Multiple=�6�   $��Disabled=�6�   ��6G   �� *CategoriesBooleans+��6�   Z� ��5C      �� 5D      .R�5E   "   � 5F      ��5H      �� 5I      .R�5J   "   �� $��3q�6M   ��6+   �� *NameToDisplay+ 6X   �� *	IsChecked+5K      5M      � 5N      $��1��6    5O      �� 5P      $
��Auto �6/   �� 5Q      $
��Auto �6/   .+�5S      �� $��0��6!   $��
Select all��61   $��Right=�6k   $��	150,0,0,0q�6�   $��Center=�6�   $��20��6�   $��75��6�   ��6F   �� *SelectAllCommand+6�   �� 5T      $��1��6!   $��Select none��61   $��Right=�6n   $��20,0,0,0q�6�   $��Center=�6�   $��20��6�   $��69��6�   ��6G   �� *SelectNoneCommand+6�   5U      5V      5W      � 5X      $��2��6    5Y      �� 5Z      $
��Auto �6$   �� 5[      $
��Auto �6$   �� 5\      $
��Auto �6$   .+�5^      �� $��0��6   $
��Left=�6)   $��3,0,0,0q�6D   $
��Wrap=�6U   $��Text filter��6i   $	��Top=�6|   �� 5_      $��1��6   $��14(�6d   ��6'   �� *Filter+ �� UpdateSourceTrigger$ PropertyChanged=�6d   �� 5`      $��2��6   $��Clear��6&   $��	207,1,0,2q�6V   ��66   �� *ClearFilter+6V   5a      5b      �� 5c   
   -   5        	 ��Name$	 lvTransactions��5c      $��1��6S   
������ $ Single=�6z   $��Visible=�6�   $
��True��6�   ��6+   �� *TransactionsVMs+��6�   Z� ��5d      �� 5e      .R�5f      -   'MoneyInTheBank.View.TransactionCardView  5g      5i      �� 5j   
   $��2��6   
 �� Orientation$
 
Horizontal=�6"   .+�5k      �� $��<<��6   ��6(   �� *FirstPageCommand+�� 5l      $��<��6   ��6$   �� *PreviousPageCommand+�� 5m      ��5n      `� 5o       �� StringFormat$3 - {0} of {1} ({2:dd-MM-yyyy} - {3:dd-MM-yyyy})��6#   .1�5p      ��  �� Path$ CurrentPage�6"   �� 5q      $ NumberOfPages�6"   �� 5r      $ 	StartDate�6"   �� 5s      $ EndDate�6"   5t      5v      �� 5w      $��>��6   ��6!   �� *NextPageCommand+�� 5x      $��>>��6   ��6"   �� *LastPageCommand+5y      5z      5|      