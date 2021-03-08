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
    public class LabelsController : ControllerBase
    {
        private readonly DataContext _context;

        public LabelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Labels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabelData>>> GetLabels()
        {
            return await _context.Labels.ToListAsync();
        }

        // GET: api/Labels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LabelData>> GetLabelData(string id)
        {
            var labelData = await _context.Labels.FindAsync(id);

            if (labelData == null)
            {
                return NotFound();
            }

            return labelData;
        }

        // PUT: api/Labels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabelData(string id, LabelData labelData)
        {
            if (id != labelData.Id)
            {
                return BadRequest();
            }

            _context.Entry(labelData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabelDataExists(id))
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

        // POST: api/Labels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LabelData>> PostLabelData(LabelData labelData)
        {
            _context.Labels.Add(labelData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LabelDataExists(labelData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLabelData", new { id = labelData.Id }, labelData);
        }

        // DELETE: api/Labels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabelData(string id)
        {
            var labelData = await _context.Labels.FindAsync(id);
            if (labelData == null)
            {
                return NotFound();
            }

            _context.Labels.Remove(labelData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LabelDataExists(string id)
        {
            return _context.Labels.Any(e => e.Id == id);
        }
    }
}
