   M S B A M L   `   `   `  ����I  EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel  5   	   9!clr-namespace:MoneyInTheBank.ViewMoneyInTheBank.View  5   	   I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5   	   "    MoneyInTheBank.View.MainView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5vm&clr-namespace:MoneyInTheBank.ViewModel     5   	   0vw!clr-namespace:MoneyInTheBank.View     5   	   Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5   	   $	��768��5
   !   $
��1024��6.     � WindowStartupLocation$  CenterScreen=�6;    � Title 6	   �� *Title+ � DataContext 5      ,   &MoneyInTheBank.ViewModel.MainViewModel  5   
   -   5        vm��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��1* �6   .+�5   
   o� .@�5      m� $��Log out��6    m� Command 6(   �� *LogoutCommand+(  "System.Windows.Controls.DatePicker  5      $��	700 0 0 0q�6d      SelectedDate 6   �� *SelectedDate+ �� UpdateSourceTrigger$ PropertyChanged=�6y   5      !  PRBD_Framework.MyTabControl  5   
   -   5          Name$ 
tabControl��5      $��10q�6-   $��1��69      HasCloseButton$
 True��6F   .@�5      �� -   5        	 ��Name$	 AccountsTab��5      $��Accounts��6+   

 � Tag$
 Accounts��6=   y�6L   �� *
IsClient+ �� 	Converter +  %PRBD_Framework.BoolToVisibleConverter  .��5      %   MoneyInTheBank.View.AccountView  5      �� 5      -   5        $	 
ManagerTab��5      $��Manager��6*   $
 Manager��6;   y�6I   �� *	IsManager+   .��5      %   MoneyInTheBank.View.ManagerView  5      �� 5       -   5        $	 AdminTab��5       $��Admin��6(   $
 Admin��67   y�6C   �� *	IsAdmin+   .��5"      #   MoneyInTheBank.View.AdminView  5#      5$      5%      5&      