namespace CybersecurityAwarenessBot.Services
{
    public static class ResponseService
    {
        public static string GetPasswordSafetyResponse()
        {
            return "Password safety means creating strong and private passwords that are difficult to guess. A strong password should include uppercase letters, lowercase letters, numbers, and symbols. You should also avoid using the same password on many accounts.";
        }

        public static string GetPhishingResponse()
        {
            return "Phishing is a cyberattack where criminals pretend to be trusted organisations or people to trick you into giving away personal information such as passwords, banking details, or OTP codes. A phishing message often creates fear, urgency, or curiosity.";
        }

        public static string GetSafeBrowsingResponse()
        {
            return "Safe browsing means using the internet carefully and responsibly. It includes visiting trusted websites, avoiding suspicious downloads, checking links before clicking, and making sure websites use secure connections such as HTTPS.";
        }

        public static string GetMalwareResponse()
        {
            return "Malware is harmful software designed to damage, spy on, or disrupt a computer, phone, or network. Malware includes viruses, worms, ransomware, and spyware. It can enter your device through unsafe downloads, fake apps, or suspicious email attachments.";
        }

        public static string GetScamResponse()
        {
            return "An online scam is a dishonest trick used on the internet to steal money, information, or access to accounts. Scammers may pretend to offer prizes, jobs, loans, or urgent warnings to manipulate victims into responding quickly without thinking carefully.";
        }

        public static string GetSuspiciousLinksResponse()
        {
            return "A suspicious link is a web address that may lead to a fake, harmful, or dangerous website. These links are often shortened, misspelled, or disguised to look real. Always inspect a link before clicking it.";
        }
    }
}