using CarBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Makes
{
    public class UpdateModel : PageModel
    {
        #region
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;
        #endregion

        #region Constructors
        public UpdateModel(CarBookingApp.Data.CarBookingAppDbContext context)
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
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }

            Makes = new SelectList(_context.Makes.ToList(), "Id", "Name");
           
            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
        #endregion
    }
}
