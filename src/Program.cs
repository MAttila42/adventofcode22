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

		// Day 3 - Rucksack Reorganization
		Console.WriteLine(
			"\nDay Three"
		);
		Console.WriteLine(
			$"\tPart One - {RucksackReorganization.PartOne()}"
		);
		Console.WriteLine(
			$"\tPart Two - {RucksackReorganization.PartTwo()}"
		);

		// Day 4 - Camp Cleanup
		Console.WriteLine(
			"\nDay Four"
		);
		Console.WriteLine(
			$"\tPart One - {CampCleanup.PartOne()}"
		);
		Console.WriteLine(
			$"\tPart Two - {CampCleanup.PartTwo()}"
		);

		// Day 5 - Supply Stacks
		SupplyStacks d5 = new();
		Console.WriteLine(
			"\nDay Five"
		);
		Console.WriteLine(
			$"\tPart One - {d5.PartOne()}"
		);
		Console.WriteLine(
			$"\tPart Two - {d5.PartTwo()}"
		);

		// Day 6 - Tuning Trouble
		TuningTrouble d6 = new();
		Console.WriteLine(
			"\nDay Six"
		);
		Console.WriteLine(
			$"\tPart One - {d6.PartOne()}"
		);
		Console.WriteLine(
			$"\tPart Two - {d6.PartTwo()}"
		);

		// Day 7 - No Space Left On Device
		NoSpaceLeftOnDevice d7 = new();
		Console.WriteLine(
			"\nDay Seven"
		);
		Console.WriteLine(
			$"\tPart One - {d7.PartOne()}"
		);
		Console.WriteLine(
			$"\tPart Two - {d7.PartTwo()}"
		);

		// Day 8 - TreetopTreeHouse
		TreetopTreeHouse d8 = new();
		Console.WriteLine(
			"\nDay Eight"
		);
		Console.WriteLine(
			$"\tPart One - {d8.PartOne()}"
		);
		// d8.Draw();
		Console.WriteLine(
			$"\tPart Two - {d8.PartTwo()}"
		);
	}
}
