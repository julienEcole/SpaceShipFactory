using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace starShipFactory.ship.shipComponent
{
    public class Engine : Component
    {
        public EngineType Type { get; }
        
        private Engine(EngineType type)
        {
            this.Type = type;
        }
        
        public static Engine Of(EngineType type = EngineType.Scrap)
        {         
            return new Engine(type);
        }

        public enum EngineType
        {
            Scrap,
            Engine_EE1,
            Engine_ES1,
            Engine_EC1
        }
    }
}
