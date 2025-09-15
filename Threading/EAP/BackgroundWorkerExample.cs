using System.ComponentModel;

public class BackgroundWorkerExample
{
    private static BackgroundWorker? _worker;

    public static void Run()
    {
        _worker = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        _worker.DoWork += DoWork;
        _worker.ProgressChanged += ProgressChanged;
        _worker.RunWorkerCompleted += RunWorkerCompleted;

        _worker.RunWorkerAsync("Hello, BackgroundWorker!");

        Console.WriteLine("Press any key in next seconds to cancel...");
        Console.ReadKey();
        if (_worker.IsBusy) _worker.CancelAsync();
    }

    private static void DoWork(object? sender, DoWorkEventArgs e)
    {
        // if (sender == null || sender.GetType() != typeof(BackgroundWorker))
        // {
        //     throw new ArgumentException("Sender is not BackgroundWorker");
        // }
        // var worker = sender as BackgroundWorker;
        var message = e.Argument as string;
        var worker = (BackgroundWorker?)sender;
        if (worker == null)
        {
            throw new ArgumentException("Sender is not BackgroundWorker");
        }

        for (int i = 1; i <= 10; i++)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            // Simulate long task
            Thread.Sleep(500);
            worker.ReportProgress(i * 10, $"{message} - Progress: {i * 10}%");
        }

        e.Result = "Task Completed Successfully!";
    }
    private static void ProgressChanged(object? sender, ProgressChangedEventArgs e)
    {
        Console.WriteLine(e.ProgressPercentage + "% - " + e.UserState);
    }
    private static void RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            Console.WriteLine("Task was cancelled.");
        }
        else if (e.Error != null)
        {
            Console.WriteLine("Error: " + e.Error.Message);
        }
        else
        {
            Console.WriteLine(e.Result);
        }
    }
}