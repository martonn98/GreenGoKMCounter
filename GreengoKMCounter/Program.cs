using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreengoKMCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader mbox = new StreamReader("mail.mbox");
            double km = 0;
            string subKm = "";
            string line = "";
            while (mbox.EndOfStream == false)
            {
                line = mbox.ReadLine();
                if (line.StartsWith("A bérlésed során"))
                {
                    string[] lines = line.Split('k');
                    char[] chArray = lines[0].ToCharArray();
                    int endPos = chArray.Length;
                    int startPos = 0;
                    for (int i = endPos - 1; i > 0; i--)
                    {
                        if (chArray[i] == '>')
                        {
                            startPos = i + 1;
                            break;
                        }
                    }
                    for (int i = startPos; i < endPos; i++)
                    {
                        subKm += chArray[i];
                    }
                    Console.WriteLine(subKm);
                    km += double.Parse(subKm, System.Globalization.CultureInfo.InvariantCulture);
                    subKm = "";
                }
            }
            Console.WriteLine("Az összes megtett kilométered: " + km);
            Console.ReadLine();
        }
    }
}
