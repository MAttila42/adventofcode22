namespace AdventOfCode;

public class CalorieCounting
{
	private readonly List<int> elves;

	public CalorieCounting()
	{
		this.elves = new List<int>() { 0 };

		using StreamReader reader = new(
			"src/CalorieCounting/source.txt");

		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine().Trim();
			if (line != "")
				this.elves[^1] += int.Parse(line);
			else
				this.elves.Add(0);
		}

		this.elves = this.elves.OrderDescending().ToList();
	}

	public int PartOne() =>
		this.elves[0];

	public int PartTwo() =>
		this.elves[0] + this.elves[1] + this.elves[2];
}
