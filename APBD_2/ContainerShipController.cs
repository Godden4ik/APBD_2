using System;

namespace APBD_2
{
    public class ContainerShipController
    {
        private ContainerShip _ship;

        public ContainerShipController(ContainerShip ship)
        {
            _ship = ship;
        }

        public void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add Container");
                Console.WriteLine("2. Load Container Cargo");
                Console.WriteLine("3. Empty Container Cargo");
                Console.WriteLine("4. Replace Container");
                Console.WriteLine("5. Remove Container");
                Console.WriteLine("6. Display available containers");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice:");
                
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            _ship.AddContainer(CreateContainer());
                            break;
                        case 2:
                            LoadContainerCargo();
                            break;
                        case 3:
                            EmptyContainerCargo();
                            break;
                        case 4:
                            ReplaceContainer();
                            break;
                        case 5:
                            RemoveContainer();
                            break;
                        case 6:
                            _ship.DisplayAllContainers();
                            break;
                        case 7:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private Container CreateContainer()
        {
            int containerType;
            double cargoMass, tareWeight, height, depth, maxPayload, temperature;
            string productType;
            bool isHazardous;

            while (true)
            {
                Console.WriteLine("Choose container type:");
                Console.WriteLine("1. Gas Container");
                Console.WriteLine("2. Liquid Container");
                Console.WriteLine("3. Refrigerated Container");
                Console.WriteLine("Enter your choice:");

                if (!int.TryParse(Console.ReadLine(), out containerType) || containerType < 1 || containerType > 3)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    continue;
                }

                Console.WriteLine("Enter cargo mass:");
                if (!double.TryParse(Console.ReadLine(), out cargoMass))
                {
                    Console.WriteLine("Invalid cargo mass. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("Enter tare weight:");
                if (!double.TryParse(Console.ReadLine(), out tareWeight))
                {
                    Console.WriteLine("Invalid tare weight. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("Enter height:");
                if (!double.TryParse(Console.ReadLine(), out height))
                {
                    Console.WriteLine("Invalid height. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("Enter depth:");
                if (!double.TryParse(Console.ReadLine(), out depth))
                {
                    Console.WriteLine("Invalid depth. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("Enter max payload:");
                if (!double.TryParse(Console.ReadLine(), out maxPayload))
                {
                    Console.WriteLine("Invalid max payload. Please enter a valid number.");
                    continue;
                }

                switch (containerType)
                {
                    case 1: // Gas Container
                        return new GasContainer(cargoMass, height, tareWeight, depth, maxPayload);
                    case 2: // Liquid Container
                        Console.WriteLine("Is the liquid hazardous? (true/false):");
                        if (!bool.TryParse(Console.ReadLine(), out isHazardous))
                        {
                            Console.WriteLine("Invalid input. Please enter true or false.");
                            continue;
                        }

                        return new LiquidContainer(cargoMass, height, tareWeight, depth, maxPayload, isHazardous);
                    case 3: // Refrigerated Container
                        RefrigeratedContainer.AvailableProductTypes();
                        Console.WriteLine("Enter product type:");
                        productType = Console.ReadLine();
                        Console.WriteLine("Enter temperature:");
                        if (!double.TryParse(Console.ReadLine(), out temperature))
                        {
                            Console.WriteLine("Invalid temperature. Please enter a valid number.");
                            continue;
                        }

                        return new RefrigeratedContainer(cargoMass, height, tareWeight, depth, maxPayload, productType,
                            temperature);
                    default:
                        Console.WriteLine("Invalid container type.");
                        continue;
                }
            }
        }

        private void LoadContainerCargo()
        {
            Console.WriteLine("Enter container serial number:");
            string serialNumber = Console.ReadLine();
            Console.WriteLine("Enter cargo mass:");
            double cargoMass;
            if (!double.TryParse(Console.ReadLine(), out cargoMass))
            {
                Console.WriteLine("Invalid cargo mass. Please enter a valid number.");
                return;
            }

            _ship.LoadContainerCargo(serialNumber, cargoMass);
        }

        private void EmptyContainerCargo()
        {
            Console.WriteLine("Enter container serial number:");
            string serialNumber = Console.ReadLine();

            _ship.EmptyContainerCargo(serialNumber);
        }

        private void ReplaceContainer()
        {
            Console.WriteLine("Enter container serial number to replace:");
            string oldSerialNumber = Console.ReadLine();
            _ship.ReplaceContainer(oldSerialNumber, CreateContainer());
        }
        
        private void RemoveContainer()
        {
            Console.WriteLine("Enter container serial number to remove:");
            string serialNumber = Console.ReadLine();

            _ship.RemoveContainer(serialNumber);
        }
    }
}