using Microsoft.EntityFrameworkCore;
using PortfolioMisc.Models;

namespace Portfolio_my.Services
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) { }
        public DbSet<EmailModel> Mails { get; set; }
    }
}