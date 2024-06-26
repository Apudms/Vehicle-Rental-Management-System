using WebVRMS.Models;

namespace WebVRMS.Contracts
{
    public interface IVehicle :ICrud<Vehicle>
    {
        IEnumerable<Vehicle> GetAllAvailableVehicles();
    }
}
