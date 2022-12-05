namespace AdventOfCode;

public class RucksackReorganization
{
	public static int PartOne()
	{
		int prioritySum = 0;
		using StreamReader reader = new(
			"src/RucksackReorganization/source.txt");

		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine();
			int half = line.Length / 2;
			HashSet<char> first = line[..half].ToHashSet();
			HashSet<char> second = line[half..].ToHashSet();
			char error = first.Intersect(second).First();
			prioritySum += GetPriority(error);
		}
		return prioritySum;
	}

	public static int PartTwo()
	{
		int prioritySum = 0;
		using StreamReader reader = new(
			"src/RucksackReorganization/source.txt");

		while (!reader.EndOfStream)
		{
			HashSet<char> first = reader.ReadLine().ToHashSet();
			HashSet<char> second = reader.ReadLine().ToHashSet();
			HashSet<char> third = reader.ReadLine().ToHashSet();
			char error = first.Intersect(second).Intersect(third).First();
			prioritySum += GetPriority(error);
		}
		return prioritySum;
	}

	private static int GetPriority(char c)
	{
		if (c >= 'A' && c <= 'Z')
			return c - 'A' + 27;
		else
			return c - 'a' + 1;
	}
}
