using starShipFactory.ship.shipComponent;
using starShipFactory.ship.shipComponent.specificalComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipType
{
    public class Cargo : Ship
    {
        public Cargo(string name, Hull[] cargos, Engine engine, Wings wings, Thrusters thruster)
            : base(name, cargos, new Engine[] { engine }, new Thrusters[] { thruster }, new Wings[] { wings })
        {
        }

        public override Dictionary<Component, int> GetRequiredComponents()
        {
            var components = new Dictionary<Component, int>
            {
                { Hull.Of(HullType.Hull_HC1), 1 },
                { Engine.Of(EngineType.Engine_EC1), 2 },
                { Thrusters.Of(ThrusterType.Thrusters_TC1), 4 }
            };

            return components;
        }

    }
}
