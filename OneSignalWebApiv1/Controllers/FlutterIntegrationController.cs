using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneSignalWebApiv1.Context;
using OneSignalWebApiv1.Services;

namespace OneSignalWebApiv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlutterIntegrationController : ControllerBase
    {

        private readonly FlutterIntegrationService _flutterIntegrationService;
        private readonly OneSignalDbContext _oneSignalDbContext;

        public FlutterIntegrationController(FlutterIntegrationService flutterIntegrationService, OneSignalDbContext oneSignalDbContext)
        {
            _flutterIntegrationService = flutterIntegrationService;
            _oneSignalDbContext = oneSignalDbContext;
        }

        [HttpPost("GetEmail")]

        public string GetEmail(string emailWithCode)
        {
            return _flutterIntegrationService.GetEmail(emailWithCode);
        }

        [HttpPost("GetEmailCode")]

        public string GetEmailCode(string emailWithCode)
        {
            return _flutterIntegrationService.GetEmailCode(emailWithCode);
        }

        
    }
}
