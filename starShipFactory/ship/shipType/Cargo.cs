using starShipFactory.ship.shipComponent.specificalComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipType
{
    public class Cargo : Ship
    {
        private Cargo(string name, Hull[] cargos, Engine engine, Wings wings, Thrusters thruster)
            : base(name, cargos, new Engine[] { engine }, new Thrusters[] { thruster }, new Wings[] { wings })
        {
        }

        public static Cargo Of(string name, Hull[] cargos, Engine engine, Wings wings, Thrusters thruster)
        {
            return (Cargo)Of(name, cargos, new Engine[] { engine }, new Thrusters[] { thruster }, new Wings[] { wings });
        }

    }
}
