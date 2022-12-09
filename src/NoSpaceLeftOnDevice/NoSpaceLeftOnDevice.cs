namespace AdventOfCode;

public class NoSpaceLeftOnDevice
{
	public static int PartOne()
	{
		using StreamReader reader = new(
			"src/NoSpaceLeftOnDevice/source.txt");

		Dictionary<string, int> directorySizes = new();
		Stack<string> currentPath = new();

		while (!reader.EndOfStream)
		{
			string[] m = reader.ReadLine().Split();
			string pathStr = string.Join("/", currentPath.Reverse());

			if (m[0] == "$")
			{
				if (m[1] == "cd")
				{
					string dir = m[2];
					if (dir == "..")
						currentPath.Pop();
					else
					{
						currentPath.Push(dir);
						directorySizes.Add($"{pathStr}/{dir}", 0);
					}
				}
			}
			else
			{
				if (int.TryParse(m[0], out int size))
					foreach (string directory in directorySizes.Select(d => d.Key))
						if (pathStr.StartsWith(directory))
							directorySizes[directory] += size;
			}
		}

		return directorySizes
			.Where(d => d.Value <= 100000)
			.Sum(d => d.Value);
	}
}
