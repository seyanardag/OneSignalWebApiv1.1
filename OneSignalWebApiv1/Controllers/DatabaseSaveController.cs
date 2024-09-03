using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneSignalWebApiv1.Context;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseSaveController : ControllerBase
    {
        private readonly OneSignalDbContext _dbContext;

        public DatabaseSaveController(OneSignalDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost("SaveOneSignalId")]
        public IActionResult SaveOneSignalId([FromBody] PlayerIdRequest request)
        {

            var playerId = request.PlayerId;
            var pushToken = request.pushToken;

            // Kullanıcının OneSignal ID'sini veritabanına kaydedin
            //var user = _dbContext.Users.Find(User.Identity.Name);
            //user.OneSignalPlayerId = request.playerId;
            //_dbContext.SaveChanges();
            return Ok();
        }


        [HttpPost("SaveOneSignalEmail")]
        public IActionResult SaveOneSignalEmail([FromBody] OneSignalEmailRequest request)
        {

            var email = request.OneSginalAddEmailTagInput;

            return Ok();
        }



    }
}
public class PlayerIdRequest
{
    public string PlayerId { get; set; }
    public string pushToken { get; set; }
}

public class OneSignalEmailRequest
{
    public string OneSginalAddEmailTagInput { get; set; }
  
}