using System.ComponentModel;
using System.Reflection;

namespace starShipFactory.ship.shipComponent.specificalComponent
{
    public class Hull : Component
    {
        public CargoType Type { get; }

        private Hull(CargoType type)
        {
            Type = type;
        }

        public static Hull Of(CargoType type = CargoType.Hull_scrap)
        {
            return new Hull(type);
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

    

    public enum CargoType
    {
        [Description("Hull_scrap")]
        Hull_scrap,
        [Description("Hull_HC1")]
        Hull_HC1
    }
}
