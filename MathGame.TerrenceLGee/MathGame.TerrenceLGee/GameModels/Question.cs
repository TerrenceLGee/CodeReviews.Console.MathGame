using MathGame.TerrenceLGee.GameOptions;

namespace MathGame.TerrenceLGee.GameModels;

public class Question
{
    public int QuestionNumber { get; set; }
    public int Operand1 { get; set; }
    public int Operand2 { get; set; }
    public char MathOperator { get; set; }
    public int ActualAnswer { get; set; }
    public int PlayerAnswer { get; set; }
    public GameType QuestionType { get; set; }
    public bool IsCorrectAnswer { get; set; }

    public override string ToString() =>
        $"{Operand1} {MathOperator} {Operand2}";
}