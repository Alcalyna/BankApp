   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework  5   	   I EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel 5	   	   (   "MoneyInTheBank.View.RecipientsView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   <f4clr-namespace:PRBD_Framework;assembly=PRBD_Framework  5   	   /vm&clr-namespace:MoneyInTheBank.ViewModel  5	   	   -   5        %   PRBD_Framework.DialogWindowBase   Name$  window��5   	    � Title$ Select a recipient��5   	    � WindowStartupLocation$ CenterScreen=�6$    � ShowInTaskbar$ False��6I   $	��350��5   	   $	��350��6    J� Opacity$ 1Q�5   	    � DataContext 5      2  ,MoneyInTheBank.ViewModel.RecipientsViewModel  5   
   -   5        vm��5   !   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��10* �6#   �� 5      $��5* �6#   .+�5       �� $��0��6   $��14(�6c   ��6&   �� *Filter+ �� UpdateSourceTrigger$ PropertyChanged=�6c   �� 5!      $��1��6   $��Clear��6%   ��65   �� *ClearFilter+5"      �� 5$   
   $��1��6   .��6   My other accounts60   �� 5%   
   -   5        	 ��Name$	 listOwnAccounts��5%      $��2��6�   
������ 
 �� SelectionMode$
 Single=�6�   $��Disabled=�6�   ��6,   �� *OwnOtherAccounts+ �� SelectedItem 6U   �� *SelectedRecipient+��6�   Z� *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5&      +  %Microsoft.Xaml.Behaviors.EventTrigger  5'         	EventName$ MouseDoubleClick��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5(      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   �� *SelectRecipientCommand+   CommandParameter 6W   ��  �� ElementName$ listOwnAccounts�� �� Path$ SelectedItem�5)      ��5,      �� 5-      .R�5.      �� ��5/      `� 50       �� StringFormat$ 
 {0} - {1}��6+   .1�51   "   �� $
 Iban�6*   �� 52   "   $ Description�6*   53      55      56      58      �� 59   
   $��3��6   y�6   �� *IsCheckingAccount+ �� 	Converter +   %PRBD_Framework.BoolToVisibleConverter  .��6l   Other accounts6|   �� 5:   
   -   5        $	 listOtherAccounts��5:      $��4��6�   
������ $
 Single=�6�   $��Disabled=�6�   ��6.   �� *OtherAccounts+ 6T   �� *SelectedRecipient+��6�   Z�  5;        5<      $ MouseDoubleClick��6!   . 5=         6,   �� *SelectRecipientCommand+ 6W   �� $ listOtherAccounts��$ SelectedItem�5>      ��5@      �� 5A      .R�5B      �� ��5C      `� 5D      $ 
 {0} - {1}��6+   .1�5E   "   �� $
 Iban�6*   �� 5F   "   $ Description�6*   5G      5I      5J      5L      �� 5M   
   $��5��6   $��Select��6I   $��0 40 0 0q�6Z   
���������6   �� *SelectRecipientCommand+6�   �� 5N   
   $��6��6   $��Cancel��6@   
���������6   �� *CancelCommand+6k   5O      5P      