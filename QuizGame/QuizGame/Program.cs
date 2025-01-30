using System;

namespace QuizGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] questions = new string[6]
            {
                "1. What is the capital of Egypt?",
                "2. What is the red planet?",
                "3. What is the largest animal?",
                "4. Who wrote 'To Kill a Mockingbird'?",
                "5. What is the square root of 144?",
                "6. What element has the chemical symbol 'O'?"
            };

            string[] answers = new string[6]
            {
                "Cairo",
                "Mars",
                "Blue whale",
                "Harper Lee",
                "12",
                "Oxygen"
            };

            int score = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine("         Welcome to Quiz Game!          ");
            Console.WriteLine("========================================");
            Console.ResetColor();
            Console.WriteLine("Answer the following questions:");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < questions.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(questions[i]);
                Console.ResetColor();
                string userAnswer = Console.ReadLine();

                try
                {
                    if (IsCorrect(userAnswer, answers[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" ----------");
                        Console.WriteLine("| Correct! |");
                        Console.WriteLine(" ----------");
                        score++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sorry, Incorrect answer. The correct answer is: {answers[i]}");
                    }
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine($"Thank you! Your score is {score} / {answers.Length}");
            Console.WriteLine("========================================");
            Console.ResetColor();
        }

        public static bool IsCorrect(string userAnswer, string correctAnswer)
        {
            if (string.IsNullOrEmpty(userAnswer))
            {
                throw new Exception("Answer can't be empty!");
            }

            // Convert both answers to uppercase for case-insensitive comparison
            return userAnswer.ToUpper() == correctAnswer.ToUpper();
        }
    }
}
