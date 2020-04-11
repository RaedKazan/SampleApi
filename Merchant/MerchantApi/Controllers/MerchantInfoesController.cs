using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MerchantData.Data;
using MerchantData.Models;

namespace MerchantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantInfoesController : ControllerBase
    {
        private readonly MerchantApiContext _context;

        public MerchantInfoesController(MerchantApiContext context)
        {
            _context = context;
        }

        // GET: api/MerchantInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MerchantInfo>>> GetMerchantInfos()
        {
            return await _context.MerchantInfos.ToListAsync();
        }

        // GET: api/MerchantInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MerchantInfo>> GetMerchantInfo(int id)
        {
            var merchantInfo = await _context.MerchantInfos.FindAsync(id);

            if (merchantInfo == null)
            {
                return NotFound();
            }

            return merchantInfo;
        }

        // PUT: api/MerchantInfoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerchantInfo(int id, MerchantInfo merchantInfo)
        {
            if (id != merchantInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(merchantInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchantInfoExists(id))
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

        // POST: api/MerchantInfoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MerchantInfo>> PostMerchantInfo(MerchantInfo merchantInfo)
        {
            _context.MerchantInfos.Add(merchantInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMerchantInfo", new { id = merchantInfo.Id }, merchantInfo);
        }

        // DELETE: api/MerchantInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MerchantInfo>> DeleteMerchantInfo(int id)
        {
            var merchantInfo = await _context.MerchantInfos.FindAsync(id);
            if (merchantInfo == null)
            {
                return NotFound();
            }

            _context.MerchantInfos.Remove(merchantInfo);
            await _context.SaveChangesAsync();

            return merchantInfo;
        }

        private bool MerchantInfoExists(int id)
        {
            return _context.MerchantInfos.Any(e => e.Id == id);
        }
    }
}
