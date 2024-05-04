using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipComponent
{
    public class Thrusters : Component
    {
        public ThrusterType type { get; }
        private Thrusters(ThrusterType type)
        {
            this.type = type;
        }
        
        public static Thrusters of(ThrusterType type = ThrusterType.Scrap) {         
            Thrusters nouveau = new Thrusters(type);
            //ajouter l'élément a l'inventaire de l'atelier (cache pour composant non utilisé) quand il sera dispo
            return nouveau;
        }
    }

    public enum ThrusterType
    {
        Scrap,
        Thruster_TE1,
        Thruster_TS1,
        Thruster_TC1
    }
}
