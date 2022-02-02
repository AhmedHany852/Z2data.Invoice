using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z2data.Invoice.Core.Entity;
using Z2data.Invoice.Core.Interfaces;
using Z2data.Invoice.Core.Repository;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Z2data.Invoice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDetailsController : ControllerBase
    {
        private IConfiguration _config;
        private ItemDetailsInterface _db;

        public ItemDetailsController(IConfiguration config)
        {
            _config = config;
            _db = new ItemDetailsRepo(_config);
        }
        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_db.GetItemDetails());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                return BadRequest(ex);
            }
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {

                return Ok(_db.GetItemDetailsByID(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }

        // POST api/<ItemsController>
        [HttpPost]
        public ActionResult Post([FromBody] ItemDetails itemDetails)
        {
            try
            {

                return Ok(_db.AddItemDetails(itemDetails));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut]
        public ActionResult Put([FromBody] ItemDetails itemDetails)
        {
            try
            {

                return Ok(_db.UpdateItemDetails(itemDetails));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {

                return Ok(_db.DeleteItemDetails(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}

