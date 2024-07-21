using System;
using System.Collections.Generic;

namespace starShipFactory.OrderManagement
{
    public class OrderManager
    {
        private List<string> orders; // Liste des commandes
        private Dictionary<string, int> stock; // Stock des vaisseaux

        public OrderManager()
        {
            orders = new List<string>();
            stock = new Dictionary<string, int>();
        }

        // Ajouter une instruction de commande
        public void AddOrder(string order)
        {
            orders.Add(order);
            Console.WriteLine($"Commande ajoutée : {order}");
        }

        // Envoyer un vaisseau déjà construit
        public void SendOrder(string shipName)
        {
            if (stock.ContainsKey(shipName) && stock[shipName] > 0)
            {
                stock[shipName]--;
                Console.WriteLine($"Vaisseau envoyé : {shipName}");
            }
            else
            {
                Console.WriteLine($"Le vaisseau {shipName} n'est pas en stock.");
            }
        }

        // Lister les commandes restantes
        public void ListOrders()
        {
            Console.WriteLine("Liste des commandes restantes :");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }

        // Mettre à jour le stock des vaisseaux
        public void UpdateStock(string shipName, int quantity)
        {
            if (stock.ContainsKey(shipName))
            {
                stock[shipName] += quantity;
            }
            else
            {
                stock[shipName] = quantity;
            }
            Console.WriteLine($"Stock mis à jour pour {shipName} : {stock[shipName]}");
        }
    }
}
