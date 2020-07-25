using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    public static partial class Sort {
        /// <summary>
        /// 单向冒泡排序
        /// </summary>
        /// <typeparam name="T">传入类型</typeparam>
        /// <param name="data">将要被排序的数组</param>
        /// <param name="direction">排序方向，true升序，false降序</param>
        /// <returns></returns>
        public static T[] BubbleSort<T>(T[] data, bool direction = true)where T:IComparable {
            //从前往后冒泡
            if(direction == true) {
                for (int i = data.Length - 1; i > 0; i--) {
                    bool flag = true;
                    for (int j = 0; j < i; j++) {
                        if (data[j].CompareTo(data[j + 1]) > 0) {
                            T temp = data[j];
                            data[j] = data[j + 1];
                            data[j + 1] = temp;
                            flag = false;
                        }
                    }
                    if (flag) break;
                }
            }
            else {
                for (int i = data.Length - 1; i > 0; i--) {
                    bool flag = true;
                    for (int j = 0; j < i; j++) {
                        if (data[j].CompareTo(data[j + 1]) < 0) {
                            T temp = data[j];
                            data[j] = data[j + 1];
                            data[j + 1] = temp;
                            flag = false;
                        }
                    }
                    if (flag) break;
                }
            }
            return data;
        }
    }
}
