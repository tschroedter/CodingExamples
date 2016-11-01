namespace IAsset.MicroServices.FlightsAssignedToGates.Interfaces.Nancy
{
    public interface IFlightsAssignedToGates
    {
        int GateId { get; set; }
        int[] FlightIds { get; set; }
    }
}