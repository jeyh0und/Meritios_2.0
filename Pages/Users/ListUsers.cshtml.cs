using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrtensLIA.Models.Domain;
using OrtensLIA.UserDBContext;

namespace OrtensLIA.Pages.Users
{
    public class ListUsersModel : PageModel
    {
        private readonly UserDbContext dBContext;
        public List<User> _Users { get; set; }
        public ListUsersModel(UserDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void OnGet()
        {
            _Users = dBContext._Users.ToList();
        }
    }
}
