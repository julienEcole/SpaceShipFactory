using starShipFactory.ship.shipComponent;
using starShipFactory.ship.shipComponent.specificalComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipType
{
    public class Explorer : Ship
    {

        public Explorer(string name, Hull hull, Engine engine, Wings wings, Thrusters thruster)
            : base(name, new Hull[] { hull }, new Engine[] { engine }, new Thrusters[] { thruster }, new Wings[] { wings })
        {
        }

        // private Explorer(string name, Hull hull, Engine engine, Wings wings, Thrusters thruster)
        //     : base(name, new Hull[0], new Engine[] { engine }, new Thrusters[] { thruster }, new Wings[] { wings })
        // {
        // }

        // public static Explorer Of(string name, Hull hull, Engine engine, Wings wings, Thrusters thruster)
        // {
        //     return (Explorer)Ship.Of(name, new Hull[0], new Engine[] { engine }, new Thrusters[] { thruster }, new Wings[] { wings });
        // }

        public override Dictionary<Component, int> GetRequiredComponents()
        {
            var components = new Dictionary<Component, int>();
            // Exemple de composants pour Explorer
            
            components.Add(Hull.Of(HullType.Hull_HE1), 1);
            components.Add(Engine.Of(EngineType.Engine_EE1), 1);
            components.Add(Wings.Of(WingsType.Wings_WE1), 2);

            return components;
        }

    }
}
