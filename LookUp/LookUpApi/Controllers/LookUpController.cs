using AutoMapper;
using LookUpAbstraction.DTO.LookUp.Request;
using LookUpAbstraction.DTO.LookUp.Response;
using LookUpData.Models;
using LookUpService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LookUpApi.Controllers
{
    [Route("api/[controller]")]
    public class LookUpController : Controller
    {
        private readonly ILookUpService lookUpService;
        private readonly IMapper mapper;

        public LookUpController(ILookUpService lookUpService, IMapper mapper)
        {
            this.lookUpService = lookUpService;
            this.mapper = mapper;
        }

        [HttpGet("type/{id}")]
        public async Task<ActionResult> GetLookUpOfType(int id)
        {
            var lookUps = await lookUpService.GetLookUps(id);

            if (lookUps != null)
                return Ok(mapper.Map<List<LookUpDTO>>(lookUps));

            return NotFound();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetLookUp(int id)
        {
            var lookup = await lookUpService.GetLookUp(id);

            if (lookup != null)
                return Ok(mapper.Map<LookUpDTO>(lookup));

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> PostLookUp([FromBody]CreateLookUpDTO createLookUpDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var lookUpId = await lookUpService.PostLookUp(mapper.Map<LookUp>(createLookUpDTO));

            if (lookUpId != default)
                return Created("LookUp Id :", lookUpId);
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutLookUp(int id,UpdateLookUpDTO updateLookUpDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var success = await lookUpService.PutLookUp(id, mapper.Map<LookUp>(updateLookUpDTO));

                if (success)
                    return Ok(updateLookUpDTO.Id);
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLookUp(int id)
        {
            var success = await lookUpService.DeleteLookUp(id);

            if (success)
                return Ok(id);
            else
                return NotFound();
        }
    }
}
