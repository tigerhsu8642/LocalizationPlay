using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace LLComm
{
    // Message
    public class Message
    {
        public const byte MSG_PREAMBLE = 0xFE;
        public const byte MSG_DID_DUMMY = 0xFC;

        public const byte MSG_LEN_MSGHEADER = 4;
        public const byte MSG_LEN_MSGHEADERCS = 5;
        public const byte MSG_LEN_DATAMAX = 128;


        private byte _preamble;
        private byte _deviceID;
        private byte _messageID;
        private byte _length;

        private byte[] _data;
        private byte _checksum = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Message()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Message(byte messageID, byte length)
        {
            _preamble = MSG_PREAMBLE;
            _deviceID = MSG_DID_DUMMY;
            _messageID = messageID;
            _length = length;

            _data = new byte[length + 1];
            Array.Clear(_data, 0, length + 1);

            _checksum = length;
            this.Checksum = (byte)(-(_deviceID + _messageID + _length));
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Message(MID messageID, byte length)
            : this((byte)messageID, length)
        {
        }

        #region 属性
        /// <summary>
        /// 校验值
        /// </summary>
        public byte Checksum
        {
            get
            {
                return _data[_checksum];
            }

            set
            {
                _data[_checksum] = value;
            }
        }

        /// <summary>
        /// 消息唯一标识
        /// </summary>
        public MID MessageID
        {
            get { return (MID)_messageID; }
        }

        /// <summary>
        /// 消息总长度
        /// </summary>
        public int Length
        {
            get { return _length + MSG_LEN_MSGHEADERCS; }
        }

        /// <summary>
        /// 消息长度
        /// </summary>
        public int MessageLength
        {
            get { return _length; }
        }
        #endregion

        /// <summary>
        /// 获取8位整型数
        /// </summary>
        public byte GetInt8(int offset = 0)
        {
            Debug.Assert(offset < this.Length);
            return _data[offset];
        }

        /// <summary>
        /// 获取16位整型数
        /// </summary>
        public short GetInt16(int offset = 0)
        {
            Debug.Assert(offset + 1 < this.Length);
            return BitConverter.ToInt16(_data, offset);
        }

        /// <summary>
        /// 获取32位整型数
        /// </summary>
        public int GetInt32(int offset = 0)
        {
            Debug.Assert(offset + 3 < this.Length);
            return BitConverter.ToInt32(_data, offset);
        }

        /// <summary>
        /// 设置8位整型数
        /// </summary>
        public void SetInt8(byte value, int offset = 0)
        {
            Debug.Assert(offset < this.Length);
            this.Checksum += (byte)(_data[offset] - value);
            _data[offset] = value;
        }

        /// <summary>
        /// 设置16位整型数
        /// </summary>
        public void SetInt16(short value, int offset = 0)
        {
            Debug.Assert(offset + 1 < this.Length);
            byte[] bytes = BitConverter.GetBytes(value);

            this.Checksum += (byte)(_data[offset] + _data[offset + 1] - bytes[0] - bytes[1]);
            _data[offset] = bytes[0];
            _data[offset+1] = bytes[1];
        }

        /// <summary>
        /// 设置32位整型数
        /// </summary>
        public void SetInt32(int value, int offset = 0)
        {
            Debug.Assert(offset + 1 < this.Length);
            byte[] bytes = BitConverter.GetBytes(value);

            this.Checksum += (byte)(_data[offset] + _data[offset + 1] + _data[offset + 2] + _data[offset + 3]
                    - bytes[0] - bytes[1] - bytes[2] - bytes[3]);
            _data[offset] = bytes[0];
            _data[offset + 1] = bytes[1];
            _data[offset + 2] = bytes[2];
            _data[offset + 3] = bytes[3];
        }

        /// <summary>
        /// 判断消息有效性
        /// </summary>
        public bool IsValid()
        {
            int cs = 0;

            cs -= _deviceID;
            cs -= _messageID;
            cs -= _length;

            for (byte i = 0; i < _length; ++i)
            {
                cs -= _data[i];
            }

            return (this.Checksum == (byte)cs);
        }

        /// <summary>
        /// 拷贝消息信息到内存中
        /// </summary>
        public byte[] ToByteArray()
        {
            byte[] data = new byte[this.Length];
            data[0] = _preamble;
            data[1] = _deviceID;
            data[2] = _messageID;
            data[3] = _length;
            Array.Copy(_data, 0, data, 4, _length + 1);
            return data;
        }

        /// <summary>
        /// 从内存中解析消息
        /// </summary>
        public bool FromByteArray(byte[] data, int offset, int length)
        {
            if (length < MSG_LEN_MSGHEADERCS)
            {
                return false;
            }

            _preamble = data[offset];
            _deviceID = data[offset + 1];
            _messageID = data[offset + 2];
            _length = data[offset + 3];

            if ((_preamble != MSG_PREAMBLE) || (length < this.Length))
            {
                return false;
            }

            _checksum = _length;
            _data = new byte[_length + 1];
            Array.Copy(data, offset + 4, _data, 0, _length + 1);

            return IsValid();
        }
    }
}
