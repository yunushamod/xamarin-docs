using System.Collections.Generic;
using System.Collections;
namespace DataStructures.Implementation{
    public interface IStack<T>
    {
        IEnumerator<T> GetEnumerator();
        bool IsEmpty();
        T Pop();
        void Push(T item);
        int Size();
    }

    public class Stack<T> : IEnumerable<T>, IStack<T>
    {
        private Node first;
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

        public void Push(T item)
        {
            var oldFirst = first;
            first = new Node
            {
                Item = item,
                Next = oldFirst
            };
            n++;
        }

        public T Pop()
        {
            T item = first.Item;
            first = first.Next;
            n--;
            return item;
        }

        public bool IsEmpty() => n == 0;
        public int Size() => n;
    }
}