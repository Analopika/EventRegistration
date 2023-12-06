using Azure;
using EventRegistration.Data;
using EventRegistration.DTO;
using EventRegistration.Entities;
using EventRegistration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EventRegistration.Controllers
{
    public class CodeController : BaseController
    {
        private readonly DataContext _context;
        private readonly IEmailService _emailService;

        public CodeController(DataContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        [HttpPost("generateCode")]
        public async Task<ActionResult<CodeDTO>> GenerateCode(RegisterDTO registerDTO)
        {
            if (await AttendeeExists(registerDTO.email))
            {
                return BadRequest("Code already generated!");
            }

            Random rnd = new Random();
            var code = rnd.Next(1000, 9999);
            var attendee = new Attendee
            {
                Email = registerDTO.email,
                CompanyId = 1,
                VerificationCode = code,
                Attended = false
            };

            //var emailDetails = new EmailDTO
            //{
            //    To = attendee.Email,
            //    Subject = "We can't wait to see you!",
            //    Body = "Thank you for registering for our Event. Here is your ONE TIME PIN to produce when you enter the venue.\n" + code
            //    //Body = body;
            //};

            //await SendEmailAsync(emailDetails);

            _context.Attendees.Add(attendee);
            await _context.SaveChangesAsync();

            return new CodeDTO
            {
                Code = code
            };
        }

        [HttpPost("attend")]
        public async Task<ActionResult> Verification(CodeDTO codeDTO)
        {
            var user = await _context.Attendees.FirstOrDefaultAsync(x => x.VerificationCode == codeDTO.Code);

            //var code = user.VerificationCode;

            if (user == null)
            {
                return Ok(JsonSerializer.Serialize("Oops, looks like you're not registered for this event!"));
            }

            user.Attended = true;
            await _context.SaveChangesAsync();
            return Ok(JsonSerializer.Serialize("Welcome " + user.Email));
        }

        [HttpGet("attendees")]
        public async Task<ActionResult<IEnumerable<RegisterDTO>>> GetAttendees()
        {
            var users = await _context.Attendees.Where(x => x.Attended == true).Select(x => x.Email).ToListAsync();

            return Ok(users);
        }

        private async Task<bool> AttendeeExists(string email)
        {
            return await _context.Attendees.AnyAsync(x => x.Email == email.ToLower());
        }
        private async Task<bool> SendEmailAsync(EmailDTO email)
        {
            _emailService.Send(email);
            return true;
        }
    }
}
