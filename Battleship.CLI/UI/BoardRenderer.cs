using System.Linq;
using Battleship.CLI.Layout;

namespace Battleship.CLI.UI
{
    public class BoardRenderer
    {
        private IBoard board;

        public BoardRenderer(IBoard board) {
            this.board = board;
        }

        // public string DrawBoard()
        // {
        //     var format = Enumerable.Range(0, this.board.HorizontalTiles)
        //         .Select(i => $" | {{{i},-{this.board.TileWidth - 3}}}")
        //         .Aggregate((s, a) => s + a) + "|";

        //     var divider = $" {string.Join("", Enumerable.Repeat("-", this.Size.Width - 1))} ";
        //     var horizontalHeaders = new string[] { " " }
        //         .Concat(
        //             Enumerable.Range(65, 65 + (this.board.HorizontalTiles - 1))
        //             .Select(e => ((char)e).ToString()))
        //         .ToArray();
        //     var sb = new StringBuilder();
        //     sb.AppendLine();
        //     sb.Append(divider);
        //     sb.AppendLine();
        //     sb.Append(string.Format(format, horizontalHeaders));
        //     sb.AppendLine();

        //     for (int y = 0; y < this.VerticalTiles - 1; y++)
        //     {
        //         sb.Append(divider);
        //         sb.AppendLine();
        //         sb.AppendLine(string.Format(format, new string[] { $"{y + 1}" }.Concat(Enumerable.Repeat("", this.HorizontalTiles - 1)).ToArray()));

        //     }
        //     sb.Append(divider);
        //     return sb.ToString();
        // }

        // private void VerifySize(Size size, string name)
        // {
        //     if (size == null || size.Width == 0 || size.Height == 0)
        //     {
        //         throw new ArgumentNullException(name);
        //     }
        // }

        // private void VerifySize(int size, string name)
        // {
        //     if (size <= 0)
        //     {
        //         throw new ArgumentException(name);
        //     }
        // }
    }
}