using Microsoft.EntityFrameworkCore;
using OrtensLIA.Models.Domain;

namespace OrtensLIA.UserDBContext
{
	public class UserDbContext : DbContext
	{
		public UserDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> _Users { get; set; }
	}
}
