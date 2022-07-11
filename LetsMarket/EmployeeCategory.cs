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
        [Display(Name = "Caixa")]
        Cashier,

        [Display(Name = "Gerente")]
        Manager,

        [Display(Name = "Assistente")]
        Assistant,
    }
}
