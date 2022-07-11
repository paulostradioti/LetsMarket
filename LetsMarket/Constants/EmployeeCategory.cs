using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Constants
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
