   M S B A M L   `   `   `  ����H  DPiłkarzeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PiłkarzeMVVM.ViewPiłkarzeMVVM.View  5   	   A%clr-namespace:PiłkarzeMVVM.ViewModelPiłkarzeMVVM.ViewModel  5   	       PiłkarzeMVVM.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   ,local clr-namespace:PiłkarzeMVVM.View  5   	   .vm%clr-namespace:PiłkarzeMVVM.ViewModel  5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)    � 
ResizeMode$ NoResize=�66    � 	Resources 5      (  "PiłkarzeMVVM.ViewModel.Management   
management��%   &	          5	   
   6   5
       � DataContext 5      �� 5   
    �� ResourceKey$ 
management��6   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     PassEventArgsToCommand . 	   Command	 6$   �� 
 �� Path$
 LoadData� �� Source# [  6j   5        5   
   $ Loaded��6   . 5         . 	 6$   �� $
 LoadAgeItems�# [  6n   5        5   
   $ 	LostFocus��6   . 5         . 	 6$   �� $
 SaveData�# [  6i   5      .��5      �� $��0,3,0,-3q�6   # [  6   ._�5   
   �  � ColumnDefinitions 5      �� 5       $
��0.4* �6#   �� 5!      $
��0.6* �6#   .+�5$      � $��0��6    � RowDefinitions 5%      �� 5&      $
��0.1* �6$   �� 5'      $
��0.1* �6$   �� 5(      $
��0.1* �6$   �� 5)      $
��0.1* �6$   �� 5*      $��0.15* �6$   �� 5+      $
��0.1* �6$   �� 5,      $
��0.1* �6$   �� 5-      $
��0.1* �6$   �� 5.      $��0.15* �6$    51      �� 52      $
��0.6* �6'   �� 53      $
��0.4* �6'   .+�57      �� $��0��6   $��0��6,   $��Imię:��69   $��30(�6F    �� Padding$ 
10 5 10 10q�6T   *   $PiłkarzeMVVM.View.TextBoxForLetters  58      -   5          Name$ firstName_tbx��58   +   
���   �$��1q�6V   $��1��6j   $��0��6z   $��2q�6�   ���#eee$��17(�6�   $��10q�6�    � ToolTip$ Uzupełnij dane��6�      Text 6�   �� $
 	FirstName� �� Mode$ TwoWay=��� 5:      $��0��6   $��1��6,   $��	Nazwisko:��69   $��30(�6J   $ 
10 5 10 10q�6X     5;      -   5        $ lastName_tbx��5;   +   
���   �$��1q�6U   $��1��6i   $��1��6y   $��2q�6�   ���#eee$��17(�6�   $��10q�6�   $ Uzupełnij dane��6�    6�   �� $
 LastName�$ TwoWay=��� 5=      $��0��6   $��2��6,   $��Wiek:��69   $��30(�6F   $ 
10 5 10 10q�6T   �� 5>      -   5         ��Name$ age_cb��5>      
���   �$��1q�6?   $��1��6S   $��2��6c   $��10q�6p   ���#eee$��15(�6�   $��10q�6�   ��6�   �� $
 AgeItems� �� SelectedItem 6�   �� $	
 Age��� 5@      $��0��6   $��3��6(   $��Waga:��65   $��30(�6E   $��
10 5 10 10q�6S   ]� 5A      $��Center=�6   $��2q�67   $��1��6B   $��3��6R   .+�5B      �� $��Right=�6V   $��40��6m   $��15(�6x   ��6   ��  �� ElementName$ weight_slider��$
 Value�6x   �� 5C      -   5        $��weight_slider��5C   s   $	��102��6    � Minimum$ 50Q�6)    � Maximum$ 99Q�66    �� TickFrequency$	 0.1Q�6D    �� IsSnapToTickEnabled .  � Value 6�   �� $
 Weight�$ TwoWay=�5D      �� 5F      -   5         ��Name$ add_btn��5F      $��5��6*   $��Dodaj��67   $��10 10 10 10q�6G   $��2��6\   $��20(�6p   ��6~   �� *	AddPlayer+�� 5G      -   5        $ 
delete_btn��5G      $��6��6-   $��Usuń��6:   $��10 10 10 10q�6I   $��2��6^   $��20(�6r   ��6�   �� *DeletePlayer+�� 5H      -   5        $ 
modify_btn��5H      $��7��6-   $��	Modyfikuj��6:   $��10 10 10 10q�6N   $��2��6c   $��20(�6w   ��6�   �� *ModifyPlayer+5J      �� 5L      -   5         ��Name$ playersList_lb��5L   &   $��1��6   $��15(�6>   ��6L   �� $
 Players� �� UpdateSourceTrigger$ PropertyChanged=� 6�   �� $
 SelectedPlayer�$ TwoWay=� 5M        5N      $ SelectionChanged��6%   . 5O        	 60   �� $

 Copy�5P      5R      5S      5U      5V      