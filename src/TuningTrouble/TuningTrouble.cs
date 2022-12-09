namespace AdventOfCode;

public class TuningTrouble
{
	public static int PartOne()
	{
		string source = File.ReadAllText(
			"src/TuningTrouble/source.txt");

		for (int i = 4; i < source.Length; i++)
		{
			HashSet<char> lastFour = source[(i - 4)..i].ToHashSet();
			if (lastFour.Count == 4)
				return i;
		}

		return -1;
	}
}
