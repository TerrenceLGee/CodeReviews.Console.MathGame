using System.ComponentModel.DataAnnotations;

namespace MathGame.TerrenceLGee.GameOptions.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var fieldInfo = enumValue
            .GetType()
            .GetField(enumValue.ToString());

        return (fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false)
            is DisplayAttribute[] descriptionAttributes && descriptionAttributes.Length > 0)
            ? descriptionAttributes[0].Name!
            : enumValue.ToString();
    }
}