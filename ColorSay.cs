using System.Text.RegularExpressions;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;

namespace ColorSay;
public class ColorSay : BasePlugin
{
    public override string ModuleName => "CMod Color Say";
    public override string ModuleAuthor => "chte @ Challengermode";
    public override string ModuleVersion => "0.0.1";

    /// <summary>
    /// Loads the Color Say module.
    /// </summary>
    /// <param name="hotReload">Indicates whether the module is being hot reloaded.</param>
    public override void Load(bool hotReload)
    {
        RegisterListener<Listeners.OnMapEnd>(() => Unload(true));
        Console.WriteLine($"{ModuleName} version {ModuleVersion} by {ModuleAuthor} is active.");
    }

    /// <summary>
    /// Handles the player chat event and sends a colored message to all players.
    /// </summary>
    /// <param name="player">The player who triggered the chat event.</param>
    /// <param name="command">The command information.</param>
    [ConsoleCommand("colorsay", "colorsay <message> - Sends a colored message to all players")]
    [ConsoleCommand("csay", "csay <message> - Sends a colored message to all players")]
    public void OnColorSayCommand(CCSPlayerController? player, CommandInfo command)
    {
        try
        {
            if (command.ArgCount < 1)
            {
                Console.WriteLine("Missing argument for colorsay");
                return;
            }
            string message = command.GetArg(1);
            if (message == null || message.Length < 1)
            {
                Console.WriteLine("Message cannot be empty");
                return;
            }

            Server.PrintToChatAll(GetColoredText(message));
            Server.PrintToConsole(GetColoredText(message));

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error could not process message", ex.Message);
        }
        return;
    }

    /// <summary>
    /// Gets the colored text by replacing color codes in the message.
    /// </summary>
    /// <param name="message">The message to be colored.</param>
    /// <returns>The colored text.</returns>
    /// <remarks>
    /// The color codes are based on the Quake 3 Arena color codes.
    /// </remarks>
    private static string GetColoredText(string message)
    {
        Dictionary<string, int> colorMap = new()
        {
            { "{default}", 1 },
            { "{white}", 1 },
            { "{darkred}", 2 },
            { "{lightpurple}", 3},
            { "{green}", 4 },
            { "{lightgreen}", 5 },
            { "{slimegreen}", 6 },
            { "{red}", 7 },
            { "{grey}", 8 },
            { "{yellow}", 9 },
            { "{invisible}", 10 },
            { "{lightblue}", 11 },
            { "{blue}", 12 },
            { "{purple}", 13 },
            { "{pink}", 14 },
            { "{fadedred}", 15 },
            { "{gold}", 16 },
            // No more colors are mapped to CS2
        };

        // Use a regular expression to find and replace color codes
        string pattern = "{(\\w+)}"; // Matches {word}
        string replaced = Regex.Replace(message, pattern, match =>
        {
            string colorCode = match.Groups[1].Value;
            if (colorMap.TryGetValue("{" + colorCode + "}", out int replacement))
            {
                // A little hack to get the color code to work
                return Convert.ToChar(replacement).ToString();
            }
            // If the color code is not found, leave it unchanged
            return match.Value;
        });
        return $"{replaced}";
    }
}


