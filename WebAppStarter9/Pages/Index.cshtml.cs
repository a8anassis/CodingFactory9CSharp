using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace WebAppStarter9.Pages
{
    public class IndexModel : PageModel
    {
        public string? CurrentDay { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            /*
             *  DateTime.Now.ToString("dddd", CultureInfo.InvariantCulture); // "Wednesday" παντού
             *   DateTime.Now.ToString("dddd");                               // CurrentCulture: "Τετάρτη" σε ελληνικό PC
             *   DateTime.Now.ToString("dddd", new CultureInfo("el-GR"));     // "Τετάρτη"
             */
            CurrentDay = DateTime.Now.ToString("dddd", CultureInfo.InvariantCulture);
            return Page();
        }
    }
}
