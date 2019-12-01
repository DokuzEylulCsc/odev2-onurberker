using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnurBerkerALHAS_2015280003
{
    class Program
    {
        /// <summary>
        /// The guide that i use for converting roman number to decimal number.
        /// </summary>
        private static Dictionary<char, int> guide2 = new Dictionary<char, int>() 
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},                
                {'M', 1000}
            };
        /// <summary>
        /// The guide that i use for converting decimal number to roman number.
        /// </summary>
        private static string[,] guide ={// 1   2     3    4    5   6      7     8      9
                             {"I","II","III","IV","V", "VI","VII","VIII","IX"},
                             {"X","XX","XXX","XL","L","LX", "LXX","LXXX","XC"},
                             {"C","CC","CCC","CD","D","DC", "DCC","DCCC","CM"},
                             {"M","MM","MMM","","","","","",""}
                                         };
        static void Main(string[] args)
        {

            menu();

            Console.ReadKey();
        }
        /// <summary>
        /// This method converts a decimal number to roman number.
        /// </summary>
        /// <param name="value">The value is the number that i get between 1 and 3999.</param>
        /// <returns>Converted roman number.</returns>
        public static string decimalToRoman(int value)
        {
            if (!(value >= 1 && value <= 3999))
            {
                Console.WriteLine("Number is out of range");
                return null;
            }

            StringBuilder sb = new StringBuilder();

            int curDigit = 0;
            while (value != 0) //for digit by digit.
            {
                curDigit++;
                if (value % 10 != 0)
                    sb.Insert(0, guide[curDigit - 1, (value % 10) - 1]);

                value = value / 10;
            }
            return sb.ToString();
        }
        /// <summary>
        /// This method converts a roman number to decimal number.
        /// </summary>
        /// <param name="s">Roman number expression.</param>
        /// <returns>Converted decimal expression.</returns>
        public static int romanToDecimal(string s)
        {


            int res = 0; //result
            int cur = 0; //decimal value of current roman number
            int pre = 0; //decimal value of previous roman number
            for (int i = s.Length - 1; i >= 0; i--)
            {
                cur = guide2[s[i]];
                res += (pre > cur) ? -cur : cur; //i used the addition and substraction rules for converting.
                pre = cur;
            }

            if (res >= 1 && res <= 3999)
                return res;
            else return -1;
        }
        /// <summary>
        /// This method gets a valid roman expression.
        /// </summary>
        /// <param name="title">Expression for client.</param>
        /// <returns>A valid roman number.</returns>
        public static string getStringOfRomanNumber(string title)
        {
            Console.WriteLine(title);
            //This regex expression is getting a valid roman number.
            Regex r = new Regex(@"(^(?=[MDCLXVI])M*(C[MD]|D?C{0,3})(X[CL]|L?X{0,3})(I[XV]|V?I{0,3})$)");

            while (true)
            {
                string s = Console.ReadLine();
                if (r.IsMatch(s.ToUpper())) return s.ToUpper();
                else Console.WriteLine("Invalid roman number");
            }

        }
        /// <summary>
        /// This method gets a number while until the number is valid.
        /// </summary>
        /// <param name="title">Expression for client.</param>
        /// <returns>A valid decimal number.</returns>
        public static int getNumber(string title)
        {
            int x = 0;
            do
            {
                if (!title.Equals("")) Console.WriteLine(title);
                try
                {
                    string s = Console.ReadLine();
                    Convert.ToInt32(s);
                    x = Convert.ToInt32(s);
                    break;
                }
                catch // FormatException OverflowException 
                {
                    Console.WriteLine("Invalid value...");
                }
            } while (true);

            return x;
        }

        /// <summary>
        /// For client.
        /// </summary>
        public static void menu()
        {
            string ret;
            while (true)
            {

                Console.WriteLine("\nFor Decimal to Roman -- Press 1\nFor Roman to Decimal -- Press 2\nFor cleaning the console -- Press 3\nFor Exit -- Press 0");
                switch (getNumber(""))
                {
                    case 1:
                        {
                            ret = decimalToRoman(getNumber("Enter a number between 1 and 3999"));

                            if (ret != null)
                                Console.WriteLine(ret);
                            break;
                        }
                    case 2:
                        {
                            ret = romanToDecimal(getStringOfRomanNumber("Enter a roman number")).ToString();
                            if (ret.Equals("-1"))
                                Console.WriteLine("Number is  out of range  or empty string");
                            else Console.WriteLine(ret);

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            break;
                        }
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            }


        }

    }     
}
