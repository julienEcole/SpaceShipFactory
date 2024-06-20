using starShipFactory.ship.shipComponent;

namespace starShipFactory.cache
{
    public static class Atelier
    {
        static readonly Dictionary<string, int> Stock = new Dictionary<string, int>();
        static readonly Dictionary<string, int> InProduction = new Dictionary<string, int>();

        static Atelier()
        {
            // Initialiser le stock avec des valeurs par defaut
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

        public static void getBackAllToStockFromProduction()
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
            return Stock.ContainsKey(type) ? Stock[type] : 0;
        }

        internal static IEnumerable<KeyValuePair<string, int>> GetStocks()
        {
            throw new NotImplementedException();
        }
    }
}
