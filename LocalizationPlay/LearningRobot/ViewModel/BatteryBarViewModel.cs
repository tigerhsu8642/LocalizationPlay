using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace LearningRobot.ViewModel
{
    // BatteryBarViewModel
    class BatteryBarViewModel : ViewModelBase
    {
        private bool _showNotification = true;

        /// <summary>
        /// 电量
        /// </summary>
        private double _quantity = -1.0;
        public double Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    RaisePropertyChanged("Quantity");

                    QuantityText = Convert.ToString(Convert.ToInt16(Math.Floor(value))) + "%";

                    if (value <= 26)
                    {
                        IsLowPower = true;

                        if (_showNotification)
                        {
                            App.ShowDialog("HMI.PowerNotificationView", new PowerNotificationViewModel());
                            _showNotification = false;
                        }
                    }
                    else
                    {
                        IsLowPower = false;
                    }
                }
            }
        }

        /// <summary>
        /// 是否是低电量状态
        /// </summary>
        private bool _isLowPower = false;
        public bool IsLowPower
        {
            get { return _isLowPower; }
            set
            {
                if (_isLowPower != value)
                {
                    _isLowPower = value;
                    RaisePropertyChanged("IsLowPower");
                }
            }
        }

        /// <summary>
        /// 是否在充电中
        /// </summary>
        private bool _isCharging = false;
        public bool IsCharging
        {
            get { return _isCharging; }
            set
            {
                if (_isCharging != value)
                {
                    _isCharging = value;
                    RaisePropertyChanged("IsCharging");
                }
            }
        }

        /// <summary>
        /// 电量文本
        /// </summary>
        private string _quantityText = "";
        public string QuantityText
        {
            get { return _quantityText; }
            set
            {
                if (!_quantityText.Equals(value))
                {
                    _quantityText = value;
                    RaisePropertyChanged("QuantityText");
                }
            }
        }
    }
}
