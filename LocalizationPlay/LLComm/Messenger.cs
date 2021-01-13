using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LLComm
{
    // Messenger
    public class Messenger
    {
        public event Action<Message> OnMessage;

        private const int BUFFER_SIZE = 128;

        private SerialPort _port = new SerialPort();
        private byte[] _buffer = new byte[BUFFER_SIZE];
        private int _count = 0;

        private Task _thread;
        private bool _runnable = true;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Messenger(string portName)
        {
            try
            {
                _port.PortName = portName;
                _port.BaudRate = 9600;
                _port.DataBits = 8;
                _port.Parity = Parity.None;
                _port.StopBits = StopBits.One;
                _port.Open();
            }
            catch { }
        }

        /// <summary>
        /// 启动线程
        /// </summary>
        public void Start()
        {
            _thread = new Task(() =>
            {
                do
                {
                    try
                    {
                        ThreadRoutine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                } while (_runnable);
            });

            _runnable = true;
            _thread.Start();
        }

        /// <summary>
        /// 停止工作
        /// </summary>
        public void Stop()
        {
            _runnable = false;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        public void SendMessage(Message msg)
        {
            lock (_port)
            {
                if (_port.IsOpen)
                {
                    byte[] data = msg.ToByteArray();
                    _port.Write(data, 0, data.Length);
                }
           	}
        }

        /// <summary>
        /// 主线程
        /// </summary>
        private void ThreadRoutine()
        {
            int pre;
            int readSize;
            int remain;
            int length;

            while (_runnable)
            {
                readSize = _port.Read(_buffer, _count, BUFFER_SIZE - _count);
                if (readSize <= 0)
                {
                    continue;
                }

                _count += readSize;

                for (pre = 0; pre < _count; )
                {
                    if (_buffer[pre] == Message.MSG_PREAMBLE)
                    {
                        remain = _count - pre;
                        if (remain < Message.MSG_LEN_MSGHEADERCS)
                        {
                            break;
                        }

                        length = _buffer[pre + 3];
                        if (length <= Message.MSG_LEN_DATAMAX)
                        {
                            if (remain < length + Message.MSG_LEN_MSGHEADERCS)
                            {
                                break;
                            }

                            Message msg = new Message();
                            if (msg.FromByteArray(_buffer, pre, remain))
                            {
                                if (OnMessage != null)
                                {
                                    OnMessage(msg);
                                }

                                //Console.WriteLine(@"ID={0}, Len={1}, CS={2}", msg.MessageID, msg.Length, msg.Checksum);
                                pre += msg.Length;
                                msg = null;
                                continue;
                            }
                        }
                    }

                    ++pre;
                }

                if (pre != 0)
                {
                    _count -= pre;
                    for (int i = 0; i < _count; ++i)
                    {
                        _buffer[i] = _buffer[i + pre];
                    }
                }
            }
        }
    }
}
