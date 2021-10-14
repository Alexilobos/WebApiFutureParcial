using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFuture.Data;
using WebApiFuture.Models;

namespace WebApiFuture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuturesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuturesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Futures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Future>>> GetFuture()
        {
            return await _context.Future.ToListAsync();
        }

        // GET: api/Futures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Future>> GetFuture(string id)
        {
            var future = await _context.Future.FindAsync(id);

            if (future == null)
            {
                return NotFound();
            }

            return future;
        }

        // PUT: api/Futures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuture(string id, Future future)
        {
            if (id != future.FuturoId)
            {
                return BadRequest();
            }

            _context.Entry(future).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FutureExists(id))
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

        // POST: api/Futures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Future>> PostFuture(Future future)
        {
            _context.Future.Add(future);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FutureExists(future.FuturoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuture", new { id = future.FuturoId }, future);
        }

        // DELETE: api/Futures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuture(string id)
        {
            var future = await _context.Future.FindAsync(id);
            if (future == null)
            {
                return NotFound();
            }

            _context.Future.Remove(future);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FutureExists(string id)
        {
            return _context.Future.Any(e => e.FuturoId == id);
        }
    }
}
