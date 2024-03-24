namespace APBD_2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        private bool IsHazardous { get; }
        
        public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, bool isHazardous) : 
            base(GenerateSerialNumber("L"), cargoMass, height, tareWeight, depth, maxPayload)
        {
            IsHazardous = isHazardous;
        }

        public override void LoadCargo(double mass)
        {
            if(mass>MaxPayload * 0.9)
                throw new OverfillException("TOO MUCH LIQUID!!!");

            if (IsHazardous && mass > MaxPayload * 0.5)
                NotifyHazard("Hazardous liquid, approaching splash zone, proceed with caution.");
            
            CargoMass = mass;
        }

        public override void EmptyCargo()
        {
            CargoMass = 0;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine(SerialNumber + ": " + message);
        }

        public override string ToString()
        {
            return base.ToString() + $" Hazardous: {IsHazardous}";
        }
    }
}