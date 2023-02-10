using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrtensLIA.Models.ViewModel;
using OrtensLIA.UserDBContext;

namespace OrtensLIA.Pages.Users;

public class EditUserModel : PageModel
{
	private readonly UserDbContext dbContext;
	[BindProperty]
	public EditUserViewModel _editUser { get; set; }
	public EditUserModel(UserDbContext dbContext)
	{
		this.dbContext = dbContext;
	}
	public void OnGet(Guid id)
	{
		var user = dbContext._Users.Find(id);
		if (user != null)
		{
			_editUser = new EditUserViewModel()
			{
				Id = user.Id,
				Education = user.Education,
				Email = user.Email,
				Location = user.Location,
				Name = user.Name,
				PhoneNr = user.PhoneNr,
				School = user.School
			};
		}
	}

	public IActionResult OnPostUpdate()
	{
		var user = dbContext._Users.Find(_editUser.Id);
		if (user != null)
		{
			user.Name = _editUser.Name;
			user.PhoneNr = _editUser.PhoneNr;
			user.Location = _editUser.Location;
			user.Education = _editUser.Education;
			user.Email = _editUser.Email;
			user.School = _editUser.School;


			dbContext.SaveChanges();
			return RedirectToPage("/Users/ListUsers");
		}
		return Page();
	}

	public IActionResult OnPostDelete()
	{
		var user = dbContext._Users.Find(_editUser.Id);
		if (user != null)
		{
			dbContext._Users.Remove(user);
			dbContext.SaveChanges();
			return RedirectToPage("/Users/ListUsers");
		}
		return Page();
	}
}