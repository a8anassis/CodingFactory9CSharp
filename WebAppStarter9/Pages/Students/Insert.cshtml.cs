using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppStarter9.DTO;
using WebAppStarter9.Model;

namespace WebAppStarter9.Pages.Students
{
    public class InsertModel : PageModel
    {
        [BindProperty]
        public InsertStudentDTO InsertStudentDTO { get; set; } = new();
        public StudentReadOnlyDTO? StudentReadOnlyDTO { get; set; }
        public SelectList? Cities { get; set; }

        public void OnGet()
        {
            LoadCities();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadCities();
                return Page();
            }

            // Service
            StudentReadOnlyDTO = new StudentReadOnlyDTO(1, InsertStudentDTO.Firstname, InsertStudentDTO.Lastname);

            TempData["StudentName"] = 
                $"{StudentReadOnlyDTO.Firstname}, {StudentReadOnlyDTO.Lastname}";

            // Post-Redirect-Get pattern: redirect to a new page after successful form submission
            return RedirectToPage("/Students/Success");
        }

        private void LoadCities()
        {
            Cities = new SelectList(new List<City>()
            {
                new City { Id = 1, Name = "Αθήνα" },
                new City { Id = 2, Name = "Πάτρα" },
                new City { Id = 3, Name = "Ηράκλειο" },
                new City { Id = 4, Name = "Δράμα" },
            }.OrderBy(c => c.Name), nameof(City.Id), nameof(City.Name));
        }
    }
}
