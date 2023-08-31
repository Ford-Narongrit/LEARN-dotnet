namespace WebApi.WebControllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;

[ApiController]
[Route("web/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailSender _emailSender;

    public EmailController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpGet("send")]
    public async Task<IActionResult> send(string receiver, string subject, string message)
    {
        if (receiver == null || subject == null || message == null)
            return BadRequest("Please fill all fields.");

        await _emailSender.SendEmailAsync(receiver, subject, message);
        return Ok("email had been sent.");
    }
}