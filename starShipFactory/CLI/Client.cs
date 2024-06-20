using Microsoft.VisualBasic;
using starShipFactory.cache;
using starShipFactory.ship.shipComponent;
using starShipFactory.ship.shipComponent.specificalComponent;

namespace starShipFactory.CLI
{
    internal class Client
    {
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
            else if (command.ToLower() == "help")
            {
                DisplayHelp();
            }
            else
            {
                Console.WriteLine("Commande non reconnue. Tapez 'help' pour obtenir la liste des commandes");
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
            // Implémentation de l'affichage des stocks nécessaires
        }

        private void DisplayInstructions(string command)
        {
            Console.WriteLine("=== INSTRUCTIONS ===");
            // Implémentation de l'affichage des instructions d'assemblage
        }

        private void VerifyCommand(string command)
        {
            Console.WriteLine("=== VERIFY ===");
            // Implémentation de la vérification d'une commande
        }

        private void ProduceCommand(string command)
        {
            Console.WriteLine("=== PRODUCE ===");
            // Implémentation de la production d'une commande
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
                            Atelier.Add(component, quantity);
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

        private Component CreateComponentFromString(string componentName)
        {
            string[] parts = componentName.Split('_');
            if (parts.Length < 2)
            {
                return null;
            }

            string className = parts[0].ToLower();
            string typeName = parts[1];

            switch (className)
            {
                case "wings":
                    if (Enum.TryParse(typeName, true, out WingsType wingsType))
                    {
                        return Wings.Of(wingsType);
                    }
                    break;
                case "hull":
                    if (Enum.TryParse(typeName, true, out HullType hullType))
                    {
                        return Hull.Of(hullType);
                    }
                    break;
                case "thrusters":
                    if (Enum.TryParse(typeName, true, out ThrusterType thrusterType))
                    {
                        return Thrusters.Of(thrusterType);
                    }
                    break;
                case "engine":
                    if (Enum.TryParse(typeName, true, out EngineType engineType))
                    {
                        return Engine.Of(engineType);
                    }
                    break;
            }
            return null;
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
            Console.WriteLine("EXIT => Quitter le programme");
        }
    }
}