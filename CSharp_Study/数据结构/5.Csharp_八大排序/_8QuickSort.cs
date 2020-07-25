using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    public static partial class Sort {
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <typeparam name="T">传入的类型</typeparam>
        /// <param name="data">将要被排序的数组</param>
        /// <param name="direction">true升序，false降序</param>
        /// <returns></returns>
        public static T[] QuickSort<T>(T[] data, bool direction = true) where T : IComparable {
            QuickSort<T>(data, 0, data.Length - 1, direction);
            return data;
        }

        private static void QuickSort<T>(T[] data, int low, int high, bool direction = true) where T : IComparable {
            if (low < high) {
                int location = partition<T>(data, low, high, direction);
                QuickSort<T>(data, low, location - 1, direction);
                QuickSort<T>(data, location + 1, high, direction);
            }
        }

        private static int partition<T>(T[] a, int low, int high,bool direction = true) where T : IComparable {
            T key = a[low];
            if(direction == true) {
                while (low < high) {
                    while (low < high && a[high].CompareTo(key) >= 0) high--;
                    T temp = a[low]; a[low] = a[high]; a[high] = temp;
                    while (low < high && a[low].CompareTo(key) <= 0) low++;
                    temp = a[low]; a[low] = a[high]; a[high] = temp;
                }
            }
            else {
                while (low < high) {
                    while (low < high && a[high].CompareTo(key) <= 0) high--;
                    T temp = a[low]; a[low] = a[high]; a[high] = temp;
                    while (low < high && a[low].CompareTo(key) >= 0) low++;
                    temp = a[low]; a[low] = a[high]; a[high] = temp;
                }
            }
            return low;
        }
    } 
}
