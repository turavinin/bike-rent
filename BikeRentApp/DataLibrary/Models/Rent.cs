using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public partial class Rent
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public decimal PartialCost { get; set; }
        public decimal? Discount { get; set; }
        public decimal FinalCost { get; set; }
        public virtual List<RentDetail> RentDetails { get; set; } = new List<RentDetail>();

    }
}
