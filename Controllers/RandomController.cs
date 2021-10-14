using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFuture.Data;
using WebApiFuture.Models;

namespace WebApiFuture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RandomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Future>> GetFuture()
        {

            var list = await _context.Future.ToListAsync();

            var max = list.Count;
            int index = new Random().Next(0, max);

            var Future = list[index];

            if (Future == null)
            {
                return NoContent();
            }

            return Future;
        }

    }
}
