using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTSU0_SwDD2_HP_Batman.LinkedList
{
    internal class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; internal set; }

        public Node(T data)
        {
            this.Data = data;
        }
    }
}
