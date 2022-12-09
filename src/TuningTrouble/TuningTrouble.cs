namespace AdventOfCode;

public class TuningTrouble
{
	private readonly string source;

	public TuningTrouble()
	{
		this.source = File.ReadAllText(
			"src/TuningTrouble/source.txt");
	}

	public int PartOne() =>
		IndexOfFirstUniqueString(4);

	public int PartTwo() =>
		IndexOfFirstUniqueString(14);

	private int IndexOfFirstUniqueString(int length)
	{
		for (int i = length; i < this.source.Length; i++)
		{
			HashSet<char> lastFour = this.source[(i - length)..i].ToHashSet();
			if (lastFour.Count == length)
				return i;
		}
		return -1;
	}
}
