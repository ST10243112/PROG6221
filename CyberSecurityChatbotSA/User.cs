﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CyberSecurityChatbotSA
{
    internal class User
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string role { get; set; }


        public string AskforName(string name)
        {
            
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.");
            }else if (name.Length <= 1 )
            {
                throw new ArgumentException("Name must be longer than 1 character." );
            }else if (name.Any(char.IsDigit))
            {
                throw new InvalidOperationException("Name cannot contain numbers.");
            }
            else
            {
                return name;
            }
        }
    }
}
