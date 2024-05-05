using System;
using System.Collections.Generic;
using System.Linq;
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

        public enum EngineType
        {
            Engine_Scrap,
            Engine_EE1,
            Engine_ES1,
            Engine_EC1
        }
    }
}
