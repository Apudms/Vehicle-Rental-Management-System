using WebVRMS.Models;

namespace WebVRMS.ViewModels
{
    public class VehicleRentalViewModel
    {
        public string VehicleId { get; set; } = null;
        public string? Year { get; set; }
        public decimal RentalPrice { get; set; }
        public int UserId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
