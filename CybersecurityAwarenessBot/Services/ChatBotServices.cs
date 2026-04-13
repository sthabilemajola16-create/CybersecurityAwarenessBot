
using CybersecurityAwarenessBot.Models;
namespace CybersecurityAwarenessBot.Services
{
    public class ChatbotService
    {
        public string GetResponse(string input, string userName)
        {
            switch (input)
            {
                case "how are you":
                case "how are you?":
                    return $"I am doing well, {userName}. Thank you for asking! I am ready to help you with cybersecurity awareness.";

                case "what is your purpose":
                case "what's your purpose":
                case "what is your purpose?":
                    return "My purpose is to teach users about cybersecurity and help them stay safe from online threats.";

                case "what can i ask you about":
                case "what can i ask you about?":
                    return "You can ask me about password safety, phishing, safe browsing, malware, scams, and suspicious links.";

                case "password":
                case "password safety":
                    return ResponseService.GetPasswordSafetyResponse();

                case "phishing":
                    return ResponseService.GetPhishingResponse();

                case "safe browsing":
                case "browsing":
                    return ResponseService.GetSafeBrowsingResponse();

                case "malware":
                    return ResponseService.GetMalwareResponse();

                case "scams":
                case "online scams":
                    return ResponseService.GetScamResponse();

                case "suspicious links":
                case "links":
                    return ResponseService.GetSuspiciousLinksResponse();

                // ===========================
                // STUDENT CUSTOM PROMPTS AREA
                // Students must add their own prompts here
                // Example:
                // case "vpn":
                //     return "A VPN protects your internet connection by encrypting your data.";
                // ===========================

                case "":
                    return "You entered an empty message. Please type a valid cybersecurity question.";

                default:
                    return "I did not quite understand that. Could you rephrase your question or ask about a cybersecurity topic?";
            }
        }

        internal void StartChat(UserProfile user)
        {
            throw new NotImplementedException();
        }
    }
}