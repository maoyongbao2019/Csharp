using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    public static partial class Sort {
        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <typeparam name="T">数组类型</typeparam>
        /// <param name="data">要被排序的数组</param>
        /// <param name="direction">排序的方向，true升序，false降序</param>
        /// <returns></returns>
        public static T[] ShellSort<T>(T[] data, bool direction = true)where T:IComparable {
            //设置步长
            int gap = data.Length / 2;
            while (gap >= 1) {
                ShellInsertSort<T>(data, gap, direction);
                gap = gap / 2;
            }
            return data;
        }

        private static void ShellInsertSort<T>(T[] data, int gap, bool direction = true) where T : IComparable {
            if (direction == true) {
                for (int i = gap; i < data.Length; i++) {
                    if (data[i].CompareTo(data[i - gap]) < 0) {
                        int j = i - gap;
                        T x = data[i];
                        data[i] = data[i - gap];
                        while (j >= 0 && x.CompareTo(data[j]) < 0) {
                            data[j + gap] = data[j];
                            j -= gap;
                        }
                        data[j + gap] = x;
                    }
                }
            }
            else {
                for (int i = gap; i < data.Length; i++) {
                    if (data[i].CompareTo(data[i - gap]) > 0) {
                        int j = i - gap;
                        T x = data[i];
                        data[i] = data[i - gap];
                        while (j >= 0 && x.CompareTo(data[j]) > 0) {
                            data[j + gap] = data[j];
                            j -= gap;
                        }
                        data[j + gap] = x;
                    }
                }
            }
        }
    }
}
