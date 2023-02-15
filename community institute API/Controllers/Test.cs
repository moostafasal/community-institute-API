using Microsoft.AspNetCore.Mvc;

namespace community_institute_API.Controllers
{
    //inherit from ControllerBase   
    [ApiController]
    [Route("[controller]")]

    public class Test : ControllerBase
        
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

    }
}
