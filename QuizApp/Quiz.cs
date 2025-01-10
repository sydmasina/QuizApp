using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Quiz
    {
        private Question[] questions;

        private int userAnswer;

        public Quiz(Question[] questions)
        {
            this.questions = questions;
        }

        public void RunQuiz()
        {
            for (int questionIndex = 0; questionIndex < questions.Length; questionIndex++) 
            {
                DisplayQuestion(questionIndex);

                DisplayAnswers(questionIndex);

                bool isValidAnswer = GetUserAnswer(questionIndex);

                if (!isValidAnswer) {
                    questionIndex -= 1;
                    continue;
                }
                
                ValidateAnswer(questionIndex);
            }

            Console.WriteLine("Quiz finished! Thank you for participating.");
        }

        private bool GetUserAnswer(int questionIndex)
        {
            int answer = 0;

            Console.Write("Your answer (number): ");
            bool isValidAnswer = int.TryParse(Console.ReadLine(), out userAnswer);

            if (!isValidAnswer || answer < 1 || (userAnswer - 1) >= (questions[questionIndex].Answers.Length))
            {
                Console.WriteLine();
                Console.WriteLine($"\u001b[1;31mInvalid selection. Your selection must be between 1 and {questions[questionIndex].Answers.Length}.\u001b[0m");
                Console.WriteLine($"\u001b[1;31mPlease try again.\u001b[0m");
                Console.WriteLine();
                return false;
            }

            return true;    
        }

        public void ValidateAnswer(int questionIndex)
        {
            if((userAnswer - 1) == questions[questionIndex].CorrectAnswerIndex)
            {
                Console.WriteLine();
                Console.WriteLine("\u001b[1;32mThat is correct! \u001b[0m");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\u001b[1;31mThat is incorrect.\u001b[0m");
            }
            string answer = questions[questionIndex].Answers[questions[questionIndex].CorrectAnswerIndex];
            Console.WriteLine($"\u001b[1;33mCorrect answer is {answer}\u001b[0m");
            Console.WriteLine("");
        }

        public void DisplayQuestion(int questionIndex)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Question                                ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(questions[questionIndex].QuestionText);
        }

        public void DisplayAnswers(int questionIndex)
        {
            for (int answerIndex = 0; answerIndex < questions[questionIndex].Answers.Length; answerIndex++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(answerIndex + 1);
                Console.ResetColor();
                Console.WriteLine($". {questions[questionIndex].Answers[answerIndex]}");
            }
        }
    }
}
