using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingApp.Data
{
    public class Car: BaseDomainEntity
    {
        #region Properties
        
        [Required]
        [Range(1990,2023)]
        public int Year { get; set; }
        
        public int? MakeId { get; set; }
        public virtual Make Make { get; set; }


        public virtual CarModel CarModel { get; set; }
        public int? ModelId { get; set; }

        public int? ColourId { get; set; }
        public virtual Colour Colour { get; set; }

        #endregion



    }
}
