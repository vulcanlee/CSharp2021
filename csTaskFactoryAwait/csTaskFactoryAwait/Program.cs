using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace csTaskFactoryAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int waitTime = 1000;
            Console.WriteLine($"開始執行");
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Reset();
            stopwatch.Start();
            var task1 = Task.Run(() =>
            {
                Thread.Sleep(waitTime);
            });
            await task1;
            stopwatch.Stop();
            Console.WriteLine($"花費時間為 : {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            var task2 = Task.Run(async () =>
            {
                await Task.Delay(waitTime);
            });
            await task2;
            stopwatch.Stop();
            Console.WriteLine($"花費時間為 : {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            var task3 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(waitTime);
            });
            await task3;
            stopwatch.Stop();
            Console.WriteLine($"花費時間為 : {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            var task4 = Task.Factory.StartNew(async () =>
            {
                await Task.Delay(waitTime);
            });
            await task4;
            stopwatch.Stop();
            Console.WriteLine($"花費時間為 : {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
