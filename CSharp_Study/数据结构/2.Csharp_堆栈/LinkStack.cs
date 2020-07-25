using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainshiTest {
    class LinkStack<T> : IStack<T> {
        private Node<T> top;
        private int num;//结点个数

        public Node<T> Top {
            get { return top;}
            set { top = value; }
        }

        public LinkStack() {
            top = null;
            num = 0;
        }

        public int Count() {
            return num;
        }

        public void Clear() {
            top = null;
            num = 0;
        }

        public bool IsEmpty() {
            if (top == null && num == 0) return true;
            else return false;
        }

        public void Push(T item) {
            Node<T> node = new Node<T>(item);
            if (top == null) top = node;
            else {
                node.Next = top;
                top = node;
            }
            num++;
        }

        public T Pop() {
            if (IsEmpty()) return default(T);
            Node<T> node = top;
            top = top.Next;
            num--;
            return node.Data;
        }

        public T Peek() {
            if (IsEmpty()) return default(T);
            return top.Data;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            if (top != null) {
                sb.Append(top.Data.ToString() + ",");
                Node<T> node = top;
                while (node.Next != null) {
                    sb.Append(node.Next.Data.ToString() + ",");
                    node = node.Next;
                }
            }
            return sb.ToString().Trim(',');
        }
    }

    public class Node<T> {
        private T data;
        private Node<T> next;
        public Node(T data, Node<T> next) {
            this.data = data;
            this.next = next;
        }
        public Node(Node<T> next) {
            this.next = next;
            this.data = default(T);
        }
        public Node(T data) {
            this.data = data;
            this.next = null;
        }
        public Node() {
            this.data = default(T);
            this.next = null;
        }
        public T Data {
            get { return this.data; }
            set { this.data = value; }
        }
        public Node<T> Next {
            get { return next; }
            set { next = value; }
        }
    }
}
