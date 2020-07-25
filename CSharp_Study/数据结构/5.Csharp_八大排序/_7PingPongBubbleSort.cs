using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    public static partial class Sort {
        /// <summary>
        /// 双向冒泡排序
        /// </summary>
        /// <typeparam name="T">要传入的类型</typeparam>
        /// <param name="data">将被排序的数组</param>
        /// <param name="direction">排序方向，true升序，false降序</param>
        /// <returns></returns>
        public static T[] PingPongBubbleSort<T>(T[] data, bool direction = true) where T : IComparable {
            //从前往后冒泡
            int m = 0;
            int i = data.Length - 1;
            while ( i > 0) {
                bool flag = true;
                for (int j = m; j < i; j++) {
                    if (direction ? data[j].CompareTo(data[j + 1]) > 0 : data[j].CompareTo(data[j + 1]) < 0) {
                        T temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                        flag = false;
                    }
                }
                if (flag) break;
                for (int j = i; j > m; j--) {
                    if (direction ? data[j].CompareTo(data[j - 1]) < 0 : data[j].CompareTo(data[j - 1]) > 0) {
                        T temp = data[j];
                        data[j] = data[j - 1];
                        data[j - 1] = temp;
                        flag = false;
                    }
                }
                if (flag) break;
                i--;
            }
            return data;
        }
    }
}
