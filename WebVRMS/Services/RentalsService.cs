﻿using Microsoft.EntityFrameworkCore;
using WebVRMS.Contracts;
using WebVRMS.Models;

namespace WebVRMS.Services
{
    public class RentalsService : IRental
    {
        private readonly VehicleRentalDbContext _context;

        public RentalsService(VehicleRentalDbContext context)
        {
            _context = context;
        }

        public Rental Add(Rental entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetAll()
        {
            var results = _context.Rentals.ToList();
            return results;
        }

        public Rental GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Rental GetById(string id)
        {
            var result = _context.Rentals
                            .Include(r => r.User)  
                            .Include(r => r.Vehicle) 
                            .FirstOrDefault(r => r.RentalId == id);

            if (result == null)
            {
                throw new ArgumentException($"Rental with ID: {id} not found");
            }
            return result;
        }

        public Rental Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}