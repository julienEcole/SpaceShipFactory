using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace starShipFactory.ship.shipComponent
{
    public static class ShipComponentDescription
    {
        public static string GetDescription<T>(T enumValue) where T : Enum
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DescriptionAttribute>()?.Description ?? enumValue.ToString();
        }
    }
}
