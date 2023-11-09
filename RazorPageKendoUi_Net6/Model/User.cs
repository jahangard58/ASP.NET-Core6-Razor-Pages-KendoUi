using System.ComponentModel.DataAnnotations;

namespace RazorPageKendoUi_Net6.Model
{
    public class User
    {
       
            [Key]
            public int Id { get; set; }

            [Display(Name = "نام و نام خانوادگی")]
            [Required(ErrorMessage = "مقداری برای {0} وارد نمایید")]
            [MaxLength(250, ErrorMessage = "نباید بیشتر از {1} کاراکتر باشد")]
            public string Name { get; set; }

            [Display(Name = "سن")]
            [MaxLength(2, ErrorMessage = "نباید بیشتر از {0} کاراکتر باشد")]
            public string? Age { get; set; }

            [Display(Name = "تلفن همراه")]
            [MaxLength(11, ErrorMessage = "نباید بیشتر از {0} کاراکتر باشد")]
            public string? Mobile { get; set; }


        
    }
}
