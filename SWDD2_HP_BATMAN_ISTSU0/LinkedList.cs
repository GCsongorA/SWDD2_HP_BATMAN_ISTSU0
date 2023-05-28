using SWDD2_HP_BATMAN_ISTSU0;
using ISTSU0_SwDD2_HP_Batman;
using System;
using System.Collections.Generic;
using System.Text;


namespace SwDD2_LinkedLists
{
    class LinkedList<T> where T : Item
    {
        class ListElement
        {
            public T data;
            public ListElement next;
        }

        ListElement head;

        public void Add(T data)
        {
            ListElement newElement = new ListElement();
            newElement.data = data;
            if (head == null)   // the list is empty
            {
                head = newElement;
            }
            else    // list has some elements in it
            {
                ListElement p = head;
                while (p.next != null)
                {
                    p = p.next;
                }
                p.next = newElement;
            }
        }

        public void Remove(T data)
        {
            ListElement p = head;
            ListElement e = null;
            while (p != null && !p.data.GetType().Equals(data.GetType()))
            {
                e = p;
                p = p.next;
            }
            if (p != null)
            {
                if (e == null)
                {
                    head = p.next;
                }
                else
                {
                    e.next = p.next;
                }
            }
            else
            {
                throw new Exception("Data is not in the list.");
            }
        }
        public void Traverse()
        {
            ListElement p = head;
            while (p.next != null)
            {
                switch (p.data)
                {
                    case Batarang:
                        Console.WriteLine("Batarang"+ " " + p.data.Cost+" "+p.data.UtilityValue);
                        break;
                    case Batcopter:
                        Console.WriteLine("Batcopter" + " " + p.data.Cost + " " + p.data.UtilityValue);
                        break;
                    case Batmobil:
                        Console.WriteLine("Batmobil" + " " + p.data.Cost + " " + p.data.UtilityValue);
                        break;
                    case ExplosiveGel:
                        Console.WriteLine("Explosivegel" + " " + p.data.Cost + " " + p.data.UtilityValue);
                        break;
                    case Parachute:
                        Console.WriteLine("Parachute" + " " + p.data.Cost + " " + p.data.UtilityValue);
                        break;
                    default:
                        Console.WriteLine("asd");
                        break;
                }
                p = p.next;
            }
            switch (p.data)
            {
                case Batarang:
                    Console.WriteLine("Batarang" +" "+ p.data.Cost + " " + p.data.UtilityValue);
                    break;
                case Batcopter:
                    Console.WriteLine("Batcopter" + " " + p.data.Cost + " " + p.data.UtilityValue);
                    break;
                case Batmobil:
                    Console.WriteLine("Batmobil" + " " + p.data.Cost + " " + p.data.UtilityValue);
                    break;
                case ExplosiveGel:
                    Console.WriteLine("Explosivegel" + " " + p.data.Cost + " " + p.data.UtilityValue);
                    break;
                case Parachute:
                    Console.WriteLine("Parachute" + " " + p.data.Cost + " " + p.data.UtilityValue);
                    break;
                default:
                    break;
            }

        }

        private Item[] ToArray()
        {
            ListElement p = head;
            int n = 0;
            while (p!=null)
            {
                n++;
                p = p.next;
            }
            Item[] array = new Item[n];
            p = head;
            for (int i = 0; i < n; i++)
            {
                array[i] = p.data;
                p = p.next;
            }
            return array;
        }
        public BinarySearchTree<Item,int> KnapsackSolution(int budget)
        {
            BinarySearchTree<Item, int> bst = new();
            Item[] items = ToArray();
            int itemCount = items.Length;
            int[,] dpTable = new int[itemCount + 1, (budget/100) + 1];
            bool[,] selectedItems = new bool[itemCount + 1, (budget/100) + 1];          //i divide budget by 100 to make the array smaller,
                                                                                        //since my least expensive item is at least 100 it wont be a problem
            for (int i = 0; i <= itemCount; i++)
            {
                for (int w = 0; w <= (budget / 100); w++)
                {
                    if (i == 0 || w == 0)
                    {
                        dpTable[i, w] = 0;
                    }
                    else if (items[i - 1].Cost/100 <= w)
                    {
                        int valueWithItem = items[i - 1].UtilityValue + dpTable[i - 1, w - items[i - 1].Cost/100];
                        int valueWithoutItem = dpTable[i - 1, w];

                        if (valueWithItem > valueWithoutItem)
                        {
                            dpTable[i, w] = valueWithItem;
                            selectedItems[i, w] = true;
                        }
                        else
                        {
                            dpTable[i, w] = valueWithoutItem;
                        }
                    }
                    else
                    {
                        dpTable[i, w] = dpTable[i - 1, w];
                    }
                }
            }
            int n = 0;
            for (int i = itemCount, w = budget/100; i >= 0; i--)
            {
                if (selectedItems[i, w]==true)
                {
                    bst.Insert(items[i - 1].UtilityValue, items[i - 1]);
                    w -= items[i - 1].Cost/100;
                    n++;
                }
            }
            if (n==0)
            {
                throw new NotEnoughMoneyException();
            }
            return bst;
        }
    }
}
