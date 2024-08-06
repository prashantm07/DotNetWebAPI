using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase
    {
        public List<string> fruits = new List<string>()
        {
            "babana","apple","kiwi","mango","cherry" ,"grapes"
        };

        [HttpGet]
        public List<string> getfruits()
        {
            return fruits;
        }
        [HttpGet("{id}")]
        public string getFruitsById(int id)
        {
            return fruits.ElementAt(id);
        }
    }
}
