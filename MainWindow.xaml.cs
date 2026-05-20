using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CybersecurityAwarenessBot.Services;

namespace CybersecurityAwarenessBot;

/// <summary>
/// Main WPF window hosting the chat interface.
/// </summary>
public partial class MainWindow : Window
{
    private readonly ChatbotService _chatbot = new();

    public MainWindow()
    {
        InitializeComponent();
        WireChatbot();
        Loaded += MainWindow_Loaded;
    }

    private void WireChatbot()
    {
        _chatbot.BotMessage += (message, isError) =>
        {
            Dispatcher.Invoke(() => AppendBotBubble(message, isError));
        };

        _chatbot.UserMessage += message =>
        {
            if (!string.IsNullOrWhiteSpace(message))
                Dispatcher.Invoke(() => AppendUserBubble(message));
        };
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        AudioPlayer.PlayGreeting("Assets/Greetings.wav");
        _chatbot.BeginSession();
        InputBox.Focus();
    }

    private void PlayGreetingButton_Click(object sender, RoutedEventArgs e)
    {
        AudioPlayer.PlayGreeting("Assets/Greetings.wav");
    }

    private void SendButton_Click(object sender, RoutedEventArgs e) => SendUserInput();

    private void InputBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            SendUserInput();
            e.Handled = true;
        }
    }

    private void SendUserInput()
    {
        string text = InputBox.Text.Trim();
        if (string.IsNullOrEmpty(text))
            return;

        InputBox.Clear();
        _chatbot.ProcessMessage(text);

        if (!_chatbot.Context.AwaitingName && !string.IsNullOrEmpty(_chatbot.User.Name))
            UserNameLabel.Text = _chatbot.User.Name;

        InputBox.Focus();
        ScrollToEnd();
    }

    private void AppendUserBubble(string text)
    {
        var border = CreateBubble(text, (Brush)FindResource("UserBubbleBrush")!, HorizontalAlignment.Right);
        ChatPanel.Children.Add(border);
        ScrollToEnd();
    }

    private void AppendBotBubble(string text, bool isError)
    {
        var brushKey = isError ? "ErrorBrush" : "BotBubbleBrush";
        var border = CreateBubble($"Bot: {text}", (Brush)FindResource(brushKey)!, HorizontalAlignment.Left);
        ChatPanel.Children.Add(border);
        ScrollToEnd();
    }

    private static Border CreateBubble(string text, Brush background, HorizontalAlignment alignment)
    {
        var label = new TextBlock
        {
            Text = text,
            TextWrapping = TextWrapping.Wrap,
            Foreground = (Brush)Application.Current.FindResource("TextBrush"),
            FontSize = 14,
            Margin = new Thickness(12, 8, 12, 8),
            MaxWidth = 640
        };

        var border = new Border
        {
            Background = background,
            CornerRadius = new CornerRadius(10),
            Margin = new Thickness(alignment == HorizontalAlignment.Right ? 80 : 0, 4, alignment == HorizontalAlignment.Left ? 80 : 0, 4),
            HorizontalAlignment = alignment,
            Child = label
        };

        return border;
    }

    private void ScrollToEnd()
    {
        ChatScrollViewer.ScrollToEnd();
    }
}
