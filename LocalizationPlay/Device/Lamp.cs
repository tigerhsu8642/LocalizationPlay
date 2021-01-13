using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LLComm;
using Option;

using System.Diagnostics;
using System.Threading;

namespace Device
{
    // Lamp
    public class Lamp : DeviceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Lamp(Settings option, Messenger messenger)
            : base(option, messenger, false)
        {
        }

        /// <summary>
        /// 打开指定位置的补光灯
        /// </summary>
        public void TurnON(Lamp.Mounting m)
        {
            
            Message msg = new Message(MID.LED_ON, 1);

            if (m == Mounting.FACE)
            {
                msg.SetInt8((byte)LED.FACE);
            }
            else if (m == Mounting.MOUTH)
            {
                msg.SetInt8((byte)LED.MOUTH);
            }
            else if (m == Mounting.HAND)
            {
                msg.SetInt8((byte)LED.HAND);
            }

            SendMessage(msg);
                   
            
        }

        /// <summary>
        /// 关掉指定位置的补光灯
        /// </summary>
        public void TurnOFF(Lamp.Mounting m)
        {
            Message msg = new Message(MID.LED_OFF, 1);

            if (m == Mounting.FACE)
            {
                msg.SetInt8((byte)LED.FACE);
            }
            else if (m == Mounting.MOUTH)
            {
                msg.SetInt8((byte)LED.MOUTH);
            }
            else if (m == Mounting.HAND)
            {
                msg.SetInt8((byte)LED.HAND);
            }

            SendMessage(msg);
        }

        // Mounting
        public enum Mounting
        {
            FACE,
            MOUTH,
            HAND
        }

    }
}
