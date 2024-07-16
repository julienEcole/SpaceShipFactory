using System;
using System.Collections.Generic;
using starShipFactory.ship;

namespace starShipFactory.cache
{
    public static class Hangar
    {
        private static readonly Hangar _instance = new Hangar();

        static readonly Dictionary<string, Ship> ShipsByName = new Dictionary<string, Ship>();

        private Hangar() { }

        public static Hangar Instance
        {
            get { return _instance; }
        }

        public static void AddShip(Ship ship)
        {
            if (!ShipsByName.ContainsKey(ship.name))
            {
                ShipsByName.Add(ship.name, ship);
            }
            else
            {
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
                return null;
            }
        }
    }
}
