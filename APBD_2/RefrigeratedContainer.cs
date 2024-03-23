namespace APBD_2

{
    public class RefrigeratedContainer : Container
    {
        private static Dictionary<string, double> _temperatureTable = new Dictionary<string, double>();
        private string _productType;
        private double _temperature;
        
        public RefrigeratedContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, string productType, double temperature) : 
            base(GenerateSerialNumber("R"), cargoMass, height, tareWeight, depth, maxPayload)
        {
            
            Temperature = temperature;
            ProductType = productType;
            
            
        }
        
        static RefrigeratedContainer()
        {
            _temperatureTable["Bananas"] = 13.3;
            _temperatureTable["Chocolate"] = 18;
            _temperatureTable["Fish"] = 2;
            _temperatureTable["Meat"] = -15;
            _temperatureTable["Ice cream"] = -18;
            _temperatureTable["Frozen pizza"] = -30;
            _temperatureTable["Cheese"] = 7.2;
            _temperatureTable["Sausages"] = 5;
            _temperatureTable["Butter"] = 20.5;
            _temperatureTable["Eggs"] = 19;
        }

        public string ProductType
        {
            get { return _productType;}
            set
            {
                if (_temperature == null)
                {
                    _productType = value;
                    return;
                }
                
                if (value != _productType && CargoMass != 0)
                {
                    Console.WriteLine("You can't haul products of multiple types.");
                    return;
                } 
                if (_temperatureTable[value] > _temperature)
                {
                    Console.WriteLine($"The container is too cold for {value}");
                    return;
                }
                _productType = value;
                
            }
        }

        public double Temperature
        {
            get { return _temperature; }
            set
            {
                if (_productType == null)
                {
                    _temperature = value;
                    return;
                }
                if (value < _temperatureTable[_productType])
                {
                    Console.WriteLine($"You can't set this temperature for {_productType}");
                    return;
                }

                _temperature = value;
            }
        }


        public override void EmptyCargo()
        {
            CargoMass = 0;
        }

        public override void LoadCargo(double mass)
        {
            if(mass > MaxPayload)
            {
                throw new OverfillException("TOO MUCH CARGO");
            }
            
            CargoMass = mass;
        }
    }
}