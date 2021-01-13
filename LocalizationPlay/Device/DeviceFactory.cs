using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LLComm;
using Option;

namespace Device
{
    // DeviceFactory
    public class DeviceFactory
    {
        public TemperatureSensor TemperatureSensor { get; set; }
        public Buzzer Buzzer { get; set; }
        public Led LED { get; set; }
        public Lamp Lamp { get; set; }
        public CardReader CardReader { get; set; }
        public ProximityDetector ProximityDetector { get; set; }
        public PowerMonitor PowerMonitor { get; set; }
        public Fan Fan { get; set; }
        private Messenger Messenger { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DeviceFactory(Settings option)
        {
            this.Messenger = new Messenger(option.PortName);

            this.TemperatureSensor = new TemperatureSensor(option, this.Messenger);

            this.Buzzer = new Buzzer(option, this.Messenger);
            this.LED = new Led(option, this.Messenger);
            this.Lamp = new Lamp(option, this.Messenger);
            this.CardReader = new CardReader(option, this.Messenger);
            this.ProximityDetector = new ProximityDetector(option, this.Messenger);
            this.PowerMonitor = new PowerMonitor(option, this.Messenger);
            this.Fan = new Fan(option, this.Messenger);

            this.Messenger.Start();
        }

        /// <summary>
        /// 析构
        /// </summary>
        public void Release()
        {
            this.TemperatureSensor.StopThread();
            this.Messenger.Stop();
        }
    }
}