using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Option;
using LLComm;

namespace Device
{
    // Led
    public class Led : DeviceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Led(Settings option, Messenger messenger)
            : base(option, messenger, false)
        {
        }

        /// <summary>
        /// 点亮红灯
        /// </summary>
        public void RedON()
        {
            TurnON(LED.ALARM_RED);
        }

        /// <summary>
        /// 关掉红灯
        /// </summary>
        public void RedOFF()
        {
            TurnOFF(LED.ALARM_RED);
        }

        /// <summary>
        /// 点亮绿灯
        /// </summary>
        public void GreenON()
        {
            TurnON(LED.ALARM_GREEN);
        }

        /// <summary>
        /// 关掉绿灯
        /// </summary>
        public void GreenOFF()
        {
            TurnOFF(LED.ALARM_GREEN);
        }

        /// <summary>
        /// 点亮标识灯
        /// </summary>
        public void MarkON()
        {
            TurnON(LED.MARK);
        }

        /// <summary>
        /// 关掉标识灯
        /// </summary>
        public void MarkOFF()
        {
            TurnOFF(LED.MARK);
        }

        /// <summary>
        /// 开启进度指示灯
        /// </summary>
        public void IndicatorON(int step = 0)
        {
            switch (step)
            {
                case 1:
                    TurnON(LED.STEP_1);
                    break;

                case 2:
                    TurnON(LED.STEP_2);
                    break;

                case 3:
                    TurnON(LED.STEP_3);
                    break;

                case 0:
                    TurnON(LED.STEP_1);
                //    TurnON(LED.STEP_2); //小凳子版20180821
                //    TurnON(LED.STEP_3);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 关闭进度指示灯
        /// </summary>
        public void IndicatorOFF()
        {
            TurnOFF(LED.STEP_1);
         //   TurnOFF(LED.STEP_2);  //小凳子版20180821
         //   TurnOFF(LED.STEP_3);
        }

        public void Warning()
        {
            TurnON(LED.STEP_3);
        }

        /// <summary>
        /// 开启
        /// </summary>
        private void TurnON(LED led)
        {
            Message msg = new Message(MID.LED_ON, 1);
            msg.SetInt8((byte)led);
            SendMessage(msg);
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void TurnOFF(LED led)
        {
            Message msg = new Message(MID.LED_OFF, 1);
            msg.SetInt8((byte)led);
            SendMessage(msg);
        }
    }
}
