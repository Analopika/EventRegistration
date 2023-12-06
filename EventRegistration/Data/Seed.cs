using EventRegistration.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EventRegistration.Data
{
    public class Seed
    {
        public static async Task SeedCompany(Company company, DataContext context)
        {
            //if (company.CompanyName.Any())
            //    return;

            var companyData = await File.ReadAllTextAsync("Data/CompanySeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var companies = JsonSerializer.Deserialize<List<Company>>(companyData);

            foreach (var comp in companies)
            {
                var com = new Company
                {
                    CompanyName = comp.CompanyName,
                    AddressOne = comp.AddressOne,
                    AddressTwo = comp.AddressTwo,
                    City = comp.City,
                    WebsiteUrl = comp.WebsiteUrl
                };

                context.Companies.Add(com);
                await context.SaveChangesAsync();

            }
        }
    }
}
