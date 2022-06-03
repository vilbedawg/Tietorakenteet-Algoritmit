using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmit
{
    public class _LinkedList
    {
        public Node headNode;
        public int length { get; private set; }

        public _LinkedList()
        {
            headNode = null;
        }

        public void AddToEnd(int data)
        {
            if(headNode == null)
            {
                headNode = new Node(data);
                length++;
            }
            else
            {
                headNode.AddToEnd(data);
                length++;
            }
        }

        public void AddSorted(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
                length++;
            }
            else if (data < headNode.data)
            {
                AddToBeginning(data);
            }
            else
            {
                headNode.AddSorted(data);
                length++;
            }
        }

        public void AddToBeginning(int data)
        {
            if(headNode == null)
            {
                headNode = new Node(data);
                length++;
            }
            else
            {
                Node temp = new Node(data);
                temp.next = headNode;
                headNode = temp;
                length++;
            }
        }

        public int Find(int data)
        {
            int index = 0;
            var temp = headNode;
            while (temp.data != data)
            {
                index++;
                temp = temp.next;
                if(temp == null)
                {
                    return -1;
                }
            }
            return index;
        }

        public void Add(int index, int data)
        {
            if (index < 0)
                throw new IndexOutOfRangeException("index: " + index);

            if(this.headNode == null || index == 0)
                AddToBeginning(data);

            else
            {
                Node current = headNode;
                for (int k = 0; k < index - 1; k++)
                    current = current.next;

                Node temp = new Node(data);
                temp.next = current.next;
                current.next = temp;
                length++;
            }
        }

        public object Remove(int index)
        {
            if(index < 0 || index > length - 1)
                throw new IndexOutOfRangeException("index: " + index);
            
            Node current = headNode;
            object result = null;

            if (index == 0)
            {
                result = current.data;
                headNode = current.next;
            }
            else
            {
                for (int k = 0; k < index - 1; k++)
                    current = current.next;
                result = current.next.data;

                current.next = current.next.next;
            }

            length--;
            return result;
        }   

        public void Clear()
        {
            headNode = null;
            length = 0;
        }
        public void Print()
        {
            if (headNode != null)
            {
                headNode.Print();
            }
        }
    }

    public class Node
    {
        public int data;
        public Node next;
        public Node(int i)
        {
            data = i;
            next = null;
        }

        public void Print()
        {
            Console.Write("|" + data + "|--->");
            if(next != null)
            {
                next.Print();
            }
        }

        public void AddSorted(int data)
        {
            if(next == null)
            {
                next = new Node(data);
            } 
            else if ( data < next.data)
            {
                Node temp = new Node(data);
                temp.next = this.next;
                this.next = temp;
            }
            else
            {
                next.AddSorted(data);
            }
        }

        public void AddToEnd(int data)
        {
            if(next == null)
            {
                next = new Node(data);
            }
            else
            {
                next.AddToEnd(data);
            }
        }

    }
}
