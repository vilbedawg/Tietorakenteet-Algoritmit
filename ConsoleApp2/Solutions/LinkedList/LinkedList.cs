using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmit
{
    public class _LinkedList
    {
        private Node headNode;
        public int length { get; private set; }
        public _LinkedList()
        {
            headNode = null;
        }
        public void AddToEnd(int data)
        {
            Node current = headNode;
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
        public Node Find(int data)
        {
            Node current = headNode;
            while (current != null)
            {
                if (current.data == data)
                {
                    return current;
                }

                current = current.next;
            }
            return null;
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

    public class _DoubleLinkedList
    {
        private Node headNode;
        private Node tail;
        public int length { get; private set; }
        public _DoubleLinkedList()
        {
            headNode = null;
            tail = null;
        }

        public void Add(int data)
        {
            Node newNode = new Node(data);

            if (tail == null)
                headNode = newNode;
            else
            {
                newNode.previous = tail;
                tail.next = newNode;
            }

            tail = newNode;
            length++;
        }
        public void AddToBeginning(int data)
        {
            Node newNode = new Node(data);
            newNode.next = headNode;

            if (headNode == null)
                tail = newNode;
            else
                headNode.previous = newNode;

            headNode = newNode;
            length++;
        }
        public Node Find(int data)
        {
            Node current = headNode;
            while (current != null)
            {
                if (current.data == data)
                {
                    return current;
                }

                current = current.next;
            }
            return null;
        }
        public Node FindLast(int data)
        {
            Node current = tail;
            while (current != null)
            {
                if (current.data == data)
                {
                    return current;
                }

                current = current.previous;
            }
            return null;
        }
        public bool Remove(int value)
        {
            Node current = headNode;

            while(current != null)
            {
                if (current.next == null)
                    tail = current.previous;
                else
                    current.next.previous = current.previous;

                if (current.previous == null)
                    headNode = current.next;
                else
                    current.previous.next = current.next;

                current = null;
                length--;
                return true;
            }
            return false;
        }
        public void RemoveFromEnd()
        {
            if (tail != null)
            {
                tail = tail.previous;

                if (tail == null)
                    headNode = null;

                length--;
            }

        }
        public void RemoveFromBeginning()
        {
            if (headNode != null)
            {
                headNode = headNode.next;

                if (headNode == null)
                    tail = null;

                length--;
            }
        }
        public void Clear()
        {
            headNode = null;
            tail = null;
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
        public Node? previous;
        public Node(int i)
        {
            data = i;
            next = null;
            previous = null;
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
