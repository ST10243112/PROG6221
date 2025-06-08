using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityChatbotSA
{
    delegate void BotDelegate();
    internal class Program
    {
        static void Main(string[] args)
        {

            CyberBot Cyberbot = new CyberBot();

            BotDelegate myDelegate = Cyberbot.Launch;

            myDelegate(); // call bot.Launch();  

        }
    }
}
