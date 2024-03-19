using APBD_2;

namespace Task2
{
    public class RefrigeratedContainer : Container
    {
        public RefrigeratedContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, string productType, double temperature) : 
            base(GenerateSerialNumber("R"), cargoMass, height, tareWeight, depth, maxPayload)
        {
            ProductType = productType;
            Temperature = temperature;
        }

        public string ProductType { get; set; }
        public double Temperature { get; set; }

        public override void EmptyCargo()
        {
            CargoMass=0;
        }

        public override void LoadCargo(double mass)
        {
            if(mass>MaxPayload)
            {
                throw new OverfillException("TOO MUCH CARGO");
            }
            CargoMass = mass;
        }
    }
}