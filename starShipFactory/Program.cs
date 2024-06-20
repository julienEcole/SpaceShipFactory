// See https://aka.ms/new-console-template for more information

using starShipFactory.CLI;
using starShipFactory.ship.shipComponent;

namespace starShipFactory // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client monCLI = new Client();
            monCLI.Run();
        }
    }
}
