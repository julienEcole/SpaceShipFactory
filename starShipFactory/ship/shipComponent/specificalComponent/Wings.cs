using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace starShipFactory.ship.shipComponent.specificalComponent
{
    public class Wings : Component
    {
        public WingsType Type { get; }

        private Wings(WingsType type)
        {
            Type = type;
        }

        public static Wings Of(WingsType type = WingsType.Wings_scrap)
        {
            return new Wings(type);
        }
    }

    public enum WingsType
    {
        Wings_scrap,
        Wings_WE1,
        Wings_WS1,
        Wings_WC1
        // Ajouter d'autres types d'ailes au besoin
    }
}
