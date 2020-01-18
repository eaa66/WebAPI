using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ubicomp_lab.Models;

namespace ubicomp_lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SensorDataController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SensorData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorData>>> GetsensorData()
        {
            return await _context.sensorData.ToListAsync();
        }

        // GET: api/SensorData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorData>> GetSensorData(long id)
        {
            var sensorData = await _context.sensorData.FindAsync(id);

            if (sensorData == null)
            {
                return NotFound();
            }

            return sensorData;
        }

        // PUT: api/SensorData/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorData(long id, SensorData sensorData)
        {
            if (id != sensorData.id)
            {
                return BadRequest();
            }

            _context.Entry(sensorData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SensorData
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<List<SensorData>>> PostSensorData(List<SensorData> sensorData)
        {

            _context.sensorData.AddRange(sensorData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorData", new { sensorData });
        }

 

        // DELETE: api/SensorData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SensorData>> DeleteSensorData(long id)
        {
            var sensorData = await _context.sensorData.FindAsync(id);
            if (sensorData == null)
            {
                return NotFound();
            }

            _context.sensorData.Remove(sensorData);
            await _context.SaveChangesAsync();

            return sensorData;
        }

        private bool SensorDataExists(long id)
        {
            return _context.sensorData.Any(e => e.id == id);
        }
    }
}
