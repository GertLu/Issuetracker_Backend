using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Issuetracker_Backend.Model;
using WorkoutApplication.Model;

namespace Issuetracker_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly DataContext _context;

        public StatesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/States
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateData>>> GetStates()
        {
            return await _context.States.ToListAsync();
        }

        // GET: api/States/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StateData>> GetStateData(string id)
        {
            var stateData = await _context.States.FindAsync(id);

            if (stateData == null)
            {
                return NotFound();
            }

            return stateData;
        }

        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStateData(string id, StateData stateData)
        {
            if (id != stateData.Id)
            {
                return BadRequest();
            }

            _context.Entry(stateData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateDataExists(id))
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

        // POST: api/States
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StateData>> PostStateData(StateData stateData)
        {
            _context.States.Add(stateData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StateDataExists(stateData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStateData", new { id = stateData.Id }, stateData);
        }

        // DELETE: api/States/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStateData(string id)
        {
            var stateData = await _context.States.FindAsync(id);
            if (stateData == null)
            {
                return NotFound();
            }

            _context.States.Remove(stateData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateDataExists(string id)
        {
            return _context.States.Any(e => e.Id == id);
        }
    }
}
