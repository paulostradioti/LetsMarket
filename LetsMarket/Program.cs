using BetterConsoleTables;
using System.Text;

namespace LetsMarket
{
    public class Printer<T> 
        where T : IImprimivel,
        IComparable<T>,
        new()
    {
        public static void Print()
        {
            T tipo = new T();
            Console.WriteLine(tipo.ToString());
        }
    }

    public interface IImprimivel
    { }

    public class NotaFiscal : IImprimivel
    {
        public NotaFiscal(int imposto)
        {

        }

        public override string ToString()
        {
            return "Eu sou uma nota fiscal";
        }
    }
    public class Extrato : IImprimivel
    {
        public override string ToString()
        {
            return "Eu sou um extrato";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}