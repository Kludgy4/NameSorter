namespace NameSorter;


public class Program
{
    public static void Main(string[] args)
    {
        // Check that the right number of arguments have been passed in
        if (args == null || args.Length != 1)
        {
            Console.WriteLine("usage: NameSorter relativeInputNamesFilePath");
            return;
        }

        // Check that the file name passed in is valid
        FileStream fileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read);
        StreamReader streamReader = new StreamReader(fileStream);
        
        // Read lines from the file until the end
        List<string> lines = new List<string>();
        while (!streamReader.EndOfStream )
        {
            string? line = streamReader.ReadLine();
            if (line == null) break;
            lines.Add(line);
        }

        List<Name> names = lines.ConvertAll<Name>(l => new Name(l));
        names.Sort();
        
        // Write the names to stdout
        foreach (Name name in names)
        {
            Console.WriteLine(name.FullName());
        }

        // Write the names to a file
        string outputFilePath = "sorted-names-list.txt";
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (Name name in names)
            {
                writer.WriteLine(name.FullName());
            }
        }
        return;
    }
}
