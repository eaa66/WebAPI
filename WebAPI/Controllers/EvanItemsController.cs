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
    public class EvanItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EvanItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/EvanItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvanItem>>> GetEvanItems()
        {
            return await _context.EvanItems.ToListAsync();
        }

        // GET: api/EvanItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvanItem>> GetEvanItem(long id)
        {
            var evanItem = await _context.EvanItems.FindAsync(id);

            if (evanItem == null)
            {
                return NotFound();
            }

            return evanItem;
        }

        // PUT: api/EvanItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvanItem(long id, EvanItem evanItem)
        {
            if (id != evanItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(evanItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvanItemExists(id))
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

        // POST: api/EvanItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EvanItem>> PostEvanItem(EvanItem evanItem)
        {
            _context.EvanItems.Add(evanItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvanItem", new { id = evanItem.Id }, evanItem);
        }

        // DELETE: api/EvanItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EvanItem>> DeleteEvanItem(long id)
        {
            var evanItem = await _context.EvanItems.FindAsync(id);
            if (evanItem == null)
            {
                return NotFound();
            }

            _context.EvanItems.Remove(evanItem);
            await _context.SaveChangesAsync();

            return evanItem;
        }

        private bool EvanItemExists(long id)
        {
            return _context.EvanItems.Any(e => e.Id == id);
        }
    }
}
