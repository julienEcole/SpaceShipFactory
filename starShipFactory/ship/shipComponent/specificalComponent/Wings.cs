using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

    public enum WingsType
    {
        [Description("Wings_scrap")]
        Wings_scrap,
        [Description("Wings_WE1")]
        Wings_WE1,
        [Description("Wings_WS1")]
        Wings_WS1,
        [Description("Wings_WC1")]
        Wings_WC1
    }
}
