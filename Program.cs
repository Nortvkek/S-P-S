using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp22
{
    internal class Program
    {
        static public int yourPts = 0, nYourPts = 0;
        static async Task Main(string[] args)
        {
            string path = "points.txt";
            await GetPointsFromFileAsync(path);
            PrintPts();
            string? your_choice = Console.ReadLine();
            Console.WriteLine($"Ваш выбор: {your_choice}");
            string? not_your_choice = Play();
            Console.WriteLine($"Выбор оппонента: {not_your_choice}");
            CheckResults(your_choice, not_your_choice);
            PrintPts();
            await AddPointsToFileAsync(path);
        }


        static string Play()
        {
            Random rand = new Random();
            string[] variants = {"stone", "scissors", "paper"};
            return variants[rand.Next(0, variants.Length)];
        }

        static void CheckResults(string? yourStr, string? othStr)
        {
            if ((yourStr.ToLower() == "stone" && othStr == "scissors") || (yourStr.ToLower() == "scissors" && othStr == "paper") || (yourStr.ToLower() == "paper" && othStr == "stone"))
            {
                Console.WriteLine("Вы победили!");
                yourPts += 1;
            }
            if ((othStr.ToLower() == "stone" && yourStr == "scissors") || (othStr.ToLower() == "scissors" && yourStr == "paper") || (othStr.ToLower() == "paper" && yourStr == "stone"))
            {
                Console.WriteLine("Вы проиграли!");
                nYourPts += 1;
            }
            else if (yourStr == othStr)
                Console.WriteLine("Ничья!");
        }

        static async Task GetPointsFromFileAsync(string path)
        {
            string[] pts;
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                pts = text.Split(new char[] { ' ' });
                yourPts = Convert.ToInt32(pts[0]);
                nYourPts = Convert.ToInt32(pts[1]);
            }
        }

        static async Task AddPointsToFileAsync(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync($"{yourPts} {nYourPts}");
            }
        }

        static void PrintPts()
        {
            Console.WriteLine($"Ваши очки: {yourPts}");
            Console.WriteLine($"Очки оппонента: {nYourPts}");
        }

    }
}
