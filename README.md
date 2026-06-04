 # Cybersecurity Awareness Bot — Part 2

A **WPF (Windows Presentation Foundation)** chatbot that teaches cybersecurity through an interactive GUI. Part 2 adds keyword recognition, random responses, conversation flow, memory, sentiment detection, and polished presentation features from Task 1 (ASCII art and voice greeting).

Overview

The bot helps users learn about password safety, phishing, malware, scams, privacy, safe browsing, suspicious links, VPNs, and two-factor authentication. It detects how users feel (worried, curious, frustrated) and adjusts replies, remembers interests, and continues topics when users ask for more detail.


**Project Structure**

```
CybersecurityAwarenessBot/
├── App.xaml / App.xaml.cs          -Application resources and startup
├── MainWindow.xaml / .cs           -GUI chat interface
├── Assets/Greetings.wav            -Voice greeting (add your WAV file)
├── Delegates/ResponseDelegates.cs   -Delegate definitions
├── Models/
│   ├── UserProfile.cs
│   ├── ConversationContext.cs
│   ├── SentimentType.cs
│   └── UserMemoryEntry.cs
└── Services/
    ├── ChatbotService.cs           -Main conversation engine
    ├── KeywordRecognizer.cs
    ├── ResponseService.cs
    ├── SentimentDetector.cs
    ├── SentimentResponseAdapter.cs
    ├── MemoryService.cs
    └── AudioPlayer.cs
```

Followed up Requirements

- **.NET 10 SDK** (target: `net10.0-windows`)
- **Windows** (WPF + WAV playback)

How To Run

1. Open a terminal in the project folder.
2. Restore and run:
   ```bash
   dotnet restore
   dotnet run
   ```
3. Optional: add `Assets/Greetings.wav` for the voice greeting (the app runs without it).

Example Conversations

**Worried + keyword (immediate tip):**
```
User: I'm worried about online scams
Bot: It's completely understandable to feel that way, Alex. You're taking the right step...
     [random scam safety tip]
```

**Memory:**
```
User: I'm interested in privacy
Bot: Great! I'll remember that you're interested in privacy. [privacy tip]

User: What do you remember?
Bot: Here's what I remember: name: Alex; interest: privacy.
```

**Follow-up flow:**
```
User: Tell me about phishing
Bot: [random phishing tip]

User: Give me another tip
Bot: Another tip for you: [another random phishing tip]
```

Video Presentation **YoutubeVideo**

- **Part 1:** https://youtu.be/uaExzqCbxa4  
- **Part 2:** https://youtu.be/twMD03EOrIg

## References

- [W3Schools - Cyber Security Tutorial](https://www.w3schools.com/cybersecurity/)
- [Microsoft Learn - WPF Documentation](https://learn.microsoft.com/dotnet/desktop/wpf/)
- [Microsoft Learn - .NET Documentation](https://learn.microsoft.com/dotnet/)
