# Cybersecurity Awareness Bot — Part 2

A **WPF (Windows Presentation Foundation)** chatbot that teaches cybersecurity through an interactive GUI. Part 2 adds keyword recognition, random responses, conversation flow, memory, sentiment detection, and polished presentation features from Task 1 (ASCII art and voice greeting).

## Overview

The bot helps users learn about password safety, phishing, malware, scams, privacy, safe browsing, suspicious links, VPNs, and two-factor authentication. It detects how users feel (worried, curious, frustrated) and adjusts replies, remembers interests, and continues topics when users ask for more detail.

## Part 2 Features (Rubric Alignment)

| Requirement | Implementation |
|-------------|----------------|
| **GUI (WPF)** | `MainWindow.xaml` — themed layout, chat bubbles, header with ASCII art, greeting button |
| **Keyword recognition** | `KeywordRecognizer` — dictionary maps natural language to topics |
| **Random responses** | `ResponseService` — `List<string>` per topic, random selection |
| **Conversation flow** | `ConversationContext` — follow-ups ("another tip", "explain more") continue current topic |
| **Memory & recall** | `MemoryService` — generic `List<UserMemoryEntry>` stores name and interests |
| **Sentiment detection** | `SentimentDetector` + `SentimentResponseAdapter` delegate |
| **Error handling** | Empty input, unknown prompts, try/catch — no crashes |
| **OOP & optimisation** | Classes, dictionaries, lists, delegates in `Delegates/ResponseDelegates.cs` |
| **Voice greeting** | `AudioPlayer` plays `Assets/Greetings.wav` on startup and via button |

## Learning Objectives Demonstrated

- **WPF GUI** — graphical chat interface replacing the console
- **Generic collections** — `List<UserMemoryEntry>`, `List<string>` response pools
- **Delegates** — `SentimentResponseHandler`, `BotMessageHandler`, `UserMessageHandler`

## Project Structure

```
CybersecurityAwarenessBot/
├── App.xaml / App.xaml.cs          # Application resources and startup
├── MainWindow.xaml / .cs           # GUI chat interface
├── Assets/Greetings.wav            # Voice greeting (add your WAV file)
├── Delegates/ResponseDelegates.cs  # Delegate definitions
├── Models/
│   ├── UserProfile.cs
│   ├── ConversationContext.cs
│   ├── SentimentType.cs
│   └── UserMemoryEntry.cs
└── Services/
    ├── ChatbotService.cs           # Main conversation engine
    ├── KeywordRecognizer.cs
    ├── ResponseService.cs
    ├── SentimentDetector.cs
    ├── SentimentResponseAdapter.cs
    ├── MemoryService.cs
    └── AudioPlayer.cs
```

## Requirements

- **.NET 10 SDK** (target: `net10.0-windows`)
- **Windows** (WPF + WAV playback)

## How To Run

1. Open a terminal in the project folder.
2. Restore and run:
   ```bash
   dotnet restore
   dotnet run
   ```
3. Optional: add `Assets/Greetings.wav` for the voice greeting (the app runs without it).

## Example Conversations

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

## Repository

**Local Git:** initialized with 6 commits (meets minimum requirement).

**Next steps:**
1. Create a new repository on [GitHub](https://github.com/new)
2. Push this project:
   ```bash
   git remote add origin https://github.com/YOUR_USERNAME/CybersecurityAwarenessBot.git
   git branch -M main
   git push -u origin main
   ```
3. Create **2–3 Releases** on GitHub (e.g. `v1.0-part1`, `v2.0-part2`) with short release notes

## Video Presentation

- **Part 1:** https://youtu.be/uaExzqCbxa4  
- **Part 2:** _Add your unlisted YouTube link here after recording_

### Part 2 voice-over summary (read while demoing the app and code)

Hello, I am **[Andiswa Majola]**, student number **[ST10486077]**. This is **Part 2** of my Cybersecurity Awareness Bot. **Part 1** was a console app with ASCII art and a voice greeting — see https://youtu.be/uaExzqCbxa4. **Part 2** upgrades it to a **WPF GUI** in C# (.NET 10) that teaches cybersecurity topics such as passwords, phishing, scams, privacy, malware, and safe browsing. The interface keeps the ASCII header and **Greetings.wav** audio, uses a chat panel with styled bubbles, and asks for the user's name for personalisation. The bot uses **keyword recognition** (`KeywordRecognizer` dictionary) to understand natural questions, **random responses** (`ResponseService` lists) so tips vary, and **conversation flow** (`ConversationContext`) so phrases like "give me another tip" continue the same topic. **Memory** (`MemoryService` with `List<UserMemoryEntry>`) stores interests and recalls them later; **sentiment detection** (`SentimentDetector` and a **delegate** in `SentimentResponseAdapter`) adjusts replies when users sound worried, curious, or frustrated — for example, "I'm worried about online scams" gets empathy plus an immediate tip. **Error handling** returns friendly fallbacks without crashing. The code is organised into Models, Services, Delegates, and UI files such as `ChatbotService`, `MainWindow.xaml`, and `ResponseDelegates.cs`. The full project is on GitHub with six or more commits and tagged releases. Thank you for watching.

---

## Submission Checklist (ARC / GitHub)

- [ ] Complete project folder on GitHub (source, README, `Assets/Greetings.wav`)
- [x] Minimum **6 meaningful commits** (7 commits done locally)
- [ ] **Releases/tags** on GitHub (rubric: at least 2–3 tagged releases with notes)
- [ ] **YouTube unlisted video** — voice-over explaining structure, logic, delegates, memory, sentiment
- [ ] Submit GitHub + video links on ARC

## References

- [W3Schools - Cyber Security Tutorial](https://www.w3schools.com/cybersecurity/)
- [Microsoft Learn - WPF Documentation](https://learn.microsoft.com/dotnet/desktop/wpf/)
- [Microsoft Learn - .NET Documentation](https://learn.microsoft.com/dotnet/)
