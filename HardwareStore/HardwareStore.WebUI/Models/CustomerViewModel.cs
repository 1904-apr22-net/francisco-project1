﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HardwareStore.Library;

namespace HardwareStore.WebUI.Models
{
    public class CustomerViewModel
    {
        [Display(Name = "Id")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LName { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name="Default location id")]
        public int DefaultLocationId { get; set; }
        public List<Order> CustomerOrders { get; set; }
        public List<Location> Locations { get; set; }

    }
}
