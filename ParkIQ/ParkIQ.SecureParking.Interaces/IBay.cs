using ParkIQ.SecureParking.Interaces.Vehicles;

namespace ParkIQ.SecureParking.Interaces
{
    public interface IBay
    {
        bool IsEmpty { get; }
        IVehicle Vehicle { get; set; }
        int Id { get; }
    }
}