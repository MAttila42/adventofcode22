using System.Text;

namespace AdventOfCode;

public class SupplyStacks
{
	List<List<char>> columns;
	List<Step> steps;

	public SupplyStacks()
	{
		this.columns = new();
		this.steps = new();

		string[] source = File.ReadAllLines(
			"src/SupplyStacks/source.txt");
		int separatorLineIndex = Array.IndexOf(
			source,
			source.First(string.IsNullOrWhiteSpace));

		LoadColumns(source, separatorLineIndex);
		LoadSteps(source, separatorLineIndex);
	}

	public string PartOne()
	{
		foreach (Step step in this.steps)
			for (int i = 0; i < step.Count; i++)
			{
				char crate = this.columns[step.From - 1].Last();
				this.columns[step.To - 1].Add(crate);
				this.columns[step.From - 1].RemoveAt(
					this.columns[step.From - 1].Count - 1);
			}

		StringBuilder sb = new();
		foreach (char crate in this.columns.Select(c => c.Last()))
			sb.Append(crate);

		return sb.ToString();
	}

	private void LoadColumns(string[] source, int separatorLineIndex)
	{
		int numberOfColumns = source[separatorLineIndex - 1][^2] - '0';
		for (int i = 0; i < numberOfColumns; i++)
			this.columns.Add(new());

		foreach (string line in source.Take(separatorLineIndex - 1))
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

	private void LoadSteps(string[] source, int separatorLineIndex)
	{
		foreach (string line in source.Skip(separatorLineIndex + 1))
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
