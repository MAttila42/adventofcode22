namespace AdventOfCode;

public class CampCleanup
{
	public static int PartOne()
	{
		int count = 0;
		using StreamReader reader = new(
			"src/CampCleanup/source.txt");
		while (!reader.EndOfStream)
		{
			string[] m = reader.ReadLine().Split(',');
			int[] assignmentOne = m[0].Split('-')
				.Select(int.Parse).ToArray();
			int[] assignmentTwo = m[1].Split('-')
				.Select(int.Parse).ToArray();
			if (assignmentOne[0] <= assignmentTwo[0] &&
				assignmentOne[1] >= assignmentTwo[1] ||
				assignmentTwo[0] <= assignmentOne[0] &&
				assignmentTwo[1] >= assignmentOne[1])
				count++;
		}
		return count;
	}

	public static int PartTwo()
	{
		int count = 0;
		using StreamReader reader = new(
			"src/CampCleanup/source.txt");
		while (!reader.EndOfStream)
		{
			string[] m = reader.ReadLine().Split(',');
			int[] assignmentOne = m[0].Split('-')
				.Select(int.Parse).ToArray();
			int[] assignmentTwo = m[1].Split('-')
				.Select(int.Parse).ToArray();
			if (assignmentOne[0] >= assignmentTwo[0] &&
				assignmentOne[0] <= assignmentTwo[1] ||
				assignmentOne[1] >= assignmentTwo[0] &&
				assignmentOne[1] <= assignmentTwo[1] ||
				assignmentTwo[0] >= assignmentOne[0] &&
				assignmentTwo[0] <= assignmentOne[1] ||
				assignmentTwo[1] >= assignmentOne[0] &&
				assignmentTwo[1] <= assignmentOne[1])
				count++;
		}
		return count;
	}
}
