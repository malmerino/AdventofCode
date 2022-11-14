namespace AoC.Solutions.Y2015
{
    public class D03 : AoCPuzzle
    {
        public D03() : base(2015,3)
        { }

        public override object SolvePuzzleA(string input)
        {
            List<House> houses = new();

            int dPosX = 0, dPosY = 0;
            houses.Add(new House(dPosX, dPosY) { GiftsReceived = 1 });

            foreach (char t in input)
            {
                Move(ref dPosX, ref dPosY, t);
                HouseTracker(houses, dPosX, dPosY);
            }

            return houses.Count;
        }

        public override object SolvePuzzleB(string input)
        {
            List<House> houses = new List<House>();

            int sdPosX = 0, sdPosY = 0;
            int rdPosX = 0, rdPosY = 0;

            houses.Add(new House(sdPosX, sdPosY) { GiftsReceived = 2 });

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Move(ref sdPosX, ref sdPosY, input[i]);
                    HouseTracker(houses, sdPosX, sdPosY);
                }
                else
                {
                    Move(ref rdPosX, ref rdPosY, input[i]);
                    HouseTracker(houses, rdPosX, rdPosY);
                }

            }

            return houses.Count;
        }


        private static void Move(ref int xPos, ref int yPos, char operation)
        {
            if (operation == '^') yPos++;
            else if (operation == 'v') yPos--;
            else if (operation == '>') xPos++;
            else if (operation == '<') xPos--;
        }

        private static void HouseTracker(ICollection<House> visitedLocations, int dPositionX, int dPositionY)
        {
            if (visitedLocations.Any(house => house.X == dPositionX && house.Y == dPositionY))
            {
                visitedLocations.First(house => house.X == dPositionX && house.Y == dPositionY).GiftsReceived++;
            }
            else visitedLocations.Add(new House(dPositionX, dPositionY) { GiftsReceived = 1 });
        }



        private class House
        {
            public int X { get; }
            public int Y { get; }

            public int GiftsReceived { get; set; }

            public House(int x, int y)
            {
                GiftsReceived = 0;
                X = x;
                Y = y;
            }
        }





    }
}
