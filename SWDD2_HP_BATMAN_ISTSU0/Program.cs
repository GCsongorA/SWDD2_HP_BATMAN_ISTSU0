using ISTSU0_SwDD2_HP_Batman.LinkedList;
using System;

namespace ISTSU0_SwDD2_HP_Batman
{
    internal class Program
    {
        enum itemType {Batmobil,Batcopter,Batarang,ExplosiveGel,Parachute}
        static Random RNG = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("How many items do you want?");
            int size = int.Parse(Console.ReadLine());
            LinkedList<Item> items = new LinkedList<Item>();
            
            for (int i = 0; i < size; i++)
            {
                itemType type = (itemType)RNG.Next();
                switch (type)
                {
                    case itemType.Batmobil:
                        Node<Item> newBatmobil = new Node<Item>(new Batmobil());
                        break;
                    case itemType.Batcopter:
                        Node<Item> newBatcopter = new Node<Item>(new Batcopter());
                        break;
                    case itemType.Batarang:
                        Node<Item> newBatarang = new Node<Item>(new Batarang());
                        break;
                    case itemType.ExplosiveGel:
                        Node<Item> newExplosiveGel = new Node<Item>(new ExplosiveGel());
                        break;
                    case itemType.Parachute:
                        Node<Item> newParachute = new Node<Item>(new Parachute());
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("What is this year's budget?");
            int budget = int.Parse(Console.ReadLine());

            
        }
    }
}
