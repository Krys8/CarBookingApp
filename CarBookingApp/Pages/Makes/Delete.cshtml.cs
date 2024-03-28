using CarBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Makes
{
    public class DeleteModel : PageModel
    {
        #region
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;
        #endregion

        #region Constructors
        public DeleteModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties
        [BindProperty]
        public Car Car { get; set; }
        #endregion

        #region Public methods
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();

        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars.FindAsync(id);

            if (Car == null)
            {
                _context.Cars.Remove(Car);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
        #endregion
    }
}


