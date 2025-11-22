using MathGame.TerrenceLGee.GameModels;
using MathGame.TerrenceLGee.GameOptions;

namespace MathGame.TerrenceLGee.GameServices;

public class GameOperations
{
    private readonly Random _random = new();

    private int SolveProblem(Func<int> problem)
    {
        return problem();
    }

    public int GetAnswer(Question question)
    {
        return question.MathOperator switch
        {
            '+' => SolveProblem(() => question.Operand1 + question.Operand2),
            '-' => SolveProblem(() => question.Operand1 - question.Operand2),
            '*' => SolveProblem(() => question.Operand1 * question.Operand2),
            '/' => SolveProblem(() => question.Operand1 / question.Operand2),
            _ => SolveProblem(() => question.Operand1 % question.Operand2)
        };
    }

    public bool IsAnswerCorrect(Question question)
    {
        return question.PlayerAnswer == question.ActualAnswer;
    }

    private bool IsCorrectForModulus(int operand1, int operand2)
    {
        return operand1 >= operand2;
    }

    private bool IsCorrectForDivision(int operand1, int operand2)
    {
        return operand1 % operand2 == 0 && operand1 > operand2;
    }

    private int GetOperand(DifficultyLevel level, int startValue)
    {
        return level switch
        {
            DifficultyLevel.Medium => _random.Next(startValue, 100),
            DifficultyLevel.Difficult => _random.Next(startValue, 1000),
            DifficultyLevel.Hard => _random.Next(startValue, 10000),
            DifficultyLevel.Legend => _random.Next(startValue, 100000),
            _ => _random.Next(startValue, 10)
        };
    }

    public Question CreateMathQuestion(GameType type, DifficultyLevel level)
    {
        var operations = new char[] { '+', '-', '*', '/', '%' };
        var gameType = type;
        int operand1 = 0;
        int operand2 = 0;

        char mathOperator;

        if (type == GameType.Random)
        {
            var gameTypes = new GameType[]
            {
                GameType.Addition,
                GameType.Subtraction,
                GameType.Multiplication,
                GameType.Division,
                GameType.Modulus
            };
            var index = _random.Next(operations.Length);
            mathOperator = operations[index];
            gameType = gameTypes[index];
        }
        else
        {
            mathOperator = type switch
            {
                GameType.Addition => operations[0],
                GameType.Subtraction => operations[1],
                GameType.Multiplication => operations[2],
                GameType.Division => operations[3],
                _ => operations[4],
            };
        }
        
        if (gameType == GameType.Division || gameType == GameType.Modulus)
        {
            operand1 = GetOperand(level, 0);
            operand2 = GetOperand(level, 1);

            if (gameType == GameType.Division)
            {
                while (!IsCorrectForDivision(operand1, operand2))
                {
                    operand1 = GetOperand(level, 0);
                    operand2 = GetOperand(level, 1);
                }
            }
            else
            {
                while (!IsCorrectForModulus(operand1, operand2))
                {
                    operand1 = GetOperand(level, 0);
                    operand2 = GetOperand(level, 1);
                }
            }
        }
        else
        {
            operand1 = GetOperand(level, 0);
            operand2 = GetOperand(level, 0);
        }

        var mathQuestion = new Question
        {
            Operand1 = operand1,
            Operand2 = operand2,
            MathOperator = mathOperator,
            QuestionType = gameType
        };

        return mathQuestion;
    }
}