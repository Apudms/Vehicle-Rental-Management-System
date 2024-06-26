using Microsoft.EntityFrameworkCore;
using WebVRMS.Contracts;
using WebVRMS.Models;

namespace WebVRMS.Services
{
    public class PaymentsService : IPayment
    {
        private readonly VehicleRentalDbContext _context;

        public PaymentsService(VehicleRentalDbContext context) 
        {
            _context = context;
        }

        public Payment Add(Payment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payment> GetAll()
        {
            var results = _context.Payments.ToList();
            return results;
        }

        public Payment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Payment GetById(string id)
        {
            var result = _context.Payments
                            .Where(i => i.PaymentId == id)
                            .FirstOrDefault();

            if (result == null)
            {
                throw new ArgumentException($"Payment with ID: {id} not found");
            }
            return result;
        }

        public Payment Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
