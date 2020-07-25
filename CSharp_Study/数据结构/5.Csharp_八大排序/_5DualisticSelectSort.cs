using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    public static partial class Sort {
        /// <summary>
        /// 二元选择排序
        /// </summary>
        /// <typeparam name="T">排序的类型</typeparam>
        /// <param name="data">将被排序的数组</param>
        /// <param name="direction">排序的方向，true升序，false降序</param>
        /// <returns></returns>
        public static T[] DualisticSelectSort<T>(T[] data, bool direction = true) where T : IComparable {
            //这个算法要考虑连续两次交换会导致值的错误
            if (direction == true) {
                int length = data.Length-1;
                for (int i = 0; i < length; i++) {
                    int minIndex = i;
                    int maxIndex = i;
                    for (int j = i + 1; j <= length; j++) {
                        if (data[minIndex].CompareTo(data[j]) > 0) {
                            minIndex = j;
                            continue;
                        }
                        if (data[maxIndex].CompareTo(data[j]) < 0)
                            maxIndex = j;
                    }
                    if (minIndex != i) {
                        T temp = data[minIndex];
                        data[minIndex] = data[i];
                        data[i] = temp;
                    }
                    if (maxIndex == i) {
                        maxIndex = minIndex;//增加这个细节防止值出错
                    }
                    if (maxIndex != length) {
                        T temp = data[maxIndex];
                        data[maxIndex] = data[length];
                        data[length] = temp;
                    }
                    length--;
                }
            }
            else {
                int length = data.Length - 1;
                for (int i = 0; i < length; i++) {
                    int minIndex = i;
                    int maxIndex = i;
                    for (int j = i + 1; j <= length; j++) {
                        if (data[maxIndex].CompareTo(data[j]) < 0) {
                            maxIndex = j;
                            continue;
                        }                  
                        if (data[minIndex].CompareTo(data[j]) > 0) 
                            minIndex = j;
                    }
                    if (minIndex != length) {
                        T temp = data[minIndex];
                        data[minIndex] = data[length];
                        data[length] = temp;
                    }
                    if (maxIndex == length) {
                        maxIndex = minIndex;//增加这个细节防止值出错
                    }
                    if(maxIndex != i) {
                        T temp = data[maxIndex];
                        data[maxIndex] = data[i];
                        data[i] = temp;
                    }
                    length--;
                }
            }
            return data;
        }
    }
}
