using BlazorDbTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDbTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAccountEmailController : ControllerBase
    {
        private readonly AccountUtilitiesService _accountUtilitiesService;
        private static int counter = 0;
        public GetAccountEmailController(AccountUtilitiesService accountUtilitiesService)
        {
            _accountUtilitiesService = accountUtilitiesService;
        }

        [HttpGet]
        public IActionResult GetEmail(string AccountID)
        {
            bool stillworking = true;

            string email = string.Empty;

            while(stillworking)
            {
                counter++;
                stillworking = false;
                try
                {
                    email = _accountUtilitiesService.GetAccountEmail(AccountID)+ "\nCount: " + counter;
                    stillworking = true;
                }
                catch (Exception e)
                {
                    email += e.Message;
                }
            }

            if(!stillworking) 
            { 
                email = "Failed after " + counter + " Hits";
            }

            return Ok(email);
        }
    }
}
