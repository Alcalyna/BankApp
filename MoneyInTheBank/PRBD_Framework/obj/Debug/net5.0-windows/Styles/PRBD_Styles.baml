   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PRBD_FrameworkPRBD_Framework  5           PRBD_Framework.PRBD_StylesW SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   validationTooltipStyle  �� 
TargetType �� Property �� Value �� RelativeSource �� Path �� 
TargetType �� 	Converter6   0PRBD_Framework.ValidationErrorsToStringConverter �� Triggers P� Property	 P� Value
 �� 
TargetName  validationTooltip  ErrorTooltip �� Triggers �� BasedOn(  "System.Windows.Controls.DatePicker  DataGridVerticalCentering*  $System.Windows.Controls.DataGridCell&   System.Windows.Controls.DataGrid �� 	Resources �� Color   PRBD_Framework.MyDataGrid   5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      "fclr-namespace:PRBD_Framework  5      %J  &	        &	     7   &	     7  '��     7  'G� R    7  '�� t    7  '�� �    7  '  �    7  &	 �    '  �    '  �    7 �� 5      "  _�6+   .�5   
   ��  �@�OverridesDefaultStyle$
 true��62   �� 5   
    � ��
 �����6'   �� 5   
    �@_�HasDropShadow$
 True��6*   �� 5   
    �@�DataContext 6(   ��  �� *Self+$ PlacementTarget��� 5   
    � �� 5      �� 5      " _�6"   .R�5      �� $��Border��6   
���  ��
�������$��0q�6P   #��z��5      #��z��6=   ._�5      �� $	��8,4q�6$   
���������6D   �� $ (Validation.Errors)�   5       5      P� 5       �@_�HasDropShadow$
	 true��6;   . �5      �� $
 Border��6%    �@��CornerRadius$ 4��6Q   �� 5      $
 Border��6%    �@J�SnapsToDevicePixels$
 true��6X   5      5      5      5       _� 5"      8��  6(   �� 5$      "  ��6!   .�5%   
   ��  �@^�InitialShowDelay$	 100��6<   �� 5&   
    �@^�ShowDuration$ 10000��68   �� 5'   
    � �� �#3333336'    5(   
   P� 5)       �@=�HasError$
	 true��65    �5*      �� 5+       �@�ToolTip8   60   �� 5,       � ��
 �  ��64   �� 5-       �@=�ErrorTemplate 5.      �� 5/      .R�50   "   �� .v�51   &   �� 
���  ��$��1q�6?   $��0q�6S   52   #   53      55      57      59      �� 5;      "  ��6   8   .�5<   
   -   5        5=      �� 5?      "  G�6   8   6.   �� 5A      "  ��6   8   6+   �� 5C      "  ��6   8   6+   �� 5E      "   6   8   6-   �� 5R      "   6.   .�5S   
   ��  � �� 5T      �� 5U      "  6"   .R�5V      � #��z��6   .+�5W      �� $��Center=�6+   5X      5Y      5[      5\      �� 5_      "   6    5`   
   ���� 5a      # Z��6a   (��       6   *1/SystemColors.InactiveSelectionHighlightBrushKey+)6a   �� 5b      # Z��6e   (��       6   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)6e   5c      5d      �� 5e      "   6   8   6/   5g      