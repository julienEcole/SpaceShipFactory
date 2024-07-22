using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starShipFactory.ship.shipComponent
{
    public interface Component    //se poser quelques questoins existanciel sur sa présence si elle a une utilité
    {
    string GetName(); // Retourne le nom du composant.
    string GetDescription(); // Utilise ShipComponentDescription pour retourner une description.
    }
}
