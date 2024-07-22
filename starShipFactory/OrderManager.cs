using System;
using System.Collections.Generic;
using System.Linq;
using starShipFactory.cache;
using starShipFactory.ship;
using starShipFactory.ship.shipComponent;

namespace starShipFactory.OrderManagement
{
    public class OrderManager
    {
        private List<Order> orders; 
        private Dictionary<Component, int> stock;

        public OrderManager()
        {
            orders = new List<Order>();
            stock = new Dictionary<Component, int>();
        }

        // Ajouter une instruction de commande
        public void AddOrder(string orderId, string shipType)
        {
            try
            {
                Ship newShip = ShipFactory.CreateShip(shipType, orderId);
                Hangar.AddShip(newShip);
                Console.WriteLine($"Vaisseau {shipType} ajouté à l'ordre {orderId}.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private bool VerifyAndCreateShip(Order order)
        {
            Ship ship = ShipFactory.CreateShip(order.ShipType, order.OrderId);
            Dictionary<Component, int> requiredComponents = ship.GetRequiredComponents();

            foreach (var item in requiredComponents)
            {
                if (stock[item.Key] < item.Value)
                    return false;
            }

            foreach (var item in requiredComponents)
            {
                stock[item.Key] -= item.Value;  // Déduit les composants utilisés du stock
            }
            
            Hangar.AddShip(ship);  // Ajoute le vaisseau au hangar si créé
            order.Complete();  // Marque la commande comme complétée
            return true;
        }



        // Envoyer un vaisseau déjà construit
        public void SendOrder(string orderId)
        {
            var order = orders.Find(o => o.OrderId == orderId);
            if (order == null)
            {
                Console.WriteLine($"Commande avec l'ID {orderId} non trouvée.");
                return;
            }

            if (order.Status != OrderStatus.Completed)
            {
                Console.WriteLine($"La commande {orderId} n'est pas complète et ne peut pas être envoyée.");
                return;
            }

            order.Send();
            Console.WriteLine($"Commande {orderId} envoyée.");
        }


        // Lister les commandes restantes
        public void ListOrders()
        {
            Console.WriteLine("Liste des commandes restantes :");
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        // Mettre à jour le stock des composants
        public void UpdateStock(Component component, int quantity)
        {
            if (stock.ContainsKey(component))
            {
                stock[component] += quantity;
            }
            else
            {
                stock[component] = quantity;
            }
            Console.WriteLine($"Stock mis à jour pour {component} : {stock[component]}");
        }

        // Vérifier les composants nécessaires pour une commande
        public void VerifyOrder(string orderId)
        {
            Order order = GetOrder(orderId);
            if (order == null)
            {
                Console.WriteLine($"Order with ID {orderId} not found.");
                return;
            }

            var missingComponents = new Dictionary<Component, int>();

            foreach (var component in order.Components)
            {
                int stockQuantity = GetStockQuantity(component.Key);
                if (stockQuantity < component.Value)
                {
                    missingComponents[component.Key] = component.Value - stockQuantity;
                }
            }

            if (missingComponents.Count == 0)
            {
                Console.WriteLine($"Order {orderId} can be completed with available stocks.");
            }
            else
            {
                Console.WriteLine($"Order {orderId} cannot be completed. Missing components:");
                foreach (var missing in missingComponents)
                {
                    Console.WriteLine($"Component: {missing.Key}, Missing Quantity: {missing.Value}");
                }
            }
        }

        // Récupérer une commande par ID
        private Order GetOrder(string orderId)
        {
            return orders.First(o => o.OrderId == orderId);
        }

        // Récupérer la quantité en stock d'un composant
        private int GetStockQuantity(Component component)
        {
            return stock.ContainsKey(component) ? stock[component] : 0;
        }
    }
}
