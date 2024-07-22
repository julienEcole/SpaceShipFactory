using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace starShipFactory.ship.shipComponent.specificalComponent
{
    public class Engine : Component
    {
        public EngineType Type { get; private set; }

        private Engine(EngineType type)
        {
            Type = type;
        }

        public static Engine Of(EngineType type)
        {
            return new Engine(type);
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

    public enum EngineType
    {
        [Description("Engine Scrap")]
        Engine_Scrap,
        [Description("Engine EE1")]
        Engine_EE1,
        [Description("Engine ES1")]
        Engine_ES1,
        [Description("Engine EC1")]
        Engine_EC1
    }
}
