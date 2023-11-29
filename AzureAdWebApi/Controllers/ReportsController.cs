using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AzureAdWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        [Authorize(Roles = "Manager")]
        [HttpGet("GetReport")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public IActionResult GetReport()
        {
            return File(System.IO.File.ReadAllBytes(@"C:\Users\vignesh.venkatesan\Desktop\My Personal\922010000225937.pdf"), "application/pdf");
        }

        [Authorize]
        [HttpGet("GetReportStatus")]
        public IActionResult GetReportStatus()
        {
            return Ok(new { Status = @"Report Generated at - " + DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss") });
        }
    }
}
