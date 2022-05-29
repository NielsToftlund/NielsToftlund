 ///<summary>Demo af Pareallel For løkke</summary>
 ///<summary><see href="https://dotnettutorials.net/lesson/parallel-for-method-csharp/"/>Denne artikkel ligger stærkt til grund for dette eksempel</summary>
 
 using System.Diagnostics;
namespace ParallelProgrammingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // stopur så vi kan se eksekverings tider
            var timer = new Stopwatch();
            // så begynder vi
            Console.WriteLine("C# almindeligt For Loop");
            int number = 10;
            timer.Start();
            for (int count = 0; count < number; count++)
            {
                //Thread.CurrentThread.ManagedThreadId returnere et heltal, der representere Thread ID¨'et 
                Console.WriteLine($"Værdien af count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
                //Sleep the loopet i 10 miliseconds
                Thread.Sleep(10);
            }
            timer.Stop();
            Console.WriteLine();
            Console.WriteLine("Tid om at udføre : " + timer.Elapsed.ToString(@"m\:ss\.fff"));
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.WriteLine("C# Parallel For Loop");

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 10 // Begræns antalet af aktive tråde 1 til mange. Hvis den udlades giver den fuld gas.
            };
            timer.Reset(); // Nulstil timer så den kan bruges igen.
            timer.Start();
            Parallel.For(0, number, options, count =>
            {
                Console.WriteLine($"Værdien af count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
                //Sleep the loop for 10 miliseconds
                Thread.Sleep(10);
            });
            timer.Stop();
            Console.WriteLine();
            Console.WriteLine("Tid om at udføre : " + timer.Elapsed.ToString(@"m\:ss\.fff"));
            Console.ReadLine();
        }
    }
}
