using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipComponent.specificalComponent
{
    public class Thrusters : Component
    {
        public ThrusterType Type { get; }
        private Thrusters(ThrusterType type)
        {
            this.Type = type;
        }

        public static Thrusters of(ThrusterType type = ThrusterType.Thrusters_scrap)
        {
            Thrusters nouveau = new Thrusters(type);
            //ajouter l'élément a l'inventaire de l'atelier (cache pour composant non utilisé) quand il sera dispo
            return nouveau;
        }

        override public string ToString()
        {
            // Utiliser Reflection pour obtenir la valeur de description de l'énumération
            string typeName = Type.GetType()
                                   .GetMember(Type.ToString())
                                   .First()
                                   .GetCustomAttribute<DescriptionAttribute>()?.Description ?? Type.ToString();

            return /*{GetType().Name}_*/$"{typeName}";
        }

    }

    public enum ThrusterType
    {
        [Description("Thrusters_scrap")]
        Thrusters_scrap,
        [Description("Thrusters_TE1")]
        Thrusters_TE1,
        [Description("Thrusters_TS1")]
        Thrusters_TS1,
        [Description("Thrusters_TC1")]
        Thrusters_TC1
    }
}
