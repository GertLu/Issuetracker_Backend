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
    public class RecordStatesController : ControllerBase
    {
        private readonly DataContext _context;

        public RecordStatesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/States
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordStateData>>> GetRecordStates()
        {
            return await _context.RecordStates.ToListAsync();
        }

        // GET: api/States/5
        [HttpGet("{recordId}/{stateId}")]
        public async Task<ActionResult<RecordStateData>> GetRecordStateData(string recordId, string stateId)
        {
            var stateData = _context.RecordStates.FirstOrDefault(x => x.RecordId == recordId && x.StateId == stateId);

            if (stateData == null)
            {
                return NotFound();
            }

            return stateData;
        }

        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{recordId}/{stateId}")]
        public async Task<IActionResult> PutRecordStateData(string recordId, string stateId, RecordStateData stateData)
        {
            if (recordId != stateData.RecordId || stateId != stateData.StateId)
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
                if (!RecordStateDataExists(recordId, stateId))
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
        public async Task<ActionResult<RecordStateData>> PostRecordStateData(RecordStateData stateData)
        {
            _context.RecordStates.Add(stateData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecordStateDataExists(stateData.RecordId, stateData.StateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecordStateData", new { recordId = stateData.RecordId, stateId = stateData.StateId }, stateData);
        }

        // DELETE: api/States/5
        [HttpDelete("{recordId}/{stateId}")]
        public async Task<IActionResult> DeleteRecordStateData(string recordId, string stateId)
        {
            var stateData = _context.RecordStates.FirstOrDefault(x => x.RecordId == recordId && x.StateId == stateId);
            if (stateData == null)
            {
                return NotFound();
            }

            _context.RecordStates.Remove(stateData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordStateDataExists(string recordId, string stateId)
        {
            return _context.RecordStates.Any(e => e.RecordId == recordId && e.StateId == stateId);
        }
    }
}
