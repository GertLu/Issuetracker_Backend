using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Issuetracker_Backend.Model;

namespace Issuetracker_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly DataContext _context;

        public TablesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Tables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableData>>> GetTables()
        {
            return await _context.Tables.ToListAsync();
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableData>> GetTableData(string id)
        {
            var tableData = await _context.Tables.FindAsync(id);

            if (tableData == null)
            {
                return NotFound();
            }

            return tableData;
        }

        // PUT: api/Tables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableData(string id, TableData tableData)
        {
            if (id != tableData.Id)
            {
                return BadRequest();
            }

            _context.Entry(tableData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableDataExists(id))
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

        // POST: api/Tables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TableData>> PostTableData(TableData tableData)
        {
            _context.Tables.Add(tableData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TableDataExists(tableData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTableData", new { id = tableData.Id }, tableData);
        }

        // DELETE: api/Tables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableData(string id)
        {
            var tableData = await _context.Tables.FindAsync(id);
            if (tableData == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(tableData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableDataExists(string id)
        {
            return _context.Tables.Any(e => e.Id == id);
        }
    }
}
