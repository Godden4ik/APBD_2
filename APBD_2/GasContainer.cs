namespace APBD_2;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload) 
        : base(GenerateSerialNumber("G"), cargoMass, height, tareWeight, depth, maxPayload)
    {
    }

    public override void LoadCargo(double mass)
    {
        if (mass > 0.9 * MaxPayload)
        {
            NotifyHazard("OH LAWD");
            throw new OverfillException("THE GAS,  IT'S TOO MUCH!!!");
        }

        CargoMass = mass;
    }

    public override void EmptyCargo()
    {
        CargoMass = 0.05 * CargoMass;
    }

    public void NotifyHazard(string message)
    {
        Console.Write(SerialNumber + ": ");
        
    }
}