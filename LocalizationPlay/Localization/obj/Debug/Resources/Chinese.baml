   M S B A M L   `   `   `  ����G  CLocalization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:LocalizationLocalization  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35   HMI 
 pickup  	assistant  medicalrobot  ChenJian 
 Attend  Medical  	Education  ParentsAttend 	 TeachersAttend 
 UpdaterInfo1  UpdaterInfo2  UpdaterInfo3  UpdaterInfo4  UpdaterInfo5  ChenJianNoFound  AttendNoFound  EducationNoFound  MedicalNoFound  DownloadMedical  MedicalDownloading  DownloadingFailed  Version  	ClassName  	ChildName  Temperature 	 Hands 	 Mouth  Eyes 	 Nails 	 Cheek 
 Mental 	  Cough 
! Trauma 	" Other 
# Passed 	$ Reset 
% Failed & Skip ' 
Inspecting ( AIAnalyzing ) SkipExam * Click_OK + Click_Confirm , Click_Close - 	Click_Min . 	ExamPass1 / 	ExamPass2 0 	ExamPass3 1 	ExamPass4 2 NoHandAndMouthWarning 3 NoMouthWarning 4 NoHandWarning 5 PoseWarning1 6 PoseWarning2 7 PoseWarning3 8 TemperatureLittleHigh 9 TemperatureHigh : MouthNG ; MouthThroatNG < 
Toothdecay = Pinkeye 
> HandNG ? IsCheckingUpdate @ ProgramLaunching A NewestVersion B InitData C LoadingDevice D 	LoadingAI E LoadingNetService F ProgramLaunchingDone G CurrentMode H 
SwitchMode I 
ManualMode J AutoMode K 
PromptTone L 	DepthMode M MaskMode N 	WristMode O SyncInfo P ErrorReport Q 	ErrorInfo R DataDetails S UpdatedInfo T HelpInfo U ErrorTable_PIN V ErrorTable_Version W ErrorTable_Date X ErrorTable_No Y ErrorTable_Type Z ErrorTable_CreateTime [ ErrorTable_Info \ DetailTable_Health ] DetailTable_Sign ^ DetailTable_Date _ DetailTable_Class ` DetailTable_Name a DetailTable_Search b DetailTable_UploadAll c DetailTable_TotalNumber d DetailTable_PassedNumber e DetailTable_FailedNumber f DetailTable_UploadSuccessed g DetailTable_UploadFailde h DetailTable_No i DetailTable_Card j DetailTable_Temperature k DetailTable_HandImg l DetailTable_MouthImg m DetailTable_EyeImg n DetailTable_Abnormality o DetailTable_Status p DetailTable_IsUploaded q DetailTable_ShowImg r DetailTable_HasUploaded s DetailTable_HasNoUploaded t DetailTable_HandNG u DetailTable_MouthNG v DetailTable_EyeNG w DetailTable_TemperatureNG x DetailTable_CheekNG y DetailTable_MentalNG z DetailTable_TraumaNG { DetailTable_CoughNG | DetailTable_LongNG } DetailTable_ToothNG ~ DetailTable_ThroatNG  DetailTable_OtherNG � Error_InitAIDL � 
Error_AIDL � Error_InitCamera � Error_Camera � Error_ExamTimeOut � Error_NetFailed � Error_LoadSettingXML � Error_LoadOptionXML � Error_LoadServerXML � NewsForWrist � NewsInfoForWrist � 
SelectMode � SelectModeInfo1 � SelectModeInfo2 � SelectModeInfo3 � SelectModeInfo4 � HelpInfoDetail1 � HelpInfoDetail2 � HelpInfoDetail3 � HelpInfoDetail4 � HelpInfoDetail5�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      $localclr-namespace:Localization  5      1system&clr-namespace:System;assembly=mscorlib  5      %4"  &	        &	 *     &	 N     &	 r     &	 �     &	 �     &	 �     &	     &	 &    &		 S    &	
 �    &	 �    &	 �    &	     &	 U    &	 �    &	 �    &	 �    &	 (    &	 U    &	 �    &	 �    &	 $    &	 H    &	 f    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	 8    &	  V    &	! t    &	" �    &	# �    &	$ �    &	% �    &	& 
    &	' (    &	( O    &	) |    &	* �    &	+ �    &	, �    &	- �    &	.     &	/ P    &	0 z    &	1 �    &	2 �    &	3 X    &	4 �    &	5 	    &	6 B	    &	7 �	    &	8 �	    &	9 �	    &	: 
    &	; _
    &	< �
    &	= �
    &	> 7    &	? |    &	@ �    &	A �    &	B     &	C B    &	D r    &	E �    &	F �    &	G �    &	H     &	I :    &	J Y    &	K x    &	L �    &	M �    &	N �    &	O     &	P ,    &	Q P    &	R z    &	S �    &	T �    &	U �    &	V     &	W 1    &	X O    &	Y m    &	Z �    &	[ �    &	\ �    &	] �    &	^     &	_ <    &	` Z    &	a x    &	b �    &	c �    &	d �    &	e     &	f /    &	g S    &	h w    &	i �    &	j �    &	k �    &	l �    &	m     &	n =    &	o a    &	p �    &	q �    &	r �    &	s �    &	t     &	u 9    &	v ]    &	w �    &	x �    &	y �    &	z �    &	{     &	| )    &	} M    &	~ k    &	 �    &	� �    &	� �    &	�     &	� C    &	� m    &	� �    &	� �    &	�      &	� :    &	� t    &	� �    &	� �    &	� �    &	� �    &	� 0    &	� c    &	� Z    &	� �    &	�     &	� �    &	� 7    ��5      成长特工站-06��6*   ��5	      离园考勤��6)   ��5
      课堂助教��6,   ��5      体检程序��6/   ��5      晨检签到��6+   ��5      离园抓拍��6)   ��5      体检程序��6*   ��5      课堂助教��6,   ��5      家长移动端入口��63   ��5      老师移动端入口��64   ��5      正在检测...��62   ��5      正在下载升级包...��65   ��5      +'下载完成，正在解压升级包...��6:   ��5      +'解压完成，正在安装升级包...��6:   ��5      2.已是最新版本,正在重新启动程序...��6=   ��5      未找到晨检程序��65   ��5      未找到考勤程序��63   ��5       未找到课堂助教程序��68   ��5!      未找到体检程序��64   ��5"      40发现新功能！是否要下载体检程序？��6>   ��5$      62下载中，大概需要五分多钟,请稍候 ...��6E   ��5%      )%下载失败,请检查网络状况...��6?   ��5)      版本号：��6*   ��5*      
班级��6*   ��5+      
姓名��6*   ��5-      
额温��6,   ��5.      
手部��6&   ��5/      
口部��6&   ��50      
眼部��6%   ��51      
指甲��6&   ��52      
腮部��6&   ��53      
精神��6'   ��54      
咳嗽��6&   ��55      
外伤��6'   ��56      
其它��6&   ��58      
入园��6'   ��59      
复检��6&   ��5:      
离园��6'   ��5;      
跳过��6%   ��5=      开始检查...��60   ��5>      图像算法分析...��63   ��5@      跳过晨检��6+   ��5C      好 的��6*   ��5D      确 定��6/   ��5E      
关闭��6,   ��5F      	最小化��6+   ��5I      你最近表现棒极了！��61   ��5J      宝贝真厉害！��6.   ��5K      ($每天都要这样健康快乐哟！��64   ��5L      .*你认真晨检的时候也太靓了吧！��66   ��5N      LH未检测到标准的口腔上颚和手部区域，请纠正晨检姿势��6L   ��5O      @<未检测到清晰的口腔上颚区，请纠正晨检姿势��6A   ��5P      C?未检测到手部或光线影响较大，请避免强光直射��6A   ��5R      +'伸伸手，抬抬头，嘴巴要张大��68   ��5S      +'弯弯腿，抬抬头，嘴巴要张大��68   ��5T      伸伸手，弯弯腿��62   ��5V      "温度略高，请注意观察��6>   ��5W      "温度偏高，请老师确认��68   ��5Y      1-检测到口腔疑似异常，请老师确认��65   ��5Z      40检测到口腔有疑似发红，请注意观察��6<   ��5[      40检测到口腔有疑似蛀牙，请注意观察��69   ��5\      40检测到眼部有疑似发红，请注意观察��66   ��5]      1-检测到手部疑似异常，请老师确认��64   ��5`      正在检测...��66   ��5a      程序启动中：��65   ��5b      1-已是最新版本，正在重新启动程序��6;   ��5c      正在加载初始数据��6/   ��5d      正在加载智能设备��64   ��5e      正在加载AI模块��60   ��5f      正在构建网络服务��68   ��5g      启动完成��67   ��5j      当前模式��6.   ��5k      切换模式��6-   ��5l      复 核��6-   ��5m      自 动��6+   ��5n      	提示音��6,   ��5o      深度模式��6,   ��5p      口罩模式��6+   ��5q      腕温模式��6,   ��5r      卡信息同步��6,   ��5s      错误上报��6.   ��5t      查看错误信息��6.   ��5u      数据明细��6.   ��5v      更新日志��6.   ��5x      使用指南��6+   ��5z      	设备号��60   ��5{      当前软件版本��67   ��5|      
日期��60   ��5}      
编号��6.   ��5~      错误类型��62   ��5      产生时间��68   ��5�      错误信息��62   ��5�      健康报告��65   ��5�      	签到表��62   ��5�      
日期��61   ��5�      
班级��62   ��5�      
姓名��61   ��5�      
查找��63   ��5�      全部上传��68   ��5�      当天晨检总人数��6=   ��5�      入园人数��6;   ��5�      离园人数��6;   ��5�      上传成功��6>   ��5�      上传失败��6;   ��5�      
序号��6/   ��5�      
卡号��61   ��5�      
体温��68   ��5�      手部图片��66   ��5�      口腔图片��67   ��5�      眼部图片��65   ��5�      异常情况��6:   ��5�      入园状态��65   ��5�      数据是否上传��6;   ��5�      显示照片��66   ��5�      	已上传��69   ��5�      	未上传��6;   ��5�      手部异常��65   ��5�      口部异常��66   ��5�      眼睛发红��64   ��5�      温度异常��6<   ��5�      腮部异常��66   ��5�      精神不佳��67   ��5�      
外伤��65   ��5�      
咳嗽��64   ��5�      指甲过长��65   ��5�      
蛀牙��64   ��5�      咽喉发红��67   ��5�      其他异常��66   ��5�      深度算法初始化失败��66   ��5�      口腔深度算法异常��61   ��5�      启动摄像头失败��66   ��5�      相机抓拍失败��61   ��5�      检查超时：20 s��69   ��5�      连接服务器失败��65   ��5�      '#Setting.xml配置文件读取出错��6F   ��5�      &"Option.xml配置文件读取出错��6D   ��5�      &"Server.xml配置文件读取出错��6D   ��5�      腕温模式上线啦！��63   ��5�      ��基于近期各地区入园要求，为方便园所每日进行幼儿温度检测，特推出【腕温模式】。 该模式下可对幼儿腕部进行温度采集，帮助园所有效提高防疫期间的入园效率。��6~   ��5�      请选择模式��6.   ��5�      ($（手、口、眼、温度四项）��6:   ��5�      （仅测量额头温度）��67   ��5�      （仅测量腕部温度）��67   ��5�      ��*具体使用方法可在选择腕温模式后，点击程序右上角设置中的【使用指南】查看。 仅初次使用时需要选择模式，后期需要调整模式请在程序右上角的设置中进行调整。��6~   ��5�      LH进入【晨检签到】程序后，点击右上角的【腕温模式】��6F   ��5�      LH等待片刻，待模式切换完成后，即可使用【腕温模式】��6F   ��5�      ��该模式下，家长刷卡后，儿童个人信息将显示在屏幕上。（也可不刷卡，后续测温数据将不与儿童个人信息绑定）��6f   ��5�      YU随后，儿童将手腕靠近机器人头部的温度传感器，距离在5cm 左右��6R   ��5�      ��机器人可自动感知温度变化，待温度数据采集完毕后，将在屏幕上显示最终测量温度，并根据该温度做出相应语音提示与屏幕显示。（为保证测温准确性，请勿将机器置于出风口或空调下，并保持腕部干燥）��6�   5�      