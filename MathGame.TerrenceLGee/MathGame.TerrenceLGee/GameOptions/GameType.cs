using System.ComponentModel.DataAnnotations;

namespace MathGame.TerrenceLGee.GameOptions;

public enum GameType
{
    [Display(Name = "Addition")]
    Addition,
    [Display(Name = "Subtraction")]
    Subtraction,
    [Display(Name = "Multiplication")]
    Multiplication,
    [Display(Name = "Division")]
    Division,
    [Display(Name = "Modulus (Remainder from Division)")]
    Modulus,
    [Display(Name = "Random Game")]
    Random,
}