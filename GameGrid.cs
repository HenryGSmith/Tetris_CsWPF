using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_WPF
{
	internal class GameGrid
	{
		private readonly int[,] grid;
		public int Rows { get; }
		public int Cols { get; }

		public int this[int r, int c]
		{
			get => grid[r, c];
			set => grid[r, c] = value;
		}

		public GameGrid(int rows, int cols)
		{
			grid = new int[rows, cols];
			Rows = rows;
			Cols = cols;
		}

		public bool IsInside(int r, int c)
		{
			return r >= 0 && r < Rows && c >= 0 && c < Cols;
		}

		public bool IsEmpty(int r, int c)
		{
			return IsInside(r, c) && grid[r, c] == 0;
		}

		public bool IsRowFull(int r)
		{
			for (int c = 0; c < Cols; c++)
			{
				if (grid[r,c] == 0)
				{
					return false;
				}
			}

			return true;
		}

		public bool IsRowEmpty(int r)
		{
			for (int c = 0; c < Cols; c++)
			{
				if (grid[r,c] != 0)
				{
					return false;
				}
			}

			return true;
		}

		private void ClearRow(int r)
		{
			for (int c = 0; c< Cols; c++)
			{
				grid[r, c] = 0;
			}
		}

		private void MoveRowDown(int r, int numRows)
		{
			for (int c = 0; c < Cols; c++)
			{
				grid[r + numRows, c] = grid[r, c];
				grid[r, c] = 0;
			}
		}

		public int ClearFullRows()
		{
			int clearedRows = 0;
			for (int r = Rows-1; r>= 0; r--)
			{
				if (IsRowEmpty(r)) return clearedRows;

				if (IsRowFull(r)) 
				{
					ClearRow(r);
					clearedRows++;
				} 
				else if (clearedRows > 0)
				{
					MoveRowDown(r, clearedRows);
				}
			}

			return clearedRows;
		}
	}
}
