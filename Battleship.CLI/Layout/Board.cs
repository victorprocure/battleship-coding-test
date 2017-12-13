using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Battleship.CLI.Ships;

namespace Battleship.CLI.Layout
{
    public class Board : IBoard
    {
        public IList<IBattleship> Ships { get; }

        public Size Size { get; }

        public int HorizontalTiles { get; }

        public int VerticalTiles { get; }


        public int TileHeight { get; private set; }
        public int TileWidth { get; private set; }


        public Board(int width, int height) : this()
        {
            this.Size = new Size(width, height);
        }

        public Board(int width, int height, int numberOfTiles) : this(width, height)
        {
            this.HorizontalTiles = numberOfTiles;
            this.VerticalTiles = numberOfTiles;
        }

        public Board(int width, int height, int verticalTiles, int horizontalTiles) : this(width, height, verticalTiles)
        {
            this.HorizontalTiles = horizontalTiles;
        }

        public Board()
        {
            this.Ships = new List<IBattleship>();
        }

        public void AddShip(IBattleship ship)
        {
            throw new NotImplementedException();
        }

        public string DrawBoard()
        {
            var format = Enumerable.Range(0, this.HorizontalTiles)
                .Select(i => $" | {{{i},-{this.TileWidth - 3}}}")
                .Aggregate((s, a) => s + a) + "|";

            var divider = $" {string.Join("", Enumerable.Repeat("-", this.Size.Width - 1))} ";
            var horizontalHeaders = new string[] { " " }
                .Concat(
                    Enumerable.Range(65, 65 + (this.HorizontalTiles - 1))
                    .Select(e => ((char)e).ToString()))
                .ToArray();
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.Append(divider);
            sb.AppendLine();
            sb.Append(string.Format(format, horizontalHeaders));
            sb.AppendLine();

            for (int y = 0; y < this.VerticalTiles - 1; y++)
            {
                sb.Append(divider);
                sb.AppendLine();
                sb.AppendLine(string.Format(format, new string[] { $"{y + 1}" }.Concat(Enumerable.Repeat("", this.HorizontalTiles - 1)).ToArray()));

            }
            sb.Append(divider);
            return sb.ToString();
        }

        public void Initialize()
        {
            this.VerifySize(this.Size, nameof(this.Size));
            this.VerifySize(this.HorizontalTiles, nameof(this.HorizontalTiles));
            this.VerifySize(this.VerticalTiles, nameof(this.VerticalTiles));

            var tileWidth = (int)Math.Floor((float)this.Size.Width / (float)this.HorizontalTiles);
            var tileHeight = (int)Math.Floor((float)this.Size.Height / (float)this.VerticalTiles);
            this.VerifySize(tileWidth, nameof(tileWidth));
            this.VerifySize(tileHeight, nameof(tileHeight));

            this.TileHeight = tileHeight;
            this.TileWidth = tileWidth;
        }

        private void VerifySize(Size size, string name)
        {
            if (size == null || size.Width == 0 || size.Height == 0)
            {
                throw new ArgumentNullException(name);
            }
        }

        private void VerifySize(int size, string name)
        {
            if (size <= 0)
            {
                throw new ArgumentException(name);
            }
        }
    }
}