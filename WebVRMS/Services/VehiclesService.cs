using Microsoft.EntityFrameworkCore;
using WebVRMS.Contracts;
using WebVRMS.Models;

namespace WebVRMS.Services
{
    public class VehiclesService : IVehicle
    {
        private readonly VehicleRentalDbContext _vehicleRentalDbContext;
        public VehiclesService(VehicleRentalDbContext dbContext)
        {
            _vehicleRentalDbContext = dbContext;
        }

        public Vehicle Add(Vehicle entity)
        {
            try
            {
                _vehicleRentalDbContext.Vehicles.Add(entity);
                _vehicleRentalDbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            try
            {
                var deleteCategory = GetById(id);
                if (deleteCategory != null)
                {
                    _vehicleRentalDbContext.Vehicles.Remove(deleteCategory);
                    _vehicleRentalDbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Category not found");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<Vehicle> GetAll()
        {
            var results = _vehicleRentalDbContext.Vehicles;
            return results.ToList();
        }

        public Vehicle GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(string id)
        {
            var result = _vehicleRentalDbContext.Vehicles.Where(c => c.VehicleId == id).FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentException("Vehicle not found");
            }
            return result;
        }

        public Vehicle Update(Vehicle entity)
        {
            try
            {
                var updateVehicle = GetById(entity.VehicleId);
                if (updateVehicle != null)
                {
                    updateVehicle.Make = entity.Make;
                    updateVehicle.Model = entity.Model;
                    updateVehicle.Year = entity.Year;
                    updateVehicle.RentalPrice = entity.RentalPrice;
                    updateVehicle.AvailabilityStatus= entity.AvailabilityStatus;                    
                    _vehicleRentalDbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Vehicle not found");
                }
                return updateVehicle;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public IEnumerable<Vehicle> GetAllAvailableVehicles()
        {
            return _vehicleRentalDbContext.Vehicles.Where(v => v.AvailabilityStatus).ToList();
        }
    }
}
