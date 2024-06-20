using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipComponent
{
    public interface Component    //se poser quelques questoins existanciel sur sa présence si elle a une utilité
    {

        public abstract string ToString();
        //public static abstract Component Of();
    }
}
