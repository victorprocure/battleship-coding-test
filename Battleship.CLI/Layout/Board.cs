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
        public IList<string> ColumnHeaders { get; private set; }
        public IList<string> RowHeaders { get; private set; }

        public TileCollection TileCollection => tileCollection;

        public Point Size => new Point(this.numberOfHorizontalTiles, this.numberOfVerticalTiles);

        private TileCollection tileCollection;
        private IList<IBattleship> ships;

        private readonly int headerPadding = 1;
        private int numberOfHorizontalTiles;
        private int numberOfVerticalTiles;


        public Board(int numberOfTiles) : this(numberOfTiles, numberOfTiles) { }

        public Board(int verticalTiles, int horizontalTiles)
        {
            this.numberOfHorizontalTiles = horizontalTiles - 1;
            this.numberOfVerticalTiles = verticalTiles - 1;

            this.ships = new List<IBattleship>();
            this.ColumnHeaders = new string[] { string.Empty };
            this.RowHeaders = new string[] { string.Empty };

            this.Initialize();
        }

        public void AddShip(string coordinates, IBattleship ship)
        {
            var tileIndex = this.GetTileIndex(coordinates);

            var colCount = this.numberOfHorizontalTiles - ship.Size.Width;
            var rowCount = this.numberOfVerticalTiles - ship.Size.Height;

            var x = (tileIndex.X).Clamp(colCount, 0);
            var y = (tileIndex.Y).Clamp(rowCount, 0);

            var shipTiles = from Tile tile in this.tileCollection
                            where tile.Location.X >= x && tile.Location.X < x + ship.Size.Width &&
                                tile.Location.Y >= y && tile.Location.Y < y + ship.Size.Height
                            select tile;

            foreach (var tile in shipTiles)
            {
                tile.AddShip(ship);
            }

        }

        public void MoveShip(string coordinates, IBattleship ship) {
            foreach(var tile in this.tileCollection){
                tile.RemoveShip();
            }

            this.AddShip(coordinates, ship);
        }

        public Tile GetTile(string coordinates)
        {

            var tileIndex = this.GetTileIndex(coordinates);
            return this.tileCollection[tileIndex.X, tileIndex.Y];
        }

        private void Initialize()
        {
            this.BuildColumnHeaders();
            this.BuildRowHeaders();
            this.tileCollection = new TileCollection(this.numberOfHorizontalTiles, this.numberOfVerticalTiles);
        }

        private Point GetTileIndex(string coordinates)
        {
            var coordinate = new Coordinate<string, int>(coordinates);
            var columnIndex = this.ColumnHeaders.IndexOf(coordinate.X) - this.headerPadding;
            var rowIndex = this.RowHeaders.IndexOf(coordinate.Y.ToString()) - this.headerPadding;

            if (columnIndex == -1 || rowIndex == -1)
            {
                throw new IndexOutOfRangeException("Tile was not found");
            }

            return new Point(columnIndex, rowIndex);
        }

        private void BuildColumnHeaders()
        {
            if (this.numberOfHorizontalTiles <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.numberOfHorizontalTiles));
            }

            this.ColumnHeaders = this.ColumnHeaders.Concat(Enumerable
                .Range(1, this.numberOfHorizontalTiles)
                .Select(n => n.ToAlphabetLetter()))
                .ToList();
        }

        private void BuildRowHeaders()
        {
            if (this.numberOfVerticalTiles <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.numberOfVerticalTiles));
            }

            this.RowHeaders = this.RowHeaders
                .Concat(Enumerable
                        .Range(1, this.numberOfVerticalTiles)
                        .Select(n => n.ToString())
                ).ToList();
        }
    }
}