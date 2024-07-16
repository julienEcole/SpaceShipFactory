using System;
using System.Collections.Generic;
using starShipFactory.ship.shipComponent;

namespace starShipFactory.cache
{
    public static class Atelier
    {
        private static readonly Atelier _instance = new Atelier();

        static readonly Dictionary<string, int> Stock;
        static readonly Dictionary<string, int> InProduction;

        static Atelier()
        {
            Stock = new Dictionary<string, int>();
            InProduction = new Dictionary<string, int>();
        }
        //

        private Atelier() { }

        public static Atelier Instance
        {
            get { return _instance; }
        }

        public static void AddStock(string typeName, int quantity)
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

        public static void AddStock(Component theComponent, int quantity)
        {
            AddStock(theComponent.ToString(), quantity);
        }

        public static bool RemoveStock(string type, int quantity)
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

        public static void MoveFromStockToProduction(string typeName, int quantity)
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

        public static void MoveBackToStockFromProduction(string typeName, int quantity)
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

        public static void GetBackAllToStockFromProduction()
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

        public static int GetQuantity(string type)
        {
            if (Stock.ContainsKey(type))
            {
                return Stock[type];
            }
            else return 0;
        }

        internal static IEnumerable<KeyValuePair<string, int>> GetStocks()
        {
            throw new NotImplementedException();
        }
    }
}
