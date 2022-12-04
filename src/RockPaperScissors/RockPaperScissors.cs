namespace AdventOfCode;

class RockPaperScissors
{
	public static int Answer()
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
			else if (opponent == "A" && player == "B")
				score += 6;
			else if (opponent == "A" && player == "C")
				score += 0;
			else if (opponent == "B" && player == "A")
				score += 0;
			else if (opponent == "B" && player == "C")
				score += 6;
			else if (opponent == "C" && player == "A")
				score += 6;
			else if (opponent == "C" && player == "B")
				score += 0;
		}
		return score;
	}
}
