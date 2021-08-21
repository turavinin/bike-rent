using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public partial class RentDetail
    {
        public int Id { get; set; }
        public int IdRent { get; set; }
        public int IdRate { get; set; }
        public int amountTerm { get; set; }
        public int totalRents { get; set; }
        [JsonIgnore]
        public Rent Rental { get; set; }

    }
}
