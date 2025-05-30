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


            //You can use action, not parameter no return value

            // Declare and assign the delegate using the below statement 
            //Action launchDelegate = bot.Launch;
            // Invoke the method via delegate as follows
           //  launchDelegate();

        }
    }
}
