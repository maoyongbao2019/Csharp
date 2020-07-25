using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MainshiTest {
    public static partial class Sort {
        /// <summary>
        /// 快速夹杂插入排序
        /// </summary>
        /// <typeparam name="T">要传入的类型</typeparam>
        /// <param name="data">要被排序的数组</param>
        /// <param name="k">最小快排分段数组的长度</param>
        /// <param name="direction">排序方向，true升序，false降序</param>
        /// <returns></returns>
        public static T[] QuickInsertSort<T>(T[] data, int k = 0, bool direction = true)where T:IComparable
        {
            if (k <= 0) k = data.Length / 4;
            QuickSort(data, 0, data.Length - 1, k, direction);
            DualisticSelectSort(data, direction);
            return data;
        }

        private static void QuickSort<T>(T[] data, int low, int high, int k, bool direction = true) where T : IComparable
        {
            if (high - low > k) 
            {
                int location = partition<T>(data, low, high, direction);
                QuickSort<T>(data, low, location - 1, k, direction);
                QuickSort<T>(data, location + 1, high, k, direction);
            }
        }

        private static int partition<T>(T[] a, int low, int high, bool direction = true) where T : IComparable
        {
            T key = a[low];
            if (direction == true)
            {
                while (low < high)
                {
                    while (low < high && a[high].CompareTo(key) >= 0) high--;
                    T temp = a[low]; a[low] = a[high]; a[high] = temp;
                    while (low < high && a[low].CompareTo(key) <= 0) low++;
                    temp = a[low]; a[low] = a[high]; a[high] = temp;
                }
            }
            else
            {
                while (low < high)
                {
                    while (low < high && a[high].CompareTo(key) <= 0) high--;
                    T temp = a[low]; a[low] = a[high]; a[high] = temp;
                    while (low < high && a[low].CompareTo(key) >= 0) low++;
                    temp = a[low]; a[low] = a[high]; a[high] = temp;
                }
            }
            return low;
        }

        private static void DualisticSelectSort<T>(T[] data, bool direction = true) where T : IComparable
        {
            //这个算法要考虑连续两次交换会导致值的错误
            if (direction == true)
            {
                int length = data.Length - 1;
                for (int i = 0; i < length; i++)
                {
                    int minIndex = i;
                    int maxIndex = i;
                    for (int j = i + 1; j <= length; j++)
                    {
                        if (data[minIndex].CompareTo(data[j]) > 0)
                        {
                            minIndex = j;
                            continue;
                        }
                        if (data[maxIndex].CompareTo(data[j]) < 0)
                            maxIndex = j;
                    }
                    if (minIndex != i)
                    {
                        T temp = data[minIndex];
                        data[minIndex] = data[i];
                        data[i] = temp;
                    }
                    if (maxIndex == i)
                    {
                        maxIndex = minIndex;//增加这个细节防止值出错
                    }
                    if (maxIndex != length)
                    {
                        T temp = data[maxIndex];
                        data[maxIndex] = data[length];
                        data[length] = temp;
                    }
                    length--;
                }
            }
            else
            {
                int length = data.Length - 1;
                for (int i = 0; i < length; i++)
                {
                    int minIndex = i;
                    int maxIndex = i;
                    for (int j = i + 1; j <= length; j++)
                    {
                        if (data[maxIndex].CompareTo(data[j]) < 0)
                        {
                            maxIndex = j;
                            continue;
                        }
                        if (data[minIndex].CompareTo(data[j]) > 0)
                            minIndex = j;
                    }
                    if (minIndex != length)
                    {
                        T temp = data[minIndex];
                        data[minIndex] = data[length];
                        data[length] = temp;
                    }
                    if (maxIndex == length)
                    {
                        maxIndex = minIndex;//增加这个细节防止值出错
                    }
                    if (maxIndex != i)
                    {
                        T temp = data[maxIndex];
                        data[maxIndex] = data[i];
                        data[i] = temp;
                    }
                    length--;
                }
            }
        }
    }
}