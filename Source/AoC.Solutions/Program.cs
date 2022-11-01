using AoC.Solutions.Y2015;

namespace AoC.Solutions
{
    internal class Program
    {
        static void Main(string[] args)
        {


            D10 s = new AoC.Solutions.Y2015.D10(File.ReadAllLines("Inputs/Y2015D10.txt"));
            s.SolveAndWriteLine();


            Console.ReadKey();



        }
    }
}
