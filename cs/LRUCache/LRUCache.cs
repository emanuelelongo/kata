using System.Collections.Generic;

namespace LRUCache
{
    public class LRUCache
    {
        int capacity;
        Entry head = null, tail = null;
        Dictionary<int, Entry> index = new Dictionary<int, Entry>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        private void moveToHead(Entry entry)
        {
            if (entry == head) return;

            entry.Next.Prev = entry.Prev;
            if (entry != tail)
            {
                entry.Prev.Next = entry.Next;
            }
            else
            {
                tail = entry.Next;
            }
            head.Next = entry;
            entry.Next = null;
            entry.Prev = head;
            head = entry;
        }

        private void insertNew(Entry entry)
        {
            if (head == null)
            {
                head = entry;
                tail = entry;
                index[entry.Key] = entry;
                return;
            }
            head.Next = entry;
            entry.Prev = head;
            entry.Next = null;
            head = entry;
            index[entry.Key] = entry;
            if (index.Keys.Count > capacity)
            {
                index.Remove(tail.Key);
                tail.Next.Prev = null;
                tail = tail.Next;
            }
        }

        public int Get(int key)
        {
            if (index.ContainsKey(key))
            {
                moveToHead(index[key]);
                return index[key].Value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (index.ContainsKey(key))
            {
                moveToHead(index[key]);
                index[key].Value = value;
            }
            else
            {
                insertNew(new Entry(key, value));
            }
        }

        class Entry
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public Entry(int key = 0, int value = 0)
            {
                Key = key;
                Value = value;
            }

            public Entry Next { get; set; }
            public Entry Prev { get; set; }
        }
    }
}