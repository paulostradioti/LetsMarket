using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Constants
{
    internal enum ClientCategory
    {
        [Display(Name = "Bronze")]
        Bronze,

        [Display(Name = "Prata")]
        Silver,

        [Display(Name = "Ouro")]
        Gold,
    }
}
