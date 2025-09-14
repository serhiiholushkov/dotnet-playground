
using System.Net;

public class WebClientExample
{
    public static void Main()
    {
        // WebClient is obsolete, but this is just an example of EAP pattern
        // Because newer HttpClient does not support EAP it is task-based
        using var client = new WebClient();
        client.DownloadStringCompleted += (s, e) =>
        {
            if (e.Cancelled)
            {
                Console.WriteLine("Download cancelled.");
                return;
            }
            else if (e.Error != null)
            {
                Console.WriteLine($"Error: {e.Error.Message}");
                return;
            }
            Console.WriteLine(e.Result.Length);
        };
        client.DownloadStringAsync(new Uri("https://www.linqpad.net/"));
    }
}