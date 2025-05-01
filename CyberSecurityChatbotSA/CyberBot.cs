using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace CyberSecurityChatbotSA
{
    internal class CyberBot : Robot, ICyberBotFeatures
    {

        private string userName { get; set; }
        public CyberBot() : base("CyberBot") { }

        string[] topics =
           {
            "1. Phishing",
            " 2. Strong Passwords",
            " 3. Two-Factor Authentication (2FA)",
            " 4. Malware & Viruses",
            " 5. Ransomware",
            " 6. Firewalls",
            " 7. VPN (Virtual Private Network)",
            " 8. Social Engineering",
            " 9. Antivirus & Security Software",
            " 10. General Chat / Questions"
            };
        public void Launch()
        {
            PlayVoiceGreeting("Welcome.wav");
            ShowWelcomeMessage();
            AskForName();
            GreetUser(userName);
            ShowCybersecurityTopics();
            StartConversation();
        }

        private void ShowWelcomeMessage()
        {
            WelcomeHeaderManager.ShowCyberHeader();
            DisplayMessage("\nHello! Welcome to the Cybersecurity Awareness Bot.");
            DisplayMessage("I'm here to help you stay safe online.\n");
        }

        private void AskForName()
        {
            int attempts = 0;
            const int maxAttempts = 4;
            User user = new User();
            bool validName = false;
            string validatedName = "No name has been validated";
            while (attempts < maxAttempts)
            {
                try
                {
                    Console.Write("What’s your name? ");
                    string input = Console.ReadLine();

                    validatedName = user.AskforName(input);
                    validName = true;
                    break;
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
                    Environment.Exit(1);
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



                {

                    Console.WriteLine($"Attempt {attempts} of {maxAttempts}\n");
                    System.Threading.Thread.Sleep(1500); // 1.5-second delay
                }

            }
            if (!validName)
            {

                Console.WriteLine("Too many invalid attempts or errors. Shutting down for security.");
                Environment.Exit(0);
            }
            userName = validatedName;
        }

        public void ShowCybersecurityTopics()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n===== Topics I Can Help With =====\n");
            Console.ResetColor();


            printWithTypingEffect(topics);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n(You can ask about any of these topics during our conversation!)\n");
            Console.ResetColor();
        }


        public void StartConversation()
        {
            string input;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n================ CyberBot Conversation Zone ================\n");
            Console.ResetColor();
            Console.WriteLine("(Type 'exit' to quit)\n");

            Dictionary<List<string>, string> awarenessTips = new Dictionary<List<string>, string>

            {

                { new List<string> { "phishing", "phish", "scam email" }, "Phishing is when attackers trick you into giving up personal information (like passwords or credit card numbers) by pretending to be someone you trust—often through fake emails or websites (Ciampa, 2021)." },

                { new List<string> { "password", "passwords", "strong password" }, "Always use strong, unique passwords for each account. A strong password includes a mix of letters, numbers, and special characters, and avoids personal information. In addtion, it must be at lease 14 characters long (Ciampa, 2021; Microsoft, 2025)." },

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
                Console.Write($"{userName}: ");
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
                        ErrorMessage();
                    }
                }

            } while (input?.ToLower().Trim() != "exit");

            DisplayBotMessage("Goodbye! Stay cyber-safe.");

        }
        public void ErrorMessage()
        {
            Random random = new Random();

            string[] errorMessagePrompts = {
            "I didn't quite understand that. Could you please rephrase?",
             $"Sorry...{userName}, I don’t have an appropriate response for that."
             };

            int randomPromptIndex = random.Next(errorMessagePrompts.Length);
            DisplayBotMessage(errorMessagePrompts[randomPromptIndex]);

            DisplayBotMessage("I can tell you more about: ");

            HashSet<int> usedIndices = new HashSet<int>();
            while (usedIndices.Count < 3)
            {
                int index = random.Next(topics.Length);
                if (usedIndices.Add(index)) // Add returns false if index already exists
                {
                    string options = topics[index];
                    DisplayBotMessage($"{options}");
                }
            }
        }
    }
}