using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LLComm;
using Option;
using System.Diagnostics;

namespace Device
{
    // CardReader
    public class CardReader : DeviceBase
    {
        public event Action<uint> OnCardID;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CardReader(Settings option, Messenger messenger)
            : base(option, messenger)
        {

        }

        /// <summary>
        /// 消息处理函数
        /// </summary>
        protected override void OnMessage(Message msg)
        {
            if (msg.MessageID == MID.CARD_ID)
            {
                uint id = (uint)msg.GetInt32();

                Console.WriteLine("CardID={0}", id);

                /*
                if (id > 0)
                {
                    NetService.Factory.Create().SignIn(id.ToString(), "");  //等接送照片拍完之后再一起发送服务器
                }*/

                if (OnCardID != null)
                {
                    OnCardID(id);
                }
            }
        }

    }
}
