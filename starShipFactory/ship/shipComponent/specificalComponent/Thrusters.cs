using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace starShipFactory.ship.shipComponent.specificalComponent
{
    public class Thrusters : Component
    {
        public ThrusterType Type { get; }

        private Thrusters(ThrusterType type)
        {
            Type = type;
        }

        public static Thrusters Of(ThrusterType type = ThrusterType.Thrusters_scrap)
        {
            return new Thrusters(type);
        }

        public override string ToString()
        {
            return ShipComponentDescription.GetDescription(Type);
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
