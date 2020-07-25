 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MainshiTest {
   
    class MyLinkList<T>{ //单链表
        private Node<T> headNode;//头结点
        private int count;//结点数量
        public int Count {
            get {
                return count;
            }
        }
        //比较器用于合并两个链表
        private Comparer<T> comparer;

        //初始化
        public MyLinkList() {
            headNode = null;
            count = 0;
            comparer = Comparer<T>.Default;
        }

        //添加链表由值,返回插入的尾部结点(增加)
        public Node<T> Add(T value) {
            if (value == null) throw new ArgumentNullException();
            else if(headNode == null) {
                //如果头结点为空，构建头结点并返回
                headNode = new Node<T>(value, null);
                count++;
                return headNode;
            }
            else {
                if (!Contains(value)) {//如果值不存在则尾部插入
                    Node<T> node = headNode;
                    while (node.next != null)
                        node = node.next;
                    node.next = new Node<T>(value, null);
                    count++;
                    return node.next;
                }
            }
            return null;
        }

        //检查链表中是否包含这些值（查看）
        public bool Contains(T value) {
            if (value == null) throw new ArgumentNullException();
            else {
                for(Node<T> current = headNode; current!=null;current = current.next) {
                    if (value.Equals(current.value)) {
                        return true;
                    }
                }
                return false;
            }
        }

        //移除结点由值（删除）
        public bool Remove(T value) {
            if (value == null) throw new ArgumentNullException();
            else if (headNode == null) return false;
            //先看表头是不是
            if (value.Equals(headNode.value)) {
                headNode = headNode.next;
                count--;
                return true;
            }
            //不是表头
            Node<T> node = headNode;
            while(node.next != null) {
                if (value.Equals(node.next.value)) {
                    node.next = node.next.next;
                    count--;
                    return true;
                }
                node = node.next;
            }
            return false;
        }

        //判断链表是否有环
        public bool HasCircle() {
            Node<T> slowNode = headNode;
            Node<T> fastNode = headNode;
            //使用快慢指针相遇则有环
            while(fastNode !=null&& fastNode.next != null) {
                slowNode = slowNode.next;
                fastNode = fastNode.next.next;
                if (slowNode.value.Equals(fastNode.value)) {
                    return true;
                }
            }
            return false;
        }

        //找到环链表的环入口点
        public Node<T> FindEnterCircleNode() {
            bool hasCircle = false;
            Node<T> slowNode = headNode;
            Node<T> fastNode = headNode;
            //使用快慢指针相遇则有环
            while (fastNode != null && fastNode.next != null) {
                slowNode = slowNode.next;
                fastNode = fastNode.next.next;
                if (slowNode.value.Equals(fastNode.value)) {
                    hasCircle = true;
                    break;
                }
            }
            if (hasCircle) {
                fastNode = headNode;
                while (slowNode.value.Equals(fastNode.value)) {
                    return fastNode;
                }
                slowNode = slowNode.next;
                fastNode = fastNode.next;
            }
            return null;
        }
        
        //移除特定值
        public bool RemoveNodeByValue(T value) {
            if (value != null&&headNode!=null) {
                //删除的是头结点
                Node<T> node = headNode;
                if (node.value.Equals(value)) {
                    headNode = headNode.next;
                    count--;
                    return true;
                }
                Node<T> preNode = node;
                node = node.next;
                while (node != null) {
                    if (node.value.Equals(value)) {
                        preNode.next = node.next;
                        count--;
                        return true;
                    }
                    preNode = node;
                    node = node.next;
                }
                return false;
            }
            return false;
        }

        //反转链表
        public void Reverse() {
            Node<T> node = headNode;
            Node<T> preNode = null;
            while (node != null) {
                // 保存原结点的next指向的结点，因为下面会修改结点next指向的结点
                Node<T> next = node.next;
                // 表头指向原链表的尾结点
                if (next == null) {
                    headNode = node;
                }
                node.next = preNode;
                preNode = node;
                node = next;
            }
        }

        //合并两个增量排序的链表
        public MyLinkList<T> Merge(MyLinkList<T> link_list1, MyLinkList<T> link_list2) {
            link_list1.headNode = Merge(link_list1.headNode, link_list2.headNode);
            return link_list1;
        }

        private Node<T> Merge(Node<T> headNode1,Node<T> headNode2) {
            if (headNode1 == null) return headNode2;
            else if (headNode2 == null) return headNode1;
            Node<T> mergeHead = new Node<T>(default(T), null);
            //default(T)是泛型中初始化的用法。因为对于泛型T你不知道是值类型还是引用类型，
            //所以传参数是可能会出错。这里就要用到default(T).
            //T t = default(T), 就是初始化，值类型的话，就是T t = 0; 引用类型的话，就是T t = null
            if(comparer.Compare(headNode1.value, headNode2.value) < 0) {
                mergeHead = headNode1;
                mergeHead.next = Merge(headNode1.next, headNode2);
            }
            else {
                mergeHead = headNode2;
                mergeHead.next = Merge(headNode1, headNode2.next);
            }
            return mergeHead;
        }

        public override string ToString() {
            string str = "";
            for (Node<T> current = headNode; current != null; current = current.next) {
                str += current.ToString();
            }
            return str;
        }

        public void Clear() {
            for(Node<T> current=headNode;current !=null;current= current.next) {
                Node<T> tempNode = current;
                tempNode.next = null;
                tempNode.value = default(T);
            }
            headNode = null;
            count = 0;
        }
    }

    public class Node<T> {
        public T value;
        public Node<T> next;

        public Node(T value, Node<T> next) {
            this.value = value;
            this.next = next;
        }

        public override string ToString() {
            return value.ToString() + " ";
        }
    }
}