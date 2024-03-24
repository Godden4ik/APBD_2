namespace APBD_2;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload) 
        : base(GenerateSerialNumber("G"), cargoMass, height, tareWeight, depth, maxPayload)
    {
    }

    public override void LoadCargo(double mass)
    {
        NotifyHazard("Pressurised gas, proceed with caution.");
        
        if (mass > 0.9 * MaxPayload)
        {
            
            throw new OverfillException("Too much gas!");
        }

        CargoMass = mass;
    }

    public override void EmptyCargo()
    {
        CargoMass = 0.05 * CargoMass;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine(SerialNumber + ": " + message);
        
    }
}