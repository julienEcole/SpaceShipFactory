using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

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

        public override string ToString()
        {
            return ShipComponentDescription.GetDescription(Type);
        }
        // Implémentation de GetName
        public string GetName()
        {
            return this.ToString();
        }

        // Implémentation de GetDescription
        public string GetDescription()
        {
            return this.ToString();
        }
    }

    public enum WingsType
    {
        [Description("Wings scrap")]
        Wings_scrap,
        [Description("Wings WE1")]
        Wings_WE1,
        [Description("Wings WS1")]
        Wings_WS1,
        [Description("Wings WC1")]
        Wings_WC1
        
    }
}
