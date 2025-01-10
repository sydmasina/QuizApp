namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question(questionText: "What is 7 + 5?", answers: ["10", "12", "13", "15"], correctAnswerIndex: 1),
                new Question(questionText: "What is 9 × 3?", answers: ["18", "27", "24", "21"], correctAnswerIndex: 1),
                new Question(questionText: "What is 20 ÷ 4?", answers: ["5", "4", "6", "8"], correctAnswerIndex: 0),
            };

            Quiz myQuiz = new Quiz(questions);
            
            myQuiz.RunQuiz();

            Console.ReadKey();
        }
    }
}
