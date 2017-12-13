using System;
using System.Linq;

namespace Battleship.CLI.Layout
{
    public class Coordinate<TX, TY>
    {
        public TX X { get; private set; }
        public TY Y { get; private set; }

        private string coordinateInput;

        public Coordinate(string coordinate)
        {
            this.coordinateInput = coordinate;

            this.Initialize();
        }

        private void Initialize()
        {
            var cleanInput = this.CleanInput();
            this.SeparateCoordinates(cleanInput);
        }

        private string CleanInput()
        {
            var cleanInput = this.coordinateInput.Trim();
            cleanInput = cleanInput.Replace(" ", string.Empty);
            cleanInput = cleanInput.ToUpper();

            return cleanInput;
        }

        private void SeparateCoordinates(string input) 
        {
            var lastLetterIndex = input
                .Where(c => char.IsLetter(c))
                .Select(i => input.LastIndexOf(i))
                .Max();

            var x = (TX)Convert.ChangeType(input.Substring(0, lastLetterIndex + 1), typeof(TX));
            var y = (TY)Convert.ChangeType(input.Substring(lastLetterIndex + 1), typeof(TY));

            this.X = x;
            this.Y = y;
        }
    }
}