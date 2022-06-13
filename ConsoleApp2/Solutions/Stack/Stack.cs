using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmit
{
    // linked list stack
    public class Stack
    {
        public Node node;

        public Node top;

        public Node bottom;

        public int length { get; private set; }
        public Stack()
        {
            this.node = null;
            this.top = null;
            this.bottom = null;
        }

        public Node Peek()
        {
            return this.top;
        }

        public void Push(int data)
        {
            Node newNode = new Node(data);

            if (length == 0)
            {
                top = newNode;
                bottom = newNode;
            }
            else
            {
                Node temp = top;
                top = newNode;
                top.next = temp;
            }

            length++;
        }

        public Node Pop()
        {
            Node removed = top;

            if(top != null)
            {
                top = top.next;
                length--;
            }

            return removed;
        }

        public bool IsEmpty()
        {
            return length == 0;
        }

        public void Print()
        {
            while(top != null)
            {
                Console.Write("|" + top.data + "|--->");
                top = top.next;
            }
        }
    }
    // array stack
    public class ArrayStack<T>
    {
        public T bottom;
        private T[] array;
        public int length { get; private set; }
        public ArrayStack(int len)
        {
            array = new T[len];
            bottom = array[0];
        }

        public void Push(T val)
        {
            try
            {
                array[length] = val;
                length++;
            } 
            catch(IndexOutOfRangeException)
            {
                return;
            }            
        }

        public T Pop()
        {
            if (length == 0) return default;

            var tmp = array[length - 1];
            int ind = length - 1;
            array[length - 1] = default;
            length--;
            return tmp;
        }

        public T Peek()
        {
            return array[length - 1];
        }

        public bool isEmpty()
        {
            return length == 0;
        }

        public void Print()
        {
            foreach(T i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
    // Queue
    public class Queue
    {
        public Node first;
        public Node last;
        public int length;
        public Queue()
        {
            first = null;
            last = null;
            length = 0;
        }

        public Node Peek()
        {
            return first;
        }

        public void enqueue(int val)
        {
            Node newNode = new Node(val);
            if (length == 0)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.next = newNode;
                last = newNode;
            }
            length++;
        }

        public void dequeue()
        {
            if (first == null)
                return;

            if(first == last)
                last = null;

            first = first.next;
            length--;
        }
    }
    // Queue with stacks
    public class MyQueue
    {
        public Stack<int> stack;
        public Stack<int> stack2;

        public MyQueue()
        {
            stack = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void Push(int x)
        {
            if(stack.Count == 0)
                stack.Push(x);
            else
            {
                while (stack.Count > 0)
                {
                    stack2.Push(stack.Pop());
                }
                stack.Push(x);
                while (stack2.Count > 0)
                {
                    stack.Push(stack2.Pop());
                }
            }

        }

        public int Pop()
        {
            return stack.Pop();
        }

        public int Peek()
        {
            return stack.Peek();
        }

        public bool Empty()
        {
            return stack.Count == 0;
        }
    }
}
