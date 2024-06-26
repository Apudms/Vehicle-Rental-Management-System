using Microsoft.EntityFrameworkCore;
using WebVRMS.Contracts;
using WebVRMS.Models;

namespace WebVRMS.Services
{
    public class InvoiceService : IInvoice
    {
        private readonly VehicleRentalDbContext _context;

        public InvoiceService(VehicleRentalDbContext context)
        {
            _context = context;
        }

        public Invoice Add(Invoice entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetAll()
        {
            var results = _context.Invoices.ToList();
            return results;
        }

        public Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Invoice GetById(string id)
        {
            var result = _context.Invoices
                            .Where(i => i.InvoiceId == id)
                            .FirstOrDefault();

            if (result == null)
            {
                throw new ArgumentException($"Invoice with ID: {id} not found");
            }
            return result;
        }

        public Invoice Update(Invoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
