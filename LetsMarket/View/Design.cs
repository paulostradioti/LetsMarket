using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharprompt;

namespace LetsMarket
{
    internal class Design
    {//concentraria aqui todos os métodos de tabelas e também de mensagens de erros e
     //alterações de cores do console
     //talvez até criar uma classe para tabelas e outra para demais config, não sei


        public static void SetupPrompt()
        {
            Prompt.ColorSchema.Answer = ConsoleColor.White;
            Prompt.ColorSchema.Select = ConsoleColor.White;

            Prompt.Symbols.Prompt = new Symbol("", "");
            Prompt.Symbols.Done = new Symbol("", "");
            Prompt.Symbols.Error = new Symbol("", "");
        }
    }
}
