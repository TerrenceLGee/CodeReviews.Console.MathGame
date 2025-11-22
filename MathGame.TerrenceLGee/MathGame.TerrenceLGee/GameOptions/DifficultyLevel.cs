using System.ComponentModel.DataAnnotations;

namespace MathGame.TerrenceLGee.GameOptions;

public enum DifficultyLevel
{
    [Display(Name = "Easy")]
    Easy,
    [Display(Name = "Medium")]
    Medium,
    [Display(Name = "Difficult")]
    Difficult,
    [Display(Name = "Hard")]
    Hard,
    [Display(Name = "Legend")]
    Legend,
}