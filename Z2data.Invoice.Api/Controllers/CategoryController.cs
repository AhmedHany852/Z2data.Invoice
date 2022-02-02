using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using ServiceStack.Text;
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
    public class CategoryController : ControllerBase
    {
        private IConfiguration _config;
        private CategoryInterfaces   _db;
        public CategoryController(IConfiguration Config)
        {
            _config = Config;
            _db = new CategoryRepo(_config);

        }
        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_db.GetCategory());
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

                return Ok(_db.GetCategoryById(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }

        // POST api/<ItemsController>
        [HttpPost]
        public ActionResult Post([FromBody] Category category)
        {
            try
            {

                return Ok(_db.AddCategory(category));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Category category)

        {
            try
            {

                return Ok(_db.UpdateCategory(category));
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

                return Ok(_db.DeleteCategory(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
