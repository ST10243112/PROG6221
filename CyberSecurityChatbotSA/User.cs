using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace CyberSecurityChatbotSA
{
    internal class User
    {
        public string userName { get; set; }
        public  string FavouriteTopic { get;  set; }
        protected string email { get; set; }
        protected  string role { get; set; }

        protected HashSet<string> mentionedTopics = new HashSet<string>();

        public string AskforNameValidate(string name)
        {
            
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.");

            }
            else if (name.Length == 1 && name.Any(char.IsLetter))
            {
                throw new ArgumentException("Name must be longer than 1 character.");

            }
            else if (name.Any(char.IsDigit))
            {
                throw new InvalidOperationException("Name cannot be or contain numbers.");
            }
            else
            {
                if (name.All(char.IsLower))
                {
                    name = char.ToUpper(name[0]) + name.Substring(1);
                }
                return name;
            }
        }

        public string AskforFavouriteTopicValidate(string topic )
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException("Topic cannot be null or empty.");

            }
            else if (topic.Length == 1 && topic.Any(char.IsLetter))
            {
                throw new ArgumentException("Topic must be longer than 1 character.");

            }
            else if (topic.All(char.IsDigit))
            {
                throw new InvalidOperationException("Topic cannot be a number.");
            }
            else
            {
                return topic; 
            }

        }
       

        public bool HashMentionedTopic(string topic)
        {
            return mentionedTopics.Contains(topic);
        }
    }
}
