using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmit
{
    public class DynamicArray
    {
        public int size;
        public int capacity = 10;
        public object[] array;

        public DynamicArray()
        {
            array = new object[capacity];
        }

        public DynamicArray(int _capacity)
        {
            capacity = _capacity;
            array = new object[capacity];
        }

        public void add(object data)
        {
            if (size >= capacity)
            {
                grow();
            }

            array[size] = data;
            size++;
        }

        public void insert(int index, object data)
        {
            if (index >= capacity) throw new IndexOutOfRangeException();

            if (size >= capacity)
            {
                grow();
            }
            for (int i = size; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = data;
            size++;
        }

        public void delete(object data)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i] == data)
                {
                    for (int j = 0; j < size - i - 1; j++)
                    {
                        array[i + j] = array[i + j + 1];
                    }
                    array[size - 1] = null;
                    size--;
                    if (size <= capacity / 3)
                    {
                        shrink();
                    }
                    break;
                }
            }
        }

        public int search(object data)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i] == data)
                {
                    return i;
                }
            }
            return -1;
        }

        private void grow()
        {
            int newCapacity = capacity * 2;
            object[] newArray = new object[newCapacity];

            for (int i = 0; i < newCapacity; i++)
            {
                newArray[i] = array[i];
            }
            capacity = newCapacity;
            array = newArray;
        }

        private void shrink()
        {
            int newCapacity = capacity / 2;
            object[] newArray = new object[newCapacity];

            for (int i = 0; i < newCapacity; i++)
            {
                newArray[i] = array[i];
            }
            capacity = newCapacity;
            array = newArray;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public string toString()
        {
            string str = "";

            for (int i = 0; i < capacity; i++)
            {
                str += array[i] + ", ";
            }

            if (str != "")
            {
                str = str.Substring(0, str.Length - 2);
            }

            return str;
        }


    }
}
