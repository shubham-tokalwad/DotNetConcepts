// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {


        // CanellationTokenSource example
        using var cts = new CancellationTokenSource();

        // Cancel after 3 seconds
        cts.CancelAfter(3000);

        try
        {
            await DoWorkAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task was cancelled!");
        }


    }


    // CanellationTokenSource example
    static async Task DoWorkAsync(CancellationToken token)
    {
        Console.WriteLine("Work started...");

        for (int i = 1; i <= 10; i++)
        {
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Working... {i}");
            await Task.Delay(1000, token); // supports cancellation
        }

        Console.WriteLine("Work completed.");
    }
}
