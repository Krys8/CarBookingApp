using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarBookingApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Makes
{
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;
        #endregion

        #region Constructors
        public IndexModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties
        public IList<Car> Cars { get; set; }
        #endregion
        #region Public methods
        public async Task OnGetAsync()
        {
           Cars = await _context.Cars.Include(q => q.Make).ToListAsync();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int? carid)
        {
            if (carid == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FindAsync(carid);
            
            if(car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
        #endregion
        
    }
}
