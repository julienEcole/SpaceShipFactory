using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


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

        override public string ToString()
        {
            // Utiliser Reflection pour obtenir la valeur de description de l'énumération
            string typeName = Type.GetType()
                                   .GetMember(Type.ToString())
                                   .First()
                                   .GetCustomAttribute<DescriptionAttribute>()?.Description ?? Type.ToString();

            return $"{GetType().Name}_{typeName}";
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
