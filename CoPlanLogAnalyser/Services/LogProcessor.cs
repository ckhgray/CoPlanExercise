    public class LogProcessor
    {
        public void ProcessLogFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var lines = File.ReadLines(filePath).Skip(1); //skipping header line

            int successfulQueryCount = 0;
            int successfulCommandCount = 0;
            long totalQueryTime = 0;
            long totalCommandTime = 0;

            foreach (var line in lines)
            {
                if (Log.TryParse(line, out var log) && log.WasSuccess)
                {
                    if (log.IsQuery)
                    {
                        successfulQueryCount++;
                        totalQueryTime += log.TimeTaken;
                    }
                    else if (log.IsCommand)
                    {
                        successfulCommandCount++;
                        totalCommandTime += log.TimeTaken;
                    }
                }
            }

            Console.WriteLine($"Successful Query Tasks: {successfulQueryCount}");
            Console.WriteLine($"Successful Command Tasks: {successfulCommandCount}");
            Console.WriteLine($"Average Time for Query Tasks: {AverageTime(totalQueryTime, successfulQueryCount)} ms");
            Console.WriteLine($"Average Time for Command Tasks: {AverageTime(totalCommandTime, successfulCommandCount)} ms");
        }

        private double AverageTime(long total, int count)
        {
            return count > 0 ? (double)total / count : 0;
        }
    }

