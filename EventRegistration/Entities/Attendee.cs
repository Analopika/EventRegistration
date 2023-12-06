using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EventRegistration.Entities
{
    public class Attendee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int VerificationCode { get; set; }
        public bool Attended { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
