using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Media;


namespace CyberSecurityChatbotSA
{
    internal abstract class Robot: User
    {
        public string BotName { get; private set; }
      

        public Robot(string botName)
        {
            BotName = botName;
        }

        public virtual void GreetUser(string userName)
        {
            DisplayBotMessage($"Hello {userName}, I am {BotName}!");
        }

        public void DisplayBotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{BotName}: ");
            Console.ResetColor();
            printWithTypingEffect(message);

        }
        public void DisplayMessage(string message)
        {
            printWithTypingEffect(message);
        }
        public void printWithTypingEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(20);
            }
            Console.WriteLine();
        }

        public void printWithTypingEffect(string[] message)
        {foreach (string s in message)
            {
                foreach (char c in s)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(20);
                }
            }
            Console.WriteLine();
        }
        public virtual void PlayVoiceGreeting(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.Load();
                    player.PlaySync();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sound error: {ex.Message}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sound file not found.");
            }
        }

       

    }
}

