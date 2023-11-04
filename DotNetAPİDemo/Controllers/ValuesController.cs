using Microsoft.AspNetCore.Mvc;

namespace DotNetAPİDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //[Route("[action]")]
        [HttpGet]
        public string GetName()
        {
            return "Hello World";
        }

        //[Route("[action]")]
        [HttpGet]
        public int GetAge()
        {
            return 21;
        }
    }
}