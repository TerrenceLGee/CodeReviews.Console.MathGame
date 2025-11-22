using System.ComponentModel.DataAnnotations;

namespace MathGame.TerrenceLGee.GameOptions;

public enum GameOverOptions
{
    [Display(Name = "Play again")]
    PlayAgain,
    [Display(Name = "Finished playing")]
    Exit,
}