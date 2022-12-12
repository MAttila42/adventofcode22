namespace AdventOfCode;

public class RopeBridge
{
	private readonly HashSet<string> visitedCoords; // "x y"
	private readonly List<string> commands;

	public RopeBridge()
	{
		this.visitedCoords = new();
		this.commands = File.ReadAllLines(
			"src/RopeBridge/source.txt"
		).ToList();
		Simulate();
	}

	public int PartOne() =>
		this.visitedCoords.Count;

	private void Simulate()
	{
		// x, y
		int[] headCoord = { 0, 0 };
		int[] tailCoord = { 0, 0 };

		foreach (string command in this.commands)
		{
			string[] m = command.Split();
			string direction = m[0];
			int distance = int.Parse(m[1]);

			for (int i = 0; i < distance; i++)
			{
				switch (direction)
				{
					case "U":
						headCoord[1]++;
						break;
					case "D":
						headCoord[1]--;
						break;
					case "L":
						headCoord[0]--;
						break;
					case "R":
						headCoord[0]++;
						break;
				}
				tailCoord = GetNewTailCoord(
					headCoord,
					tailCoord
				);
				this.visitedCoords.Add(
					$"{tailCoord[0]} {tailCoord[1]}"
				);
			}
		}
	}

	private static int[] GetNewTailCoord(int[] headCoord, int[] tailCoord)
	{
		if (tailCoord[0] >= headCoord[0] - 1 &&
			tailCoord[0] <= headCoord[0] + 1 &&
			tailCoord[1] >= headCoord[1] - 1 &&
			tailCoord[1] <= headCoord[1] + 1)
			return tailCoord;

		if (headCoord[0] > tailCoord[0])
			tailCoord[0]++;
		if (headCoord[0] < tailCoord[0])
			tailCoord[0]--;
		if (headCoord[1] > tailCoord[1])
			tailCoord[1]++;
		if (headCoord[1] < tailCoord[1])
			tailCoord[1]--;

		return tailCoord;
	}
}
