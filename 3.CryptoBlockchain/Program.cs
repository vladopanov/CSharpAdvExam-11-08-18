using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _3.CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                sb.Append(line);
            }

            string input = sb.ToString();
            
            string pattern = @"(\{\D*\d+\D*\}|\[\D*\d+\D*\])";
            MatchCollection matches = Regex.Matches(input, pattern);

            string output = "";
            foreach (Match match in matches)
            {
                var groups = match.Groups;
                for (int i = 1; i < groups.Count; i++)
                {
                    var numbersMatch = Regex.Match(groups[i].Value, @"\d+");

                    char[] numbers = numbersMatch.Value.ToCharArray();
                    if (numbers.Length % 3 == 0)
                    {
                        for (int z = 0; z < numbers.Length; z += 3)
                        {
                            int number = int.Parse(numbers[z].ToString() + numbers[z + 1].ToString() + numbers[z + 2].ToString()) - groups[i].Value.Length;
                            output += ((char)number);
                        }
                    }
                }
            }

            Console.WriteLine(output);
        }
    }
}
