using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LLComm;
using System.Threading.Tasks;
using System.Threading;
using Option;

namespace Device
{
    // Buzzer
    public class Buzzer : DeviceBase
    {
        public const int DEFAULT_FREQ = 4000;

        private Task _alarmBeepTask = null;
        private AutoResetEvent _alarmBeepTaskEvent = new AutoResetEvent(false);

        /// <summary>
        /// 构造函数
        /// </summary>
        public Buzzer(Settings option, Messenger messenger)
            : base(option, messenger, false)
        {
            _alarmBeepTask = new Task(() =>
            {
                while (true)
                {
                    // 等待请求
                    _alarmBeepTaskEvent.WaitOne();

                    bool beep = true;
                    while (beep)
                    {
                        foreach (AlarmBeepUnit unit in _AlarmBeepUnitTable)
                        {
                            if (Interlocked.Exchange(ref _alarmFlag, _alarmFlag) == 0)
                            {
                                beep = false;
                                break;
                            }

                            Beep(unit.Duration, unit.Freq);
                            Thread.Sleep(unit.Duration);
                        }

                        Thread.Sleep(2000);
                    }
                }
            });

            _alarmBeepTask.Start();
        }

        /// <summary>
        /// 蜂鸣
        /// </summary>
        public void Beep(int duration, int freq = DEFAULT_FREQ)
        {
            Message msg = new Message(MID.START_BEEP, 8);
            msg.SetInt32(freq, 0);
            msg.SetInt32(duration, 4);
            SendMessage(msg);
        }

        #region 警报
        private int _alarmFlag = 0;

        // AlarmBeepUnit
        class AlarmBeepUnit
        {
            public int Freq { get; set; }
            public int Duration { get; set; }
            public int Delay { get; set; }
        }

        private const int TONE_5 = 1568;
        private const int TONE_4 = 1397;
        private const int TONE_3 = 1318;
        private const int TONE_2 = 1175;
        private const int TONE_1 = 1046;

        private static readonly AlarmBeepUnit[] _AlarmBeepUnitTable = new AlarmBeepUnit[] {
            new AlarmBeepUnit{ Freq = TONE_5, Duration = 270 ,Delay = 390},
            new AlarmBeepUnit{ Freq = TONE_1, Duration = 140 ,Delay = 190},
            new AlarmBeepUnit{ Freq = TONE_2, Duration = 140 ,Delay = 190},
            new AlarmBeepUnit{ Freq = TONE_3, Duration = 140 ,Delay = 190},
            new AlarmBeepUnit{ Freq = TONE_4, Duration = 140 ,Delay = 190},
            new AlarmBeepUnit{ Freq = TONE_5, Duration = 270 ,Delay = 390},
            new AlarmBeepUnit{ Freq = TONE_1, Duration = 270 ,Delay = 390},
            new AlarmBeepUnit{ Freq = TONE_1, Duration = 270 ,Delay = 390},
        };

        /// <summary>
        /// 停止蜂鸣报警
        /// </summary>
        public void StopAlarmBeep()
        {
            Interlocked.Exchange(ref _alarmFlag, 0);
        }

        /// <summary>
        /// 开始蜂鸣报警
        /// </summary>
        public void StartAlarmBeep()
        {
            Interlocked.Exchange(ref _alarmFlag, 1);
            _alarmBeepTaskEvent.Set();
        }

        #endregion
    }
}
