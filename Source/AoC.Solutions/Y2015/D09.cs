using System.Text.RegularExpressions;

namespace AoC.Solutions.Y2015
{
    public class D09 : AoCPuzzle
    {


        public D09(string[] input) : base(input, 2015, 9)
        {
        }

        public override int SolvePuzzleA()
        {
            List<Path> paths = PermutationAndTransformRoutes();
            return paths.Min(x=> x.Distance);
        }

        public override int SolvePuzzleB()
        {
            List<Path> paths = PermutationAndTransformRoutes();
            return paths.Max(x => x.Distance);
        }


        private List<Path> PermutationAndTransformRoutes()
        {
            List<Route> routeList = Input.Select(RouteFromString).ToList();

            List<string> uniqueLocations = routeList.Select(x => x.Start)
                .Concat(routeList.Select(x => x.End))
                .GroupBy(x => x)
                .Select(x => x.First())
                .ToList();

            List<IEnumerable<string>> permutations = GetPermutations(uniqueLocations).ToList();
            List<Path> paths = new();

            foreach (IEnumerable<string> route in permutations)
            {
                List<string> destinations = route.ToList();

                bool errorRoute = true;
                int length = 0;

                for (int i = 0; i < destinations.Count - 1; i++)
                {
                    if (routeList.Any(x =>
                            (x.Start == destinations[i] && x.End == destinations[i + 1]) ||
                            (x.Start == destinations[i + 1] && x.End == destinations[i])))
                    {
                        length += routeList.First(x =>
                            (x.Start == destinations[i] && x.End == destinations[i + 1]) ||
                            (x.Start == destinations[i + 1] && x.End == destinations[i])).Distance;
                    }
                    else
                    {
                        errorRoute = false;
                        break;
                    }
                }

                if (errorRoute)
                {
                    paths.Add(new Path(destinations.ToArray(), length));
                }
            }

            return paths;
        }

        
        private static Route RouteFromString(string row)
        {
            string pattern = @"([A-Za-z]*) to ([A-Za-z]*) = (\d{1,4})";
            Match regex = Regex.Match(row, pattern);
            return new Route(regex.Groups[1].Value, regex.Groups[2].Value, int.Parse(regex.Groups[3].Value));
        }



        private struct Path
        {
            public string[] Routes { get; }
            public int Distance { get;}

            public Path(string[] routes, int dist)
            {
                Routes = routes;
                Distance = dist;
            }
        }

        private struct Route
        {
            public string Start { get; }
            public string End { get; }
            public int Distance { get; }
            public Route(string start, string end, int distance)
            {
                Start = start;
                End = end;
                Distance = distance;
            }
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> enumerable)
        {
            T[] array = enumerable as T[] ?? enumerable.ToArray();

            long[] factorials = Enumerable.Range(0, array.Length + 1)
                .Select(Factorial)
                .ToArray();

            for (long i = 0L; i < factorials[array.Length]; i++)
            {
                int[] sequence = GenerateSequence(i, array.Length - 1, factorials);

                yield return GeneratePermutation(array, sequence);
            }
        }

        private static IEnumerable<T> GeneratePermutation<T>(T[] array, IReadOnlyList<int> sequence)
        {
            T[] clone = (T[])array.Clone();

            for (int i = 0; i < clone.Length - 1; i++)
            {
                Swap(ref clone[i], ref clone[i + sequence[i]]);
            }

            return clone;
        }

        private static int[] GenerateSequence(long number, int size, IReadOnlyList<long> factorials)
        {
            int[] sequence = new int[size];

            for (int j = 0; j < sequence.Length; j++)
            {
                long factorial = factorials[sequence.Length - j];

                sequence[j] = (int)(number / factorial);
                number = (int)(number % factorial);
            }

            return sequence;
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }

        private static long Factorial(int n)
        {
            long result = n;

            for (int i = 1; i < n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
