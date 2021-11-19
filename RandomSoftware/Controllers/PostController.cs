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
    public class PostController : ControllerBase
    {
        private readonly IMockApiService mockApiService;

        public PostController(IMockApiService mockApiService)
        {
            this.mockApiService = mockApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mockApiService.GetAllPosts());
        }
    }
}
