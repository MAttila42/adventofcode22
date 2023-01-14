namespace AdventOfCode;

public class MonkeyInTheMiddle
{
	private readonly List<Monkey> monkeys;

	public MonkeyInTheMiddle()
	{
		monkeys = new();

		using StreamReader reader = new(
			"src/MonkeyInTheMiddle/source.txt");

		while (!reader.EndOfStream)
		{
			int id = int.Parse(
				reader.ReadLine().Split()[1]);

			List<int> items = reader
				.ReadLine()
				.Split(':')[1]
				.Split(',')
				.Select(int.Parse)
				.ToList();

			string[] operationLine = reader.ReadLine().Trim().Split();
			Tuple<char, int> operation = new(
				operationLine[4][0],
				int.Parse(operationLine[5]));

			Tuple<int, int, int> test = new(
				int.Parse(reader.ReadLine().Split().Last()),
				int.Parse(reader.ReadLine().Split().Last()),
				int.Parse(reader.ReadLine().Split().Last()));

			Monkey monkey = new()
			{
				Id = id,
				Items = items,
				Operation = operation,
				Test = test
			};

			monkeys.Add(monkey);
		}
	}

	private class Monkey
	{
		public int Id { get; set; }
		public List<int> Items { get; set; }
		public Tuple<char, int> Operation { get; set; }
		public Tuple<int, int, int> Test { get; set; }
	}
}
