﻿namespace NameSorter;


public class Program
{
    public static void Main(string[] args)
    {
        // Check that the right number of arguments have been passed in
        if (args == null || args.Length != 1)
        {
            Console.Error.WriteLine("usage: NameSorter relativeInputNamesFilePath", System.Console.Error);
            return;
        }

        // Attempt to open the file using the provided filename to be sorted
        FileStream fileStream;
        StreamReader streamReader;
        try
        {
            fileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read);
            streamReader = new StreamReader(fileStream);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Unable to open file " + args[0]);
            Console.Error.WriteLine(e.Message);
            return;
        }

        // Read lines from the file until the end
        List<string> lines = new List<string>();
        while (!streamReader.EndOfStream )
        {
            string? line = streamReader.ReadLine();
            if (line == null) break;
            lines.Add(line);
        }

        // Parse names using the default parsing strategy
        NameParsingStrategy nameParsingStrategy = new DyeAndDurhamNameParsingStrategy();
        List<Name> names;
        try
        {
            names = lines.ConvertAll<Name>(l => new Name(nameParsingStrategy.ParseName(l)));
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Error.WriteLine("Invalid Name Format", System.Console.Error);
            Console.Error.WriteLine(e.Message, System.Console.Error);
            return;
        }

        // Sort names using the default sorting strategy (last name then given names)
        NameSortingStrategy nameSortingStrategy = new DyeAndDurhamNameSortingStrategy();
        names.Sort(nameSortingStrategy);
        
        // Write the names to stdout
        foreach (Name name in names)
        {
            Console.WriteLine(name.FullName());
        }

        // Write the names to a file
        string outputFilePath = "sorted-names-list.txt";
        StreamWriter writer;
        try
        {
            writer = new StreamWriter(outputFilePath, true);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Unable to open file " + args[0] + " to write sorted names", System.Console.Error);
            Console.Error.WriteLine(e.Message, System.Console.Error);
            return;
        }

        foreach (Name name in names)
        {
            writer.WriteLine(name.FullName());
        }

        return;
    }
}
