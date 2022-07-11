using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Constants
{
    public enum ClientCategory
    {
        [Display(Name = "Bronze")]
        Bronze,

        [Display(Name = "Prata")]
        Silver,

        [Display(Name = "Ouro")]
        Gold,
    }
}
