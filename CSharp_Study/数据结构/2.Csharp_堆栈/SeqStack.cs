using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    //顺序堆栈
    public class SeqStack<T> : IStack<T> {
        private int size;
        private T[] data;
        private int top;
        public SeqStack(int size) {
            this.size = size;
            data = new T[size];
            top = -1;
        }
        #region 接口实现部分
        public int Count() {
            return top + 1;
        }

        public void Clear() {
            top = -1;
        }

        public void Push(T item) {
            if (IsFull()) {
                Console.WriteLine("数据已满！");
                return;
            }
            data[++top] = item;
        }

        public T Pop() {
            T tmp = default(T);
            if (top == -1) {
                Console.WriteLine("数据为空！");
                return tmp;
            }
            tmp = data[top];
            top--;
            return tmp;
        }

        public T Peek() {
            T tmp = default(T);
            if (top == -1) {
                Console.WriteLine("数据为空！");
                return tmp;
            }
            return data[top];
        }
        #endregion
        public bool IsFull() {
            return top == size - 1;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (int i = top; i >= 0; i++)
                sb.Append(data[i] + ",");
            return sb.ToString().Trim(',');
        }

        public bool IsEmpty() {
            return top == -1;
        }
    }
}
