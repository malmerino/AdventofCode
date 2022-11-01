using AoC.Solutions.Y2015;

namespace AoC.Solutions
{
    internal class Program
    {
        static void Main(string[] args)
        {


            D11 s = new AoC.Solutions.Y2015.D11(File.ReadAllLines("Inputs/Y2015D11.txt"));
            s.SolveAndWriteLine();


            Console.ReadKey();



        }
    }
}
