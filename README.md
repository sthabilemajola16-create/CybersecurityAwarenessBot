# Cybersecurity Awareness Bot

Youtube Video Link [https://youtu.be/uaExzqCbxa4]

A C# console chatbot that teaches basic cybersecurity concepts such as password safety, phishing, safe browsing, malware, scams, and suspicious links.

## Overview

This project is a beginner-friendly educational bot built with .NET. It introduces users to important cyber safety topics through simple, text-based interaction in the console.

At startup, the app:
- Displays a themed console header
- Plays a greeting audio file (`Assets/Greetings.wav`) when available
- Asks for the user's name
- Provides cybersecurity guidance based on user prompts

## Features

- Interactive chatbot conversation in the terminal
- Named user profile for personalized responses
- Predefined cybersecurity topic responses
- Styled console output for bot, errors, and success messages
- Optional WAV greeting playback using `System.Media.SoundPlayer`

## Supported Prompts

Examples of prompts currently handled:
- `how are you`
- `what's your purpose`
- `what can i ask you about`
- `password` or `password safety`
- `phishing`
- `safe browsing`
- `malware`
- `scams` or `online scams`
- `suspicious links` or `links`

## Project Structure

- `Program.cs` - Application entry point and startup flow
- `Services/ChatBotServices.cs` - Prompt matching and response routing
- `Services/ResponseServices.cs` - Cybersecurity response content
- `Services/AudioPlayer.cs` - Greeting audio playback helper
- `UI/ConsoleUI.cs` - Console output styling and typing effect
- `Model/UserProfile.cs` - Basic user model
- `CybersecurityAwarenessBot.csproj` - Project configuration and dependencies

## Requirements

- .NET 10 SDK (target framework: `net10.0`)
- Windows environment for WAV playback support

## How To Run

1. Open a terminal in the project folder.
2. Restore dependencies:
   - `dotnet restore`
3. Run the app:
   - `dotnet run`

## Notes

- The greeting audio file is configured to copy to output if `Assets/Greetings.wav` exists.
- `ChatbotService.StartChat(...)` is currently not implemented in the source and must be completed for full chat-loop behavior.


## References

- [W3Schools - Cyber Security Tutorial](https://www.w3schools.com/cybersecurity/)
- [Microsoft Learn - .NET Documentation](https://learn.microsoft.com/dotnet/)

