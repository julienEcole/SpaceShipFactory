using starShipFactory.cache;
using starShipFactory.ship.shipComponent;
using starShipFactory.ship.shipComponent.specificalComponent;
using starShipFactory.ship.shipType;
using System;
using System.Collections.Generic;

namespace starShipFactory.ship
{
    public static class ShipFactory
    {
        public static Ship CreateShip(string shipType, string name)
        {
            Dictionary<Component, int> requiredComponents;
            Ship ship = null;

            switch (shipType.ToLower())
            {
                case "cargo":

                    ship = new Cargo(name, new[] {Hull.Of(HullType.Hull_HC1)}, Engine.Of(EngineType.Engine_EC1), Wings.Of(WingsType.Wings_WC1), Thrusters.Of(ThrusterType.Thrusters_TC1));
                    break;
                case "explorer":
                    ship = new Explorer(name, Hull.Of(HullType.Hull_HE1), Engine.Of(EngineType.Engine_EE1), Wings.Of(WingsType.Wings_WE1), Thrusters.Of(ThrusterType.Thrusters_TE1));
                    break;
                case "speeder":
                    ship = new Speeder(name, Engine.Of(EngineType.Engine_ES1), Wings.Of(WingsType.Wings_WS1), Thrusters.Of(ThrusterType.Thrusters_TS1), Thrusters.Of(ThrusterType.Thrusters_TS1));
                    break;
                default:
                    throw new ArgumentException($"Type de vaisseau inconnu : {shipType}");
            }

            requiredComponents = ship.GetRequiredComponents();

            if (Atelier.AreComponentsAvailable(requiredComponents))
            {
                Atelier.ConsumeComponents(requiredComponents);
                return ship;
            }
            else
            {
                throw new InvalidOperationException("Pas assez de composants disponibles pour créer le vaisseau.");
            }
        }
    }
}
