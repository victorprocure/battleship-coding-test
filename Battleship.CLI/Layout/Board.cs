using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Battleship.CLI.Ships;
using Battleship.CLI.Utilities;

namespace Battleship.CLI.Layout
{
    public class Board : IBoard
    {
        public IList<IBattleship> Ships { get; }

        public IList<string> ColumnHeaders { get; private set; }
        public IList<string> RowHeaders { get; private set; }

        public int HorizontalTiles { get; }

        public int VerticalTiles { get; }

        private Tile[,] tiles;


        public Board(int numberOfTiles) : this()
        {
            this.HorizontalTiles = numberOfTiles;
            this.VerticalTiles = numberOfTiles;
        }

        public Board(int verticalTiles, int horizontalTiles) : this(verticalTiles)
        {
            this.HorizontalTiles = horizontalTiles;
        }

        public Board()
        {
            this.Ships = new List<IBattleship>();
            this.ColumnHeaders = new string[] { string.Empty };
            this.RowHeaders = new string[] { string.Empty };
        }

        public void AddShip(IBattleship ship)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            this.BuildColumnHeaders();
            this.BuildRowHeaders();
            this.BuildTiles();
        }

        public Tile GetTile(string coordinates)
        {
            var coordinate = new Coordinate<string, int>(coordinates);
            var columnIndex = this.ColumnHeaders.IndexOf(coordinate.X) - 1;
            var rowIndex = this.RowHeaders.IndexOf(coordinate.Y.ToString()) - 1;
            
            return this.tiles[columnIndex, rowIndex];
        }

        private void BuildTiles()
        {
            this.tiles = new Tile[this.HorizontalTiles, this.VerticalTiles];

            for (int x = 0; x < this.HorizontalTiles; x++)
            {
                for (int y = 0; y < this.VerticalTiles; y++)
                {
                    this.tiles[x, y] = new Tile(x, y);
                }
            }
        }

        private void BuildColumnHeaders()
        {
            if (this.HorizontalTiles <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.HorizontalTiles));
            }

            this.ColumnHeaders = this.ColumnHeaders.Concat(Enumerable
                .Range(1, this.HorizontalTiles - 1)
                .Select(n => n.ToAlphabetLetter()))
                .ToList();
        }

        private void BuildRowHeaders()
        {
            if (this.VerticalTiles <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.VerticalTiles));
            }

            this.RowHeaders = this.RowHeaders
                .Concat(Enumerable
                        .Range(1, this.VerticalTiles - 1)
                        .Select(n => n.ToString())
                ).ToList();
        }
    }
}