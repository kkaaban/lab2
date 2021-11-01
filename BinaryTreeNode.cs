using System;

namespace laboratory2
{
    public class BinaryTreeNode<T> : IComparable<T>, IComparable
        where T: class, IComparable // Можно будет использовать любой тип данных, реализующий IComparable
    {
        public BinaryTreeNode(T data, BinaryTreeNode<T> leftNode, BinaryTreeNode<T> rightNode)
        {
            Data = data;
            LeftNode = leftNode;
            RightNode = rightNode;
        }
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public BinaryTreeNode<T> LeftNode { get; private set; }
        public BinaryTreeNode<T> RightNode { get; private set; }
        public BinaryTreeNode<T> ParentNode { get; private set; }
        public override string ToString() => Data.ToString();

        public void Add(T data)
        {
            var newNode = new BinaryTreeNode<T>(data);
            if (newNode.Data.CompareTo(Data)== -1)
            {
                if (LeftNode == null)
                {
                    LeftNode = newNode;
                }
                else
                {
                    LeftNode.Add(newNode.Data);
                }
            }
            else
            {
                if (RightNode == null)
                {
                    RightNode = newNode;
                }
                else
                {
                    RightNode.Add(newNode.Data);
                }
            }
        }
        public int CompareTo(object obj)
        {
            if (obj is BinaryTreeNode<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new ArgumentException("Не совпадение типов");
            }
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}
