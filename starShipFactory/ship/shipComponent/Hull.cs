using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipComponent
{
    public class Hull : Component
    {
        public CargoType Type { get; }
        
        private Hull(CargoType type)
        {
            this.Type = type;
        }
        
        public static Hull Of(CargoType type = CargoType.Scrap)
        {         
            return new Hull(type);
        }
    }

    public enum CargoType
    {
        Scrap,
        Hull_HC1,
        Engine_EC1,
        Wings_WC1,
        Thruster_TC1
    }
}
