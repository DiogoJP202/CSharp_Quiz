using System.Security.Cryptography.X509Certificates;

namespace Questions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = 
            {
                new Question("What is the name of the final boss in Terraria's base game?", new string[] { "The Destroyer", "Moon Lord", "Skeletron Prime", "Plantera" }, 1),
                new Question("Which NPC sells explosives?", new string[] { "Guide", "Demolitionist", "Merchant", "Goblin Tinkerer" }, 1),
                new Question("What material is required to craft a Hellstone Bar?", new string[] { "Gold Ore", "Iron Ore", "Hellstone and Obsidian", "Demonite Ore" }, 2),
                new Question("What biome does the Goblin Tinkerer spawn in after being rescued?", new string[] { "Forest", "Underground", "Jungle", "Ocean" }, 1),
                new Question("Which of these weapons can be crafted using Fallen Stars?", new string[] { "Night's Edge", "Starfury", "Star Cannon", "Space Gun" }, 2),

            }; 

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();
            Console.ReadLine();
        }
    }
}
