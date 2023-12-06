using EventRegistration.DTO;

namespace EventRegistration.Services
{
    public interface IEmailService
    {
        void Send(EmailDTO request);
    }
}
