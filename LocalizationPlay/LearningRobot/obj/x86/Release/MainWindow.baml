   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms I ELearningRobot, Version=6.30.2.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LearningRobot.ViewModelLearningRobot.ViewModel -clr-namespace:LearningRobotLearningRobot 7 clr-namespace:LearningRobot.utilLearningRobot.util    LearningRobot.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Hi:http://schemas.microsoft.com/expression/2010/interactivity     Hei9http://schemas.microsoft.com/expression/2010/interactions     gWinFormHostOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     \WinFormControls@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     j fGalaSoft.MvvmLight.Extras.WPF4, Version=4.2.30.23173, Culture=neutral, PublicKeyToken=1673db7d5906b0ad-custom http://www.galasoft.ch/mvvmlight  .vm%clr-namespace:LearningRobot.ViewModel  'localclr-namespace:LearningRobot  6ValueConverters clr-namespace:LearningRobot.util  -     � WindowState$  	Maximized=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � AllowsTransparency . ��Z�  � 	Resources ;  5LearningRobot.util.SliderPositionValueToTextConverter &  "SliderPositionValueToTextConverterD  >LearningRobot.util.SliderRemainingPositionValueToTextConverter / +SliderRemainingPositionValueToTextConverter��%   &	        &	          .��� 
������� � RowDefinitions �� $
��0.5* ��� $
��1.0* ��� $��12.5* �.+�� $��0�����#2676FF  �� 
TargetType �� Property	 �� Value��%�   '��       �� " ��.���  � ��$
	 Left=���  � ��$	 Center=���  � ��$	 Uniform=���  � ��$	 30����  � ��$	 30����  � ��$	 1q�
 � ColumnDefinitions
 �� $��1* ��� $��1* ��� $��1* �.+�  LearningRobot.BatteryBar  -     Name$ _battery��$��2��$��Right=�$��Center=�$��0,3,8,3q�$��65��$��14�� � DataContext ��  �� Path$ BatteryBarViewModel�� $��1�����#1D8DFF   ButtonCommonStyle  ImageBaseStyle��%�  &	       '�� P     &	 �     �� " ��.���  � ��$		 120����  � ��$	 40����  � ��$	 20(��� " ��.���  � ��$	 Center=���  � ��$	 Center=���  � ��
	 �������  � ��$	 15(���  � ��$
	 Bold"��� " ��.���  � ��$	 Center=���  � ��$	 Center=���  � ��$	 Uniform=���  � ��$	 30����  � ��$	 30����  � ��$	 1q�
 �� $
��0.5* ��� $
��0.5* ��� $
��1.8* ��� $
��1.8* ��� $
��1.0* �.+��� $��0��  Version#���  $��21(�$��Center=��� -    ��Name$ _versionLabel��$��1��$��06.30.01��$��16(�$
��Left=�� $��4��$��Right=�  
 btnmin �� 
TargetType ��Name  btnclose��%�   &	       &	 Y     �� " ��.���  � ��	 �� " ��.R�� .+��� $ Close��$��Images/min.png���� " ��.���  � ��	 �� " ��.R�� .+��� $ Close��$��Images/close.png��
 �� $��1* ��� $��1* �.+��� -    ��Name$ btnmin��  	Click_Min � ToolTip# �  $��Right=�$��0,3,55,0q�#���  $��26��$��26���� -   $ btnclose��  Click_Close# �  $��Right=�$��0,3,15,0q�#���  $��26��$��26��� $��2��
 �� $��1* ��� $��2* �.+�� $��0��  
	 addbtn 
 	deletebtn  playTemplate �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName  delTemplate��%�  &		       &	
 Y     &	 �     &	     �� " ��.���  � ��	 �� " ��.R�� .+��� $ Close��$��Images/add.png���� " ��.���  � ��	 �� " ��.R�� .+��� $ delete��$��Images/delete.png���� " ��.R��� $��BorderCB��$ 10��#��z��#��z��$��40��$��20��._�� .+��� $��SliderCB��$��Images/current_play.png��$��Center=�$��0��$��20q�$��26��$��26��$y�Hidden=� P�  �@d�	IsChecked$ falseY�. ��� $ SliderCB�� � y�$	 Hidden=�P�  �@d�	IsChecked$
 trueY�. ��� $ SliderCB�� � y�$	 Visible=��� " ��.R��� $��BorderCB��$ 10��#��z��#��z��$��20��$��20��._�� .+��� $��SliderCB��-   $
��Left=�#��� 
 $��Center=�$��5q�$��26��$��26������ $ Index� P�  �@d�	IsChecked$ falseY�. ��� $ SliderCB�� � y�$	 Hidden=�P�  �@d�	IsChecked$
 trueY�. ��� $ SliderCB�� � y�$	 Visible=� �� $��60 ��� .+�� $��0�����#1C65CC.+���   PlayList#���  ���	#EEFFFFFF$��5q�$��26(�$��Center=�$
��Bold"��� -   $ addbtn��  Open# �  $��Right=�$��0,3,15,0q�#��� 	 $��26��$��26��� -   $��1�����#237EFF.+��� -	   $��	musicList��$��Stretch=�{�.  J� 	AllowDrop . ���#237EFF���� .R�� $��Stretch=�$	��300��
 �� $��60 ��� $	��215 ��� $��35 �.+�� $��1��$��2�����	#AAFFFFFF$��1��$��Bottom=��� $��0��#��[ $��0,1,1,1q� d� 	IsChecked �� *
IsSelected+ �� RelativeSource ��  �� AncestorType$ ListViewItemL��� $��1��$��20(�$��Center=����	#DDFFFFFF$
��Left=����� $ 	musicName��� $��Center=�#��[ $��2�� �� *
IsSelected+ �� $ ListViewItemL�� $��1��$��20q�.+��� $ 15��$��3q����#3A84BD���#3A84BD J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ #3A84BD��   
BlurRadius$ 15Q�   ShadowDepth$ 0Q�    Opacity$  1Q�._�� $��15q�.+�  LearningRobot.GifImage  !   Source$! Images/robot_eyes.gif���  �� $
��3.3* ��� $	��16* ��� $��4* �.+��� $��0�����	#44FFFFFF$��15q�$ 12��._�� .+��� -
   $ lbname��$��30,0,0,0q�$��Center=�$��27(�  Waiting#���  ���	#FFECECEC�� $��2�����	#44FFFFFF$��20q�$ 12��._��    ButtonStyleBack  ButtonStylePlay  ButtonStyleNext  ButtonStyleSound��%�  &	       &	 Y     &	 �     &	     �� " ��.���  � ��	 �� " ��.R�� .+��� $
 back��$��Images/back.ico���� " ��.���  � ��	 �� " ��.R�� .+��� $ Close��$��Images/play.ico���� " ��.���  � ��	 �� " ��.R�� .+��� $ Close��$��Images/next.ico���� " ��.���  � ��	 �� " ��.R�� .+��� $ Close��$��Images/538130.png��
 �� $
��1.0* ��� $
��2.5* ��� $
��2.5* ��� $
��2.5* ��� $
��0.8* ��� $��4* ��� $	��12* ��� $��4* ��� $
��0.6* ��� $
��2.2* ��� $��6* ��� $
��0.6* �.+��� -   $ btBack��  Last# �  $��1��#���  $��32��$��32���� -   $ btPlay��  PlayOrPause# �  $��2��#���  $��32��$��32���� -   $ btNext��  Next# �  $��3��#���  $��32��$��32��� $��5��$��3��
 �� $
��2.5* ��� $	��12* ��� $��3* �.+��� $��0�����	#FFACACAC$��17(�$��Right=�$��Center=����� " �� ElementName$" sdMusic��$ Value�# �� Mode$# OneWay=�$ �� FallbackValue$
$ 0:00��% �� 	Converter#% [  �� -   $��sdMusic��$��1��$��24��  sliderstyle#���  & �� IsMoveToPointEnabled& . ' � Cursor$
' Hand��( � Maximum$
( 0.00Q�$��Center=�) � Value) �� *	AllTime+�� $��2��$
��Left=�$��Center=����	#FFACACAC$��17(���`� $$ -0:00��* `� 	Converter#* [ .1��� $" sdMusic��$ Value�$# OneWay=��� $" sdMusic��$ Maximum�$# OneWay=��� -   $��yinliang��$��10��$( 1Q�+ � LargeChange$	+ 0.1Q�, � SmallChange$	, 0.1Q�$	) 0.5Q�#���  $��24��$	��100��$
��Left=�$��Center=���Z� ��Z� �� $��Images/538130.png��$��9��$��32��$��32��$��Center=�$��Right=�