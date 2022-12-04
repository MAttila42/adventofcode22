namespace AdventOfCode;

public class RockPaperScissors
{
	public static int PartOne()
	{
		int score = 0;
		using StreamReader reader = new("src/RockPaperScissors/source.txt");
		while (!reader.EndOfStream)
		{
			string[] m = reader.ReadLine().Split();
			string opponent = m[0];
			string player = "";

			switch (m[1])
			{
				case "X":
					score += 1;
					player = "A";
					break;
				case "Y":
					score += 2;
					player = "B";
					break;
				case "Z":
					score += 3;
					player = "C";
					break;
			}

			if (opponent == player)
				score += 3;
			else if (
				opponent == "A" && player == "B" ||
				opponent == "B" && player == "C" ||
				opponent == "C" && player == "A")
				score += 6;
		}
		return score;
	}

	public static int PartTwo()
	{
		int score = 0;
		using StreamReader reader = new("src/RockPaperScissors/source.txt");
		while (!reader.EndOfStream)
		{
			string[] m = reader.ReadLine().Split();
			string opponent = m[0];
			string player = m[1];

			switch (player)
			{
				case "X":
					switch (opponent)
					{
						case "A":
							score += 3;
							break;
						case "B":
							score += 1;
							break;
						case "C":
							score += 2;
							break;
					}
					break;
				case "Y":
					switch (opponent)
					{
						case "A":
							score += 1;
							break;
						case "B":
							score += 2;
							break;
						case "C":
							score += 3;
							break;
					}
					score += 3;
					break;
				case "Z":
					switch (opponent)
					{
						case "A":
							score += 2;
							break;
						case "B":
							score += 3;
							break;
						case "C":
							score += 1;
							break;
					}
					score += 6;
					break;
			}
		}
		return score;
	}
}
