using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDD2_HP_BATMAN_ISTSU0
{
    delegate void CallbackFunction(object value);
    class BinarySearchTree<TValue,TKey> where TKey:IComparable 
    {
        class BSTNode
        {
            public TValue data;
            public TKey key;
            public BSTNode leftChild;
            public BSTNode rightChild;
        }
        BSTNode root;
        private void RecursiveInsert(ref BSTNode currentRoot,BSTNode newNode)
        {
            if (currentRoot==null)
            {
                currentRoot = newNode;
            }
            else if (currentRoot.key.CompareTo(newNode.key)>=0)
            {
                RecursiveInsert(ref currentRoot.leftChild, newNode);
            }
            else if (currentRoot.key.CompareTo(newNode.key) < 0)
            {
                RecursiveInsert(ref currentRoot.rightChild, newNode);
            }
            else
            {
                throw new Exception();
            }
        }

        public void Insert(TKey key,TValue data)
        {
            BSTNode newNode = new();
            newNode.data = data;
            newNode.key = key;
            RecursiveInsert(ref root, newNode);
        }
        public void Remove(TKey key)
        {
            RecursiveRemove(ref root, key);
        }
        private void RemoveTwoChildren(BSTNode nodeToRemove,ref BSTNode replacementNode)
        {
            if (replacementNode.rightChild!=null)
            {
                RemoveTwoChildren(nodeToRemove,ref replacementNode.rightChild);
            }
            else
            {
                nodeToRemove.key = replacementNode.key;
                nodeToRemove.data = replacementNode.data;
                replacementNode = replacementNode.leftChild;
            }
        }

        private void RecursiveRemove(ref BSTNode nodeToRemove,TKey key)
        {
            if (nodeToRemove!=null)
            {
                if (nodeToRemove.key.Equals(key))
                {
                    if (nodeToRemove.leftChild==null&&nodeToRemove.rightChild==null)
                    {
                        nodeToRemove = null;
                    }
                    else if (nodeToRemove.leftChild!=null&&nodeToRemove.rightChild!=null)
                    {
                        RemoveTwoChildren(nodeToRemove,ref nodeToRemove.leftChild);
                    }
                    else if (nodeToRemove.leftChild!=null)
                    {
                        nodeToRemove = nodeToRemove.leftChild;
                    }
                    else
                    {
                        nodeToRemove = nodeToRemove.rightChild;
                    }
                }
                else
                {
                    if (nodeToRemove.key.CompareTo(key)>0)
                    {
                        RecursiveRemove(ref nodeToRemove.leftChild,key);
                    }
                    else
                    {
                        if (nodeToRemove.key.CompareTo(key) < 0)
                        {
                            RecursiveRemove(ref nodeToRemove.rightChild, key);
                        }
                    }
                }
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        private void InOrderTraversal(BSTNode currentRoot,CallbackFunction callback)
        {
            if (currentRoot!=null)
            {
                InOrderTraversal(currentRoot.leftChild, callback);
                callback?.Invoke(currentRoot.data);
                InOrderTraversal(currentRoot.rightChild, callback);
            }
        }

        public void InOrderTraversal(CallbackFunction callback)
        {
            InOrderTraversal(root, callback);
        }

        public void WriteTreeData()
        {
            InOrderTraversal(WriteDataCallback);
        }
        private void WriteDataCallback(object value)
        {
            TValue data = (TValue)value;
            Console.WriteLine(data);
        }
        public void Clear()
        {
            root = null;
        }
    }
}
