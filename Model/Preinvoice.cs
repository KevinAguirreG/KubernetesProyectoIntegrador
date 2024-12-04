using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsip_Rentas.Model
{
    public class Preinvoice
    {
        public int Id { get; set; }
        public int RentalContractId { get; set; }
        public DateTime ChargeDate { get; set; }
        public int AssetsAmount { get; set; }
        public decimal Total { get; set; }
    }
}
