using System.Text.RegularExpressions;
using CoUtilities.Extensions;

namespace AoC.Solutions.Y2015
{
    public class D09 : AoCPuzzle
    {
        public D09(string[] input) : base(input, 2015, 9)
        { }

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

            List<IEnumerable<string>> permutations = uniqueLocations.GetPermutations().ToList();
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
    }
}
