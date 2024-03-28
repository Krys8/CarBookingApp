using CarBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Makes
{
    public class DetailsModel : PageModel
    {
        #region
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;
        #endregion

        #region Constructors
        public DetailsModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties
        public Car Car { get; set; }
        #endregion

        #region Public methods
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
     
            Car = await _context.Cars.Include(q => q.Make).FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}

   

