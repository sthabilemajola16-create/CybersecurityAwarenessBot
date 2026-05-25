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
- **Part 2:** 

### Part 2 voice-over summary 

**Part 1** was a console app with ASCII art and a voice greeting — see https://youtu.be/uaExzqCbxa4. **Part 2** upgrades it to a **WPF GUI** in C# (.NET 10) that teaches cybersecurity topics such as passwords, phishing, scams, privacy, malware, and safe browsing. The interface keeps the ASCII header and **Greetings.wav** audio, uses a chat panel with styled bubbles, and asks for the user's name for personalisation. The bot uses **keyword recognition** (`KeywordRecognizer` dictionary) to understand natural questions, **random responses** (`ResponseService` lists) so tips vary, and **conversation flow** (`ConversationContext`) so phrases like "give me another tip" continue the same topic. **Memory** (`MemoryService` with `List<UserMemoryEntry>`) stores interests and recalls them later; **sentiment detection** (`SentimentDetector` and a **delegate** in `SentimentResponseAdapter`) adjusts replies when users sound worried, curious, or frustrated — for example, "I'm worried about online scams" gets empathy plus an immediate tip. **Error handling** returns friendly fallbacks without crashing. The code is organised into Models, Services, Delegates, and UI files such as `ChatbotService`, `MainWindow.xaml`, and `ResponseDelegates.cs`. The full project is on GitHub with six or more commits and tagged releases. Thank you for watching.


## References

- [W3Schools - Cyber Security Tutorial](https://www.w3schools.com/cybersecurity/)
- [Microsoft Learn - WPF Documentation](https://learn.microsoft.com/dotnet/desktop/wpf/)
- [Microsoft Learn - .NET Documentation](https://learn.microsoft.com/dotnet/)
