using MathGame.TerrenceLGee.GameModels;
using MathGame.TerrenceLGee.GameOptions.Extensions;
using Spectre.Console;

namespace MathGame.TerrenceLGee.GameUI;

public static class GameInformationDisplay
{
    public static void DisplayGames(Player player)
    {
        if (!player.Games.Any())
        {
            AnsiConsole.MarkupLine("[bold red]There are no games to display[/]");
            return;
        }
        
        AnsiConsole.MarkupLine($"[green]Games played by {player.Name}\n[/]");
        var table = new Table();

        table.AddColumn("Game #");
        table.AddColumn("Number of questions");
        table.AddColumn("Type of Game");
        table.AddColumn("Difficulty Level");
        table.AddColumn("Questions Correct");
        table.AddColumn("Questions Incorrect");
        table.AddColumn("Score");
        table.AddColumn("Time elapsed");

        foreach (var game in player.Games)
        {
            table.AddRow(
                game.GameNumber.ToString(),
                game.NumberOfMathQuestions.ToString(),
                game.GameType.GetDisplayName(),
                game.DifficultyLevel.GetDisplayName(),
                game.QuestionsCorrect.ToString(),
                game.QuestionsIncorrect.ToString(),
                $"{game.Score:0}",
                $"{(int)game.GameLength.TotalMinutes}:{game.GameLength.TotalSeconds:00}");
        }
        
        AnsiConsole.Write(table);
    }

    public static void DisplayGameStatistics(Player player, Game game)
    {
        AnsiConsole.MarkupLine($"[green]Information for Game #{game.GameNumber}\n[/]");
        AnsiConsole.MarkupLine($"[green]Player name: {player.Name}[/]");
        AnsiConsole.MarkupLine($"[green]Number of questions: {game.NumberOfMathQuestions}[/]");
        AnsiConsole.MarkupLine($"[green]Difficulty level: {game.DifficultyLevel.GetDisplayName()}[/]");
        AnsiConsole.MarkupLine($"[green]Questions correct: {game.QuestionsCorrect}[/]");
        AnsiConsole.MarkupLine($"[green]Questions incorrect: {game.QuestionsIncorrect}[/]");
        AnsiConsole.MarkupLine($"[green]Score: {game.Score:0}[/]");
        AnsiConsole.MarkupLine(
            $"[green]Elapsed time: {(int)game.GameLength.TotalMinutes}:{game.GameLength.TotalSeconds:00}\n[/]");
        
        AnsiConsole.MarkupLine($"[underline green]Questions[/]");
        var table = new Table();
        table.AddColumn("Question #");
        table.AddColumn("Question type");
        table.AddColumn("Question");
        table.AddColumn("Your answer");
        table.AddColumn("Actual answer");
        table.AddColumn("Answered correctly?");

        foreach (var question in game.QuestionsFromGame)
        {
            table.AddRow(
                question.QuestionNumber.ToString(),
                question.QuestionType.GetDisplayName(),
                question.ToString(),
                question.PlayerAnswer.ToString(),
                question.ActualAnswer.ToString(),
                question.IsCorrectAnswer ? 
                    "Yes" 
                    :"No");
        }
        AnsiConsole.Write(table);
    }
}