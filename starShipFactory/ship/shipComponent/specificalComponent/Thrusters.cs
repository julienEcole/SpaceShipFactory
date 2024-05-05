using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipComponent.specificalComponent
{
    public class Thrusters : Component
    {
        public ThrusterType type { get; }
        private Thrusters(ThrusterType type)
        {
            this.type = type;
        }

        public static Thrusters of(ThrusterType type = ThrusterType.Thrusters_scrap)
        {
            Thrusters nouveau = new Thrusters(type);
            //ajouter l'élément a l'inventaire de l'atelier (cache pour composant non utilisé) quand il sera dispo
            return nouveau;
        }
    }

    public enum ThrusterType
    {
        Thrusters_scrap,
        Thrusters_TE1,
        Thrusters_TS1,
        Thrusters_TC1
    }
}
