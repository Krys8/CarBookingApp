using System.ComponentModel.DataAnnotations;

namespace CarBookingApp.Data
{
    public class CarModel:BaseDomainEntity
    {
        #region Properties

        [Display(Name = "Model")]

        public string Name { get; set; }

        public virtual List<Car> Cars { get; set; }
        #endregion
    }
}