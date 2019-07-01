using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using dotnetcore._2.x.DTO;
using dotnetcore._2.x.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore._2.x.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashesController : ControllerBase
    {
        private IHashesService _hashesService;

        public HashesController(IHashesService hashesService)
        {
            _hashesService = hashesService;
        }

        [Route("/")]
        [HttpGet]
        public ContentResult Get()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<html><body>Hello World</body></html>"
            };
        }

        // POST api/Hashes
        [HttpPost]
        public IActionResult Post([FromBody] hashRequest request)
        {
            return Ok(_hashesService.hashPassword(request));
        }
        [HttpPost("/api/[controller]Verify")]
        public IActionResult Verify([FromBody] hashVerifyRequest request)
        {
            return Ok(_hashesService.hashVerify(request));
        }
    }
}
