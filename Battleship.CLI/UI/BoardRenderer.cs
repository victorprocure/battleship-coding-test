using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Battleship.CLI.Layout;

namespace Battleship.CLI.UI
{
    public class BoardRenderer
    {

        public BoardRenderer() { }

        public string DrawBoard(IBoard board)
        {
            var format = Enumerable.Range(0, board.ColumnHeaders.Count)
                .Select(i => $" | {{{i},-{board.Size.X - 3}}}")
                .Aggregate((s, a) => s + a) + "|";

            var divider = $" {string.Join("", Enumerable.Repeat("-", (board.Size.X) * board.ColumnHeaders.Count))} ";
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.Append(divider);
            sb.AppendLine();
            sb.Append(string.Format(format, board.ColumnHeaders.ToArray()));
            sb.AppendLine();

            for (int y = 0; y < board.RowHeaders.Count - 1; y++)
            {
                var list = new List<string>();
                list.Add(board.RowHeaders[y+1]);

                var tiles = board.TileCollection
                    .Where(t=>t.Location.Y == y)
                    .Select(t => {
                        if(t.Ship != null){
                            return "S";
                        } 

                        if(t.Status == TileStatus.Hit){
                            return "X";
                        }

                        if(t.Status == TileStatus.Missed) {
                            return "M";
                        }

                        return "";
                    });
                
                sb.Append(divider);
                sb.AppendLine();
                sb.AppendLine(string.Format(format, new string[] { $"{board.RowHeaders[y+1]}" }
                    .Concat(tiles)
                    .ToArray()));

            }
            sb.Append(divider);
            return sb.ToString();
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