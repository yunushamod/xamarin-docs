using System.Collections.Generic;
using System.Collections;

namespace DataStructures.Implementation{
    public interface IBag<T>
    {
        void Add(T item);
        IEnumerator<T> GetEnumerator();
        bool IsEmpty();
        int Size();
    }

    public class Bag<T> : IEnumerable<T>, IBag<T>
    {
        private Node first;
        private int n;
        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }
        }

        public bool IsEmpty() => n == 0;
        public int Size() => n;

        public IEnumerator<T> GetEnumerator()
        {
            for (Node node = first; node.Next != null; node = node.Next)
            {
                yield return node.Item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(T item)
        {
            var oldFirst = first;
            first = new Node
            {
                Item = item,
                Next = oldFirst,
            };
            n++;
        }
    }
}