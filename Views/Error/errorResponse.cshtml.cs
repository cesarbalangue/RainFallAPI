using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RainFall.Views.Error
{
    public class errorResponseModel : PageModel
    {
        public string? ErrCode { get; set; }
        public string? ErrDesc { get; set; }

        public void OnGet(string errcode, string errdescription)
        {

            ErrCode = errcode;
            ErrDesc = errdescription;

        }
    }
}
