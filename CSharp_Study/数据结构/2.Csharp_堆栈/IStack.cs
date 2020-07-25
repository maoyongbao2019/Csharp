using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    interface IStack<T> {
        //返回堆栈得实际元素个数
        int Count();
        //判断堆栈是否为空
        bool IsEmpty();
        //清空堆栈里得元素
        void Clear();
        //入栈:将元素压入堆栈中
        void Push(T item);
        //出栈:从堆栈顶取一个元素，并从堆栈中删除
        T Pop();
        //取堆栈顶部的元素(但不删除)
        T Peek();
    }

    
}
