using System.IO;
using System.Media;

namespace CybersecurityAwarenessBot.Services;

/// <summary>
/// Plays the greeting WAV file from Task 1 when available.
/// </summary>
public static class AudioPlayer
{
    public static void PlayGreeting(string filePath)
    {
        try
        {
            string fullPath = Path.GetFullPath(filePath);

            if (!File.Exists(fullPath))
                return;

            using var player = new SoundPlayer(fullPath);
            player.Play();
        }
        catch
        {
            // Greeting audio is optional; never crash the application.
        }
    }
}
