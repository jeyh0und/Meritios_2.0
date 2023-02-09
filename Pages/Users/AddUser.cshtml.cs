using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrtensLIA.Models.Domain;
using OrtensLIA.Models.ViewModel;
using OrtensLIA.UserDBContext;

namespace OrtensLIA.Pages.Users
{
	public class AddUserModel : PageModel
	{
		private readonly UserDbContext dBContext;
		[BindProperty]
		public AddUserViewModel addUserRequest { get; set; }
		public AddUserModel(UserDbContext dBContext)
		{
			this.dBContext = dBContext;
		}

		public void OnGet()
		{
		}

		public void OnPost()
		{
			var userDomainModel = new User
			{
				Name = addUserRequest.Name,
				Email = addUserRequest.Email,
				PhoneNr = addUserRequest.PhoneNr,
				Education = addUserRequest.Education,
				Location = addUserRequest.Location,
				School = addUserRequest.School
			};

			dBContext._Users.Add(userDomainModel);
			dBContext.SaveChanges();
		}
	}
}
