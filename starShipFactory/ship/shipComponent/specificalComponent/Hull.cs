using System.Reflection;

using System;
using System.Linq;
using System.ComponentModel;



namespace starShipFactory.ship.shipComponent.specificalComponent
{
    public class Hull : Component
    {
        public HullType Type { get; }

        private Hull(HullType type)
        {
            Type = type;
        }

        public static Hull Of(HullType type = HullType.Hull_scrap)
        {
            return new Hull(type);
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

    public enum HullType
    {
        [Description("Hull scrap")]
        Hull_scrap,
        [Description("Hull HC1")]
        Hull_HC1,
        [Description("Hull HE1")]
        Hull_HE1
    }
}
