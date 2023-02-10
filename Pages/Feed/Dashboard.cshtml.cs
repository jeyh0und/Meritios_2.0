using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrtensLIA.Pages.Feed
{
    public class DashboardModel : PageModel
    {
        private FirestoreDb _db;
        public List<Dictionary<string, object>> Posts { get; set; }
        public DashboardModel()
        {
            string filePath = "./linkedinaze-firebase-adminsdk-8dttu-ae263b7551.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _db = FirestoreDb.Create("linkedinaze");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string content = Request.Form["postContent"];

            var post = new Dictionary<string, object>
            {
                {"content", content },
                {"createdAt", DateTime.UtcNow }
            };

            await _db.Collection("posts").AddAsync(post);
            return RedirectToPage();
        }
        public async Task OnGetAsync()
        {
            var postRef = _db.Collection("posts");
            var query = await postRef.OrderByDescending("createdAt").GetSnapshotAsync();
            Posts = query.Documents.Select(d => d.ToDictionary()).ToList();
        }
    }
}
