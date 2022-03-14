using Microsoft.EntityFrameworkCore;
using PasswordManagement.Api.Models;

namespace PasswordManagement.Api
{
    public class PasswordManagementContext : DbContext
    {
        public PasswordManagementContext(DbContextOptions<PasswordManagementContext> options)
            : base(options)
        {
        }
        public DbSet<PasswordCard> PasswordCards { get; set; }
    }
}
