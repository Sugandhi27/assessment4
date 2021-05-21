using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDetailsController : ControllerBase
    {
        private readonly WeatherContext _context;

        public WeatherDetailsController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/WeatherDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherDetail>>> GetWeatherDetails()
        {
            return await _context.WeatherDetails.ToListAsync();
        }

        // GET: api/WeatherDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherDetail>> GetWeatherDetail(string id)
        {
            var weatherDetail = await _context.WeatherDetails.FindAsync(id);

            if (weatherDetail == null)
            {
                return NotFound();
            }

            return weatherDetail;
        }

        // PUT: api/WeatherDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherDetail(string id, WeatherDetail weatherDetail)
        {
            if (id != weatherDetail.City)
            {
                return BadRequest();
            }

            _context.Entry(weatherDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherDetailExists(id))
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

        // POST: api/WeatherDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherDetail>> PostWeatherDetail(WeatherDetail weatherDetail)
        {
            _context.WeatherDetails.Add(weatherDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WeatherDetailExists(weatherDetail.City))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWeatherDetail", new { id = weatherDetail.City }, weatherDetail);
        }

        // DELETE: api/WeatherDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherDetail(string id)
        {
            var weatherDetail = await _context.WeatherDetails.FindAsync(id);
            if (weatherDetail == null)
            {
                return NotFound();
            }

            _context.WeatherDetails.Remove(weatherDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherDetailExists(string id)
        {
            return _context.WeatherDetails.Any(e => e.City == id);
        }
    }
}
