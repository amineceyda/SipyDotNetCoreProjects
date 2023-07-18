using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SipayFirstAPI.Controllers
{
    [Route("sipy/api/[controller]")]
    [ApiController]
    public class RouteValuesController : ControllerBase
    {
        public RouteValuesController()
        {

        }


        [HttpGet("GetByIdQuery")]
        public string GetByIdQuery([FromQuery] int id)
        {
            return "GetByIdQuery";
        }

        [HttpGet("GetByIdRoute/{id}")]
        public string GetByIdRoute(int id)
        {
            return "GetByIdRoute";
        }

        [HttpGet("GetByParamenterQuery")]
        public string GetByParamenterQuery([FromQuery] int? id, [FromQuery] string? name, [FromQuery] string? lastname)
        {
            return $"id={id}||name={name}||lastname={lastname}";
        }

        [HttpGet("GetByParamenterRoute/{id}/{name}/{lastname}")]
        public string GetByParamenterRoute(int? id, string? name, string? lastname)
        {
            return $"id={id}||name={name}||lastname={lastname}";
        }
    }
}
