   M S B A M L   `   `   `  ����H  DLearningRobot, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LearningRobot.ViewModelLearningRobot.ViewModel  5   	   )    #LearningRobot.PowerNotificationView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5   	   Hei9http://schemas.microsoft.com/expression/2010/interactions     5   	   j fGalaSoft.MvvmLight.Extras.WPF4, Version=4.2.30.23173, Culture=neutral, PublicKeyToken=1673db7d5906b0ad-custom http://www.galasoft.ch/mvvmlight  5   	   .vm%clr-namespace:LearningRobot.ViewModel  5   	     � WindowStartupLocation$  CenterScreen=�5   	   $	��460��5	   	   $	��300��6   
������  � Topmost .  � WindowStyle$
 None=�5
   	    � AllowsTransparency .  � ShowInTaskbar .   � 	Resources 5       �� 
TargetType �� Property �� Value	 �� Triggers
 :� RoutedEvent �� TargetProperty g� 	BeginTime W� From	 W� To g� Duration g� AutoReverse g� RepeatBehavior��%�  '��       '�� �    '�� (    �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 22q�6'   	 5      :� 5      $
 Loaded��6   .[�5      �� .��5      �� .��5      W� $ Opacity�6.   $ 00:00:00X�5   .   $ 1X�6C   $	 0.1X�6L   $ 00:00:01D�5   .    . $ Forever��5   .   5      5      5      5      �� 5   
   " ��6   .�5       ��  � ��$ Center=�64   �� 5!       � ��$ Center=�62   �� 5"       � ��$ 15(�6)   5#      �� 5%   
   " ��6   .�5&      ��  � ��$ 150 20 150 20q�6'   5'      5(      .��5*      ��  �� CornerRadius$ 5��6   $��2q�6   ���	#FFE5E5E5
������� J� Effect 5+   
   3  -System.Windows.Media.Effects.DropShadowEffect  5,         Color$ 	#FFE5E5E5��6      
BlurRadius$ 5Q�61      ShadowDepth$ 0Q�6@      Opacity$ 1Q�6P   ._�5/   
   �  � RowDefinitions 50      �� 51      $
��1.5* �6    �� 52      $��1* �6    �� 53      $��1* �6    .+�56      �� $��0��6   $%��/HMI;component/Images/power.png��6!   �� 58      $��1��6   .��59      �� $
��Wrap=�6   $Z��T警告：设备电量低，为保证正常使用，请尽快连接电源线充电。��60   5:      �� 5<      $��2��6   $��	知道了��6"   ��60   ��  �� Path$ CloseCommand�5=      5>      5?      