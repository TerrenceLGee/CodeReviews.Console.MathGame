using MathGame.TerrenceLGee.GameModels;
using MathGame.TerrenceLGee.GameServices;
using Spectre.Console;

namespace MathGame.TerrenceLGee.GameUI;

public static class GameDisplay
{
    public static void GameUi(Game game)
    {
        var gameOperations = new GameOperations();
        
        AnsiConsole.WriteLine();

        for (var questionNumber = 1; questionNumber <= game.NumberOfMathQuestions; questionNumber++)
        {
            var question = gameOperations.CreateMathQuestion(game.GameType, game.DifficultyLevel);
            question.QuestionNumber = questionNumber;
            question.PlayerAnswer = GetPlayerAnswer(question);
            question.ActualAnswer = gameOperations.GetAnswer(question);
            question.IsCorrectAnswer =  gameOperations.IsAnswerCorrect(question);
            if (question.IsCorrectAnswer)
            {
                game.QuestionsCorrect++;
            }
            else
            {
                game.QuestionsIncorrect++;
            }
            game.QuestionsFromGame.Add(question);
            DisplayResultOfQuestionAnswered(question);
        }
        
        game.Score = (decimal)game.QuestionsCorrect / game.NumberOfMathQuestions * 100m;
        DisplayGameSummary(game, game.NumberOfMathQuestions);
    }

    private static int GetPlayerAnswer(Question question)
    {
        return AnsiConsole.Ask<int>($"[lime]{question.Operand1} {question.MathOperator} {question.Operand2} = [/] ");
    }

    private static void DisplayResultOfQuestionAnswered(Question question)
    {
        var result = question.IsCorrectAnswer
            ? "Correct!"
            : "Incorrect";
        AnsiConsole.MarkupLine($"[fuchsia]{result}[/]");
        AnsiConsole.MarkupLine("[fuchsia]Press any key to continue: [/]");
        Console.ReadKey();
        AnsiConsole.Clear();
    }

    private static void DisplayGameSummary(Game game, int numberOfQuestions)
    {
        AnsiConsole.MarkupLine($"[mediumspringgreen]You got {game.QuestionsCorrect} out of {numberOfQuestions} correct[/]");
        AnsiConsole.MarkupLine($"[mediumspringgreen]Your score for this game is {game.Score:0}%[/]");
        AnsiConsole.MarkupLine("[mediumspringgreen]Press any key to continue: [/]");
        Console.ReadKey();
        AnsiConsole.Clear();
    }
}