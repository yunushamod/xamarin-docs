using System.Collections.Generic;
using System.Collections;
namespace DataStructures.Implementation{
    public interface IQueue<T>
    {
        T Dequeue();
        void Enqueue(T item);
        IEnumerator<T> GetEnumerator();
        bool IsEmpty();
        int Size();
    }

    public class Queue<T> : IEnumerable<T>, IQueue<T>
    {
        private Node first;
        private Node last;
        private int n;
        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node node = first; node.Next != null; node = node.Next)
            {
                yield return node.Item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public bool IsEmpty() => n == 0;
        public int Size() => n;
        public void Enqueue(T item)
        {
            var oldLast = last;
            last = new Node
            {
                Item = item,
                Next = null,
            };
            if (IsEmpty()) first = last;
            else oldLast.Next = last;
            n++;
        }

        public T Dequeue()
        {
            T item = first.Item;
            first = first.Next;
            if (IsEmpty()) last = null;
            n--;
            return item;
        }
    }
}