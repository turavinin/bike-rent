using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public partial class Rates
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public decimal Price { get; set; }
    }
}
