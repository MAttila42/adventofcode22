namespace AdventOfCode;

public class TreetopTreeHouse
{
	private readonly int[,] trees;

	private readonly int rowCount;
	private readonly int columnCount;

	public TreetopTreeHouse()
	{
		string[] source = File.ReadAllLines(
			"src/TreetopTreeHouse/source.txt");

		this.rowCount = source.Length;
		this.columnCount = source[0].Length;

		this.trees = new int[this.columnCount, this.rowCount];

		for (int y = 0; y < this.rowCount; y++)
			for (int x = 0; x < this.columnCount; x++)
				this.trees[x, y] = source[y][x] - '0';
	}

	public int PartOne()
	{
		int visibleCount = 0;

		for (int y = 0; y < this.rowCount; y++)
			for (int x = 0; x < this.columnCount; x++)
				if (!IsHidden(x, y))
					visibleCount++;

		return visibleCount;
	}

	public void Draw()
	{
		for (int y = 0; y < this.rowCount; y++)
		{
			for (int x = 0; x < this.columnCount; x++)
			{
				if (!IsHidden(x, y))
					Console.ForegroundColor = ConsoleColor.Red;
				else
					Console.ForegroundColor = ConsoleColor.Green;

				if (x == 0 && y == 97)
				{ }

				if (x == 2 && y == 97)
				{ }

				Console.Write(this.trees[x, y]);
			}
			Console.WriteLine();
		}
	}

	private bool IsHidden(int x, int y)
	{
		if (x == 0 && y == 97)
		{ }

		if (x == 2 && y == 97)
		{ }

		int treeHeight = this.trees[x, y];

		if (x == 0 ||
			y == 0 ||
			x == this.columnCount - 1 ||
			y == this.rowCount - 1)
			return false;

		int[] row = GetRow(y);
		int[] column = GetColumn(x);

		if (!row.Take(x).Any(t => t >= treeHeight))
			return false;
		if (!row.Skip(x + 1).Any(t => t >= treeHeight))
			return false;
		if (!column.Take(y).Any(t => t >= treeHeight))
			return false;
		if (!column.Skip(y + 1).Any(t => t >= treeHeight))
			return false;

		return true;
	}

	private int[] GetRow(int y)
	{
		int[] row = new int[this.rowCount];
		for (int i = 0; i < this.rowCount; i++)
			row[i] = this.trees[i, y];
		return row;
	}

	private int[] GetColumn(int x)
	{
		int[] column = new int[this.columnCount];
		for (int i = 0; i < this.columnCount; i++)
			column[i] = this.trees[x, i];
		return column;
	}
}
