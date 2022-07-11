using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Constants
{
    internal enum EmployeeCategory
    {
        [Display(Name = "Caixa")]
        Cashier,

        [Display(Name = "Gerente")]
        Manager,

        [Display(Name = "Assistente")]
        Assistant,
    }
}
