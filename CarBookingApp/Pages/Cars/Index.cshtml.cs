using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CarBookingApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructors
        public IndexModel(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        #endregion

        #region Public methods
        public void OnGet()
        {
            Heading = "List of Cars - From Variable";
            Message = _configuration["Message"];
        }
        #endregion

        #region Properties
        public string Heading { get; set; }
        public string Message { get; set; }
        public string Reason { get; set; }
        #endregion



    }
}
