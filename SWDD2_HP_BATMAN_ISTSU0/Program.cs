
using SwDD2_LinkedLists;
using SWDD2_HP_BATMAN_ISTSU0;
using System;

namespace ISTSU0_SwDD2_HP_Batman
{
    public enum itemType { Batmobil, Batcopter, Batarang, ExplosiveGel, Parachute }
    internal class Program
    {
        public static Random RNG = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("How many items do you want?");
            int size = int.Parse(Console.ReadLine());
            SwDD2_LinkedLists.LinkedList<Item> list = new();


            for (int i = 0; i < size; i++)
            {
                itemType type = (itemType)RNG.Next(5);
                switch (type)
                {
                    case itemType.Batmobil:
                        list.Add(new Batmobil());
                        break;
                    case itemType.Batcopter:
                        list.Add(new Batcopter());
                        break;
                    case itemType.Batarang:
                        list.Add(new Batarang());
                        break;
                    case itemType.ExplosiveGel:
                        list.Add(new ExplosiveGel());
                        break;
                    case itemType.Parachute:
                        list.Add(new Parachute());
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("What is this year's budget?");
            int budget = int.Parse(Console.ReadLine());
            Webshop.PrintList(list);
            Console.WriteLine();
            Webshop.Start(list,budget);
            
        }
    }
}
