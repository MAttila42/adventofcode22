namespace AdventOfCode;

public class Program
{
	public static void Main()
	{
		// Day 1 - Calorie Counting
		CalorieCounting d1 = new();
		Console.WriteLine(
			"Day One"
		);
		Console.WriteLine(
			$"\tPart One - {d1.PartOne()}"
		);
		Console.WriteLine(
			$"\tPart Two - {d1.PartTwo()}"
		);

		// Day 2 - Rock Paper Scissors
		Console.WriteLine(
			"\nDay Two"
		);
		Console.WriteLine(
			$"\tPart One - {RockPaperScissors.PartOne()}"
		);
		Console.WriteLine(
			$"\tPart Two - {RockPaperScissors.PartTwo()}"
		);
	}
}
