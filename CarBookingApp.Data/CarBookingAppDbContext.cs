using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingApp.Data
{
    public class CarBookingAppDbContext : DbContext
    {
        #region Properties
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        #endregion

        #region Constructors
        public CarBookingAppDbContext(DbContextOptions<CarBookingAppDbContext> options): base(options) { }
        #endregion

    }
}
