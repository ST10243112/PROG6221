using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace CyberSecurityChatbotSA
{
    internal class CyberBot
    {
        private string userName;

        public void Launch()
        {
            PlayVoiceGreeting();
            ShowWelcomeMessage();
            AskForName();
            GreetUser();
            StartConversation();
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Welcome.wav");
                player.Load();
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio playback failed: " + ex.Message);
            }
        }

        private void ShowWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
_________        ___.                                                  .__  __              _____                                                              
\_   ___ \___.__.\_ |__   ___________  ______ ____   ____  __ _________|__|/  |_ ___.__.   /  _  \__  _  _______ _______   ____   ____   ____   ______ ______  
/    \  \<   |  | | __ \_/ __ \_  __ \/  ___// __ \_/ ___\|  |  \_  __ \  \   __<   |  |  /  /_\  \ \/ \/ /\__  \\_  __ \_/ __ \ /    \_/ __ \ /  ___//  ___/  
\     \___\___  | | \_\ \  ___/|  | \/\___ \\  ___/\  \___|  |  /|  | \/  ||  |  \___  | /    |    \     /  / __ \|  | \/\  ___/|   |  \  ___/ \___ \ \___ \   
 \______  / ____| |___  /\___  >__|  /____  >\___  >\___  >____/ |__|  |__||__|  / ____| \____|__  /\/\_/  (____  /__|    \___  >___|  /\___  >____  >____  >  
        \/\/          \/     \/           \/     \/     \/                       \/              \/             \/            \/     \/     \/     \/     \/  
");
            Console.ResetColor();

            Console.WriteLine("\nHello! Welcome to the Cybersecurity Awareness Bot.");
            Console.WriteLine("I'm here to help you stay safe online.\n");
        }

        private void AskForName()
        {
            while (true)
            {
                Console.Write("What’s your name? ");
                userName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userName))
                {
                    break;
                }
                Console.WriteLine("Please enter a valid name.");
            }
        }

        private void GreetUser()
        {
            Console.WriteLine($"\nNice to meet you, {userName}! Let's get started with some cybersecurity tips.\n");
        }

        public void StartConversation()
        {
            string input;
            Console.WriteLine("You can ask me about cybersecurity topics like phishing, passwords, 2FA, and more.\n(Type 'exit' to quit)\n");

            // Keyword-based cybersecurity tips
            Dictionary<List<string>, string> awarenessTips = new Dictionary<List<string>, string>
{
    {
        new List<string> { "phishing", "phish", "scam email" },
        "Phishing is when attackers trick you into giving up personal info by pretending to be a trusted source. Never click suspicious links or emails asking for your credentials."
    },
    {
        new List<string> { "password", "passwords", "strong password" },
        "Always use strong, unique passwords for each account. A good password has at least 12 characters, with a mix of letters, numbers, and symbols."
    },
    {
        new List<string> { "2fa", "two factor", "two-factor", "multi-factor" },
        "Two-Factor Authentication (2FA) adds an extra layer of protection by requiring a second form of verification after your password."
    },
    {
        new List<string> { "malware", "virus", "trojan", "spyware" },
        "Malware is malicious software designed to harm or steal data. Avoid downloading files from untrusted sources and keep your antivirus up to date."
    },
    {
        new List<string> { "ransomware", "data locked", "encrypted files" },
        "Ransomware encrypts your files and demands payment for decryption. Backup your files regularly and be cautious of suspicious email attachments."
    },
    {
        new List<string> { "firewall", "network protection" },
        "A firewall acts as a barrier between your device and potential threats from the internet. Always keep your firewall enabled and configured properly."
    },
    {
        new List<string> { "vpn", "virtual private network", "secure connection" },
        "A VPN (Virtual Private Network) encrypts your internet connection, adding privacy and security, especially when using public Wi-Fi."
    },
    {
        new List<string> { "social engineering", "manipulation", "human attack" },
        "Social engineering involves manipulating people into revealing confidential info. Always verify identities before sharing sensitive data."
    },
    {
        new List<string> { "antivirus", "antimalware", "security software" },
        "Always keep your antivirus software up to date to detect and remove potential threats early."
     }
    };

            do
            {
                Console.Write("You: ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot: I didn't catch that. Could you please say something?");
                    continue;
                }

                string lowerInput = input.ToLower();
                bool foundTip = false;

                foreach (var entry in awarenessTips)
                {
                    foreach (var keyword in entry.Key)
                    {
                        if (lowerInput.Contains(keyword))
                        {
                            Console.WriteLine($"Bot: {entry.Value}");
                            foundTip = true;
                            break;
                        }
                    }

                    if (foundTip) break;
                }

                if (!foundTip)
                {
                    if (lowerInput.Contains("how are you"))
                    {
                        Console.WriteLine($"Bot: I'm functioning as expected, thanks for asking!");
                    }
                    else if (lowerInput.Contains("purpose") || lowerInput.Contains("what do you do"))
                    {
                        Console.WriteLine($"Bot: My purpose is to help you learn how to stay safe online.");
                    }
                    else if (lowerInput.Contains("what can i ask") || lowerInput.Contains("help"))
                    {
                        Console.WriteLine($"Bot: You can ask me about online safety, password tips, phishing scams, or just chat!");
                    }
                    else if (lowerInput != "exit")
                    {
                        Console.WriteLine($"Bot: I didn't quite understand that. Could you please rephrase?");
                    }
                }

            } while (input?.ToLower() != "exit");

            Console.WriteLine($"Bot: Goodbye! Stay cyber-safe.");
        }
    }
}