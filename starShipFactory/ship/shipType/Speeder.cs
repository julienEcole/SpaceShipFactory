using starShipFactory.cache;
using starShipFactory.ship.shipComponent;
using starShipFactory.ship.shipComponent.specificalComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipType
{
    internal class Speeder : Ship
    {

        public Speeder(string name, Engine engine, Wings wings, Thrusters thruster1, Thrusters thruster2)
            : base(name, new Hull[0], new Engine[] { engine }, new Thrusters[] { thruster1, thruster2 }, new Wings[] { wings })
        {
        }

        public static Speeder Of(string name, Engine engine, Wings wings, Thrusters thruster1, Thrusters thruster2)
        {
            Speeder leSpeeder = new Speeder(name, engine, wings, thruster1, thruster2);
            Hangar.AddShip(leSpeeder);
            return leSpeeder;
        }

        // public static Speeder Of(string name, Engine engine, Wings wings, Thrusters[] thrusters)
        // {
        //     if (thrusters.Length >= 2) {
        //         return Speeder.Of(name, engine, wings, thrusters[0], thrusters[1]);
        //     }
        //     throw new ArgumentException("il manque des thrusters pour construire ce speeder");
        // }

        // public static Speeder Of(string name, Engine[] engine, Wings[] wings, Thrusters[] thrusters)
        // {
        //     if (thrusters.Length >= 2 && engine.Length >= 1 && wings.Length >= 1)
        //     {
        //         return Speeder.Of(name, engine[0], wings[0], thrusters[0], thrusters[1]);
        //     }
        //     throw new ArgumentException("il manque des thrusters pour construire ce speeder");
        // }

        public override Dictionary<Component, int> GetRequiredComponents()
        {
            var components = new Dictionary<Component, int>();
            // Exemple de composants pour Speeder

            components.Add(Engine.Of(EngineType.Engine_ES1), 1);
            components.Add(Wings.Of(WingsType.Wings_WS1), 2);
            components.Add(Thrusters.Of(ThrusterType.Thrusters_TS1), 4);

            return components;
        }

    }
}
