using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Logger
{
    class Program
    {
        static void Main()
        {
            string inputDare = Console.ReadLine();
            var now = GetValue(inputDare);
            SortedDictionary<DateTime, string> messegeDictionary = new SortedDictionary<DateTime, string>();
            string line = String.Empty;
            while ((line = Console.ReadLine()) != "END")
            {
                string[] temp = line.Split('/');
                string messege = temp[0].Trim();
                string dateForMessege = temp[1].Trim();
                var dateMessege = GetValue(dateForMessege);
                messegeDictionary.Add(dateMessege, messege);
            }
            foreach (var pair in messegeDictionary)
            {
                Console.WriteLine("<div>{0}</div>", SecurityElement.Escape(pair.Value));
            }
            var lastActivity = messegeDictionary.Last().Key;
            TimeSpan time = now - lastActivity;
            if ((now.Day - 1) > lastActivity.Day)
            {
                Console.WriteLine("<p>Last active: <time>{0:dd-MM-yyyy}</time></p>", messegeDictionary.Last().Key);
                return;
            }

            if (lastActivity.Day == now.Day - 1)
            {
                Console.WriteLine("<p>Last active: <time>yesterday</time></p>");
                return;
            }

            if (lastActivity.Day == now.Day && time.TotalHours >= 1)
            {
                Console.WriteLine("<p>Last active: <time>{0} hour(s) ago</time></p>", (int)time.TotalHours);
            }
            else if (time.TotalHours < 1 && time.TotalMinutes >= 1)
            {
                Console.WriteLine("<p>Last active: <time>{0} minute(s) ago</time></p>", (int)time.TotalMinutes);
            }
            else
            {
                Console.WriteLine("<p>Last active: <time>a few moments ago</time></p>");
            }



        }

        private static DateTime GetValue(string inputdate)
        {

            string[] dateNow = inputdate.Split(' ', '-', ':');
            int day = int.Parse(dateNow[0] + "");
            int mounth = int.Parse(dateNow[1] + "");
            int year = int.Parse(dateNow[2] + "");
            int hour = int.Parse(dateNow[3] + "");
            int minute = int.Parse(dateNow[4] + "");
            int sec = int.Parse(dateNow[5] + "");
            DateTime now = new DateTime(year, mounth, day, hour, minute, sec);
            return now;
        }
    }
}
