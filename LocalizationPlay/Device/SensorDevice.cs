using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LLComm;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Option;

namespace Device
{
    // SensorDevice
    public class SensorDevice<R, T> : DeviceBase
    {
        public event Action<R> OnRawData;

        private object _rawDataLocker = new object();
        private R _rawData = default(R);
        private T _sample = default(T);

        private Task _task = null;
        private bool _runnable = true;
        private AutoResetEvent _event = new AutoResetEvent(false);

        /// <summary>
        /// 构造函数
        /// </summary>
        protected SensorDevice(Settings option, Messenger messenger)
            : base(option, messenger)
        {
            //StartThread();
        }

        /// <summary>
        /// 启动数据处理线程
        /// </summary>
        public void StartThread()
        {
            if (_task == null)
            {
                _task = new Task(ThreadRoutine);
            }
            _runnable = true;
            _task.Start();
        }

        /// <summary>
        /// 停止数据处理线程
        /// </summary>
        public void StopThread()
        {
            _runnable = false;
            _event.Set();
        }

        /// <summary>
        /// 唤醒数据处理线程
        /// </summary>
        protected void StartDataProcessing()
        {
            _event.Set();
        }

        /// <summary>
        /// 处理原始数据
        /// </summary>
        protected virtual void ProcessData(R d)
        {
        }

        /// <summary>
        /// 传感器原始数据
        /// </summary>
        protected R RawData
        {
            get
            {
                lock (_rawDataLocker)
                {
                    return _rawData;
                }
            }

            set
            {
                lock (_rawDataLocker)
                {
                    _rawData = value;
                }
            }
        }

        /// <summary>
        /// 传感器采样值(处理后)
        /// </summary>
        public T Sample
        {
            get
            {
                lock (_sample)
                {
                    return _sample;
                }
            }

            set
            {
                lock (_sample)
                {
                    _sample = value;
                }
            }
        }

        /// <summary>
        /// 数据处理线程
        /// </summary>
        private void ThreadRoutine()
        {
            while (true)
            {
                // 等待数据
                _event.WaitOne();

                if (!_runnable)
                {
                    break;
                }

                // 获取原始数据
                R rawData = this.RawData;

                // 发送原始数据更新通知
                if (OnRawData != null)
                {
                    OnRawData(rawData);
                }

                // 数据处理
                ProcessData(rawData);
            }
        }
    }
}
