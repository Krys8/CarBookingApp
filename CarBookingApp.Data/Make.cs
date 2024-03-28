using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingApp.Data
{
    public class Make: BaseDomainEntity
    {
        #region Properties

        [Display(Name = "Make")]

        public string Name { get; set; }

        public virtual List<Car> Cars { get; set; }
        #endregion


    }
}
