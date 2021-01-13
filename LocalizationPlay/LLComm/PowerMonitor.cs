using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLComm
{
    // PowerMonitor
    public class PowerMonitor : DeviceBase
    {
        public event Action<double> OnPowerChanged;

        private const int FILTER_THRESHOLD = 5;
        private const double POWER_MAX = 25.5;
        private const double POWER_MIN = 21.6;

        private int _sampleCount = 0;
        private double _percent = -1.0;

        private WindowMeanFilter _meanFilter = new WindowMeanFilter(FILTER_THRESHOLD);

        /// <summary>
        /// 构造函数
        /// </summary>
        public PowerMonitor(Messenger messenger)
            : base(messenger)
        {
        }

        /// <summary>
        /// 添加样本
        /// </summary>
        private void AddNewSample(double power)
        {
            // 更新采样数
            _sampleCount++;

            // 滤波
            double value = _meanFilter.Filter(power);
            if (_sampleCount >= FILTER_THRESHOLD)
            {
                power = value;
            }

            //Console.WriteLine("power = {0} V", power);

            // 计算百分比
            double percent = 0.0;
            if (power >= POWER_MAX)
            {
                percent = 100.0;
            }
            else if (power <= POWER_MIN)
            {
                percent = 0.0;
            }
            else
            {
                percent = (power - POWER_MIN) * 100.0 / (POWER_MAX - POWER_MIN);
            }

            //Console.WriteLine("percent = {0}%", percent);

            // 更新通知
            if (percent != _percent)
            {
                _percent = percent;

                if (OnPowerChanged != null)
                {
                    OnPowerChanged(percent);

                //    System.Windows.Forms.MessageBox.Show("OnPowerChanged:"+ percent);
                }
            }
        }

        /// <summary>
        /// 消息处理函数
        /// </summary>
        protected override void OnMessage(Message msg)
        {
            if (msg.MessageID == MID.POWER)
            {
                double value = (msg.GetInt32() / 10000.0) * 112.4 / 12.4;
                AddNewSample(value);
            }
        }
    }
}
