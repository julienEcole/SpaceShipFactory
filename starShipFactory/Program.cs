// See https://aka.ms/new-console-template for more information

using starShipFactory.CLI;
using starShipFactory.OrderManagement;
using starShipFactory.ship.shipComponent;
using starShipFactory.ship.shipComponent.specificalComponent;

namespace starShipFactory // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize CLI client
            Client monCLI = new Client();
            monCLI.Run();

            // Example of creating components using ComponentFactory
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

            // Initialize OrderManager and manage interactions
            var orderManager = new OrderManager();
            // Update stock with correct component instances
            orderManager.UpdateStock(ComponentFactory.CreateComponent("engine", "Engine_EE1"), 10);
            orderManager.UpdateStock(ComponentFactory.CreateComponent("hull", "Hull_HC1"), 5);
            orderManager.UpdateStock(ComponentFactory.CreateComponent("thrusters", "Thrusters_TE1"), 20);
            orderManager.UpdateStock(ComponentFactory.CreateComponent("wings", "Wings_WE1"), 15);

            // Add an order and manage orders
            // orderManager.AddOrder("ORDER1");
            // orderManager.VerifyOrder("ORDER1");  // Assuming a verification method exists
            orderManager.SendOrder("Starship_A1");
            orderManager.ListOrders();
        }
    }
}
