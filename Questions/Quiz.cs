using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Questions
{
    internal class Quiz
    {
        private Question[] _question;
        private int _score;

        public Quiz(Question[] question)
        {
            _question = question;
            _score = 0;
        }

        public void StartQuiz()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Quiz!");
            Console.ResetColor();
            int questionNumber = 1; // To display question numbers.

            foreach (Question question in _question)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" --------------");
                Console.WriteLine($"|  Question {questionNumber++}  |");
                Console.WriteLine(" --------------\n");
                Console.ResetColor();

                DisplayQuestion(question);
                int userChoice = GetUserChoice();

                if (question.IsCorrectAnswer(userChoice))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                    _score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect!");
                    Console.ResetColor();
                    Console.WriteLine($"The correct answer was the choice: {question.CorrectAnswerIndex}");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            DisplayTheResults();
        }

        private void DisplayQuestion(Question question)
        {
            Console.WriteLine(question.QuestionText);

            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("   ");
                Console.Write(i + 1);
                Console.ResetColor();
                Console.WriteLine($". {question.Answers[i]}");
            }
        }

        private void DisplayTheResults()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ------------");
            Console.WriteLine($"|  Results  |");
            Console.WriteLine(" ------------\n");
            Console.ResetColor();

            Console.WriteLine($"Quiz finished. Your score is {_score} out of {_question.Length}");

            double percentage = (double) _score / _question.Length;

            if (percentage > 0.8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Excelent Work!");
            }
            else if (percentage >= 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good effort!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keep practicing!");
            }

            Console.ResetColor();
        }

        private int GetUserChoice()
        {
            Console.WriteLine("Your Answer (number): ");
            string input = Console.ReadLine();
            int choice = 0;
            
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4: ");
                input = Console.ReadLine();
            }

            return choice - 1; // Adjust to 0 indexed array.
        }
    }
}
