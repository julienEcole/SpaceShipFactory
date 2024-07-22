using starShipFactory.ship.shipComponent.specificalComponent;
using System;

namespace starShipFactory.ship.shipComponent
{
    public static class ComponentFactory
    {
        public static Component CreateComponent(string componentType, string enumType)
        {
            switch (componentType.ToLower())
            {
                case "engine":
                    if (Enum.TryParse(enumType, out EngineType engineType))
                    {
                        return Engine.Of(engineType);
                    }
                    break;

                case "hull":
                    if (Enum.TryParse(enumType, out HullType hullType))
                    {
                        return Hull.Of(hullType);
                    }
                    break;

                case "thrusters":
                    if (Enum.TryParse(enumType, out ThrusterType thrusterType))
                    {
                        return Thrusters.Of(thrusterType);
                    }
                    break;

                case "wings":
                    if (Enum.TryParse(enumType, out WingsType wingsType))
                    {
                        return Wings.Of(wingsType);
                    }
                    break;
            }

            throw new ArgumentException($"Unknown component type or enum value: {componentType}, {enumType}");
        }
    }

}
