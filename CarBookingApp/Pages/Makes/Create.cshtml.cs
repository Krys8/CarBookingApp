using CarBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Makes
{
    public class CreateModel : PageModel
    {

        #region Fields
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;
        #endregion

        #region Constructors
        public CreateModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties
        [BindProperty]
        public Car Car { get; set; }
        public SelectList Makes { get; set; }
        #endregion

        #region Public methods
        public async Task<IActionResult> OnGet()
        {
           await LoadInitialData();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               await LoadInitialData();
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task LoadInitialData()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");

        }
        #endregion

    }
}
