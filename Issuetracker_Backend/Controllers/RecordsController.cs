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
    public class RecordsController : ControllerBase
    {
        private readonly DataContext _context;

        public RecordsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordData>>> GetRecords()
        {
            return await _context.Records.ToListAsync();
        }

        // GET: api/Records/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecordData>> GetRecordData(string id)
        {
            var recordData = await _context.Records.FindAsync(id);

            if (recordData == null)
            {
                return NotFound();
            }

            return recordData;
        }

        // PUT: api/Records/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordData(string id, RecordData recordData)
        {
            if (id != recordData.Id)
            {
                return BadRequest();
            }

            _context.Entry(recordData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordDataExists(id))
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

        // POST: api/Records
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecordData>> PostRecordData(RecordData recordData)
        {
            _context.Records.Add(recordData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecordDataExists(recordData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecordData", new { id = recordData.Id }, recordData);
        }

        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecordData(string id)
        {
            var recordData = await _context.Records.FindAsync(id);
            if (recordData == null)
            {
                return NotFound();
            }

            _context.Records.Remove(recordData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordDataExists(string id)
        {
            return _context.Records.Any(e => e.Id == id);
        }
    }
}
