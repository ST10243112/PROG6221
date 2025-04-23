using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace CyberSecurityChatbotSA
{
    internal class CyberBot
    {
        private string userName {  get; set; }

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
                player.Load();//optional 
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
            int attempts = 0;
            const int maxAttempts = 4;

            while (attempts < maxAttempts)
            {
                try
                {
                    Console.Write("What’s your name? ");
                    userName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        Console.WriteLine("Name CANNOT be empty.");
                    }
                    else if (userName.Length <= 1)
                    {
                        Console.WriteLine("Name MUST be longer than one character.");
                    }
                    else if (userName.Any(char.IsDigit))
                    {
                        Console.WriteLine("Name should NOT contain numbers.");
                    }
                    else
                    {
                        // Valid name
                        return;
                    }

                    attempts++;
                    Console.WriteLine($"Attempt {attempts} of {maxAttempts}\n");
                    System.Threading.Thread.Sleep(1500); // 1.5-second delay
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"Input/output error: {ioEx.Message}");
                    attempts++;
                    System.Threading.Thread.Sleep(1500);
                }
                catch (OutOfMemoryException memEx)
                {
                    Console.WriteLine($"Memory error: {memEx.Message}");
                    Environment.Exit(1); // Graceful exit due to serious error
                }
                catch (ArgumentOutOfRangeException argEx)
                {
                    Console.WriteLine($"Unexpected error: {argEx.Message}");
                    attempts++;
                    System.Threading.Thread.Sleep(1500);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    attempts++;
                    System.Threading.Thread.Sleep(1500);
                }
            }

            Console.WriteLine("Too many invalid attempts or errors. Shutting down for security.");
            Environment.Exit(0);
        }

        private void GreetUser()
        {
            Console.WriteLine($"\nNice to meet you, {userName}! Let's get started with some cybersecurity tips.\n");
        }

        public void StartConversation()
        {
            string input;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n================ CyberBot Conversation Zone ================\n");
            Console.ResetColor();
            Console.WriteLine("Ask me about cybersecurity topics like phishing, passwords, 2FA, etc.");
            Console.WriteLine("(Type 'exit' to quit)\n");

            Dictionary<List<string>, string> awarenessTips = new Dictionary<List<string>, string>
   
            {
        
                { new List<string> { "phishing", "phish", "scam email" }, "Phishing is when attackers trick you into giving up personal information (like passwords or credit card numbers) by pretending to be someone you trust—often through fake emails or websites (Ciampa, 2021)." },
       
                { new List<string> { "password", "passwords", "strong password" }, "Always use strong, unique passwords for each account. A strong password includes a mix of letters, numbers, and special characters, and avoids personal information. In addtion, it must be at lease 8 characters long (Ciampa, 2021)." },
       
                { new List<string> { "2fa", "two factor", "two-factor", "multi-factor" }, "2FA adds an extra layer of protection by requiring something you know (like a password) and something you have (like a code sent to your phone) before you can log in (Ciampa, 2021)." },
       
                { new List<string> { "malware", "virus", "trojan", "spyware" }, "Malware is malicious software designed to damage or gain unauthorized access to your computer system. It includes viruses, trojans, spyware, and more (Ciampa, 2021)." },
        
                { new List<string> { "ransomware", "data locked", "encrypted files" }, "Ransomware is a type of malware that encrypts your files and demands payment (a ransom) to unlock them. Never pay the ransom—report the attack instead (Ciampa, 2021)." },
        
                { new List<string> { "firewall", "network protection" }, "A firewall acts as a protective barrier between your device and the internet, blocking unauthorized access while allowing safe communication (Ciampa, 2021)." },
        
                { new List<string> { "vpn", "virtual private network", "secure connection" }, "A VPN encrypts your internet connection to keep your data private—especially when using public Wi-Fi or unsecured networks (Ciampa, 2021)." },
       
                { new List<string> { "social engineering", "manipulation", "human attack" }, "Social engineering is the use of manipulation to trick people into giving away confidential information. It targets human psychology rather than system vulnerabilities (Ciampa, 2021)." },
        
                { new List<string> { "antivirus", "antimalware", "security software" }, "Antivirus (or antimalware) software helps detect, block, and remove malicious threats from your system. Always keep it up to date for the best protection (Ciampa, 2021)." }
   
            };

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                Console.ResetColor();
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayBotMessage("I didn't catch that. Could you please say something?");
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
                            DisplayBotMessage(entry.Value);
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
                        DisplayBotMessage("I'm functioning as expected, thanks for asking!");
                    }
                    else if (lowerInput.Contains("purpose") || lowerInput.Contains("what do you do"))
                    {
                        DisplayBotMessage("My purpose is to help you learn how to stay safe online.");
                    }
                    else if (lowerInput.Contains("what can i ask") || lowerInput.Contains("help"))
                    {
                        DisplayBotMessage("You can ask me about online safety, password tips, phishing scams, or just chat!");
                    }
                    else if (lowerInput.Contains("thanks") || lowerInput.Contains("thank you"))
                    {
                        DisplayBotMessage("My pleasure!");
                    }
                    else if (lowerInput.Contains("cool"))
                    {
                        DisplayBotMessage("No problem!");
                    }
                    else if (lowerInput != "exit")
                    {
                        DisplayBotMessage("I didn't quite understand that. Could you please rephrase?");
                    }
                }

            } while (input?.ToLower() != "exit");

            DisplayBotMessage("Goodbye! Stay cyber-safe.");
        }

        private void DisplayBotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Bot: ");
            Console.ResetColor();

            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(15); // typing effect
            }
            Console.WriteLine();
        }
    }
}