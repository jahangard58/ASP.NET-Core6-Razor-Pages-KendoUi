using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageKendoUi_Net6.Data;
using RazorPageKendoUi_Net6.Model;


namespace RazorPageKendoUi_Net6.Pages
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
        public static IList<User> users;
        public readonly ContextApplicationDB _db;
        public UpdateModel(ContextApplicationDB db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public JsonResult OnPostUpdate([DataSourceRequest] DataSourceRequest request, User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Age))
                {
                    //return RedirectToPage("ListUsers");
                }
                if (user.Age.Length > 2)
                {
                    //return RedirectToPage("ListUsers");
                }
                if (users != null)
                {
                    users.Clear();
                }
                users = _db.Users.ToList();
                users.Where(x => x.Id == user.Id).Select(x => user);

                //Update Row
                var entity = _db.Users.FirstOrDefault(item => item.Id == user.Id);
                if (entity != null)
                {
                    entity.Name = user.Name;
                    entity.Age = user.Age;
                    entity.Mobile = user.Mobile;
                    _db.SaveChanges();
                }




                return new JsonResult(new[] { user }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                return null;
            }

        }

        public async Task<IActionResult> OnPostUpdateNew(User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Age))
                {
                    return RedirectToPage("ListUsers");
                }
                if (user.Age.Length > 2)
                {
                    return RedirectToPage("ListUsers");
                }
                if (users != null)
                {
                    users.Clear();
                }
                users = _db.Users.ToList();
                users.Where(x => x.Id == user.Id).Select(x => user);

                //Update Row
                var entity = _db.Users.FirstOrDefault(item => item.Id == user.Id);
                if (entity != null)
                {
                    entity.Name = user.Name;
                    entity.Age = user.Age;
                    entity.Mobile = user.Mobile;
                    await _db.SaveChangesAsync();
                }

                return RedirectToPage("ListUsers");



            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                return null;
            }
        }
    }
}
