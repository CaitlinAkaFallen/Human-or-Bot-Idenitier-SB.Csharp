using System;
public class CPHInline
{
    public bool Execute()
    {
        // Get arguments from Streamer.Bot
        if (!CPH.TryGetArg("commandId", out Guid commandId))
        {
            CPH.LogWarn("Failed to get commandId.");
            return false;
        }

        if (!CPH.TryGetArg("rawInput", out string rawInput))
        {
            CPH.LogWarn("Failed to get rawInput.");
            return false;
        }

        if (!CPH.TryGetArg("user", out string user))
        {
            CPH.LogWarn("Failed to get user.");
            return false;
        }

        // Convert commandId to string for comparison
        string commandIdString = commandId.ToString();

        switch (commandIdString)
        {
            case "COMMAND_ID_IDENTIFY_USER": // Replace with your actual command ID
                IdentifyUserOrBot(user);
                break;

            default:
                CPH.SendMessage("Unknown command.");
                break;
        }

        return true;
    }

    private void IdentifyUserOrBot(string username)
    {
        // Check if the username contains 'bot' or is a known bot user
        if (username.ToLower().Contains("bot") || IsKnownBot(username))
        {
            CPH.SendMessage($"User {username} has been identified as a bot.");
        }
        else
        {
            CPH.SendMessage($"User {username} is a regular user.");
        }
    }

    // This function checks a list of known bot accounts
    private bool IsKnownBot(string username)
    {
        // List of known bot usernames (can be expanded)
        string[] knownBots = { "streamelements", "nightbot", "moobot", "botisbot" };

        // Check if the username is in the list of known bot usernames
        foreach (string bot in knownBots)
        {
            if (username.Equals(bot, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}
