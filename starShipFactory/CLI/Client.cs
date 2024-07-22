using Microsoft.VisualBasic;
using starShipFactory.cache;
using starShipFactory.OrderManagement;
using starShipFactory.ship.shipComponent;
using starShipFactory.ship.shipComponent.specificalComponent;
using System;

namespace starShipFactory.CLI
{
    internal class Client
    {
        private OrderManager orderManager;

        public Client()
        {
            orderManager = new OrderManager();
        }

        public void Run()
        {
            Console.WriteLine("Bienvenue dans l'usine de vaisseaux !");
            Console.WriteLine("Tapez 'help' pour obtenir la liste des commandes.");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                ProcessCommand(input);
            }
        }

        private void ProcessCommand(string command)
        {
            if (command.StartsWith("STOCKS"))
            {
                DisplayStocks();
            }
            else if (command.StartsWith("NEEDED_STOCKS"))
            {
                DisplayNeededStocks(command);
            }
            else if (command.StartsWith("INSTRUCTIONS"))
            {
                DisplayInstructions(command);
            }
            else if (command.StartsWith("VERIFY"))
            {
                VerifyCommand(command);
            }
            else if (command.StartsWith("PRODUCE"))
            {
                ProduceCommand(command);
            }
            else if (command.StartsWith("RECEIVE"))
            {
                ReceiveCommand(command);
            }
            else if (command.StartsWith("ORDER"))
            {
                AddOrder(command);
            }
            else if (command.StartsWith("SEND"))
            {
                SendOrder(command);
            }
            else if (command.StartsWith("LIST_ORDER"))
            {
                ListOrders();
            }
            else if (command.ToLower() == "help")
            {
                DisplayHelp();
            }
            else
            {
                Console.WriteLine("Commande non reconnue. Tapez 'help' pour obtenir la liste des commandes.");
            }
        }

        private void DisplayStocks()
        {
            Console.WriteLine("=== STOCKS ===");
            foreach (var kvp in Atelier.GetStocks())
            {
                Console.WriteLine($"Component: {kvp.Key}, Quantity: {kvp.Value}");
            }
        }

        private void DisplayNeededStocks(string command)
        {
            Console.WriteLine("=== NEEDED_STOCKS ===");
        }

        private void DisplayInstructions(string command)
        {
            Console.WriteLine("=== INSTRUCTIONS ===");
        }

        private void VerifyCommand(string command)
        {
            Console.WriteLine("=== VERIFY ===");
            
        }

        private void ProduceCommand(string command)
        {
            Console.WriteLine("=== PRODUCE ===");
        }

        private void ReceiveCommand(string command)
        {
            Console.WriteLine("=== RECEIVE ===");
            string[] parts = command.Split(' ');
            if (parts.Length > 1)
            {
                for (int i = 1; i < parts.Length; i++)
                {
                    string[] item = parts[i].Split(':');
                    if (item.Length == 2 && int.TryParse(item[1], out int quantity))
                    {
                        string componentName = item[0];
                        Component component = CreateComponentFromString(componentName);
                        if (component != null)
                        {
                            Atelier.AddStock(component, quantity);
                            Console.WriteLine($"Added {quantity} of {componentName} to stock.");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid component: {componentName}");
                        }
                    }
                }
                Console.WriteLine("Stock mis à jour.");
            }
            else
            {
                Console.WriteLine("Commande RECEIVE invalide.");
            }
        }


        private void AddOrder(string command)
        {
            Console.WriteLine("=== ADD ORDER ===");
            string[] parts = command.Split(' ');
            if (parts.Length > 2)
            {
                string orderId = parts[1];
                string shipType = parts[2];
                orderManager.AddOrder(orderId, shipType);
            }
            else
            {
                Console.WriteLine("Usage: ORDER <orderId> <shipType>");
            }
        }

        private void SendOrder(string command)
        {
            Console.WriteLine("=== SEND ORDER ===");
            string[] parts = command.Split(' ');
            if (parts.Length > 1)
            {
                orderManager.SendOrder(parts[1]);
            }
            else
            {
                Console.WriteLine("Commande SEND invalide.");
            }
        }

        private void ListOrders()
        {
            Console.WriteLine("=== LIST ORDERS ===");
            orderManager.ListOrders();
        }

        private Component CreateComponentFromString(string componentName)
        {
            Console.WriteLine($"Processing component: {componentName}");
            
            string[] parts = componentName.Split('_');
            if (parts.Length < 2)
            {
                Console.WriteLine($"Invalid format: {componentName}");
                return null;
            }

            string className = parts[0].ToLower();
            string typeName = string.Join('_', parts.Skip(1));
            string normalizedTypeName = NormalizeDescription(typeName);

            Console.WriteLine($"Class: {className}, Type: {typeName}, Normalized Type: {normalizedTypeName}");

            switch (className)
            {
                case "wings":
                    if (Enum.TryParse(typeof(WingsType), normalizedTypeName, true, out var wingsType))
                    {
                        Console.WriteLine($"Matched wings type: {wingsType}");
                        return Wings.Of((WingsType)wingsType);
                    }
                    break;
                case "hull":
                    if (Enum.TryParse(typeof(HullType), normalizedTypeName, true, out var hullType))
                    {
                        Console.WriteLine($"Matched hull type: {hullType}");
                        return Hull.Of((HullType)hullType);
                    }
                    break;
                case "thrusters":
                    if (Enum.TryParse(typeof(ThrusterType), normalizedTypeName, true, out var thrusterType))
                    {
                        Console.WriteLine($"Matched thrusters type: {thrusterType}");
                        return Thrusters.Of((ThrusterType)thrusterType);
                    }
                    break;
                case "engine":
                    if (Enum.TryParse(typeof(EngineType), normalizedTypeName, true, out var engineType))
                    {
                        Console.WriteLine($"Matched engine type: {engineType}");
                        return Engine.Of((EngineType)engineType);
                    }
                    break;
            }

            Console.WriteLine($"No match found for: {componentName}");
            return null;
        }

        private string NormalizeDescription(string typeName)
        {
            // Transforme les noms en descriptions compatibles avec les enums
            return typeName.Replace('_', ' ').ToUpper();
        }


        private void DisplayHelp()
        {
            Console.WriteLine("Liste des commandes :");
            Console.WriteLine("STOCKS => Afficher les stocks disponibles");
            Console.WriteLine("NEEDED_STOCKS ARGS => Afficher les stocks nécessaires pour une commande");
            Console.WriteLine("INSTRUCTIONS ARGS => Afficher les instructions d'assemblage pour une commande");
            Console.WriteLine("VERIFY ARGS => Vérifier une commande");
            Console.WriteLine("PRODUCE ARGS => Produire une commande");
            Console.WriteLine("RECEIVE ARGS => Recevoir du stock");
            Console.WriteLine("ORDER ARGS => Ajouter une commande");
            Console.WriteLine("SEND ARGS => Envoyer un vaisseau");
            Console.WriteLine("LIST_ORDER => Lister les commandes restantes");
            Console.WriteLine("EXIT => Quitter le programme");
        }
    }
}
