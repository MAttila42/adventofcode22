namespace AdventOfCode;

public class CathodeRayTube
{
	private readonly List<int> cycles;

	public CathodeRayTube()
	{
		this.cycles = new() { 1 };

		using StreamReader reader = new("src/CathodeRayTube/source.txt");

		string lastCommand = "noop";
		while (!reader.EndOfStream)
		{
			string[] command = reader.ReadLine().Split();

			if (lastCommand == "noop")
				this.cycles.Add(this.cycles.Last());
			lastCommand = command[0];

			if (command[0] == "addx")
			{
				this.cycles.Add(this.cycles.Last());
				this.cycles.Add(this.cycles.Last() + int.Parse(command[1]));
			}
		}
	}

	public int PartOne()
	{
		int sum = 0;
		for (int i = 20; i <= 220; i += 40)
			sum += this.cycles[i] * i;
		return sum;
	}
}
