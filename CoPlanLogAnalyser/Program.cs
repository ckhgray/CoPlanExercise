class Program
{
    static void Main(string[] args)
    {
        string filePath;
        
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the log file:");
            filePath = Console.ReadLine();
        }
        else
        {
            filePath = args[0];
        }

        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("No file path provided. Exiting...");
            return;
        }

        var processor = new LogProcessor();
        processor.ProcessLogFile(filePath);
    }
}
