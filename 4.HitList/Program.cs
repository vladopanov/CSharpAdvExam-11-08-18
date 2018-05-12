using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            byte targetInfoIndex = byte.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            var dictionary = new Dictionary<string, Dictionary<string, string>>();
            while (line != "end transmissions")
            {
                string[] splitByEqual = line.Split(new char[] { '=' }, StringSplitOptions.None);
                string name = splitByEqual[0];
                string[] keyValuePairs = splitByEqual[1].Split(new char[] { ';' }, StringSplitOptions.None);
                foreach(var keyValuePair in keyValuePairs)
                {
                    string key = keyValuePair.Split(new char[] { ':' }, StringSplitOptions.None)[0];
                    string value = keyValuePair.Split(new char[] { ':' }, StringSplitOptions.None)[1];
                    if (dictionary.ContainsKey(name))
                    {
                        dictionary[name][key] = value;
                    }
                    else
                    {
                        dictionary[name] = new Dictionary<string, string>
                        {
                            [key] = value
                        };
                    }
                }

                line = Console.ReadLine();
            }

            string lastLine = Console.ReadLine();
            string nameKilled = lastLine.Split("Kill ")[1];

            var killedPerson = dictionary[nameKilled];
            var sb = new StringBuilder();
            sb.AppendLine($"Info on {nameKilled}:");
            int infoIndex = 0;
            foreach (var keyValuePair in killedPerson.OrderBy(kv => kv.Key))
            {
                infoIndex += keyValuePair.Key.Length + keyValuePair.Value.Length;
                sb.AppendLine($"---{keyValuePair.Key}: {keyValuePair.Value}");
            }
            sb.AppendLine($"Info index: {infoIndex}");
            if (infoIndex >= targetInfoIndex)
            {
                sb.AppendLine("Proceed");
            }
            else
            {
                sb.AppendLine($"Need {targetInfoIndex - infoIndex} more info.");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
