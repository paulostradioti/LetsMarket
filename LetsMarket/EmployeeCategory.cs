using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket
{
    public enum EmployeeCategory
    {
        [Display(Name = "Cashier")]
        Cashier,

        [Display(Name = "Manager")]
        Manager,

        Assistant,
    }
}
