using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Option;
using LLComm;

namespace Device
{
    // Fan
    public class Fan : DeviceBase
    {
        private const byte FAN_ON = 1;
        private const byte FAN_OFF = 0;

        private object _locker = new object();
        //    private Timer _timer = new Timer(); //小凳子版20180824 眼睛用风扇控制

        /// <summary>
        /// 构造函数
        /// </summary>
        public Fan(Settings option, Messenger messenger)
            : base(option, messenger, false)
        {
        //    _timer.Elapsed += new ElapsedEventHandler(Timeout);
        //    _timer.Interval = 4000;
        }

        /// <summary>
        /// 开启风扇
        /// </summary>
        public void Start()
        {
            lock (_locker)
            {
                // 开启风扇
                SetOnOff(FAN_ON);

                // 开启定时器
         //       _timer.Enabled = true;
            }
        }

        /// <summary>
        /// 关闭风扇
        /// </summary>
        public void Stop()
        {
            lock (_locker)
            {
                // 关闭风扇
                SetOnOff(FAN_OFF);

                // 关闭定时器
        //        _timer.Enabled = false;
            }
        }

        /// <summary>
        /// 发送命令, 开启/关闭风扇
        /// </summary>
        private void SetOnOff(byte value)
        {
            Message msg = new Message(MID.FAN, 1);
            msg.SetInt8(value);
            SendMessage(msg);
        }

        /// <summary>
        /// 计时完成
        /// </summary>
        private void Timeout(object sender, ElapsedEventArgs e)
        {
            Stop();
        }
    }
}
