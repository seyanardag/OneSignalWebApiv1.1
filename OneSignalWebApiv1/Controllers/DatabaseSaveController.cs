using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneSignalWebApiv1.Context;
using OneSignalWebApiv1.Services;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseSaveController : ControllerBase 
    {
        private readonly OneSignalDbContext _dbContext;
        private readonly OneSignalServiceGetUserInfo _oneSignalServiceGetUserInfo;

        public DatabaseSaveController(OneSignalDbContext dbContext, OneSignalServiceGetUserInfo oneSignalServiceGetUserInfo)
        {
            _dbContext = dbContext;
            _oneSignalServiceGetUserInfo = oneSignalServiceGetUserInfo;
        }

        [HttpPost("SaveSDKDatas")]
        public async Task<IActionResult> SaveSDKDatas([FromBody] SaveSDKData request)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.GUID.ToString() == request.StudentGUID);
            if (student == null) return BadRequest("Öğrenci bulunamadı"); //ÖĞRENCİ EKLENEREK DEVAM EDİLEBİLİR


            var studentOneSignalId = await _oneSignalServiceGetUserInfo.GetOneSignalIdByPlayerId(request.PlayerId);
            student.OneSignalId = studentOneSignalId;

            student.SubscriptionId = request.PlayerId;
            student.PushToken = request.PushToken;

            await _dbContext.SaveChangesAsync();

            return Ok(student);
        }



        //[HttpPost("SaveOneSignalId")]
        //public IActionResult SaveOneSignalId([FromBody] PlayerIdRequest request)
        //{

        //    var playerId = request.PlayerId;
        //    var pushToken = request.pushToken;

        //    // Kullanıcının OneSignal ID'sini veritabanına kaydedin
        //    //var user = _dbContext.Users.Find(User.Identity.Name);
        //    //user.OneSignalPlayerId = request.playerId;
        //    //_dbContext.SaveChanges();
        //    return Ok();
        //}


        //[HttpPost("SaveOneSignalEmail")]
        //public IActionResult SaveOneSignalEmail([FromBody] OneSignalEmailRequest request)
        //{

        //    var email = request.OneSginalAddEmailTagInput;

        //    return Ok();
        //}



    }
}


//public class PlayerIdRequest
//{
//    public string PlayerId { get; set; }
//    public string pushToken { get; set; }
//}

//public class OneSignalEmailRequest
//{
//    public string OneSginalAddEmailTagInput { get; set; }
  
//}

public class SaveSDKData
{
    public string? PlayerId { get; set; }
    public string? PushToken { get; set; }
    public string? OneSignalAddEmailInputVal { get; set; }
    public string? StudentGUID { get; set; }


}