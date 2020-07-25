using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MainshiTest {
    public static partial class Sort {
        /// <summary>
        /// 直接插入排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="data">将被排序的数据集合</param>
        /// <param name="sortDirection">排序方向，true升序，false降序</param>
        /// <returns>排序过后的数组</returns>
        public static IList<T> StraightInsertSort<T>(IList<T> data, bool sortDirection = true) where T : IComparable<T> {
            T temp = default(T);
            for (int i = 1; i < data.Count; i++) {
                temp = data[i];
                if (sortDirection == true) {
                    for (int j = i - 1; j >= 0; j--) {
                        if (data[j].CompareTo(temp) > 0) {
                            data[j + 1] = data[j];
                            if (j == 0) {
                                data[0] = temp;
                                break;
                            }
                        }
                        else {
                            data[j + 1] = temp;
                            break;
                        }
                    }
                }
                else {
                    for (int j = i - 1; j >= 0; j--) {
                        if (data[j].CompareTo(temp) < 0) {
                            data[j + 1] = data[j];
                            if (j == 0) {
                                data[0] = temp;
                                break;
                            }
                        }
                        else {
                            data[j + 1] = temp;
                            break;
                        }
                    }
                }

            }
            return data;
        }

        public static T[] StraightInsertSort<T>(T[] data, bool sortDirection = true) where T : IComparable<T> {
            T temp = default(T);
            for (int i = 1; i < data.Length; i++) {
                temp = data[i];
                if (sortDirection == true) {
                    for (int j = i - 1; j >= 0; j--) {
                        if (data[j].CompareTo(temp) > 0) {
                            data[j + 1] = data[j];
                            if (j == 0) {
                                data[0] = temp;
                                break;
                            }
                        }
                        else {
                            data[j + 1] = temp;
                            break;
                        }
                    }
                }
                else {
                    for (int j = i - 1; j >= 0; j--) {
                        if (data[j].CompareTo(temp) < 0) {
                            data[j + 1] = data[j];
                            if (j == 0) {
                                data[0] = temp;
                                break;
                            }
                        }
                        else {
                            data[j + 1] = temp;
                            break;
                        }
                    }
                }
            }
            return data;
        }
    }
}