using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Media;
using System.ComponentModel;

namespace ShieldBotGUI
{
    public partial class MainWindow : Window
    {
        private ShieldBotEngine _bot = new ShieldBotEngine();
        public ObservableCollection<ChatMessage> ChatMessages { get; set; } = new ObservableCollection<ChatMessage>();
        private string _assetsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");

        public MainWindow()
        {
            InitializeComponent();
            ChatListBox.ItemsSource = ChatMessages;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInterfaceAssets();
        }

        private void LoadInterfaceAssets()
        {
            try
            {
                // Task 1: Load ASCII art
                string logoPath = Path.Combine(_assetsPath, "logo.txt");
                if (File.Exists(logoPath))
                    AsciiLogoDisplay.Text = File.ReadAllText(logoPath);
                else
                    AsciiLogoDisplay.Text = "🛡️ [SHIELDBOT SYSTEM ONLINE] 🛡️";

                LoginGuideDisplay.Text = _bot.GetLoginInstructions();
            }
            catch (Exception)
            {
                AsciiLogoDisplay.Text = "🛡️ CORE GUARDIAN ONLINE 🛡️";
            }
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginName.Text))
            {
                // Task 5: Memory - Store user name
                _bot.UserName = LoginName.Text.Trim();
                LoginOverlay.Visibility = Visibility.Collapsed;

                PlayVoice(); // Task 1: Multimedia

                string greeting = _bot.GetTimeGreeting();
                await AddBotMessageWithTyping($"{greeting}, {_bot.UserName}! Security environment initialized.");
                await AddBotMessageWithTyping(_bot.GetInteractiveGuide());
            }
        }

        private void PlayVoice()
        {
            try
            {
                string path = Path.Combine(_assetsPath, "greeting.wav");
                if (File.Exists(path))
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Audio Error: " + ex.Message);
            }
        }

        private async Task AddBotMessageWithTyping(string fullText)
        {
            var msg = new ChatMessage { Text = "", BubbleColor = "#333333", Align = HorizontalAlignment.Left };
            ChatMessages.Add(msg);
            foreach (char c in fullText)
            {
                msg.Text += c;
                ChatListBox.ScrollIntoView(msg);
                await Task.Delay(20);
            }
        }

        private async void SendMessage()
        {
            string userText = InputTxt.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            ChatMessages.Add(new ChatMessage { Text = userText, BubbleColor = "#0078D4", Align = HorizontalAlignment.Right });
            InputTxt.Clear();

            // Task 2 & 8: Optimized Query Processing
            string botResponse = _bot.ProcessQuery(userText);
            await AddBotMessageWithTyping(botResponse);
            ChatListBox.ScrollIntoView(ChatMessages[ChatMessages.Count - 1]);
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e) => await AddBotMessageWithTyping(_bot.GetInteractiveGuide());
        private void SendBtn_Click(object sender, RoutedEventArgs e) => SendMessage();
        private void InputTxt_KeyDown(object sender, KeyEventArgs e) { if (e.Key == Key.Enter) SendMessage(); }
    }

    public class ChatMessage : INotifyPropertyChanged
    {
        private string _text = string.Empty;
        public string Text
        {
            get => _text;
            set { _text = value; OnPropertyChanged("Text"); }
        }
        public string BubbleColor { get; set; } = "#333333";
        public HorizontalAlignment Align { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}