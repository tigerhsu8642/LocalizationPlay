using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LLComm;
using Option;



namespace Device
{
    // TemperatureSample
    public class TemperatureSample
    {
        public TemperatureSample(double Tamb, double Tobj)
        {
            this.Tamb = Tamb;
            this.Tobj = Tobj;
        }

        public double Tamb { get; set; }
        public double Tobj { get; set; }
    }

    // TemperatureSensor
    public class TemperatureSensor : SensorDevice<TemperatureSample, Double>
    {
        private MeanFilter _filter = new MeanFilter();

        // CorrectUnit
        class CorrectUnit
        {
            public double OriginalValue { get; set; }
            public double CorrectValue { get; set; }
        };

        private static readonly CorrectUnit[] _CorrectTable = new CorrectUnit[] {
            new CorrectUnit{ OriginalValue = 37.6, CorrectValue = 37.4 },
            new CorrectUnit{ OriginalValue = 37.5, CorrectValue = 37.3 },
            new CorrectUnit{ OriginalValue = 37.4, CorrectValue = 37.2 },
            new CorrectUnit{ OriginalValue = 37.3, CorrectValue = 37.1 },
            new CorrectUnit{ OriginalValue = 36.7, CorrectValue = 36.8 },
            new CorrectUnit{ OriginalValue = 36.6, CorrectValue = 36.8 },
            new CorrectUnit{ OriginalValue = 36.5, CorrectValue = 36.8 },
            new CorrectUnit{ OriginalValue = 36.4, CorrectValue = 36.8 },
            new CorrectUnit{ OriginalValue = 36.3, CorrectValue = 36.8 },
            new CorrectUnit{ OriginalValue = 36.2, CorrectValue = 36.7 },
            new CorrectUnit{ OriginalValue = 36.1, CorrectValue = 36.7 },
            new CorrectUnit{ OriginalValue = 36.0, CorrectValue = 36.7 },
            new CorrectUnit{ OriginalValue = 35.9, CorrectValue = 36.6 },
            new CorrectUnit{ OriginalValue = 35.8, CorrectValue = 36.6 },
            new CorrectUnit{ OriginalValue = 35.7, CorrectValue = 36.6 },
            new CorrectUnit{ OriginalValue = 35.6, CorrectValue = 36.5 },
            new CorrectUnit{ OriginalValue = 35.5, CorrectValue = 36.5 },
            new CorrectUnit{ OriginalValue = 35.4, CorrectValue = 36.5 },
            new CorrectUnit{ OriginalValue = 35.3, CorrectValue = 36.4 },
            new CorrectUnit{ OriginalValue = 35.2, CorrectValue = 36.4 },
            new CorrectUnit{ OriginalValue = 35.1, CorrectValue = 36.3 },
            new CorrectUnit{ OriginalValue = 35.0, CorrectValue = 36.3 },
            new CorrectUnit{ OriginalValue = 34.9, CorrectValue = 36.2 },
            new CorrectUnit{ OriginalValue = 34.8, CorrectValue = 36.0 },
            new CorrectUnit{ OriginalValue = 34.7, CorrectValue = 35.7 },
            new CorrectUnit{ OriginalValue = 34.6, CorrectValue = 35.3 },
            new CorrectUnit{ OriginalValue = 34.5, CorrectValue = 35.2 },
        };

        /// <summary>
        /// 构造函数
        /// </summary>
        public TemperatureSensor(Settings option, Messenger messenger)
            : base(option, messenger)
        {
            // 启动线程
            StartThread();
        }

        public void Reset()
        {
            lock (_filter)
            {
                _filter.Reset();
            }
        }

        /// <summary>
        /// 处理原始数据
        /// </summary>
        protected override void ProcessData(TemperatureSample rawData)
        {
            if (rawData == null)
            {
                return;
            }

            double Tobj = rawData.Tobj;
            double Tamb = rawData.Tamb;

            const double dt = 0.2;
            double value = Calibrate((Tobj + dt) + 0.188 * (Tobj + dt - Tamb));

            lock (_filter)
            {
                value = _filter.Filter(value);
                if (value > 26.0 && value <= 36.0)
                {
                    value = 36.0 + 0.1 * (value - 26.0);
                }

                this.Sample = value;
            }
        }

        /// <summary>
        /// 消息处理函数
        /// </summary>
        protected override void OnMessage(Message msg)
        {
            if (msg.MessageID == MID.TP_UPD)
            {
                double Tobj = msg.GetInt16(0) * 0.02 - 273.15;
                double Tamb = msg.GetInt16(2) * 0.02 - 273.15;
                this.RawData = new TemperatureSample(Tamb, Tobj);
                StartDataProcessing();
               
            }
        }

        /// <summary>
        /// 温度值校验
        /// </summary>
        private double Calibrate(double data)
        {
            double value = Convert.ToDouble(data.ToString("0.0"));
            foreach (CorrectUnit unit in _CorrectTable)
            {
                if (value == unit.OriginalValue)
                {
                    value = unit.CorrectValue;
                    break;
                }
            }
            return value;
        }

       
    }
}
