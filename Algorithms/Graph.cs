using System;
using System.Collections;
using System.Collections.Generic;

namespace CodingInterview.Algorithms
{
    public class List : IEnumerable
    {
        private object[] _objects;
        public List()
        {
            _objects = new object[100];
        }
        public void Add(object obj)
        {
            _objects[_objects.Length] = obj;
        }
        public IEnumerator GetEnumerator()
        {
            return new ListEnumerator();
        }
        private class ListEnumerator : IEnumerator
        {
            private int _currentIndex = -1;
            public object Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                _currentIndex++;
                return (_currentIndex < _objects.Count);
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
    public class Bag<Item> : IEnumerable<Item>
    {
        private Node first;
        private class Node
        {
            Item item;
            public Node next;
            public Node(Item item) { this.item = item; }
        }
        public void add(Item item)
        {
            Node oldFirst = first;
            first = new Node(item);
            first.next = oldFirst;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        private class ListIterator : IEnumerator<Item>
        {
            public Item Current { get { return; } }

            bool IEnumerator.MoveNext()
            {
                throw new NotImplementedException();
            }

            void IEnumerator.Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
    public class Graph
    {
        private int _V;
        private int _E;
        private Bag<int>[] adj;

        public Graph(int vertexCount)
        {
            this._V = vertexCount; this._E = 0;
            adj = new Bag<int>[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                adj[i] = new Bag<int>();
            }
        }
        public int V() { return _V; }
        public int E() { return _E; }

        public IEnumerable<int> adjItem(int v)
        {
            return adj[v];
        }
    }
}