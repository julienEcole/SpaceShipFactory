using starShipFactory.ship.shipComponent;

namespace starShipFactory.cache
{
    public static class Atelier
    {
        static readonly Dictionary<string, int> Stock = new Dictionary<string, int>();
        static readonly Dictionary<string, int> InProduction = new Dictionary<string, int>();

        static Atelier()
        {
            // Initialize the stock with default values
            // Example: Stock["Engine_EE1"] = 10;
        }

        public static void AddStock(string typeName, int quantity)
        {
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

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
            if (theComponent == null) throw new ArgumentNullException(nameof(theComponent));

            AddStock(theComponent.ToString(), quantity);
        }

        public static bool RemoveStock(string type, int quantity)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

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
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

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
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));

            if (InProduction.ContainsKey(typeName) && InProduction[typeName] >= quantity)
            {
                InProduction[typeName] -= quantity;
                AddStock(typeName, quantity);  // Add back to stock
            }
            else
            {
                throw new InvalidOperationException("Not enough items in production to move back to stock.");
            }
        }

        public static void GetBackAllToStockFromProduction()
        {
            foreach (var item in new Dictionary<string, int>(InProduction))
            {
                MoveBackToStockFromProduction(item.Key, item.Value);
            }
        }

        public static int GetQuantity(string type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return Stock.ContainsKey(type) ? Stock[type] : 0;
        }

        public static int GetProductionQuantity(string type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return InProduction.ContainsKey(type) ? InProduction[type] : 0;
        }

        public static Dictionary<string, int> GetStocks()
        {
            return new Dictionary<string, int>(Stock);
        }

        public static Dictionary<string, int> GetProductionStocks()
        {
            return new Dictionary<string, int>(InProduction);
        }

        public static bool AreComponentsAvailable(Dictionary<Component, int> requiredComponents)
        {
            if (requiredComponents == null) throw new ArgumentNullException(nameof(requiredComponents));

            foreach (var component in requiredComponents)
            {
                if (!InProduction.ContainsKey(component.Key.ToString()) || InProduction[component.Key.ToString()] < component.Value)
                    return false;
            }
            return true;
        }

        public static void ConsumeComponents(Dictionary<Component, int> requiredComponents)
        {
            if (requiredComponents == null) throw new ArgumentNullException(nameof(requiredComponents));

            foreach (var component in requiredComponents)
            {
                if (InProduction.ContainsKey(component.Key.ToString()))
                {
                    InProduction[component.Key.ToString()] -= component.Value;
                }
            }
        }
    }
}
