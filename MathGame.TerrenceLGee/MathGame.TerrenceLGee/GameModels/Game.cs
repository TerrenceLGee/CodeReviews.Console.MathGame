using MathGame.TerrenceLGee.GameOptions;

namespace MathGame.TerrenceLGee.GameModels;

public class Game
{
    public int GameNumber { get; init; }
    public int NumberOfMathQuestions { get; init; }
    public TimeSpan GameLength { get; set; }
    public int QuestionsCorrect { get; set; }
    public int QuestionsIncorrect { get; set; }
    public decimal Score { get; set; }
    public List<Question> QuestionsFromGame { get; set; } = [];
    public DifficultyLevel DifficultyLevel { get; init; }
    public GameType GameType { get; init; }
}