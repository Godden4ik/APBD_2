namespace APBD_2
{
    public abstract class Container
    {
        private static int _id = 0;
        protected Container(string serialNumber, double cargoMass, double height, double tareWeight, double depth, double maxPayload)
        {
            SerialNumber = serialNumber;
            CargoMass = cargoMass;
            Height = height;
            TareWeight = tareWeight;
            Depth = depth;
            MaxPayload = maxPayload;
        }

        public string SerialNumber { get; }
        public double CargoMass { get; protected set; }
        public double Height { get; }
        public double TareWeight { get; }
        public double Depth { get; }
        public double MaxPayload { get; }

        public abstract void LoadCargo(double mass);
        public abstract void EmptyCargo();
        protected static string GenerateSerialNumber(string type) {
            //implementation of generation of unique number for each container [ids have to be unique]
            return $"KON-{type}-{++_id}";
        }

        public override string ToString()
        {
            return $"{SerialNumber}: Cargo mass: {CargoMass} kg, Tare weight: {TareWeight} kg, " +
                   $"Height: {Height} cm, Depth: {Depth} cm, Max Payload: {MaxPayload} kg, ";
        }
    }
}