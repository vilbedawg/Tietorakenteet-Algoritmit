using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmit
{
    // Dictionary implementation from scratch
    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int INITIAL_SIZE = 16;
        LinkedList<KeyValuePair<K, V>>[] values;

        public HashTable()
        {
            this.values = new LinkedList<KeyValuePair<K, V>>[INITIAL_SIZE];
        }
        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }
        public void Add(K key, V value)
        {
            var hash = this.HashKey(key);
            if (this.values[hash] == null)
            {
                this.values[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var keyExists = this.values[hash].Any(p => p.Key.Equals(key));

            if(keyExists)
            {
                throw new InvalidOperationException(
                    "Key already exists. You cannot add 2 elements with the same key."
                    );
            }

            var pair = new KeyValuePair<K, V>(key, value);
            this.values[hash].AddLast(pair);
            this.Count++;

            if(this.Count > this.Capacity * 0.75)
            {
                this.ResizeAndReAddValues();
            }
        }

        public V Find(K key)
        {
            var hash = this.HashKey(key);

            if (this.values[hash] == null)
            {
                return default(V);
            }
            var collection = this.values[hash];
            return collection.First(p => p.Key.Equals(key)).Value;
        }

        public bool ContainsKey(K key)
        {
            var hash = this.HashKey(key);
            if (this.values[hash] == null)
            {
                return false;
            }

            var collection = this.values[hash];
            return collection.Any(pair => pair.Key.Equals(key));
        }

        private int HashKey(K key)
        {
            var hash = Math.Abs(key.GetHashCode()) % this.Capacity;
            return hash;
        }

        private void ResizeAndReAddValues()
        {
            // cache the values
            var cachedValues = this.values;
            // resize 
            this.values = new LinkedList<KeyValuePair<K, V>>[2 * this.Capacity];
            // Add values
            this.Count = 0;
            foreach(var collection in cachedValues)
            {
                if(collection != null)
                {
                    foreach (var value in collection)
                    {
                        this.Add(value.Key, value.Value);
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach(var collection in this.values)
            {
                if(collection != null)
                {
                    foreach(var value in collection)
                    {
                        yield return value;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
