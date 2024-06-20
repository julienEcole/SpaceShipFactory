using starShipFactory.cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                DisplayNeededStocks();
            }
            else if (command.StartsWith("INSTRUCTIONS"))
            {
                DisplayInstructions();
            }
            else if (command.StartsWith("VERIFY"))
            {
                VerifyCommand();
            }
            else if (command.StartsWith("PRODUCE"))
            {
                ProduceCommand(command);
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
            foreach (KeyValuePair<string, int> kvp in Atelier.GetStocks())
            {
                Console.WriteLine($"Component: {kvp.Key}, Quantity: {kvp.Value}");
            }
        }

        private void DisplayNeededStocks()
        {
            Console.WriteLine("=== NEEDED_STOCKS ===");
            // Implémentation de l'affichage des stocks nécessaires
        }

        private void DisplayInstructions()
        {
            Console.WriteLine("=== INSTRUCTIONS ===");
            // Implémentation de l'affichage des instructions d'assemblage
        }

        private void VerifyCommand()
        {
            Console.WriteLine("=== VERIFY ===");
            // Implémentation de la vérification d'une commande
        }

        private void ProduceCommand(string command)
        {
            Console.WriteLine("=== PRODUCE ===");
            // Implémentation de la production d'une commande
        }

        private void DisplayHelp()
        {
            Console.WriteLine("Liste des commandes :");
            Console.WriteLine("STOCKS => Afficher les stocks disponibles");
            Console.WriteLine("NEEDED_STOCKS => Afficher les stocks nécessaires pour une commande");
            Console.WriteLine("INSTRUCTIONS => Afficher les instructions d'assemblage pour une commande");
            Console.WriteLine("VERIFY => Vérifier une commande");
            Console.WriteLine("PRODUCE [type] [quantity] => Produire une commande");
            Console.WriteLine("EXIT => Quitter le programme");
        }
    }
}