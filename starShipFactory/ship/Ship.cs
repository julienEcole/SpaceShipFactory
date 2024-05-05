using starShipFactory.cache;
using starShipFactory.ship.shipComponent;
using starShipFactory.ship.shipComponent.specificalComponent;

namespace starShipFactory.ship
{
    public class Ship
    {
        private Hull[] _cargos;
        private Engine[] _engines;
        private Thrusters[] _thrusters;
        private Wings[] _wings;
        private string _name;
        public string name { get { return _name; } }

        private bool canFly;

        protected Ship()
        {
            _cargos = [];
            _engines = [];
            _thrusters = [];
            _wings = [];
            canFly = false;
            _name = string.Empty;
        }

        protected Ship(string name) : this()
        {
            _name = name;
        }
        protected Ship(string name, Hull[] cargos, Engine[] engines, Thrusters[] thrusters, Wings[] wings) : this(name)
        {
            _cargos = cargos;
            _engines = engines;
            _thrusters = thrusters;
            _wings = wings;
            canFly = _engines.Length > 0 && _thrusters.Length > 0 && _wings.Length > 0;
        }
        private void updateFlyStatus()
        {
            canFly = _engines.Length > 0 && _thrusters.Length > 0 && _wings.Length > 0;
        }
        public void AddComponent(Component comp)
        {
            //ajouter le component dans la bonne liste
            updateFlyStatus();
        }

        public void RemoveComponent(Component comp)
        {
            //le retirer puis le mettre au stock quand implem
            updateFlyStatus();
        }

        public bool CanTheShipFly()
        {
            if (canFly) { }
            else
            {
                if(_thrusters.Length == 0)
                {
                    Console.WriteLine("il manque des propulseurs au vaisseau");
                }
                if(_wings.Length == 0)
                {
                    Console.WriteLine("il manques des ailes au vaisseau même en 0 g");
                }
                if(_engines.Length == 0)
                {
                    Console.WriteLine("il manque un moteur au vaisseau, au moins pour décoller");
                }
            }
            return canFly;
        }

        public static Ship Of(string name, Hull[] cargos, Engine[] engines, Thrusters[] thrusters, Wings[] wings)
        {
            //make verification here
            //Ship newShip;
            if (Hangar.GetShip(name) != null) return Hangar.GetShip(name);
            else
            {
                Hangar.AddShip(new Ship(name, cargos, engines, thrusters, wings));
                return Hangar.GetShip(name);
            }
        }

        /*

        public static Ship Of(string name, Hull[] cargos, Engine[] engines, Thrusters[] thrusters, Wings[] wings)
            {
            //Ship newShip;
            /*if (ShipCache.GetShip(name) != null) return ShipCache.GetShip(name);
            else
            {
                ShipCache.AddShip(new Ship(name, cargos, engines, thrusters, wings));
                return ShipCache.GetShip(name);
            }

            // Vérification du nom du vaisseau
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Le nom du vaisseau ne peut pas être vide.");
            }

            // Vérification des composants fournis
            if (cargos == null || engines == null || thrusters == null || wings == null ||
                cargos.Length == 0 || engines.Length == 0 || thrusters.Length == 0 || wings.Length == 0)
            {
                throw new ArgumentException("Le vaisseau doit avoir au moins un composant de chaque type.");
            }

            // Vérification de la disponibilité des composants dans le stock
            foreach (Cargo cargo in cargos)
            {
                if (ComponentStock.GetQuantity(cargo.Type) <= 0)
                {
                    throw new InvalidOperationException($"La pièce {cargo.Type} n'est pas disponible dans le stock.");
                }
            }

            foreach (Engine engine in engines)
            {
                if (ComponentStock.GetQuantity(engine.Type) <= 0)
                {
                    throw new InvalidOperationException($"La pièce {engine.Type} n'est pas disponible dans le stock.");
                }
            }

            foreach (Thrusters thruster in thrusters)
            {
                if (ComponentStock.GetQuantity(thruster.Type) <= 0)
                {
                    throw new InvalidOperationException($"La pièce {thruster.Type} n'est pas disponible dans le stock.");
                }
            }

            foreach (Wings wing in wings)
            {
                if (ComponentStock.GetQuantity(wing.Type) <= 0)
                {
                    throw new InvalidOperationException($"La pièce {wing.Type} n'est pas disponible dans le stock.");
                }
            }

            // Si toutes les vérifications sont réussies, créer et retourner le vaisseau
            if (ShipCache.GetShip(name) != null) return ShipCache.GetShip(name);
            else
            {
                Ship newShip = new Ship(name, cargos, engines, thrusters, wings);
                ShipCache.AddShip(newShip);
                return newShip;
            }
        }
        */
    }

}

