// See https://aka.ms/new-console-template for more information

using starShipFactory.ship.shipComponent;

namespace starShipFactory // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
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



        static void ProcessCommand(string command)
        {
            if (command.StartsWith("STOCKS"))
            {
                Console.WriteLine("=== STOCKS ===");

                /*
                foreach (KeyValuePair<Component, int> kvp in Atelier.Stock)
                {
                    Console.WriteLine($"Component: {kvp.Key}, Quantity: {kvp.Value}");
                }
                */

            }
            else if (command.StartsWith("NEEDED_STOCKS"))
            {
                Console.WriteLine("=== NEEDED_STOCKS ===");
            }
            else if (command.StartsWith("INSTRUCTIONS"))
            {
                Console.WriteLine(" === INSTRUCTIONS ===");
            }
            else if (command.StartsWith("VERIFY"))
            {
                Console.WriteLine(" === VERIFY ===");
            }
            else if (command.StartsWith("PRODUCE"))
            {
                Console.WriteLine(" === PRODUCE ===");
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


        static void DisplayHelp()
        {
            Console.WriteLine("Liste des commandes :");
            Console.WriteLine("STOCKS => Afficher les stocks disponibles");
            Console.WriteLine("NEEDED_STOCKS => Afficher les stocks nécessaires pour une commande");
            Console.WriteLine("INSTRUCTIONS => Afficher les instructions d'assemblage pour une commande");
            Console.WriteLine("VERIFY => Vérifier une commande");
            Console.WriteLine("PRODUCE => Produire une commande");
            Console.WriteLine("EXIT => Quitter le programme");
        }
    }
}
