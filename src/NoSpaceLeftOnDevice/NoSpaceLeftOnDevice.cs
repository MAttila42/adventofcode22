namespace AdventOfCode;

public class NoSpaceLeftOnDevice
{
	private readonly Dictionary<string, int> directories;
	private readonly Stack<string> currentPath;

	private string PathStr =>
		string.Join("/", this.currentPath.Reverse());

	public NoSpaceLeftOnDevice()
	{
		this.directories = new();
		this.currentPath = new();
	}

	public int PartOne()
	{
		using StreamReader reader = new(
			"src/NoSpaceLeftOnDevice/source.txt");

		while (!reader.EndOfStream)
		{
			string[] m = reader.ReadLine().Split();

			if (m[1] == "cd")
			{
				if (m[2] == "..")
					this.currentPath.Pop();
				else
				{
					this.currentPath.Push(m[2]);
					this.directories.Add(this.PathStr, 0);
				}
			}
			else
			{
				if (int.TryParse(m[0], out int size))
					foreach (string directory in this.directories.Select(d => d.Key))
						if (this.PathStr.StartsWith(directory))
							this.directories[directory] += size;
			}
		}

		return directories
			.Where(d => d.Value <= 100000)
			.Sum(d => d.Value);
	}

	public int PartTwo()
	{
		int freeUp = this.directories["/"] - 40000000;
		return this.directories
			.Where(d => d.Value >= freeUp)
			.Min(d => d.Value);
	}
}
