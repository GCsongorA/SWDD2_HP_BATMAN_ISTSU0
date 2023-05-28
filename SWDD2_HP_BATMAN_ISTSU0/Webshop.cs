using SWDD2_HP_BATMAN_ISTSU0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ISTSU0_SwDD2_HP_Batman
{
    internal static class Webshop
    {
        public static void BatmanLogo()
        {
            Console.WriteLine("                   ,.ood888888888888boo.,\n              .od888P^\"\"            \"\"^Y888bo.\n          .od8P''   ..oood88888888booo.    ``Y8bo.\n       .odP'\"  .ood8888888888888888888888boo.  \"`Ybo.\n     .d8'   od8'd888888888f`8888't888888888b`8bo   `Yb.\n    d8'  od8^   8888888888[  `'  ]8888888888   ^8bo  `8b\n  .8P  d88'     8888888888P      Y8888888888     `88b  Y8.\n d8' .d8'       `Y88888888'      `88888888P'       `8b. `8b\n.8P .88P            \"\"\"\"            \"\"\"\"            Y88. Y8.\n88  888                                              888  88\n88  888                                              888  88\n88  888.        ..                        ..        .888  88\n`8b `88b,     d8888b.od8bo.      .od8bo.d8888b     ,d88' d8'\n Y8. `Y88.    8888888888888b    d8888888888888    .88P' .8P\n  `8b  Y88b.  `88888888888888  88888888888888'  .d88P  d8'\n    Y8.  ^Y88bod8888888888888..8888888888888bod88P^  .8P\n     `Y8.   ^Y888888888888888LS888888888888888P^   .8P'\n       `^Yb.,  `^^Y8888888888888888888888P^^'  ,.dP^'\n          `^Y8b..   ``^^^Y88888888P^^^'    ..d8P^'\n              `^Y888bo.,            ,.od888P^'\n                   \"`^^Y888888888888P^^'\"");
        }

        public static void PrintList(SwDD2_LinkedLists.LinkedList<Item> list)
        {
            Console.Clear();
            BatmanLogo();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            list.Traverse();
        }

        public static void Add(SwDD2_LinkedLists.LinkedList<Item> list)
        {
            Console.Clear();
            Console.Write("Which item to add? ( possible items:");
            foreach (itemType types in Enum.GetValues(typeof(itemType)))
            {
                Console.Write(types+" ");
            }
            Console.WriteLine(")");
            string itemToAdd=Console.ReadLine();
            switch (Enum.Parse<itemType>(itemToAdd))
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
            }
            
        }

        public static void Remove(SwDD2_LinkedLists.LinkedList<Item> list)
        {
            Console.Clear();
            Console.WriteLine("Which item to remove?");
            string itemToAdd = Console.ReadLine();

            switch (Enum.Parse<itemType>(itemToAdd))
            {
                case itemType.Batmobil:
                    list.Remove(new Batmobil());
                    break;
                case itemType.Batcopter:
                    list.Remove(new Batcopter());
                    break;
                case itemType.Batarang:
                    list.Remove(new Batarang());
                    break;
                case itemType.ExplosiveGel:
                    list.Remove(new ExplosiveGel());
                    break;
                case itemType.Parachute:
                    list.Remove(new Parachute());
                    break;
            }
        }
        public static void KnapsackPurchaseOffer(SwDD2_LinkedLists.LinkedList<Item> list,int budget)
        {
            BinarySearchTree<Item, int> offer = list.KnapsackSolution(budget);
            offer.WriteTreeData();
        }
        public static void Start(SwDD2_LinkedLists.LinkedList<Item> list,int budget) 
        {
            Webshop.PrintList(list);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            try
            {
                Console.WriteLine("Best purchase offer:");
                KnapsackPurchaseOffer(list, budget);
            }
            catch(NotEnoughMoneyException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are broke :(");
                Console.ResetColor();
            }
            Console.ResetColor();
            Console.WriteLine();
            while (true)
            {
                string action = Console.ReadLine();
                switch (action)
                {
                    case "Add":
                        Webshop.Add(list);
                        break;
                    case "Remove":
                        Webshop.Remove(list);
                        break;
                    default: break;
                }
                if (action == "Stop")
                {
                    break;
                }
                Webshop.PrintList(list);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    Console.WriteLine("Best purchase offer:");
                    KnapsackPurchaseOffer(list, budget);
                }
                catch (NotEnoughMoneyException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are broke :(");
                    Console.ResetColor();
                }
                Console.ResetColor();
                Console.WriteLine();
            }

        }
    }
}
