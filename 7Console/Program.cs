using System;
using System.Threading.Tasks;

namespace _7Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            void WriteLine(string text) => Console.WriteLine(text);

            WriteLine("C# 7 Feature Exploration");

            (int id, string name) GetIdentity() => (id: 10_24_42_80, name: "Eddy");
            var (id, name) = GetIdentity();
            WriteLine($"\tId: {id}\n\tName: {name}");
            Console.ReadKey();

            var processor = new ProcessorThing();
            Task task = Task.Run(() =>
            {
                var array = new[] { "char", "int", "hex", "bin" };
                for (var i = 0; i < 10_000; i++)
                {
                    if (i % 5 == 0)
                        Console.Clear();
                    Console.Write($"{array.AtRandom()}* rando -set:'{i}'\n");
                }
                Console.Clear();
            });
            PrintResults(processor.Process(task));
            PrintResults(processor.Process("Whoa!"));
            PrintResults(processor.Process(42));
            Console.ReadKey();

            Console.Clear();
            CalculateUnits(2f, out var inRadius, out var circumRadius);
            PrintResults((result: 69, $"{inRadius}, {circumRadius}!", string.Empty));
            Console.ReadKey();

            void PrintResults((int result, string message, string error) results) =>
                WriteLine($"Results: {results.result}, {results.message} {results.error}");
        }

        private static Random s_rand = new Random();

        public static string AtRandom(this string[] array)
        {
            return array[s_rand.Next(0, array.Length)];
        }

        public static void CalculateUnits(float length, out float inRadius, out float circumRadius)
        {
            inRadius = length / (float)Math.Sqrt(3);
            circumRadius = inRadius * 1.5f;
        }
    }
}