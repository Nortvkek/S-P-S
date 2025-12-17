namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? your_choice = Console.ReadLine();
            Console.WriteLine($"Ваш выбор: {your_choice}");
            string? not_your_choice = Play();
            Console.WriteLine($"Выбор оппонента: {not_your_choice}");
        }


        static string Play()
        {
            Random rand = new Random();
            string[] variants = {"stone", "scissors", "paper"};
            return variants[rand.Next(0, variants.Length)];
        }

    }
}
