using System;
using System.Collections.Generic;
using starShipFactory.ship.shipComponent;

namespace starShipFactory.cache
{
    public class Atelier
    {
        // Déclaration de l'instance statique readonly
        private static readonly Atelier _instance = new Atelier();

        // Dictionnaire pour stocker les composants et leur production
        private readonly Dictionary<string, int> Stock;
        private readonly Dictionary<string, int> InProduction;

        // Constructeur privé pour empêcher l'instanciation directe
        private Atelier()
        {
            Stock = new Dictionary<string, int>();
            InProduction = new Dictionary<string, int>();
        }

        // Propriété pour accéder à l'instance unique
        public static Atelier Instance
        {
            get { return _instance; }
        }

        // Méthode pour ajouter du stock
        public void AddStock(string typeName, int quantity)
        {
            if (Stock.ContainsKey(typeName))
            {
                Stock[typeName] += quantity;
            }
            else
            {
                Stock[typeName] = quantity;
            }
        }

        // Surcharge de la méthode AddStock pour accepter un composant
        public void AddStock(Component theComponent, int quantity)
        {
            AddStock(theComponent.ToString(), quantity);
        }

        // Méthode pour retirer du stock
        public bool RemoveStock(string type, int quantity)
        {
            if (Stock.ContainsKey(type))
            {
                Stock[type] -= quantity;
                if (Stock[type] < 0)
                {
                    Stock[type] += quantity;
                    return false;
                }
                return true;
            }
            return false;
        }

        // Méthode pour déplacer du stock vers la production
        public void MoveFromStockToProduction(string typeName, int quantity)
        {
            if (RemoveStock(typeName, quantity))
            {
                if (InProduction.ContainsKey(typeName))
                {
                    InProduction[typeName] += quantity;
                }
                else
                {
                    InProduction[typeName] = quantity;
                }
            }
            else
            {
                throw new InvalidOperationException("Not enough stock to move to production.");
            }
        }

        // Méthode pour retourner de la production au stock
        public void MoveBackToStockFromProduction(string typeName, int quantity)
        {
            if (InProduction.ContainsKey(typeName) && InProduction[typeName] >= quantity)
            {
                InProduction[typeName] -= quantity;
                if (Stock.ContainsKey(typeName))
                {
                    Stock[typeName] += quantity;
                }
                else
                {
                    Stock[typeName] = quantity;
                }
            }
            else
            {
                throw new InvalidOperationException("Not enough items in production to move back to stock.");
            }
        }

        // Méthode pour retourner toute la production au stock
        public void GetBackAllToStockFromProduction()
        {
            foreach (var item in InProduction)
            {
                if (Stock.ContainsKey(item.Key))
                {
                    Stock[item.Key] += item.Value;
                }
                else
                {
                    Stock[item.Key] = item.Value;
                }
            }
            InProduction.Clear();
        }

        // Méthode pour obtenir la quantité en stock d'un type de composant
        public int GetQuantity(string type)
        {
            if (Stock.ContainsKey(type))
            {
                return Stock[type];
            }
            else return 0;
        }

        // Méthode pour obtenir les stocks (à implémenter si nécessaire)
        public IEnumerable<KeyValuePair<string, int>> GetStocks()
        {
            // Implémentez cette méthode selon vos besoins
            return Stock;
        }
    }
}
