using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace starShipFactory.ship.shipComponent.specificalComponent
{
    public class Engine : Component
    {
        public EngineType Type { get; }

        private Engine(EngineType type)
        {
            Type = type;
        }

        public static Engine Of(EngineType type = EngineType.Engine_Scrap)
        {
            return new Engine(type);
        }

        public override string ToString()
        {
            return ShipComponentDescription.GetDescription(Type);
        }
    }

    public enum EngineType
    {
        [Description("Engine_Scrap")]
        Engine_Scrap,
        [Description("Engine_EE1")]
        Engine_EE1,
        [Description("Engine_ES1")]
        Engine_ES1,
        [Description("Engine_EC1")]
        Engine_EC1
    }
}
