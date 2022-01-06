using MudBlazor.Utilities;

namespace FunPlanner.Colors
{
    public static class MudColors
    {
        public static string GetRandomColor()
        {
            string[] colors = { "#9C27B0", "#4A148C", "#2196F3", "#C62828", "#CDDC39", "#33691E", "#FFD54F" };
            return colors[new Random().Next(colors.Length)];
        }

        public static string GetRandomColorCssBackground()
        {
            return default(StyleBuilder)
                .AddStyle("background-color", GetRandomColor())
                .Build();
        }
    }
}
