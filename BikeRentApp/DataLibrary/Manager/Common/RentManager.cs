using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Manager.Common
{
    public class RentManager : BaseManager<Rent>
    {
        public RentManager(bool ProxyCreationEnabled = true) : base(ProxyCreationEnabled: ProxyCreationEnabled)
        {
        }



        public Rent GetCosts(Rent model)
        {
            try
            {
                decimal price = 0;
                decimal partialCost = 0;
                decimal discount = 0;
                decimal finalCost = 0;
                int totalRents = 0;

                foreach(var rent in model.RentDetails)
                {
                    price = dbContext.Rates.Where(x => x.Id == rent.IdRate).FirstOrDefault().Price;
                    partialCost += rent.amountTerm * price * rent.totalRents;
                    totalRents += rent.totalRents;
                }


                if(totalRents >= 3 && totalRents <= 5)
                {
                    discount = (partialCost * (decimal)0.3);
                    finalCost = partialCost - discount;
                }
                else
                {
                    finalCost = partialCost;
                }

                model.PartialCost = partialCost;
                model.FinalCost = finalCost;
                model.Discount = discount;

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Rent GetById(int id)
        {
            var model = new Rent();
            model = dbContext.Rent.Where(x => x.Id == id).FirstOrDefault();
            return model;
        }
    }
}
