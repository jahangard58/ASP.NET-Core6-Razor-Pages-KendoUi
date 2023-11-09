using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageKendoUi_Net6.Data;
using RazorPageKendoUi_Net6.Model;

namespace RazorPageKendoUi_Net6.Pages
{
    [BindProperties]
    public class AddModel : PageModel
    {
        public User User { get; set; }
        private readonly  ContextApplicationDB? _db =null;

        public AddModel(ContextApplicationDB db)
        {
            _db= db;    
        }
        public void OnGet()
        {

        }

        public async  Task<IActionResult> OnPostAdd(User user)
        {
            
               await _db.Users.AddAsync(user);
               await _db.SaveChangesAsync();
               return RedirectToPage("ListUsers");
            
            
        }
    }
}
