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
            CheckResults(your_choice, not_your_choice);
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
                Console.WriteLine("Вы победили!");
            if ((othStr.ToLower() == "stone" && yourStr == "scissors") || (othStr.ToLower() == "scissors" && yourStr == "paper") || (othStr.ToLower() == "paper" && yourStr == "stone"))
                Console.WriteLine("Вы проиграли!");
            else if (yourStr == othStr)
                Console.WriteLine("Ничья!");
        }

    }
}
