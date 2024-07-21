using System;
using System.Collections.Generic;
using starShipFactory.ship;

namespace starShipFactory.cache
{
    public class Hangar
    {
        // Déclaration de l'instance statique readonly
        private static readonly Hangar _instance = new Hangar();

        // Dictionnaire pour stocker les vaisseaux
        private readonly Dictionary<string, Ship> ShipsByName = new Dictionary<string, Ship>();

        // Constructeur privé pour empêcher l'instanciation directe
        private Hangar() { }

        // Propriété pour accéder à l'instance unique
        public static Hangar Instance
        {
            get { return _instance; }
        }

        // Méthode pour ajouter un vaisseau
        public void AddShip(Ship ship)
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

        // Méthode pour retirer un vaisseau
        public void RemoveShip(string shipName)
        {
            ShipsByName.Remove(shipName);
        }

        // Méthode pour obtenir un vaisseau par son nom
        public Ship? GetShip(string shipName)
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
