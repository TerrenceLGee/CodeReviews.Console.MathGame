namespace MathGame.TerrenceLGee.GameModels;

public class Player
{
    public string Name { get; set; } = string.Empty;
    public List<int> Scores { get; set; } = [];
    public List<Game> Games { get; set; } = [];
}