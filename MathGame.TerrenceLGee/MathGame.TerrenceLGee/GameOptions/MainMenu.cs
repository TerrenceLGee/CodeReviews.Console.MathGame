using System.ComponentModel.DataAnnotations;

namespace MathGame.TerrenceLGee.GameOptions;

public enum MainMenu
{
    [Display(Name = "Play Math Game")]
    PlayGame,
    [Display(Name = "Exit program")]
    Exit,
}