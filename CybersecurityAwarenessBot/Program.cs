
using CybersecurityAwarenessBot.Models;
using CybersecurityAwarenessBot.Services;
using CyberSecurityAwarenessBot.UI;

namespace CyberSecurityAwarenessBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            ConsoleUI.DisplayHeader();
            AudioPlayer.PlayGreeting("Assets/Greetings.wav");

            UserProfile user = new UserProfile();
            ChatbotService chatbot = new ChatbotService();

            ConsoleUI.WriteBotMessage("Hello! Welcome to the Cybersecurity Awareness Bot.");
            ConsoleUI.WriteBotMessage("I am here to help you stay safe online.");
            ConsoleUI.WriteBotMessage("What is your name?");

            string? nameInput = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(nameInput))
            {
                ConsoleUI.WriteError("Name cannot be empty. Please enter your name:");
                nameInput = Console.ReadLine();
            }

            user.Name = nameInput.Trim();

            ConsoleUI.WriteSuccess($"Nice to meet you, {user.Name}!");
            ConsoleUI.WriteBotMessage("You can ask me things like:");
            ConsoleUI.WriteBotMessage("- How are you?");
            ConsoleUI.WriteBotMessage("- What's your purpose?");
            ConsoleUI.WriteBotMessage("- What can I ask you about?");
            ConsoleUI.WriteBotMessage("- Tell me about password safety");
            ConsoleUI.WriteBotMessage("- What is phishing?");
            ConsoleUI.WriteBotMessage("- How do I browse safely?");
            ConsoleUI.WriteBotMessage("Type 'exit' to close the chatbot.");

            chatbot.StartChat(user);
        }
    }
}