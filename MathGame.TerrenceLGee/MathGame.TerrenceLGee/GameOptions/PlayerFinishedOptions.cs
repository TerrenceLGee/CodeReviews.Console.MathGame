using System.ComponentModel.DataAnnotations;

namespace MathGame.TerrenceLGee.GameOptions;

public enum PlayerFinishedOptions
{
    [Display(Name = "Show your game statistics")]
    ShowGames,
    [Display(Name = "Exit the program")]
    Exit,
}