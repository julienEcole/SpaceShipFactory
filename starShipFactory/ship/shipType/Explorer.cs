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
        private Explorer(string name, Hull hull, Engine engine, Wings wings, Thrusters thruster)
            : base(name, new Hull[0], new Engine[] { engine }, new Thrusters[] { thruster }, new Wings[] { wings })
        {
        }

        public static Explorer Of(string name, Hull hull, Engine engine, Wings wings, Thrusters thruster)
        {
            return (Explorer)Ship.Of(name, new Hull[0], new Engine[] { engine }, new Thrusters[] { thruster }, new Wings[] { wings });
        }
    }
}
