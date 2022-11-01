namespace AoC.Solutions.Y2015
{
    public class D03 : AoCPuzzle<int>
    {
        public D03(string[] input) : base(input,2015,3)
        { }

        public override int SolvePuzzleA()
        {
            List<House> houses = new List<House>();

            int dPosX = 0, dPosY = 0;
            houses.Add(new House(dPosX, dPosY) { GiftsReceived = 1 });

            foreach (char t in GetInputAsString)
            {
                Move(ref dPosX, ref dPosY, t);
                HouseTracker(houses, dPosX, dPosY);
            }

            return houses.Count;
        }

        public override int SolvePuzzleB()
        {
            List<House> houses = new List<House>();

            int SdPosX = 0, SdPosY = 0;
            int RdPosX = 0, RdPosY = 0;

            houses.Add(new House(SdPosX, SdPosY) { GiftsReceived = 2 });

            for (int i = 0; i < GetInputAsString.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Move(ref SdPosX, ref SdPosY, GetInputAsString[i]);
                    HouseTracker(houses, SdPosX, SdPosY);
                }
                else
                {
                    Move(ref RdPosX, ref RdPosY, GetInputAsString[i]);
                    HouseTracker(houses, RdPosX, RdPosY);
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

        private static void HouseTracker(List<House> visitedLocations, int dposX, int dposY)
        {
            if (visitedLocations.Any(house => house.X == dposX && house.Y == dposY))
            {
                visitedLocations.First(house => house.X == dposX && house.Y == dposY).GiftsReceived++;
            }
            else visitedLocations.Add(new House(dposX, dposY) { GiftsReceived = 1 });
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
