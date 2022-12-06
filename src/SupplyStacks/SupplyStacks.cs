using System.Text;

namespace AdventOfCode;

public class SupplyStacks
{
	private readonly List<List<char>> columns;
	private readonly List<Step> steps;

	private readonly string[] source;
	private readonly int separatorLineIndex;

	public SupplyStacks()
	{
		this.columns = new();
		this.steps = new();

		this.source = File.ReadAllLines(
			"src/SupplyStacks/source.txt");
		this.separatorLineIndex = Array.IndexOf(
			source,
			source.First(string.IsNullOrWhiteSpace));

		LoadSteps();
	}

	public string PartOne()
	{
		LoadColumns();

		foreach (Step step in this.steps)
			for (int i = 0; i < step.Count; i++)
			{
				List<char> columnFrom = this.columns[step.From - 1];
				char crate = columnFrom.Last();
				this.columns[step.To - 1].Add(crate);
				columnFrom.RemoveAt(columnFrom.Count - 1);
			}

		StringBuilder sb = new();
		foreach (char crate in this.columns.Select(c => c.Last()))
			sb.Append(crate);

		return sb.ToString();
	}

	public string PartTwo()
	{
		LoadColumns();

		foreach (Step step in this.steps)
			for (int i = 0; i < step.Count; i++)
			{
				List<char> columnFrom = this.columns[step.From - 1];
				List<char> columnTo = this.columns[step.To - 1];
				char crate = columnFrom.Last();
				columnTo.Insert(columnTo.Count - i, crate);
				columnFrom.RemoveAt(columnFrom.Count - 1);
			}

		StringBuilder sb = new();
		foreach (char crate in this.columns.Select(c => c.Last()))
			sb.Append(crate);

		return sb.ToString();
	}

	private void LoadColumns()
	{
		this.columns.Clear();

		int numberOfColumns = this.source[this.separatorLineIndex - 1][^2] - '0';
		for (int i = 0; i < numberOfColumns; i++)
			this.columns.Add(new());

		foreach (string line in this.source.Take(this.separatorLineIndex - 1))
		{
			byte currentColumn = 0;
			for (int i = 1; i < line.Length; i += 4)
			{
				if (line[i] >= 'A' && line[i] <= 'Z')
					this.columns[currentColumn].Insert(0, line[i]);
				currentColumn++;
			}
		}
	}

	private void LoadSteps()
	{
		foreach (string line in this.source.Skip(this.separatorLineIndex + 1))
			this.steps.Add(new Step(line));
	}
}

public class Step
{
	public int Count { get; }
	public int From { get; }
	public int To { get; }

	public Step(string line)
	{
		string[] m = line.Split();
		this.Count = int.Parse(m[1]);
		this.From = int.Parse(m[3]);
		this.To = int.Parse(m[5]);
	}
}
