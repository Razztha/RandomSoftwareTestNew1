using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockAPIService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomSoftware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMockApiService mockApiService;

        public PersonController(IMockApiService mockApiService)
        {
            this.mockApiService = mockApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mockApiService.GetAllPersons());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await this.mockApiService.GetPersonById(id));
        }
    }
}
