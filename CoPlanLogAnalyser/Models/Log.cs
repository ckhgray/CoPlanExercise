using System.Globalization;

public class Log
{
    public int RequestId { get; set; }
    public DateTime RequestStarted { get; set; }
    public string TaskName { get; set; }
    public int TimeTaken { get; set; }
    public bool WasSuccess { get; set; }
    public int RequestContentLength { get; set; }
    public int ResponseContentLength { get; set; }
    public bool IsQuery => TaskName.EndsWith("Query", StringComparison.OrdinalIgnoreCase);
    public bool IsCommand => TaskName.EndsWith("Command", StringComparison.OrdinalIgnoreCase);

    public static bool TryParse(string line, out Log log)
    {
        log = null;
        var fields = line.Split(';');

        if (fields.Length != 7)
            return false;

        try
        {
            log = new Log
            {
                RequestId = int.Parse(fields[0].Trim()),
                RequestStarted = DateTime.Parse(fields[1].Trim(), CultureInfo.InvariantCulture),
                TaskName = fields[2].Trim(),
                TimeTaken = int.Parse(fields[3].Trim()),
                WasSuccess = bool.Parse(fields[4].Trim()),
                RequestContentLength = int.Parse(fields[5].Trim()),
                ResponseContentLength = int.Parse(fields[6].Trim())
            };

            return true;
        }
        catch
        {
            return false;
        }
    }
}
