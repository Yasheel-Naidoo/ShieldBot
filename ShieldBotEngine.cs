using System;
using System.Collections.Generic;
using System.Linq;

namespace ShieldBotGUI
{
    public class ShieldBotEngine
    {
        // Task 8: Dictionary for optimized keyword management
        private Dictionary<string, List<string>> _knowledgeBase = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
        private Random _rnd = new Random();

        // Task 5: Memory for personalization
        public string UserName { get; set; } = "User";
        public string LastTopic { get; set; } = "";

        public ShieldBotEngine() { InitializeData(); }

        private void InitializeData()
        {
            // Task 3: Random variation with a touch of wit
            _knowledgeBase = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "password", new List<string> {
                    "Using 'Password123' is like locking your house with a piece of wet spaghetti. Try a long passphrase instead!",
                    "Your password should be like a toothbrush: choose a good one, don't share it, and change it if things get weird.",
                    "If your password is your dog's name, even the dog is disappointed in you. Use 12+ mixed characters!" }},
                { "phishing", new List<string> {
                    "If a prince from a far-off land emails you for money, he's probably not a prince. Don't click that link!",
                    "Phishing emails are like bad exes: they pretend to be someone they're not and just want your data. Block them.",
                    "Always hover over links. If it says 'Bank' but the link goes to 'ScamCity.exe', maybe don't click it?" }},
                { "mfa", new List<string> {
                    "MFA is the digital equivalent of a bouncer with a clipboard. No code, no entry!",
                    "Even if a hacker steals your password, MFA stops them cold. It's the MVP of security.",
                    "Using MFA stops 99% of bulk attacks. The other 1% is just me being impressed by your security habits." }}
            };
        }

        public string GetLoginInstructions() => "1. Identify yourself (First Name)\n2. Provide the secret handshake (Access Key)\n3. Click INITIALIZE to summon me.\n© 2026 Yasheel Naidoo";

        public string GetInteractiveGuide() => "🛡️ SHIELDBOT MANUAL:\n• Ask about 'Passwords', 'Phishing', or 'MFA'.\n• Type 'Tell me more' if you're feeling curious.\n• I can sense if you're 'worried' or 'scared'—I've got your back!\n• I don't do weather or sports. I have standards.";

        public string GetTimeGreeting() => DateTime.Now.Hour < 12 ? "Morning, early bird" : DateTime.Now.Hour < 17 ? "Good Afternoon" : "Good Evening, night owl";

        public string ProcessQuery(string input)
        {
            string cleanInput = input.ToLower().Trim();

            // Time Correction logic with humor
            int hour = DateTime.Now.Hour;
            if (cleanInput.Contains("morning") && hour >= 12)
                return $"Morning? {UserName}, it's {DateTime.Now:HH:mm}. The sun is literally right there. Anyway, how's your security?";

            // Domain Limiting with personality
            if (cleanInput.Contains("weather") || cleanInput.Contains("sport"))
                return "Do I look like a news anchor? I'm here to stop hackers, not tell you if it's raining. Ask me about your passwords!";

            // Task 6: Sentiment Detection & Humor-infused Support
            if (cleanInput.Contains("worried") || cleanInput.Contains("scared") || cleanInput.Contains("overwhelmed"))
                return "Deep breaths, {UserName}. The internet is a dark place, but that's why I'm here. Let's fix one thing at a time. Start with MFA!";

            // Task 4: Affirmative natural flow
            if (cleanInput == "sure" || cleanInput == "yes" || cleanInput == "ok")
                return "That's the spirit! Should we look at MFA or Phishing first?";

            // Task 2: Keyword Recognition
            foreach (var key in _knowledgeBase.Keys)
            {
                if (cleanInput.Contains(key))
                {
                    LastTopic = key;
                    return $"[Subject: {key}] " + _knowledgeBase[key][_rnd.Next(_knowledgeBase[key].Count)];
                }
            }

            // Task 5: Memory Recall
            if ((cleanInput.Contains("more") || cleanInput.Contains("explain")) && !string.IsNullOrEmpty(LastTopic))
            {
                return $"Still hungry for info on {LastTopic}? I like your style. Here's more: " + _knowledgeBase[LastTopic][_rnd.Next(_knowledgeBase[LastTopic].Count)];
            }

            return "I'm a genius bot, but even I don't know what that means. Try asking about 'Passwords' or 'MFA'.";
        }
    }
}