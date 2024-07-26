using EmailSender.Interfaces;
using EmailSender.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailSenderController : Controller
    {
        private readonly IMailSendService _mailService;

        public MailSenderController(IMailSendService mailService)
        {
            this._mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> EmailSender([FromForm] MailRequest request)
        {
            try
            {
                await _mailService.EmailSenderAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
