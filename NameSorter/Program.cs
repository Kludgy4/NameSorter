namespace NameSorter;

public class Program
{
    public static void Main(string[] args)
    {
        // Check that the right number of arguments have been passed in
        if (args == null || args.Length != 1)
        {
            Console.WriteLine("usage: NameSorter inputNamesFile");
            return;
        }

        // Check that the file name passed in is valid
        FileStream fileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read);
        StreamReader streamReader = new StreamReader(fileStream);
        
        // Read lines from the file until the end
        List<String> lines = new List<String>();
        while (!streamReader.EndOfStream )
        {
            string line = streamReader.ReadLine();
            lines.Add(line);
        }

        Console.WriteLine(args[0]);
        return;
    }
}
