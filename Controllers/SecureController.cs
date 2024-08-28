//
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI2{
    //Controller setting
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    //Class
    public class SecureController : ControllerBase{
        //Endpoint:
        [HttpGet("[Action]")]
        public IActionResult data(){
            return Ok(new{message = "This is secure controller"});
        }

    }
}