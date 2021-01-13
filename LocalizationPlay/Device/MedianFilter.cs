using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Device
{
    class MedianFilter
    {
        private List<double> _dataList = new List<double>();

        /// <summary>
        /// 重置滤波器
        /// </summary>
        public void Reset()
        {
            _dataList.Clear();
        }

        /// <summary>
        /// 滤波
        /// </summary>
        public double Filter(double value)
        {
            if (_dataList.Count > 50)
            {
                _dataList.RemoveAt(0);
            }

            _dataList.Add(value);
            _dataList.Sort();
            return _dataList[_dataList.Count / 2];
        }
    }
}
