using Issuetracker_Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Issuetracker_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableStatesController : ControllerBase
    {
        private readonly DataContext _context;

        public TableStatesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TableStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableStateData>>> GetTableStates()
        {
            return await _context.TableStates.ToListAsync();
        }

        // GET: api/TableStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableStateData>> GetTableStateData(string id)
        {
            var tableStateData = await _context.TableStates.FindAsync(id);

            if (tableStateData == null)
            {
                return NotFound();
            }

            return tableStateData;
        }

        // PUT: api/TableStates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableStateData(string id, TableStateData tableStateData)
        {
            if (id != tableStateData.Id)
            {
                return BadRequest();
            }

            _context.Entry(tableStateData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableStateDataExists(id))
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

        // POST: api/TableStates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TableStateData>> PostTableStateData(TableStateData tableStateData)
        {
            _context.TableStates.Add(tableStateData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TableStateDataExists(tableStateData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTableStateData", new { id = tableStateData.Id }, tableStateData);
        }

        // DELETE: api/TableStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableStateData(string id)
        {
            var tableStateData = await _context.TableStates.FindAsync(id);
            if (tableStateData == null)
            {
                return NotFound();
            }

            _context.TableStates.Remove(tableStateData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableStateDataExists(string id)
        {
            return _context.TableStates.Any(e => e.Id == id);
        }
    }
}
