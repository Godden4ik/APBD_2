namespace APBD_2;
    public class ContainerShip
    {
        public ContainerShip(int maxSpeed, int maxContainerNumber, double maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainerNumber = maxContainerNumber;
            MaxWeight = maxWeight;
            ++_lastId;
            Id = _lastId;
        }

        public List<Container> Containers { get; set; } = new List<Container>();
        public int MaxSpeed { get; }
        public int MaxContainerNumber { get; }
        public double MaxWeight { get; }
        public int Id { get; set; }
        private static int _lastId = 0;

        public void AddContainer(Container container)
        {
            double currentMass = 0;
            double containerMass = container.CargoMass + container.TareWeight;
            foreach (var c in Containers)
            {
                currentMass += c.CargoMass + c.TareWeight;
            }

            double newMass = containerMass + currentMass;

            if (newMass > MaxWeight)
            {
                Console.WriteLine($"The container {container.SerialNumber} exceeds the maximum payload for this ship.");
                return;
            }

            if (Containers.Count + 1 > MaxContainerNumber)
            {
                Console.WriteLine($"The ship can't hold more than {MaxContainerNumber} containers.");
                return;
            }
            
            Containers.Add(container);
        }
    
        // Other methods - for loading cargo, removing container, etc.

        public void LoadContainerCargo(string serialNumber, double cargoMass)
        {
            Container container = FindContainerBySerialNumber(serialNumber);
            Containers.Remove(container);
            container.LoadCargo(cargoMass);
            Containers.Add(container);
        }

        public void EmptyContainerCargo(string serialNumber)
        {
            FindContainerBySerialNumber(serialNumber).EmptyCargo();
        }

        public void ReplaceContainer(string serialNumber, Container container)
        {
            Containers.Remove(FindContainerBySerialNumber(serialNumber));
            Containers.Add(container);
        }

        public Container FindContainerBySerialNumber(string serialNumber)
        {
            foreach (var con in Containers)
            {
                if (con.SerialNumber == serialNumber)
                    return con;
            }

            throw new ArgumentException("No such container exists.");
        }

        public void RemoveContainer(string serialNumber)
        {
            Containers.Remove(FindContainerBySerialNumber(serialNumber));
        }

        public void DisplayAllContainers()
        {
            foreach (var con in Containers)
            {
                Console.WriteLine(con);
            }
        }

        public override string ToString()
        {
            return $"{Id}";
        }
    }