// See https://aka.ms/new-console-template for more information

using APBD_2;

Console.WriteLine("Hello, World!");

ContainerShip ship = new ContainerShip(30, 100, 20000);

ContainerShipController containerShipController = new ContainerShipController(ship);
containerShipController.MainMenu();
