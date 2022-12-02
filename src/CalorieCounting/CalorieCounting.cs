namespace AdventOfCode;

class CalorieCounting
{
	public static int Answer()
	{
		List<int> elves = new() { 0 };
		using StreamReader reader = new("src/CalorieCounting/source.txt");
		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine().Trim();
			if (line != "")
				elves[^1] += int.Parse(line);
			else
				elves.Add(0);
		}
		return elves.Max();
	}
}
