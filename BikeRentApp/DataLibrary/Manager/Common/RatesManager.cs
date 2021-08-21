using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Manager.Common
{
    public class RatesManager : BaseManager<Rates>
    {

        #region Constructor
        public RatesManager(bool ProxyCreationEnabled = true) : base(ProxyCreationEnabled: ProxyCreationEnabled)
        {
        }
        #endregion


        #region Methods
        public bool SaveRate(Rates rate)
        {
            try
            {
                return Save(rate);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion


    }
}
