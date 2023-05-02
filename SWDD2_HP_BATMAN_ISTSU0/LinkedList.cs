using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTSU0_SwDD2_HP_Batman.LinkedList
{
    internal class LinkedList<T>
    {
        public Node<T> First { get; private set; }
        public Node<T> Last { get; private set; }
        public int Count { get; private set; }

        public void AddFirst(Node<T> newNode)
        {
            if (this.First == null)
            {
                this.First = newNode;
                this.Last = newNode;
            }
            else
            {
                newNode.Next = this.First;
                this.First = newNode;
            }
            Count++;
        }

        public void AddLast(Node<T> newNode)
        {
            if (this.First == null)
            {
                this.First = newNode;
                this.Last = newNode;
            }
            else
            {
                this.Last.Next = newNode;
                Last = newNode;
            }
            Count++;
        }

        public Node<T> Find(T target)
        {
            Node<T> CurrentNode = First;
            while (CurrentNode != null && !CurrentNode.Data.Equals(target))
            {
                CurrentNode = CurrentNode.Next;
            }
            return CurrentNode;
        }

        public void RemoveFirst()
        {
            if (First == null || this.Count == 0)
            {
                return;
            }
            First = First.Next;
            this.Count--;
        }

        public void Remove(Node<T> NodeToRemove)
        {
            if (First == null || this.Count == 0)
            {
                return;
            }
            if (this.First == NodeToRemove)
            {
                RemoveFirst();
                return;
            }

            Node<T> previous = First;
            Node<T> current = previous.Next;

            while (current != null && current != NodeToRemove)
            {
                previous = current;
                current = previous.Next;
            }
            if (current != null)
            {
                previous.Next = current.Next;
                Count--;
            }
        }

        public void Traverse()
        {
            Node<T> node = this.First;

            while (node.Next != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
            Console.WriteLine(node.Data);
        }
    }

}
