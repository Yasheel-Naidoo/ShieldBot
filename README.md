🛡️ **ShieldBot: The Sassy Digital Guardian**
ShieldBot is a high-performance, WPF-based Cybersecurity Chatbot designed to combat digital threats in South Africa through interactive education. Built for Rosebank International Software Development Programming POE (Part 2), it combines a professional Navy, Gold, and Black aesthetic with a witty, empathetic personality to make learning about IT safety engaging and accessible.

**✨ Key Features**
**Secure Initialization:** A sleek, terminal-style login overlay that serves as a secure gateway for authorized users.

**Dynamic Intellect:** Implements time-aware greetings (e.g., correcting "Good Morning" if it is actually evening) and real-time context adjustment.

**Empathetic Sentiment Logic:** Advanced detection that identifies when a user feels "worried" or "overwhelmed," providing tailored emotional support alongside technical advice.

**Optimized Knowledge Base:** Uses Generic Dictionaries and Lists for high-speed keyword recognition targeting Phishing, Passwords, and MFA.

**Memory Recall:** Remembers user details (Name) and the last discussed topic, allowing for natural follow-up queries like "Tell me more."

**Multimedia Integration:** Synchronized voice greetings and custom ASCII branding initialized via relative pathing.

**🛠️ Technical Implementation**
**Architecture (Separation of Concerns)**
The project utilizes Object-Oriented Programming (OOP) to maintain a clean boundary between the interface and the brain:

**MainWindow.xaml / .cs:** Handles the WPF "Visual Engine," including XAML layouts, typewriter animations, and multimedia event triggers.

**ShieldBotEngine.cs:** The "Logic Engine" containing the knowledge base, sentiment analysis, and memory state.

**ChatMessage.cs:** A dedicated model implementing INotifyPropertyChanged to support real-time UI data binding.

**Advanced Techniques**
**Asynchronous Programming:** Uses async/await and Task.Delay to drive a typewriter-style animation without freezing the UI thread.

**Defensive Programming:** Comprehensive try-catch blocks protect multimedia and file-loading logic from runtime crashes.

**Relative Pathing:** Implements AppDomain.CurrentDomain.BaseDirectory to ensure the Assets/ folder is located correctly across different deployment environments.

```plain text
ShieldBot/
├── .github/
│   └── workflows/
│       └── dotnet-ci.yml        # Automated CI/CD Build Workflow
├── Assets/
│   ├── greeting.wav            # Task 1: Voice Greeting Multimedia Asset
│   └── logo.txt                # Task 1: Custom ASCII Art Branding
├── App.xaml                    # Application Entry Definition
├── App.xaml.cs                 # Application Startup Logic
├── AssemblyInfo.cs             # Project Metadata & Versioning
├── MainWindow.xaml             # Task 1: WPF UI Layout (Navy, Gold, Black Theme)
├── MainWindow.xaml.cs          # UI Logic, Multimedia Control & Animations
├── ShieldBotEngine.cs          # Task 2-8: Logic Engine (Sentiment, Memory, Dictionaries)
├── ShieldBot.csproj            # .NET Project Configuration File
├── ShieldBot.sln               # Visual Studio Solution File
└── README.md                   # Project Documentation & Harvard References

```

**🚀 How to Use**
**Login:** Enter your First Name and an Access Key. Click INITIALIZE to summon the bot.

**Voice Greeting:** Upon successful login, the system will play an automated voice greeting.

**Interact:** Type questions about cybersecurity.

**Example:** "Give me a phishing tip" or "I am worried about my security."

**Explore:** Use the memory recall by typing "Tell me more" or "Explain further" to expand on the previous topic.

**Help:** Click the ❓ icon in the header at any time to recall the interactive user guide.

**📖 References (Harvard Style)**
**Academic & Threat Landscape**
Pieterse, H. (2021) 'The Cyber Threat Landscape in South Africa: A 10-Year Review', The African Journal of Information and Communication, 28, pp. 1-21. doi:10.23962/10539/32213.

**Technical Documentation**
Microsoft (2024) INotifyPropertyChanged Interface (System.ComponentModel). Available at: [https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged) (Accessed: 29 May 2026).

Microsoft (2024) ObservableCollection Class (System.Collections.ObjectModel). Available at: [https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1) (Accessed: 29 May 2026).

Microsoft (2024) SoundPlayer Class (System.Media). Available at: [https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer](https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer) (Accessed: 29 May 2026).

**Books & Programming Principles**
Troelsen, A. and Japikse, P. (2022) Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11th edn. New York: Apress.

WPF Tutorial (2026) WPF Data Binding and Typewriter Effects. Available at: [https://www.wpf-tutorial.com/](https://www.wpf-tutorial.com/) (Accessed: 29 May 2026).

© 2026 Yasheel Naidoo. All Rights Reserved.
