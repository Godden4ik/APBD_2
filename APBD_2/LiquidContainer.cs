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
            if (IsHazardous)
            {
                NotifyHazard("ITS GONNA EXPLODE!!!");
                if (mass > MaxPayload * 0.5)
                    throw new OverfillException("TOO MUCH HAZARDOUS LIQUID!!!");
                CargoMass = mass;
                return;
            }

            if(mass>MaxPayload * 0.9)
            {
                throw new OverfillException("TOO MUCH LIQUID");
            }
            CargoMass = mass;
            return;
        }

        public override void EmptyCargo()
        {
            throw new NotImplementedException();
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine(message);
        }
    }
}