using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System.Windows;
using System.Diagnostics;
using System.Windows.Threading;
using LLComm;
using Option;
using System.Threading.Tasks;
using System.Threading;

namespace LearningRobot.ViewModel
{
    class MainWindowModel : ViewModelBase
    {
        private Window window { get; set; }
        public BatteryBarViewModel BatteryBarViewModel { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainWindowModel()
        {
            Init();
        }

        /// <summary>
        /// 构造函数，接收window作为参数
        /// </summary>
        public MainWindowModel(object window)
        {
            this.window = (Window)window;
            Init();
        }

        /// <summary>
        /// 初始化资源
        /// </summary>
        private void Init()
        {
            this.BatteryBarViewModel = new BatteryBarViewModel();
            this.BatteryBarViewModel.Quantity = 100;

            DeviceFactory.Factory.Create().PowerMonitor.OnPowerChanged += OnBattery;  
        }

        /// <summary>
        /// 网络连接
        /// </summary>
        private void OnConnected(string param)
        {
            IsConnected = true;
        }

        /// <summary>
        /// 网络断开
        /// </summary>
        private void OnDisconnected()
        {
            IsConnected = false;
        }

        /// <summary>
        /// 网络连接状态
        /// </summary>
        private bool _isConnected = false;
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }

            set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    RaisePropertyChanged("IsConnected");
                }
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        private void Release()
        {
            DeviceFactory.Factory.Create().PowerMonitor.OnPowerChanged -= OnBattery;
            App.DestoryWindow();
        }        

        private string _title = "";
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// 电量更新通知
        /// </summary>
        private void OnBattery(double value)
        {
            this.BatteryBarViewModel.Quantity = value;
        }
    
    }
}