using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsip_Rentas.Model
{
    public class RentalContract
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RentalStatusId { get; set; }
        public int NumberRentalPeriod { get; set; }
        public int RentalPeriodId { get; set; }

    }
}
