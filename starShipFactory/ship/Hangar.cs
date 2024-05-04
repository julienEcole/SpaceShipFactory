using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship
{
    public static class Hangar
    {
        static readonly Dictionary<string, Ship> ShipsByName = new Dictionary<string, Ship>();

        public static void AddShip(Ship ship)
        {
            if (!ShipsByName.ContainsKey(ship.name))
            {
                ShipsByName.Add(ship.name, ship);
            }
            else
            {
                // Gérer le cas où un vaisseau avec le même nom existe déjà
                throw new ArgumentException("A ship with the same name already exists in the cache.");
            }
        }

        public static void RemoveShip(string shipName)
        {
            ShipsByName.Remove(shipName);
        }

        public static Ship? GetShip(string shipName)
        {
            if (ShipsByName.ContainsKey(shipName))
            {
                return ShipsByName[shipName];
            }
            else
            {
                // Gérer le cas où aucun vaisseau avec le nom donné n'existe dans le cache
                return null;
            }
        }
    }
}
