namespace AdventOfCode;

public class RucksackReorganization
{
	public static int PartOne()
	{
		int prioritySum = 0;
		using StreamReader reader = new("src/RucksackReorganization/source.txt");
		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine();
			int half = line.Length / 2;
			HashSet<char> first = line[..half].ToHashSet();
			HashSet<char> second = line[half..].ToHashSet();
			char error = first.Intersect(second).First();
			if (error >= 'A' && error <= 'Z')
				prioritySum += error - 'A' + 27;
			else
				prioritySum += error - 'a' + 1;
		}
		return prioritySum;
	}
}
