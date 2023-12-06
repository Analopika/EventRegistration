namespace EventRegistration.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string AddressOne { get; set; }
        public string? AddressTwo { get; set; }
        public string City { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
