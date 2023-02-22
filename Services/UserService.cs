using DrinksWebApp.Data;
using DrinksWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DrinksWebApp.Services
{
	public class UserService
	{
		public async Task<IdentityUser> GetUserByName(string username)
		{
            using var context = new DrinksAppContext();
            return await context.Users
				.Where(u => u.UserName == username)
				.FirstOrDefaultAsync();
        }

		public async Task<ICollection<IdentityUser>> GetUsersAsync()
		{
            using var context = new DrinksAppContext();
			return await context.Users.ToListAsync();
        }

		public async Task UpdateUser(IdentityUser user)
		{
			using var context = new DrinksAppContext();
			context.Update(user);
			await context.SaveChangesAsync();
		}

		public async Task<IdentityUser> GetDetails(string userId)
		{
            using var context = new DrinksAppContext();
            return await context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }
	}
}
