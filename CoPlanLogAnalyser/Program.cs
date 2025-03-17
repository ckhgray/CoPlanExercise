class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the log file.");
            return;
        }
        string filePath = args[0];
        var processor = new LogProcessor();
        processor.ProcessLogFile(filePath);
    }
}
