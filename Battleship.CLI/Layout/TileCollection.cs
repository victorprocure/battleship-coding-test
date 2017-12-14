using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Battleship.CLI.Layout
{
    public class TileCollection: IEnumerable<Tile>
    {
        public Tile this[int colIndex, int rowIndex]
        {
            get
            {
                return this.tiles[colIndex, rowIndex];
            }
        }

        private Tile[,] tiles;

        public TileCollection(int horizontalTiles, int verticalTiles)
        {
            this.CreateTiles(horizontalTiles, verticalTiles);
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            foreach(var tile in this.tiles) 
            {
                yield return tile;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private void CreateTiles(int horizontalTiles, int verticalTiles)
        {
            this.tiles = new Tile[horizontalTiles, verticalTiles];

            for (int x = 0; x < horizontalTiles; x++)
            {
                for (int y = 0; y < verticalTiles; y++)
                {
                    this.tiles[x, y] = new Tile(x, y);
                }
            }
        }

    }
}