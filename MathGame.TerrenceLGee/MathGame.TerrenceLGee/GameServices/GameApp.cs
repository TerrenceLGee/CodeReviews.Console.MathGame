using System.Diagnostics;
using MathGame.TerrenceLGee.GameModels;
using MathGame.TerrenceLGee.GameOptions;
using MathGame.TerrenceLGee.GameOptions.Extensions;
using MathGame.TerrenceLGee.GameUI;
using Spectre.Console;

namespace MathGame.TerrenceLGee.GameServices;

public class GameApp
{
    public void Run()
    {
        AnsiConsole.MarkupLine("[darkturquoise]Welcome to the Math Game![/]");
        var playerName = GetUserName();
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine($"[darkturquoise]Hello {playerName}![/]");
        PressAnyKeyToContinue(playerName, "Press any key to begin");
        var player = new Player
        {
            Name = playerName,
        };
        
        var menuChoice = DisplayMainMenu(player.Name);

        switch (menuChoice)
        {
            case MainMenu.PlayGame:
                PlayGame(player);
                break;
            case MainMenu.Exit:
                break;
            default: 
                AnsiConsole.MarkupLine("[bold red]Invalid choice! Exiting program[/]");
                return;
        }
        
        PressAnyKeyToContinue(
            player.Name, "Thank you for playing the Math Game!\nPress any key to exit");
    }

    private Game InitializeGame(Player player, int currentGame)
    {
        var numberOfQuestions = GetNumberOfQuestions(player.Name);
        PressAnyKeyToContinue(player.Name);
        var difficultyLevel = GetDifficultyLevel(player.Name);
        var gameType = GetGameType(player.Name);
        PressAnyKeyToContinue(player.Name, "Press any key to begin your game!");

        return new Game
        {
            GameNumber = currentGame,
            NumberOfMathQuestions = numberOfQuestions,
            DifficultyLevel = difficultyLevel,
            GameType = gameType,
            QuestionsCorrect = 0,
            QuestionsIncorrect = 0,
            Score = 0
        };
    }

    private void PlayGame(Player player)
    {
        var finishedPlayingGame = false;
        var currentGame = 0;
        
        do
        {
            currentGame++;
            var game = InitializeGame(player, currentGame);
            var startTime = Stopwatch.GetTimestamp();
            GameDisplay.GameUi(game);
            game.GameLength = Stopwatch.GetElapsedTime(startTime);
            player.Games.Add(game);
            GameInformationDisplay.DisplayGameStatistics(player, game);
            PressAnyKeyToContinue(player.Name);

            var playingAgain = GetGameOverOptions(player.Name);


            if (playingAgain == GameOverOptions.Exit)
            {
                finishedPlayingGame = true;
            }

        } while (!finishedPlayingGame);

        var finishedPlayingOptions = GetPlayerFinishedOptions(player.Name);

        if (finishedPlayingOptions == PlayerFinishedOptions.ShowGames)
        {
            GameInformationDisplay.DisplayGames(player);
        }
    }

    private int GetNumberOfQuestions(string name)
    {
        int numberOfQuestions = 0;

        while (numberOfQuestions < 5)
        {
            AnsiConsole.Markup($"[green3_1]{name}, Please enter the number of questions you would like to answer [/]");
            numberOfQuestions =  AnsiConsole.Ask<int>($"[green3_1](Minimum: 5): [/]");
        }

        return numberOfQuestions;
    }
    
    private string GetUserName()
    {
        return AnsiConsole.Ask<string>("[darkturquoise]Please enter your name: [/]");
    }

    private MainMenu DisplayMainMenu(string name)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<MainMenu>()
                .Title($"[darkturquoise]{name}, please choose one of the following options:[/]")
                .AddChoices(Enum.GetValues<MainMenu>())
                .UseConverter(choice => choice.GetDisplayName()));
    }

    private GameType GetGameType(string name)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<GameType>()
                .Title($"[darkorange3]{name}, Please choose which type of Math Game you wish to play[/]")
                .AddChoices(Enum.GetValues<GameType>())
                .UseConverter(choice => choice.GetDisplayName()));
    }

    private DifficultyLevel GetDifficultyLevel(string name)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<DifficultyLevel>()
                .Title($"[magenta3_1]{name}, Please choose your difficulty level[/]")
                .AddChoices(Enum.GetValues<DifficultyLevel>())
                .UseConverter(choice => choice.GetDisplayName()));
    }

    private GameOverOptions GetGameOverOptions(string name)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<GameOverOptions>()
                .Title($"[cyan2]{name}, Please choose one of the following options[/]")
                .AddChoices(Enum.GetValues<GameOverOptions>())
                .UseConverter(choice => choice.GetDisplayName()));
    }

    private PlayerFinishedOptions GetPlayerFinishedOptions(string name)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<PlayerFinishedOptions>()
                .Title($"[blueviolet]{name}, Please choose one of the following options[/]")
                .AddChoices(Enum.GetValues<PlayerFinishedOptions>())
                .UseConverter(choice => choice.GetDisplayName()));
    }

    private void PressAnyKeyToContinue(string name, string message = "Press any key to continue")
    {
        AnsiConsole.MarkupLine($"[cornflowerblue]{name}, {message}:[/]");
        Console.ReadKey();
        AnsiConsole.Clear();
    }
}