namespace APBD_2

{
    public class RefrigeratedContainer : Container
    {
        private static Dictionary<string, double> _temperatureTable = new Dictionary<string, double>();
        private string _productType;
        private double _temperature;

        public RefrigeratedContainer(double cargoMass, double height, double tareWeight, double depth,
            double maxPayload, string productType, double temperature) : base(GenerateSerialNumber("R"), cargoMass,
            height, tareWeight, depth, maxPayload)
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
            get => _productType;
            set
            {
                if (_productType != null && value != _productType)
                {
                    throw new InvalidOperationException("You can't haul products of multiple types.");
                }

                if (_temperatureTable.ContainsKey(value))
                {
                    if (_temperature < _temperatureTable[value])
                    {
                        throw new InvalidOperationException($"The container is too cold for {value}");
                    }

                    _productType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid product type.");
                }
            }
        }

        public double Temperature
        {
            get => _temperature;
            set
            {
                if (_productType == null)
                {
                    _temperature = value;
                }
                else if (value < _temperatureTable[_productType])
                {
                    throw new InvalidOperationException($"You can't set this temperature for {_productType}");
                }
                else
                {
                    _temperature = value;
                }
            }
        }

        public override void EmptyCargo()
        {
            CargoMass = 0;
        }

        public override void LoadCargo(double mass)
        {
            if (mass > MaxPayload)
            {
                throw new OverfillException("Too much cargo!");
            }

            CargoMass = mass;
        }

        public static void AvailableProductTypes()
        {
            foreach (KeyValuePair<string, double> product in _temperatureTable)
            {
                Console.WriteLine($"Product: {product.Key}, Temperature needed for transportation: {product.Value}");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Product: {ProductType}, Temperature: {Temperature}C";
        }
    }
}