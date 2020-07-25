using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    public static partial class Sort {
        public static T[] InsertSortWithBinarySearch<T>(T[] data, bool direction = true) where T:IComparable {
            for(int i = 1; i < data.Length; i++) {
                T temp = data[i];
                int mid = BinarySearchForInsertSort<T>(data, 0, i - 1, i, true);
                for(int j = i - 1; j >= mid; j--) {
                    data[j + 1] = data[j];
                }
                data[mid] = temp;
            }
            return data;
        }

        private static int BinarySearchForInsertSort<T>(T[] data, int low,int high, int key, bool direction = true) where T:IComparable {
            while (low<=high) {
                int mid = (low + high) / 2;
                if (data[mid].CompareTo(data[key]) == 0) return mid;
                if (data[mid].CompareTo(data[key]) < 0) {
                    if (data[mid + 1].CompareTo(data[key]) >= 0) return mid + 1;
                    else low = mid + 1;
                }
                else {
                    if (mid - 1 < 0) return 0;
                    if (data[mid - 1].CompareTo(data[key]) < 0) return mid;
                    else high = mid - 1;
                }
            }
            return key;
        }
    }
}
