// See https://aka.ms/new-console-template for more information

using APBD_2;

Console.WriteLine("Hello, World!");

LiquidContainer lc = new LiquidContainer(0, 100, 100, 50, 1000, true);
GasContainer gc = new GasContainer(0, 100, 100, 50, 1000);
RefrigeratedContainer rc = new RefrigeratedContainer(0, 100, 100, 50, 1000, "Bananas", 15);



lc.LoadCargo(600);
try
{
    gc.LoadCargo(1000000000);
}
catch (Exception e)
{
    Console.WriteLine("Everythin's fine, there's nothin' of interest 'ere");
}
rc.Temperature = 15;


