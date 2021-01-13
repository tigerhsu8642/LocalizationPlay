using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Option;

namespace LLComm
{
    public class DeviceFactory
    {
        public PowerMonitor PowerMonitor { get; set; }
        public Fan Fan { get; set; }

        private Messenger Messenger { get; set; }

        private DeviceFactory(Settings option)
        {
            this.Messenger = new Messenger(option.PortName);

            this.PowerMonitor = new PowerMonitor(this.Messenger);
            this.Fan = new Fan(this.Messenger);

            this.Messenger.Start();
        }

        /// <summary>
        /// 析构
        /// </summary>
        public void Release()
        {
            this.Messenger.Stop();
        }

        public class Factory
        {
            private static DeviceFactory _robot = null;

            /// <summary>
            /// 工厂方法
            /// </summary>
            public static DeviceFactory Create()
            {

                if (_robot == null)
                {
                    _robot = new DeviceFactory(Settings.Left);
                }

                return _robot;
            }
        }
    }
}
