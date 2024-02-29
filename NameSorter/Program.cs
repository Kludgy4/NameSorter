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
        foreach (Name name in names)
        {
            Console.WriteLine(name.FullName());
        }
        //Console.WriteLine(args[0]);
        return;
    }
}
