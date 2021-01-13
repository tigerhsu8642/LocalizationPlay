using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LLComm;
using System.Xml;
using Option;

namespace Device
{
    // DeviceBase
    public class DeviceBase
    {
        protected Messenger Messenger { get; set; }
        protected Settings Option { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected DeviceBase(Settings option, Messenger messenger, bool recvMsg = true)
        {
            Option = option;
            Messenger = messenger;

            if (recvMsg)
            {
                Messenger.OnMessage += MessageHandler;
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~DeviceBase()
        {
            Messenger.OnMessage -= MessageHandler;
            Messenger = null;
        }

        /// <summary>
        /// 消息处理函数
        /// </summary>
        protected virtual void OnMessage(Message msg)
        {

        }

        /// <summary>
        /// 发送消息
        /// </summary>
        protected void SendMessage(Message msg)
        {
            Messenger.SendMessage(msg);
        }

        /// <summary>
        /// 分发处理来自LLComm的消息
        /// </summary>
        public void MessageHandler(Message msg)
        {
            this.OnMessage(msg);
        }

       
    }
}
