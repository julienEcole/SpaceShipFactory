using starShipFactory.ship.shipComponent;

namespace starShipFactory.OrderManagement
{
    public enum OrderStatus
    {
        Pending,
        Completed,
        Sent
    }

    public class Order
    {
        public string OrderId { get; }
    public Dictionary<Component, int> Components { get; }
    public OrderStatus Status { get; private set; }
    public string ShipType { get; set; }  // Nouveau: Type de vaisseau pour cette commande

    public Order(string orderId, string shipType)
    {
        OrderId = orderId;
        ShipType = shipType;
        Components = new Dictionary<Component, int>();
        Status = OrderStatus.Pending;
    }

        public void AddComponent(Component component, int quantity)
        {
            if (Components.ContainsKey(component))
            {
                Components[component] += quantity;
            }
            else
            {
                Components[component] = quantity;
            }
        }

        public void Complete()
        {
            Status = OrderStatus.Completed;
        }

        public void Send()
        {
            Status = OrderStatus.Sent;
        }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, Status: {Status}, Components: {string.Join(", ", Components.Select(kvp => kvp.Key.ToString() + ": " + kvp.Value))}";
        }
    }
}
