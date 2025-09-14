
public class BasicLocking
{
    public static void Main()
    {
        var tasks = new Task[10];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() => ThreadSafe.Do());
        }

        Task.WaitAll(tasks);
        Console.WriteLine("BasicLocking Done");
    }

    class ThreadSafe
    {
        // A new lock class is introduced in C# 13.0 (dotnet 9)
        static readonly Lock _lock = new();
        static int _val1 = 2, _val2 = 1;

        public static void Do()
        {
            lock (_lock)
            {
                // Without the lock, this can throw a DivideByZeroException
                // if another thread sets _val2 to zero between the check and the division.
                if (_val2 != 0) Console.WriteLine(_val1 / _val2);
                else Console.WriteLine("Division by zero avoided.");
                _val2 = 0;
            }
        }
    }
}