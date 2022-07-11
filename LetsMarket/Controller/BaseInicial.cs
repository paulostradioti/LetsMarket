using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public class BaseInicial
    {// se a gente conseguir unificar os métodos similares em funcionarios,
     // produtos e clientes, acho que eles deveriam ficar no Controller,
     // pois depende de um input de usuário e impacta diretamente os dados do negócio

        private static string CreateLoginSuggestionBasedOnName(string nome) //usar ou retirar
        {
            var parts = nome?.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var suggestion = parts?.Length > 0 ? parts.Length > 1 ? $"{parts[0]}.{parts[parts.Length - 1]}" : $"{parts[0]}" : "";

            return suggestion.ToLower();
        }
    }
}
