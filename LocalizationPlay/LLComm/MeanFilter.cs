using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace LLComm
{
    class MeanFilter
    {
        private double _sum = 0.0;
        private double _count = 0;

        /// <summary>
        /// 复位
        /// </summary>
        public void Reset()
        {
            _sum = 0.0;
            _count = 0;
        }

        /// <summary>
        /// 滤波
        /// </summary>
        public double Filter(double value)
        {
            _sum += value;
            _count++;

            return _sum / _count;
        }
    }

    // WindowMeanFilter
    class WindowMeanFilter
    {
        double[] _data = null;

        /// <summary>
        /// 构建滤波器
        /// </summary>
        public WindowMeanFilter(int d)
        {
            Debug.Assert(d > 1);
            _data = new double[d];
            Array.Clear(_data, 0, d);
        }

        /// <summary>
        /// 滤波
        /// </summary>
        public double Filter(double value)
        {
            _data[0] = value;
            value = _data.Average();

            for (int i = _data.Length - 1; i > 0; --i)
            {
                _data[i] = _data[i - 1];
            }

            return value;
        }
    }
}
