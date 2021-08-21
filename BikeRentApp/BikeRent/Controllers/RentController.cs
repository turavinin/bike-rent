using DataLibrary.Manager.Common;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BikeRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        // GET: api/<RentController>
        [HttpGet]
        public IActionResult Get()
        {
            var manager = new RatesManager();
            var model = manager.GetData;


            if(model != null)
                return Ok(model);
            else
                return NotFound(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Rent rent)
        {
            var mg = new RentManager();
            rent = mg.GetCosts(rent);
            if (rent.FinalCost != 0)
            {
                mg.Save(rent);
                return Ok(rent);
            }
            return NotFound(rent);
        }
    }
}
