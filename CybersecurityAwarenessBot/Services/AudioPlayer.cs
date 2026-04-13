using System;
using System.IO;
using System.Media;

public class AudioPlayer
{
    public static void PlayGreeting(string filePath)
    {
        try
        {
            Console.WriteLine($"Looking for file at: {Path.GetFullPath(filePath)}");

            if (File.Exists(filePath))
            {
                SoundPlayer player = new SoundPlayer(filePath);
                player.PlaySync(); // ensures it actually plays
            }
            else
            {
                Console.WriteLine("[Audio file not found. Continuing without voice greetings.]");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing audio: {ex.Message}");
        }
    }
}
