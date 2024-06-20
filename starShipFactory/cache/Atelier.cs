using starShipFactory.ship.shipComponent;

namespace starShipFactory.cache
{
    public static class Atelier
    {
        static readonly Dictionary<Component, int> Stock = new Dictionary<Component, int>();

        static Atelier()
        {
            // Initialiser le stock avec des valeurs par defaut
            foreach (Component type in Enum.GetValues(typeof(Component)))
            {
                Stock[type] = 0;
            }
        }

        public static void Add(Component type, int quantity)
        {
            if (Stock.ContainsKey(type))
            {
                Stock[type] += quantity;
            }
            else
            {
                Stock[type] = quantity;
            }
        }

        public static void Remove(Component type, int quantity)
        {
            if (Stock.ContainsKey(type))
            {
                Stock[type] -= quantity;
                if (Stock[type] < 0)
                {
                    Stock[type] = 0;
                }
            }
        }

        public static int GetQuantity(Component type)
        {
            return Stock.ContainsKey(type) ? Stock[type] : 0;
        }

        internal static IEnumerable<KeyValuePair<string, int>> GetStocks()
        {
            throw new NotImplementedException();
        }
    }
}
