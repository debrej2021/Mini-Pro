using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a String: ");
            string st = Console.ReadLine();
            int result = LongestSubstring(st);
            Console.WriteLine("Length of the longest substring: " + result);
        }

        static int LongestSubstring(string s)
        {
            int maxLength = 0;
            int left = 0;
            int right = 0;
            HashSet<char> charSet = new HashSet<char>();

            while (right < s.Length)
            {
                if (!charSet.Contains(s[right]))
                {
                    charSet.Add(s[right]);

                    maxLength = Math.Max(maxLength, right - left + 1);

                    right++;
                }
                else
                {
                    charSet.Remove(s[left]);

                    left++;
                }
            }
            return maxLength;


        }
    }
}
//Console.WriteLine("Hello, World!");
