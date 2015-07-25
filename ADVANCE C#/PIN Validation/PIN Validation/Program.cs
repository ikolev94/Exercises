using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIN_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            if (names.Length != 2 || names[0].First() < 'A' || names[0].First() > 'Z' || names[1].First() < 'A' || names[1].First() > 'Z')
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }
            string firstName = names[0];
            string lastName = names[1];
            string gender = Console.ReadLine();
            string pin = Console.ReadLine();

            int mount = int.Parse(pin[2] + "" + pin[3]);
            int bonusYears = 1900;

            if (mount >= 40)
            {
                bonusYears = 2000;
                mount -= 40;
            }
            else if (mount >= 20)
            {
                bonusYears = 1800;
                mount -= 20;
            }
            int day = int.Parse(pin[4] + "" + pin[5]);
            int year = int.Parse(pin[0] + "" + pin[1]) + bonusYears;
            string realData = year + "," + mount + "," + day;

            bool genderValid = GenderChek(pin, gender);

            DateTime temp = new DateTime();
            if (!DateTime.TryParse(realData, out temp) || genderValid == false)
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
            }
            else
            {
                int[] nuberToMultiplay = new[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
                char[] pinToChar = pin.ToCharArray();
                int sum = 0;
                for (int i = 0; i < nuberToMultiplay.Length; i++)
                {
                    sum += nuberToMultiplay[i] * int.Parse("" + pin[i]);
                }
                int checksum = 0;
                if (sum % 11 != 10)
                {
                    checksum = sum % 11;
                }
                if (checksum == int.Parse(pinToChar[9] + ""))
                {
                    Console.Write("{");
                    Console.Write("\"name\":\"{0} {1}\",\"gender\":\"{2}\",\"pin\":\"{3}\"", firstName, lastName, gender, pin);
                    Console.Write("}");

                }
                else
                {
                    Console.WriteLine("<h2>Incorrect data</h2>");
                }

            }

        }

        private static bool GenderChek(string pin, string gender)
        {
            bool temp = false;
            int genNmber = int.Parse("" + pin[8]);
            if (gender == "male" && genNmber % 2 == 0)
            {
                temp = true;
            }
            if (gender == "female" && genNmber % 2 == 1)
            {
                temp = true;
            }
            return temp;

        }
    }
}
