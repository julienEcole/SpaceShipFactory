using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipComponent.specificalComponent
{
    public class Hull : Component
    {
        public CargoType Type { get; }

        private Hull(CargoType type)
        {
            Type = type;
        }

        public static Hull Of(CargoType type = CargoType.Hull_scrap)
        {
            return new Hull(type);
        }
    }

    public enum CargoType
    {
        [Description("Hull_scrap")]
        Hull_scrap,
        [Description("Hull_HC1")]
        Hull_HC1
    }
}
