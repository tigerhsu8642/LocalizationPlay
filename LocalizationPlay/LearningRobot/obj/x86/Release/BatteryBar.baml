   M S B A M L   `   `   `  ����   LearningRobot    LearningRobot.BatteryBar   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources   �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Path �� Value �� 
TargetType	 �� CornerRadius��%W  '��       '� �     �� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 12(� ��  �� $ 
IsLowPower� true.a���  � �� �	#FFEE6158��  �� $ 
IsLowPower�	 false.a���  � �� �	#FFFFFFFF�� " �.���  � �� �� " �.R�� .+��� $��
PART_Track��$	 1�����	#FFFFFFFF$��1q��� $��PART_Indicator��$	��1.5q�$��1q�$
��Left=�  ���� '��       " �� ��  �� $ 
IsLowPower� true.a���  � �� �	#FFEE6158��  �� $ 
IsLowPower�	 false.a���  � �� �	#FFFFFFFF.��� 
 � ColumnDefinitions
 �� $
��1.2* ��� $��1* �.+�� $��1�� � RowDefinitions �� $
��1.2* ��� $��1* ��� $
��1.2* �
 �� $��9* ��� $��1* �.+�� $��0��$��3��$��0��
���  ��
������� � Value �� *
Quantity+�� $��1��$��1�����	#FFFFFFFF�� $��0��$��1q����� *QuantityText+