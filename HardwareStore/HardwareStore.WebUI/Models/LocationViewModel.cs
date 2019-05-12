using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HardwareStore.WebUI.Models
{
    public class LocationViewModel
    {
        //each locationvhas name id address,list of customers
        [Display(Name="ID")]
        public int LocationId { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string Address { get; set; }
        //maybe add list of customers later
    }
}
