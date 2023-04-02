namespace SkylineVVehicleTuning.Classes
{
    public class VehicleModel
    {
        public string VehicleName { get; set; }

        public string VehicleKit { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="vehicleName"></param>
        /// <param name="vehicleKit"></param>
        public VehicleModel(string vehicleName, string vehicleKit)
        {
            VehicleName = vehicleName;
            VehicleKit = vehicleKit;
        }
    }
}