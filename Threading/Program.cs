
Console.WriteLine("Starting Threading/BasicLocking");
BasicLocking.Main();
Console.WriteLine("Finished Threading/BasicLocking");
// Console.ReadKey();

Console.WriteLine("Starting Threading/EAP/WebClientExample");
WebClientExample.Run();
// Next finish line output will not wait for the async operation to complete
// and will likely be written before complete event hendler is executed
Console.WriteLine("Finished Threading/EAP/WebClientExample");
Console.ReadKey();

Console.WriteLine("Starting Threading/EAP/BackgroundWorkerExample");
BackgroundWorkerExample.Run();
Console.WriteLine("Finished Threading/EAP/BackgroundWorkerExample");
Console.ReadKey();


Console.WriteLine("All Threading Done");