using System;
using System.Collections;
using System.Collections.Generic;

namespace laboratory2
{
    class BinaryTree<T> : IEnumerable
        where T: class, IComparable
    {
        public BinaryTree(params T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Add(data[i]);
            }
        }
        public T this[int position] // индексатор, Postorder
        {
            get
            {
                if (position < Postorder().Count)
                {
                    return Postorder()[position];
                }
                return null;
            }
        }
        public BinaryTreeNode<T> Root { get; private set; }
        public int Count { get; private set; }

        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<T>(data);
                Count = 1;
                return;
            }
            Root.Add(data);
            Count++;
        }
        public List<T> Preorder()
        {
            if (Root == null)
            {
                throw new Exception("Root is null");
            }
            return Preorder(Root);

        }
        private List<T> Preorder(BinaryTreeNode<T> node)
        {
            List<T> list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);
                if (node.LeftNode != null)
                {
                    list.AddRange(Preorder(node.LeftNode));
                }
                if (node.RightNode != null)
                {
                    list.AddRange(Preorder(node.RightNode));
                }
            }
            return list;
        }


        public List<T> Postorder()
        {
            if (Root == null)
            {
                throw new Exception("Root is null");
            }
            return Postorder(Root);

        }
        private List<T> Postorder(BinaryTreeNode<T> node)
        {
            List<T> list = new List<T>();
            if (node != null)
            {
                if (node.LeftNode != null)
                {
                    list.AddRange(Postorder(node.LeftNode));
                }
                if (node.RightNode != null)
                {
                    list.AddRange(Postorder(node.RightNode));
                }
                list.Add(node.Data);
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return Postorder().GetEnumerator();
        }
    }
}
