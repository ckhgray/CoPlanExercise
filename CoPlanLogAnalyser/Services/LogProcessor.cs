    public class LogProcessor
    {
        public void ProcessLogFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var lines = File.ReadLines(filePath).Skip(1); // skipping header line

            int totalTasks = 0;
            int successfulQueryCount = 0;
            int successfulCommandCount = 0;
            // int failedQueryCount = 0;
            // int failedCommandCount = 0;
            long totalQueryTime = 0;
            long totalCommandTime = 0;

            foreach (var line in lines)
            {
                totalTasks++;

                if (Log.TryParse(line, out var log))
                {
                    if (log.WasSuccess)
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
                    // else
                    // {
                    //     if (log.IsQuery)
                    //     {
                    //         failedQueryCount++;
                    //     }
                    //     else if (log.IsCommand)
                    //     {
                    //         failedCommandCount++;
                    //     }
                    // }
                }
            }

            //int totalFailures = failedQueryCount + failedCommandCount;

            // Displaying results
            Console.WriteLine();
            Console.WriteLine("----- Log File Statistics -----");
            // Console.WriteLine($"Total Tasks Processed: {totalTasks}");
            // Console.WriteLine();
            
            Console.WriteLine($"Successful Query Tasks: {successfulQueryCount}");
            //Console.WriteLine($"Failed Query Tasks: {failedQueryCount}");
            Console.WriteLine($"Average Time for Query Tasks: {AverageTime(totalQueryTime, successfulQueryCount)} ms");
            Console.WriteLine();

            Console.WriteLine($"Successful Command Tasks: {successfulCommandCount}");
            //Console.WriteLine($"Failed Command Tasks: {failedCommandCount}");
            Console.WriteLine($"Average Time for Command Tasks: {AverageTime(totalCommandTime, successfulCommandCount)} ms");
            Console.WriteLine();

            // Console.WriteLine($"Total Failures: {totalFailures}");
        }

        private double AverageTime(long total, int count)
        {
            return count > 0 ? (double)total / count : 0;
        }
    }

