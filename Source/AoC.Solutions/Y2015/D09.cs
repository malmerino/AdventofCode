namespace AoC.Solutions.Y2015
{
    public class D09 : AoCPuzzle
    {
        public D09(string[] input) : base(input, 2015,9)
        {
        }

        public override int SolvePuzzleA()
        {
            List<Route> routes = new List<Route>();
            foreach (string row in Input) routes.Add(LoadRoute(row));
            List<string> locationsToVisit = new List<string>();

            foreach (string location in routes.Select(x => x.Start).Distinct().Concat(routes.Select(x => x.End).Distinct()))
                if (!locationsToVisit.Contains(location)) locationsToVisit.Add(location);

                //https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer






            return 0;
        }

        public override int SolvePuzzleB()
        {
            throw new NotImplementedException();
        }









        private Route LoadRoute(string row)
        {
            string[] r = row.Split(' ');
            return new Route(r[0], r[2], int.Parse(r[4]));
        }




        private struct Route
        {
            public string Start { get; set; }
            public string End { get; set; }
            public int Distance { get; set; }
            public Route(string start, string end, int distance)
            {
                Start = start;
                End = end;
                Distance = distance;
            }
        }
    }
}
