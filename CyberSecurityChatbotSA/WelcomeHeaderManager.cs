using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityChatbotSA
{
    internal class WelcomeHeaderManager
    {
        public static void ShowCyberHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"


   _____      _                                        _ _                                                             
  / ____|    | |                                      (_) |             /\                                             
 | |    _   _| |__   ___ _ __ ___  ___  ___ _   _ _ __ _| |_ _   _     /  \__      ____ _ _ __ ___ _ __   ___  ___ ___ 
 | |   | | | | '_ \ / _ \ '__/ __|/ _ \/ __| | | | '__| | __| | | |   / /\ \ \ /\ / / _` | '__/ _ \ '_ \ / _ \/ __/ __|
 | |___| |_| | |_) |  __/ |  \__ \  __/ (__| |_| | |  | | |_| |_| |  / ____ \ V  V / (_| | | |  __/ | | |  __/\__ \__ \
  \_____\__, |_.__/ \___|_|  |___/\___|\___|\__,_|_|  |_|\__|\__, | /_/    \_\_/\_/ \__,_|_|  \___|_| |_|\___||___/___/
         __/ |                                                __/ |                                                    
        |___/                                                |___/                                                     


");
            Console.ResetColor();

        }

        public static void ShowMathHeader() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"



  __  __       _   _       ______    _                 _   _             
 |  \/  |     | | | |     |  ____|  | |               | | (_)            
 | \  / | __ _| |_| |__   | |__   __| |_   _  ___ __ _| |_ _  ___  _ __  
 | |\/| |/ _` | __| '_ \  |  __| / _` | | | |/ __/ _` | __| |/ _ \| '_ \ 
 | |  | | (_| | |_| | | | | |___| (_| | |_| | (_| (_| | |_| | (_) | | | |
 |_|  |_|\__,_|\__|_| |_| |______\__,_|\__,_|\___\__,_|\__|_|\___/|_| |_|
                                                                         
                                                                         


            ");

        }

        public static void ShowHealthHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"




  _    _            _ _   _       ______    _                 _   _             
 | |  | |          | | | | |     |  ____|  | |               | | (_)            
 | |__| | ___  __ _| | |_| |__   | |__   __| |_   _  ___ __ _| |_ _  ___  _ __  
 |  __  |/ _ \/ _` | | __| '_ \  |  __| / _` | | | |/ __/ _` | __| |/ _ \| '_ \ 
 | |  | |  __/ (_| | | |_| | | | | |___| (_| | |_| | (_| (_| | |_| | (_) | | | |
 |_|  |_|\___|\__,_|_|\__|_| |_| |______\__,_|\__,_|\___\__,_|\__|_|\___/|_| |_|
                                                                                

            ");
        }

        public static void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"

 __          __  _                          
 \ \        / / | |                         
  \ \  /\  / /__| | ___ ___  _ __ ___   ___ 
   \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \
    \  /\  /  __/ | (_| (_) | | | | | |  __/
     \/  \/ \___|_|\___\___/|_| |_| |_|\___|
            ");
        }
    }
}
