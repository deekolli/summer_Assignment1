using System;

using System.Linq;
using System.Text;

namespace summer_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

               //Question 1
                Console.WriteLine("Q1 : Enter the Moves of Robot:");
                string moves = Console.ReadLine();
                bool pos = JudgeCircle(moves);
                if (pos)
                {
                    Console.WriteLine("The Robot returns to the initial position (0,0)");
                }
                else
                {
                    Console.WriteLine("The Robot does not return to the initial postion (0,0)");
                }

            // Question 2
            Console.WriteLine("Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            // Question 3
            Console.WriteLine("Q3:\nEnter array length");
            int len = int.Parse(Console.ReadLine());
            int[] arr = new int[len];
            Console.WriteLine("Enter the array of numbers");
            for (int i = 0; i < len; i++)
                arr[i] = int.Parse(Console.ReadLine());

            int result = NumIdenticalPairs(arr);
            Console.WriteLine("The number of IdenticalPairs in the array are:{0}", result);
            //Question 4
            Console.WriteLine("Q4:\nEnter the array length");
            int len1 = int.Parse(Console.ReadLine());
            int[] arr1 = new int[len1];
            Console.WriteLine("Enter the array of numbers");
            for (int i = 0; i < len1; i++)
                arr1[i] = int.Parse(Console.ReadLine());
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            //Question 5
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);
            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();






        }


        static public bool JudgeCircle(string moves)
            {
            try
            {
                //Initiliaze the variable to 0 as robot stating position is at the origin
                int x = 0;
                int y = 0;
                char[] pos = moves.ToCharArray();

                for (int i = 0; i < pos.Length; i++)
                {
                    //If the Move is R the robot moves once towards right so increment x by 1
                    if (pos[i] == 'R')
                        x=x+1;
                    //If the Move is L the robot moves once towards left so decrement x by 1
                    else if (pos[i] == 'L')
                        x=x-1;
                    //If the Move is U the robot moves once towards up so increment y by 1
                    else if (pos[i] == 'U')
                        y=y+1;
                    //If the Move is D the robot moves once towards down so decrement y by 1
                    else if (pos[i] == 'D')
                        y=y-1;
                }
                //If both x and y values are 0, it returns true, meaning that the robot returns to the starting position  
                return (x == 0 && y == 0);
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }
        static public bool CheckIfPangram(string s)
        {
            try { 
            //Initialize a variable containing the 26 alphabet(regular expression)
            string reg= "abcdefghijklmnopqrstuvwxyz";
            int count = 0;
           //Iterating every character in the regular expression and the string we entered using for loop
            foreach (char c in reg)
            {
                foreach (char c2 in s)
                {
                    if (c == c2)
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count == 26)
                return true;
            else
                return false;
        }
              catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }
        public static int NumIdenticalPairs(int[] arr)
        {
            try { 
            int count = 0;
            //iterating using for loop through the arrays and using conditional statements to identify the good pairs
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j] && i < j)
                        count++;
                }

            }
            return count;
        }
              catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }
        private static int PivotIndex(int[] nums)
        {
            try
            {

                int sum = 0, leftsum = 0;
                //using the for loops to iterate through the arrays
                for (int x = 0; x < nums.Length - 1; x++) sum += x;
                for (int i = 0; i < nums.Length; ++i)
                {
                    if (leftsum == sum - leftsum - nums[i]) return i;
                    leftsum += nums[i];
                }
                return -1;

            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }
        public static string MergeAlternately(string word1, string word2)
        {
            try
            {
                int i = 0, j = 0;
                char[] c = new char[word1.Length + word2.Length];
                //iterating through the characters 
                
                while (i < c.Length)
                {
                    
                    if (i < word1.Length)
                    {
                        c[j] = word1[i];
                    }
                    else
                    {
                        break;
                    }
                    //merging the letters alternatively
                    if (i < word2.Length)
                    {
                        c[j + 1] = word2[i];
                    }
                    else
                    {
                        break;
                    }
                    i++;
                    j += 2;
                }

                for (; i < word1.Length; i++)
                {
                    c[j++] = word1[i];
                }

                for (; i < word2.Length; i++)
                {
                    c[j++] = word2[i];
                }


                return new string(c);
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }
        private static string ToGoatLatin(string sentence)
        {
            try
            {
                //Break the words in the sentence
                var words = sentence.Split(' ');
                string s = "";
                int count = 0;
                foreach (string w in words)
                {
                    count++;
                    //if word starts with vowel
                    if (
                        w[0] == 'a' || w[0] == 'e' || w[0] == 'i' || w[0] == 'o' || w[0] == 'u' ||
                        w[0] == 'A' || w[0] == 'E' || w[0] == 'I' || w[0] == 'O' || w[0] == 'U'
                      )
                    {
                        s= s + w;
                    }
                    // if word starts with consonant
                    else
                    {
                        for (int i = 1; i < w.Length; i++)
                            s=s+w[i];
                        // add first letter of the word in the end
                        s= s + w[0];
                    }
                    // append ma
                    s = s + "ma";
                    //append a
                    for (int i = 0; i < count; i++)
                        s=s+"a";
                    
                    if (count < words.Length)
                        s = s + " ";
                }

                return s.ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }


        }


    }
}




    
 
