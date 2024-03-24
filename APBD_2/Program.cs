// See https://aka.ms/new-console-template for more information

using APBD_2;

Console.WriteLine("Hello, World!");

LiquidContainer lc = new LiquidContainer(0, 100, 100, 50, 1000, true);
GasContainer gc = new GasContainer(0, 100, 100, 50, 1000);
RefrigeratedContainer rc = new RefrigeratedContainer(0, 100, 100, 50, 1000, "Bananas", 15);



lc.LoadCargo(600);
gc.LoadCargo(500);
rc.Temperature = 15;

ContainerShip ship = new ContainerShip(30, 100, 20000);

ship.AddContainer(lc);
ship.AddContainer(gc);
ship.AddContainer(rc);

ship.LoadContainerCargo("KON-L-1", 900);

Console.WriteLine(rc);

ContainerShipController containerShipController = new ContainerShipController();
containerShipController.ShipMenu();
