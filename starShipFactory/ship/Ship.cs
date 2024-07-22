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

        // Méthode abstraite à implémenter dans chaque sous-classe
        // public Dictionary<Component, int> GetRequiredComponents(){
        //     return new Dictionary<Component>();
        // } 
        public virtual Dictionary<Component, int> GetRequiredComponents()
        {
            return new Dictionary<Component, int>();
        }
    }

}

