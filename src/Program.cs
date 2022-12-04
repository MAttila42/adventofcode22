namespace AdventOfCode;

public class Program
{
	public static void Main()
	{
		// Day 1 - Calorie Counting
		CalorieCounting d1 = new();
		Console.WriteLine(
			$"The most calories an elf carries is {d1.PartOne()}."
		);
		Console.WriteLine(
			$"The top 3 elves carry {d1.PartTwo()} calories.\n"
		);

		// Day 2 - Rock Paper Scissors
		Console.WriteLine(
			$"My total score would be {RockPaperScissors.Answer()}."
		);
	}
}
