using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Z_Type
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] textToArrey = addWords();

            int wordsCount = 0;
            Random ran = new Random();
            Console.BufferHeight = Console.WindowHeight;
            DateTime start = DateTime.Now;
            fallingWords(ran, textToArrey, wordsCount, start);
        }

        private static void fallingWords(Random ran, string[] textToArrey, int wordsCount, DateTime start)
        {
            int randomWordIndesx = ran.Next(0, textToArrey.Length);
            int randomWordPosition = ran.Next(10, 60);
            string curentWordString = textToArrey[randomWordIndesx];
            Queue<char> que = new Queue<char>();
            foreach (var letter in curentWordString)
            {
                que.Enqueue(letter);
            }

            for (int i = 0; ; i++)
            {
                if (que.Count == 0)
                {
                    wordsCount++;
                    fallingWords(ran, textToArrey, wordsCount, start);
                    break;
                }
                Console.Clear();
                char pressedBuon = new char();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo a = Console.ReadKey();
                    pressedBuon = a.KeyChar;
                    Console.Clear();
                }

                // var tem = que.First();
                if (que.First() == pressedBuon)
                {
                    que.Dequeue();
                }
                if (i == Console.BufferHeight)
                {
                    DateTime end = DateTime.Now;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("GAME OVER");
                    var playedTime = end - start;
                    int min = 0;
                    if (playedTime.Minutes > min)
                    {
                        min = playedTime.Minutes;
                    }
                    double playedTimeInSeconds = playedTime.Seconds + (min * 60);
                    double wordsPerSecond = wordsCount / playedTimeInSeconds;
                    Console.WriteLine("Words per minute: {0:0.#}", wordsPerSecond * 60);
                    //Console.WriteLine("play time {0}",playedTime);
                    //Console.WriteLine("seconds={0}",playedTimeInSeconds);
                    //Console.WriteLine(wordsCount);
                    break;
                }
                //print
                Console.SetCursorPosition(randomWordPosition, i);
                Console.Write(new string(' ', curentWordString.Length - que.Count));
                foreach (var letter in que)
                {
                    Console.Write(letter);
                }
                //sleep++
                Thread.Sleep(400);
            }
        }

        public static string[] addWords()
        {
            string text =
                "anyone reads old english literary text familiar brown volume with symbol jewel embossed front cover " +
                "most works attributed along with some those bishop much editor receive royal expenses only very " +
                "anonymou prose and verse from the period found within skip society secular prose academic behaviour " +
                "three serie of space surviving medieval drama most middle english romance much religious drain club " +
                "verse including the english work most print all find their place rarely commission choice sent adapt " +
                "publications without editions study of medieval english texts would hardly possible wave united " +
                "frost cold zafir arm turns planet spare dedicated clears hints net impact download always a very " +
                "pleasing experience dive unique world support mood music hope enjoy listening together individual";
            string[] texttoArr = text.Split();
            return texttoArr;
        }
    }
}
