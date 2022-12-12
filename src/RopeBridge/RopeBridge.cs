namespace AdventOfCode;

public class RopeBridge
{
	private readonly List<string> commands;

	public RopeBridge()
	{
		this.commands = File.ReadAllLines(
			"src/RopeBridge/source.txt"
		).ToList();
	}

	public int PartOne() =>
		GetVisitedCoordsCount(2);

	public int PartTwo() =>
		GetVisitedCoordsCount(10);

	private int GetVisitedCoordsCount(int knotCount)
	{
		HashSet<string> visitedCoords = new(); // "x y"

		List<int[]> knotCoords = new();
		for (int i = 0; i < knotCount; i++)
			knotCoords.Add(new[] { 0, 0 }); // x, y

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
						knotCoords.First()[1]++;
						break;
					case "D":
						knotCoords.First()[1]--;
						break;
					case "L":
						knotCoords.First()[0]--;
						break;
					case "R":
						knotCoords.First()[0]++;
						break;
				}
				for (int j = 1; j < knotCoords.Count; j++)
				{
					knotCoords[j] = GetNewTailCoord(
						knotCoords[j - 1],
						knotCoords[j]
					);
				}
				visitedCoords.Add(
					string.Join(" ", knotCoords.Last())
				);
			}
		}
		return visitedCoords.Count;
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
