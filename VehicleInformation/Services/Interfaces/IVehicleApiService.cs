using VehicleInformation.Models.Domain;

namespace VehicleInformation.Services.Interfaces
{
    public interface IVehicleApiService
    {
        Task<IEnumerable<CarMake>> GetAllMakesAsync();
        Task<IEnumerable<VehicleType>> GetVehicleTypesForMakeAsync(int makeId);
        Task<IEnumerable<CarModel>> GetModelsAsync(int makeId, int year);
    }
}
