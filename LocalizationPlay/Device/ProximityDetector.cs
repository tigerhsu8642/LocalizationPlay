using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LLComm;
using Option;
using System.Threading.Tasks;
using System.Threading;

namespace Device
{
    // ProximityDetector
    public class ProximityDetector : DeviceBase
    {
        public event Action OnTriggered;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ProximityDetector(Settings option, Messenger messenger)
            : base(option, messenger)
        {
            //Task task = new Task(() =>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(8000);
            //        if (OnTriggered != null)
            //        {
            //            OnTriggered();
            //        }
            //    }
            //});

            //task.Start();
        }

        /// <summary>
        /// 消息处理函数
        /// </summary>
        protected override void OnMessage(Message msg)
        {
            if (msg.MessageID == MID.DT_TRIGGERED)
            {
                if (OnTriggered != null)
                {
                    OnTriggered();
                }
            }
        }
    }
}
