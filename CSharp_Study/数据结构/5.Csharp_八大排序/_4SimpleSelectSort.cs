using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    public static partial class Sort {
        /// <summary>
        /// 简单选择排序
        /// </summary>
        /// <typeparam name="T">传入类型</typeparam>
        /// <param name="data">将要被排序的数组</param>
        /// <param name="direction">true升序，false降序</param>
        /// <returns></returns>
        public static T[] SimpleSelectSort<T>(T[] data, bool direction = true) where T:IComparable{
            if(direction == true) {
                for (int i = 0; i < data.Length - 1; i++) {
                    int minIndex = i;
                    for (int j = i + 1; j < data.Length; j++) {
                        if (data[minIndex].CompareTo(data[j]) > 0)
                            minIndex = j;
                    }
                    if (minIndex != i) {
                        T temp = data[minIndex];
                        data[minIndex] = data[i];
                        data[i] = temp;
                    }
                }
            }
            else {
                for (int i = 0; i < data.Length - 1; i++) {
                    int maxIndex = i;
                    for (int j = i + 1; j < data.Length; j++) {
                        if (data[maxIndex].CompareTo(data[j]) < 0)
                            maxIndex = j;
                    }
                    if (maxIndex != i) {
                        T temp = data[maxIndex];
                        data[maxIndex] = data[i];
                        data[i] = temp;
                    }
                }
            }
            return data;
        }
    }
}
