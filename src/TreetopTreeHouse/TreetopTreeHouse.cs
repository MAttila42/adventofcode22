namespace AdventOfCode;

public class TreetopTreeHouse
{
	private readonly int[,] trees;

	private readonly int columnCount;
	private readonly int rowCount;

	public TreetopTreeHouse()
	{
		string[] source = File.ReadAllLines(
			"src/TreetopTreeHouse/source.txt");

		this.columnCount = source[0].Length;
		this.rowCount = source.Length;

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

	public int PartTwo()
	{
		int maxScore = 0;
		for (int y = 0; y < this.rowCount; y++)
			for (int x = 0; x < this.columnCount; x++)
				maxScore = Math.Max(maxScore, ScenicScore(x, y));
		return maxScore;
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
				Console.Write(this.trees[x, y]);
			}
			Console.WriteLine();
		}
	}

	private bool IsHidden(int x, int y)
	{
		int treeHeight = this.trees[x, y];

		if (IsOnEdge(x, y))
			return false;

		int[] column = GetColumn(x);
		int[] row = GetRow(y);

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

	private int ScenicScore(int x, int y)
	{
		if (x == 2 && y == 3)
		{ }

		if (IsOnEdge(x, y))
			return 0;

		int treeHeight = this.trees[x, y];
		int[] column = GetColumn(x);
		int[] row = GetRow(y);
		List<int[]> directions = new();
		List<int> visibleTreeCounts = new();

		directions.Add(row.Take(x).Reverse().ToArray());
		directions.Add(row.Skip(x + 1).ToArray());
		directions.Add(column.Take(y).Reverse().ToArray());
		directions.Add(column.Skip(y + 1).ToArray());

		foreach (int[] direction in directions)
		{
			int n = 0;
			foreach (int tree in direction)
			{
				n++;
				if (tree >= treeHeight || n == direction.Length)
				{
					visibleTreeCounts.Add(n);
					break;
				}
			}
		}

		int score = visibleTreeCounts.First();
		foreach (int visibleTreeCount in visibleTreeCounts.Skip(1))
			score *= visibleTreeCount;

		return score;
	}

	private bool IsOnEdge(int x, int y) =>
		x == 0 || y == 0 ||
		x == this.columnCount - 1 ||
		y == this.rowCount - 1;

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
