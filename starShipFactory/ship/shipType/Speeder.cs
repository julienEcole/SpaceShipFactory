using starShipFactory.ship.shipComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipType
{
    internal class Speeder : Ship
    {
        private Speeder(string name, Engine engine, Wings wings, Thrusters thruster1, Thrusters thruster2)
            : base(name, new Hull[0], new Engine[] { engine }, new Thrusters[] { thruster1, thruster2 }, new Wings[] { wings })
        {
        }

        public static Speeder Create(string name, Engine engine, Wings wings, Thrusters thruster1, Thrusters thruster2)
        {
            return (Speeder)Ship.Of(name, new Hull[0], new Engine[] { engine }, new Thrusters[] { thruster1, thruster2 }, new Wings[] { wings });
        }
    }
}
