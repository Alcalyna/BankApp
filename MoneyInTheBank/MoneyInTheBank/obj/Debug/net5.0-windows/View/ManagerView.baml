   M S B A M L   `   `   `  ����I  EMoneyInTheBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MoneyInTheBank.ViewModelMoneyInTheBank.ViewModel  5      9!clr-namespace:MoneyInTheBank.ViewMoneyInTheBank.View  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	      %    MoneyInTheBank.View.ManagerView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      /vm&clr-namespace:MoneyInTheBank.ViewModel  5      *vw!clr-namespace:MoneyInTheBank.View  5      <f4clr-namespace:PRBD_Framework;assembly=PRBD_Framework  5	      -   5        $  PRBD_Framework.UserControlBase   Name$	  win��5       � DataContext 5      /   )MoneyInTheBank.ViewModel.ManagerViewModel  5   
   -   5        vm��5      .��5      �  � RowDefinitions 5   
   �� 5      $	��21* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��174* �6   .+�5   
   �� $��0��6   $��Agency��6   $
��Left=�6.   $��Center=�6I   $��26��6d   $��49��6p   �� 5   
   -   5         ��Name$ agency��5       $��0��6   $
��Left=�6y   $��Center=�6�   $	��727��6�   $��63,0,0,0q�6�   $��22��6�   ��60   �� *
Agencies+ �� SelectedItem 6Q   �� *SelectedAgency+��5      �� 5      .R�5      �� ��6    �� *Name+68   5      5        PRBD_Framework.MyDataGrid  5    
   -   5          Name$ clientsAgencyData��5    $   $��1��6   &   System.Windows.Controls.DataGrid   
IsReadOnly$
 True��6?      AutoGenerateColumns$ False��6q   $
��Auto=�6�   ��6Q   �� *	Clients+ 6�   �� *SelectedClient+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5!      +  %Microsoft.Xaml.Behaviors.EventTrigger  5"      	   	EventName$	 
MouseClick��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 5#      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   �� *ClientSelectedCommand+   CommandParameter 6V   �� 5$         Columns 5'      0	  *System.Windows.Controls.DataGridTextColumn	  5(      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Client number��6%    
  SortDirection 
Descending6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   ��  �� Path$ ClientNumber�6b   	  5)      $ 
First name��6%    69   �� $ 	FirstName�	  5*      $ 	Last name��6%    68   �� $ LastName�5,      �� 5-   
   $��
New Client��6   $��2��6&   $��323,0,338,274q�63   $��2��6J   ��6[   �� *NewClientCommand+!  PRBD_Framework.MyTabControl  5/   
   -   5          Name$ 
tabControl��5/      $��10q�6-   $��3��69      HasCloseButton$ False��6F   .@�50      �� -   5         ��Name$ 	ClientTab��50      $��Client��6)   
 � Tag$ Client��69   .��51      $   MoneyInTheBank.View.ClientView  52      �� 53      -   5        $ AccountClientTab��53      $��Accounts��60   $ AccountClient��6B   .��54      ,   &MoneyInTheBank.View.AccountsClientView  55      56      58      59      