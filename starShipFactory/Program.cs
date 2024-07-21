// See https://aka.ms/new-console-template for more information

using starShipFactory.CLI;
using starShipFactory.ship.shipComponent;
using starShipFactory.ship.shipComponent.specificalComponent;

namespace starShipFactory // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialisation du client CLI
            Client monCLI = new Client();
            monCLI.Run();

            // Exemple de création de composants via ComponentFactory
            try
            {
                Component engine = ComponentFactory.CreateComponent("engine", "Engine_EE1");
                Component hull = ComponentFactory.CreateComponent("hull", "Hull_HC1");
                Component thrusters = ComponentFactory.CreateComponent("thrusters", "Thrusters_TE1");
                Component wings = ComponentFactory.CreateComponent("wings", "Wings_WE1");

                Console.WriteLine(engine.ToString());
                Console.WriteLine(hull.ToString());
                Console.WriteLine(thrusters.ToString());
                Console.WriteLine(wings.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Initialisation de OrderManager
            var orderManager = new OrderManagement.OrderManager();
            orderManager.AddOrder("ORDER1");
            orderManager.SendOrder("Starship_A1");
            orderManager.ListOrders();
            orderManager.UpdateStock("Starship_A1", 5);
            orderManager.SendOrder("Starship_A1");
            orderManager.ListOrders();
        }
    }
}
