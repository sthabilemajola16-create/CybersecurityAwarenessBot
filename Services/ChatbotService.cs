using CybersecurityAwarenessBot.Delegates;
using CybersecurityAwarenessBot.Models;

namespace CybersecurityAwarenessBot.Services;

/// <summary>
/// Core chatbot engine: keyword recognition, memory, sentiment, flow, and random responses.
/// </summary>
public class ChatbotService
{
    private readonly KeywordRecognizer _keywordRecognizer = new();
    private readonly MemoryService _memory = new();
    private readonly ConversationContext _context = new();
    private readonly UserProfile _user = new();
    private readonly SentimentResponseHandler _adaptResponse;

    public event BotMessageHandler? BotMessage;
    public event UserMessageHandler? UserMessage;

    public ChatbotService(SentimentResponseHandler? adaptResponse = null)
    {
        _adaptResponse = adaptResponse ?? SentimentResponseAdapter.Adapt;
    }

    public UserProfile User => _user;
    public ConversationContext Context => _context;
    public MemoryService Memory => _memory;

    /// <summary>
    /// Initial greeting sequence when the GUI loads.
    /// </summary>
    public void BeginSession()
    {
        EmitBot("Hello! Welcome to the Cybersecurity Awareness Bot.");
        EmitBot("I am here to help you stay safe online.");
        EmitBot("What is your name?");
        _context.AwaitingName = true;
    }

    /// <summary>
    /// Processes one user message and returns the bot reply (also raised via BotMessage).
    /// </summary>
    public string ProcessMessage(string rawInput)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(rawInput))
            {
                return EmitBot("You entered an empty message. Please type a valid cybersecurity question.");
            }

            UserMessage?.Invoke(rawInput);

            string input = rawInput.Trim();
            string normalized = input.ToLowerInvariant();

            if (_context.AwaitingName)
            {
                return HandleNameInput(input);
            }

            if (IsExitCommand(normalized))
            {
                return EmitBot($"Goodbye, {_user.Name}! Stay alert, stay secure, and stay informed.");
            }

            var sentiment = SentimentDetector.Detect(input);
            _context.LastSentiment = sentiment;

            // Remember stated interests
            if (TryCaptureInterest(input, out string interestTopic))
            {
                _user.Interests.Add(interestTopic);
                _memory.Remember("interest", interestTopic);
                string ack = $"Great! I'll remember that you're interested in {interestTopic}. ";
                string tip = BuildTopicResponse(interestTopic, sentiment, includeMemory: false);
                _context.SetTopic(interestTopic);
                return EmitBot(_adaptResponse(ack + tip, sentiment, _user.Name));
            }

            // Follow-up flow without restarting conversation
            if (IsFollowUpRequest(normalized))
            {
                return HandleFollowUp(sentiment);
            }

            // Greetings and meta questions
            string? meta = TryMetaResponse(normalized, sentiment);
            if (meta != null)
                return EmitBot(meta);

            // Keyword recognition inside natural language
            string? topic = _keywordRecognizer.RecognizeTopic(input);
            if (topic != null)
            {
                _context.SetTopic(topic);
                return EmitBot(BuildTopicResponse(topic, sentiment, includeMemory: true));
            }

            // Recall memory in general queries
            string? memoryReply = TryMemoryRecall(normalized, sentiment);
            if (memoryReply != null)
                return EmitBot(memoryReply);

            return EmitBot(_adaptResponse(
                "I'm not sure I understand. Can you try rephrasing? " +
                "You can ask about passwords, phishing, privacy, malware, scams, safe browsing, or suspicious links.",
                sentiment,
                _user.Name));
        }
        catch (Exception)
        {
            return EmitBot("Something unexpected happened, but I'm still here. Please try your question again.", isError: true);
        }
    }

    private string HandleNameInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return EmitBot("Name cannot be empty. Please enter your name:", isError: true);
        }

        _user.Name = input.Trim();
        _memory.Remember("name", _user.Name);
        _context.AwaitingName = false;

        EmitBot($"Nice to meet you, {_user.Name}!");
        EmitBot("You can ask me things like:");
        EmitBot("• I'm worried about online scams");
        EmitBot("• Tell me about password safety");
        EmitBot("• Give me a phishing tip");
        EmitBot("• I'm interested in privacy");
        EmitBot("• Give me another tip / explain more");
        EmitBot("Type 'exit' when you are done.");

        return string.Empty;
    }

    private string HandleFollowUp(SentimentType sentiment)
    {
        if (string.IsNullOrEmpty(_context.CurrentTopic))
        {
            return EmitBot(_adaptResponse(
                "Happy to share more! Which topic should we continue—passwords, phishing, privacy, scams, or malware?",
                sentiment,
                _user.Name));
        }

        string tip = ResponseService.GetFollowUpDetail(_context.CurrentTopic);
        string intro = sentiment == SentimentType.Curious
            ? "Here's more on that topic: "
            : "Another tip for you: ";

        return EmitBot(_adaptResponse(intro + tip, sentiment, _user.Name));
    }

    private string BuildTopicResponse(string topic, SentimentType sentiment, bool includeMemory)
    {
        string tip = ResponseService.GetRandomResponse(topic);
        string response = tip;

        if (includeMemory && _memory.HasInterest(topic))
        {
            response = $"As someone interested in {topic}, this is especially relevant: " + tip;
        }
        else if (_user.Interests.Count > 0 && includeMemory)
        {
            string lastInterest = _user.Interests[^1];
            if (!lastInterest.Equals(topic, StringComparison.OrdinalIgnoreCase))
            {
                response += $" (You also mentioned interest in {lastInterest}—happy to explore that next.)";
            }
        }

        return _adaptResponse(response, sentiment, _user.Name);
    }

    private bool TryCaptureInterest(string input, out string topic)
    {
        topic = string.Empty;
        string lower = input.ToLowerInvariant();

        string[] patterns =
        [
            "interested in ",
            "interest in ",
            "i like ",
            "i love ",
            "i care about "
        ];

        foreach (string pattern in patterns)
        {
            int idx = lower.IndexOf(pattern, StringComparison.Ordinal);
            if (idx < 0) continue;

            string remainder = input[(idx + pattern.Length)..].Trim().TrimEnd('.', '!', '?');
            if (remainder.Length == 0) continue;

            topic = _keywordRecognizer.RecognizeTopic(remainder) ?? remainder.Split(' ')[0].ToLowerInvariant();
            return true;
        }

        return false;
    }

    private string? TryMetaResponse(string normalized, SentimentType sentiment)
    {
        if (normalized is "how are you" or "how are you?" or "how are you doing")
        {
            return _adaptResponse(
                $"I am doing well, {_user.Name}. Thank you for asking! I am ready to help you with cybersecurity awareness.",
                sentiment,
                _user.Name);
        }

        if (normalized.Contains("purpose") || normalized.Contains("what do you do"))
        {
            return _adaptResponse(
                "My purpose is to teach users about cybersecurity and help them stay safe from online threats.",
                sentiment,
                _user.Name);
        }

        if (normalized.Contains("what can i ask") || normalized.Contains("what can you help") || normalized.Contains("help me with"))
        {
            var topics = string.Join(", ", ResponseService.GetTopicList());
            return _adaptResponse(
                $"You can ask me about {topics}, or tell me what you're interested in so I can remember it.",
                sentiment,
                _user.Name);
        }

        if (normalized.Contains("hello") || normalized is "hi" or "hey")
        {
            return _adaptResponse($"Hello again, {_user.Name}! What cybersecurity topic can I help with?", sentiment, _user.Name);
        }

        return null;
    }

    private string? TryMemoryRecall(string normalized, SentimentType sentiment)
    {
        if (normalized.Contains("my name") || normalized.Contains("who am i") || normalized.Contains("remember my name"))
        {
            string? name = _memory.Recall("name") ?? _user.Name;
            return _adaptResponse($"Your name is {name}.", sentiment, _user.Name);
        }

        if (normalized.Contains("what do you remember") || normalized.Contains("what did i tell you"))
        {
            var entries = _memory.GetAll();
            if (entries.Count == 0)
                return _adaptResponse("I haven't stored any details yet—tell me what you're interested in!", sentiment, _user.Name);

            string facts = string.Join("; ", entries.Select(e => $"{e.Key}: {e.Value}"));
            return _adaptResponse($"Here's what I remember: {facts}.", sentiment, _user.Name);
        }

        string? interest = _memory.Recall("interest");
        if (interest != null && (normalized.Contains("interest") || normalized.Contains("remember")))
        {
            return _adaptResponse(
                $"You mentioned you're interested in {interest}. Would you like another tip about that?",
                sentiment,
                _user.Name);
        }

        return null;
    }

    private static bool IsFollowUpRequest(string normalized) =>
        normalized.Contains("another tip") ||
        normalized.Contains("more tip") ||
        normalized.Contains("explain more") ||
        normalized.Contains("tell me more") ||
        normalized.Contains("give me more") ||
        normalized is "more" ||
        normalized.Contains("go on") ||
        normalized.Contains("continue");

    private static bool IsExitCommand(string normalized) =>
        normalized is "exit" or "quit" or "bye" or "goodbye" or "close";

    private string EmitBot(string message, bool isError = false)
    {
        BotMessage?.Invoke(message, isError);
        return message;
    }
}
