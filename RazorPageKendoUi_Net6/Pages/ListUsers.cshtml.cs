using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageKendoUi_Net6.Data;
using RazorPageKendoUi_Net6.Model;

namespace RazorPageKendoUi_Net6.Pages
{
    [BindProperties]
    public class ListUserModel : PageModel
    {
        public static IList<User>? Users;
        public readonly ContextApplicationDB _db;

        public ListUserModel(ContextApplicationDB db)
        {
            _db=db;
        }
        public void OnGet()
        {
            if (Users !=null)
            {
                Users.Clear();
            } 
            Users = _db.Users.OrderByDescending(f=> f.Id).ToList();
        }

        public JsonResult OnPostList([DataSourceRequest] DataSourceRequest request ,string additionalParameter)
        {
            Users = _db.Users.OrderByDescending(f => f.Id).ToList();

            return new JsonResult(Users.ToDataSourceResult(request));
        }
       
        public JsonResult OnPostDestroy([DataSourceRequest] DataSourceRequest request, User user)
        {
            var entity = _db.Users.FirstOrDefault(f => f.Id == user.Id);
            if (entity != null)
            {
                _db.Users.Remove(entity);
                _db.SaveChanges();  
            }
            return new JsonResult(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OnPostUpdate([DataSourceRequest] DataSourceRequest request, User user)
        {
            _db.Users.Where(x => x.Id == user.Id).Select(x => user);

            return new JsonResult(new[] { user }.ToDataSourceResult(request, ModelState));
        }

    }
}
