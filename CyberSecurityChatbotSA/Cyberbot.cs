using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Net;
using System.Runtime.Remoting.Messaging;

namespace CyberSecurityChatbotSA
{
    internal class CyberBot : Robot, ICyberBotFeatures
    {
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
            " 10. Spoofing"
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
            WriteConsole("\n(You can ask about any of these topics during our conversation!)\n", "DarkGray");
           
            printWithTypingEffect(topics);

            WriteConsole("\n(You can ask about any of these topics during our conversation!)\n", "DarkGray"); 
            
        }


        private void WriteConsole(string output, string color)
        {

            if (Enum.TryParse(color, true, out ConsoleColor consoleColor))
            {
                Console.ForegroundColor = consoleColor;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White; // fallback color
            }

            Console.WriteLine(output);
            Console.ResetColor();
        }

        public void StartConversation()
        {
            string input;
            WriteConsole("\n================ CyberBot Conversation Zone ================\n", "Yellow");
            Console.WriteLine("(Type 'exit' or 'bye' to quit)\n");

            DisplayBotMessage("What is  your favourite topic related to online safety?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{userName}: ");
            Console.ResetColor();
            string favouriteTopic = Console.ReadLine();
            User user = new User();
            user.UpdateFavouriteTopic(favouriteTopic);

            DisplayBotMessage($"You mentioned {user.FavouriteTopic} as your favourite topic. I'll keep that in mind.");


            Dictionary<List<string>, List<string>> awarenessTips = new Dictionary<List<string>, List<string>>

            {

              { new List<string> { "phishing", "phish", "scam email", "scams" },
                     new List<string>{
                       "Phishing is when attackers trick you into giving up personal information (like passwords or credit card numbers) by pretending to be someone you trust—often through fake emails or websites (Ciampa, 2021).",
                       "Watch out for emails with urgent messages asking you to click on a link or provide credentials.",
                       "Always verify the sender’s address and never click suspicious links—phishing attacks can look very convincing!"
                     } 
              },

              { new List<string> { "password", "passwords", "strong password" },
                     new List<string> {
                       "Always use strong, unique passwords for each account. A strong password includes a mix of letters, numbers, and special characters, and avoids personal information. In addition, it must be at least 14 characters long (Ciampa, 2021; Microsoft, 2025).",
                       "Do not share your password with others. Change it frequently and follow strong password best practices—minimum 14 characters, with complexity.",
                       "Your password is your first line of defense. Make it long, complex, and memorable—and don’t reuse passwords across sites!"
                     }  
              },

              { new List<string> { "2fa", "two factor", "two-factor", "multi-factor" },
                       new List<string> {
                         "2FA adds an extra layer of protection by requiring something you know (like a password) and something you have (like a code sent to your phone) before you can log in (Ciampa, 2021).",
                         "Always enable two-factor authentication (2FA) when available—it significantly reduces the chances of unauthorized access.",
                         "Multi-factor authentication protects your accounts even if your password gets compromised—use an app or SMS code as the second layer."
                       } 
                },

              { new List<string> { "malware", "virus", "trojan", "spyware" },
                       new List<string> {
                        "Malware is malicious software designed to damage or gain unauthorized access to your computer system. It includes viruses, trojans, spyware, and more (Ciampa, 2021).",
                        "Viruses, trojans, and spyware are all types of malware—keep your software updated to avoid infection.",
                        "Avoid downloading unknown attachments or software. That’s how malware often enters systems unnoticed."
                       }
                },

   
                { new List<string> { "ransomware", "data locked", "encrypted files" },
                    new List<string> {
                      "Ransomware is a type of malware that encrypts your files and demands payment (a ransom) to unlock them. Never pay the ransom—report the attack instead (Ciampa, 2021).",
                      "Backup your data regularly—ransomware can lock you out of everything in seconds.",
                      "Ransomware attacks can cripple entire organizations. Stay protected with strong security hygiene and system backups."
                    } 
                },

  
                { new List<string> { "firewall", "network protection" },
                    new List<string> {
                       "A firewall acts as a protective barrier between your device and the internet, blocking unauthorized access while allowing safe communication (Ciampa, 2021).",
                       "Enable firewalls on your device—they help control traffic and protect against external threats.",
                       "Firewalls are like gatekeepers for your network, filtering out malicious traffic before it reaches you."
                    }
                },

       
                { new List<string> { "vpn", "virtual private network", "secure connection" },
                     new List<string> {
                        "A VPN encrypts your internet connection to keep your data private—especially when using public Wi-Fi or unsecured networks (Ciampa, 2021).",
                        "Use a VPN when accessing sensitive data over public Wi-Fi. It hides your IP and encrypts your traffic.",
                        "VPNs help protect your online privacy by masking your IP address and encrypting your data."
                     } 
                },

   
                { new List<string> { "social engineering", "manipulation", "human attack" },
                     new List<string> {
                         "Social engineering is the use of manipulation to trick people into giving away confidential information. It targets human psychology rather than system vulnerabilities (Ciampa, 2021).",
                         "Attackers often impersonate someone you trust to get information. Always double-check before you act!",
                         "Don’t be fooled by urgency or authority in messages. Social engineering thrives on pressure and trust."
   
                     }
                },

      
                { new List<string> { "antivirus", "antimalware", "security software" },
                    new List<string> {
                         "Antivirus (or antimalware) software helps detect, block, and remove malicious threats from your system. Always keep it up to date for the best protection (Ciampa, 2021).",
                         "Set your antivirus software to update automatically and scan regularly.",
                         "Security software is essential—without it, you're vulnerable to many known threats."
                    
        
                    }
                },

  
                { new List<string> { "spoofing", "email spoofing", "ip spoofing" },
                      new List<string> {
                         "Spoofing is when an attacker disguises themselves as a trusted source by faking information—like an email address or IP— to trick you into interacting with malicious content or revealing sensitive data (Ciampa, 2021).",
                         "Email spoofing makes fake emails look real. Always check the sender's full address and headers.",
                         "IP spoofing is a technique hackers use to hide their real identity and mimic trusted devices."
                      } 
                },

                 { new List<string> { "shoulder surfing", "watching", "peeking" },
                       new List<string> {
                            "Shoulder surfing is a low-tech attack where someone observes your screen or keyboard to steal sensitive information, like PINs or passwords. Always be aware of your surroundings when entering credentials (Ciampa, 2021).",
                            "Cover your screen and keyboard when entering sensitive data in public.",
                            "Watch out for people standing too close when you're entering your password—it could be a shoulder surfer."
       
                       } 
                },

  
                { new List<string> { "patch", "software update", "security update" },
        
                    new List<string> {
           
                        "Patching involves updating software to fix security vulnerabilities. Regularly applying patches and updates is critical to keeping systems protected against newly discovered threats (Ciampa, 2021).",
            
                        "Outdated software is a hacker’s dream. Always install updates as soon as they’re available.",
           
                        "Patches close the doors that attackers could otherwise walk through—don’t skip updates!"
       
                    } 
                },

  
                { new List<string> { "data breach", "breach", "leaked data" },
        
                    new List<string> {
                         "A data breach occurs when sensitive or confidential information is accessed or exposed without authorization. Breaches can lead to identity theft, financial loss, and reputational damage (Ciampa, 2021).",
                         "Breached data often ends up on the dark web—watch for alerts and change your credentials if notified.",
                         "Strong passwords and MFA can reduce the damage of a data breach. Always stay proactive."
                    
                    }
                 },

                { new List<string> { "zero-day", "0day", "zero day vulnerability" },
        
                    new List<string> {
                         "A zero-day vulnerability is a security flaw that is unknown to the vendor and has no patch available. Hackers can exploit it before it’s discovered and fixed, making it highly dangerous (Ciampa, 2021).",
                         "Zero-day exploits are dangerous because there's no defense yet. This is why rapid patching is so important.",
                         "Zero-day attacks can bypass normal defenses—use multiple layers of security and stay updated."
                
                    }
                },

   
                { new List<string> { "invoice scam" },
      
                    new List<string> {
            
                        "This is where a user clicks on a link from a fictitious website resulting in receiving a fake overdue invoice that demands immediate payment (Ciampa, 2021).",
            
                        "Invoice scams pretend to be from a supplier or vendor and push for urgent payment—always verify the request.",
           
                        "Don’t trust emailed invoices without double-checking the sender and cross-referencing with your records."
       
                    }
                }
            };

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{userName}: ");
                Console.ResetColor();
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ErrorMessage();
                   // DisplayBotMessage("I didn't catch that. Could you please say something?");
                    continue;
                }

                string lowerInput = input.ToLower().Trim();
                bool foundTip = false;
                string[] words = lowerInput.Split(new char[] { ' ', '.', ',', '?', '!', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                HashSet<string> displayedTips = new HashSet<string>();
                Random random = new Random();

                if (lowerInput.ToLower().Trim() != "exit" && lowerInput.ToLower().Trim() != "bye" && lowerInput?.ToLower().Trim() != "Goodbye")
                {
                    //We exit the loop if sentinel value is entered, and avoid error message and topic being displayed. 
                    break; 

                }
                foreach (var entry in awarenessTips)
                {
                    foreach (var keyword in entry.Key)
                    {
                        if (lowerInput.Contains(keyword.ToLower()))
                        {
                            if (!displayedTips.Contains(keyword.ToLower()))
                            {
                                var possibleResponses = entry.Value;
                                string selectedResponse = possibleResponses[random.Next(possibleResponses.Count)];
                                DisplayBotMessage(selectedResponse);
                                displayedTips.Add(keyword.ToLower());
                                foundTip = true;
                            }
                            break;
                        }

                        // Then check individual words and fuzzy match
                        foreach (var word in words)
                        {
                            bool fuzzyMatch = LevenshteinDistance(word, keyword.ToLower()) <= 1;
                            if (word.Contains(keyword.ToLower()) || fuzzyMatch)
                            {
                                if (!displayedTips.Contains(keyword.ToLower()))
                                {
                                    var possibleResponses = entry.Value;
                                    string selectedResponse = possibleResponses[random.Next(possibleResponses.Count)];
                                    DisplayBotMessage(selectedResponse);
                                    displayedTips.Add(keyword.ToLower());
                                    foundTip = true;
                                }
                                break;
                            }
                        }
                    }
                    
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

            } while (input?.ToLower().Trim() != "exit" && input?.ToLower().Trim() != "bye" && input?.ToLower().Trim() != "Goodbye");

            DisplayBotMessage("Goodbye! Stay cyber-safe.");

        }
        public void ErrorMessage()
        {
            Random random = new Random();

            string[] errorMessagePrompts = {
                 "I didn't quite understand that. Could you please rephrase?",
                 $"Sorry...{userName}, I don’t have an appropriate response for that.",
                 "Hmm, that’s outside my knowledge base. Want to try asking in a different way?",
                 $"Apologies, {userName}, I’m still learning and don’t recognize that input yet.",
                 "That's a tricky one—I don’t have an answer for it just now.",
                 "Oops! That doesn’t match any of my security topics. Want to try a related keyword?",
                 $"I couldn’t match that to anything specific, {userName}. Can you ask it differently?",
                 "That might be outside the current topic list. Maybe try something like 'phishing' or 'malware'?",
                 "I’m not sure how to respond to that yet. I’ll get smarter with time!"
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

        private int LevenshteinDistance(string a, string b)
        {
            int[,] dp = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++)
                dp[i, 0] = i;
            for (int j = 0; j <= b.Length; j++)
                dp[0, j] = j;

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int cost = (a[i - 1] == b[j - 1]) ? 0 : 1;
                    dp[i, j] = Math.Min(
                        Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                        dp[i - 1, j - 1] + cost);
                }
            }

            return dp[a.Length, b.Length];
        }

    }
}