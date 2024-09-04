using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneSignalWebApiv1.Context;
using OneSignalWebApiv1.Entities;
using OneSignalWebApiv1.Entities.OneSignalEntities;
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
        public async Task<IActionResult> SaveSDKDatas([FromBody] SaveSDKDataEntity request)
        {
            Student student = _dbContext.Students.FirstOrDefault(x => x.GUID.ToString() == request.StudentGUID);
            if (student == null) return BadRequest("Öğrenci bulunamadı"); //ÖĞRENCİ EKLENEREK DEVAM EDİLEBİLİR

            try
            {
                var studentOneSignalId = await _oneSignalServiceGetUserInfo.GetOneSignalIdByPlayerId(request.PlayerId);
                student.OneSignalId = studentOneSignalId;
            }
            catch (Exception)
            {

                throw;
            }
            student.Email = request.OneSignalAddEmailInputVal;
            student.SubscriptionId = request.PlayerId;
            student.PushToken = request.PushToken;

            await _dbContext.SaveChangesAsync();

            return Ok(student);
        }



    }
}


