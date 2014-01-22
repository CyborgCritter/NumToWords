using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumToWord
{
    class Program
    {
        static string[] onesList = new string[10] 
        {
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
        };
        
        static string[] teensList = new string[10] 
        {
            "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
			"seventeen", "eighteen", "nineteen"
        };

        static string[] tensList = new string[10] 
        {
            "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy",
			"eighty", "ninety"
        };

        static string[] thousandsList = new string [21] 
        {
            //Account for numbers up to 10^63.
            "", "thousand", "million", "billion", "trillion", "quadrillion",
			"quintillion", "sextillion", "septillion", "octillion", 
			"nonillion", "decillion", "undecillion", "duodecillion", 
			"tredecillion", "quattuordecillion", "sexdecillion", 
			"septendecillion", "octodecillion", "novemdecillion", 
			"vigintillion"
        };

        static void Main(string[] args)
        {
            Console.WriteLine(NumToString(5681121));
            Console.Write("\n\nPress any key to Exit... ");
            Console.ReadKey(true);
        }

        static string NumToString(int cardNum)
        {
            string numStr = cardNum.ToString();
            int numStrLen = numStr.Length;
            int groups = (int)Math.Ceiling(numStrLen/3.0f);
            int numDigits = groups * 3;
            numStr = numStr.PadLeft(numDigits, '0');

            List<string> numWordsList = new List<string>();
            
            if (cardNum == 0)
            {
                numWordsList.Add("zero");
            }
            else
            {
                for (int currentThreeDigits = 0; currentThreeDigits < numDigits; currentThreeDigits += 3)
                {
                    int hundredsPlace = int.Parse(numStr[currentThreeDigits].ToString());
                    int tensPlace = int.Parse(numStr[currentThreeDigits + 1].ToString());
                    int onesPlace = int.Parse(numStr[currentThreeDigits + 2].ToString());
                    int currentGroup = groups - (int)Math.Ceiling((currentThreeDigits / 3.0f) + 1);
                    if (hundredsPlace >= 1)
                    {
                        Console.WriteLine(hundredsPlace);
                        numWordsList.Add(onesList[hundredsPlace]);
                        numWordsList.Add("hundred");
                        //if ((tensPlace + onesPlace) > 0)
                        //{
                        //    // Add the Brittish usage "and" to the number.
                        //    numWordsList.Add("and");
                        //}
                    }

                    //else if (groups > 1 && currentGroup < 1 && (tensPlace + onesPlace) > 0)
                    //{
                    //    // Add Brittish usage "and" in the case where the number is no hundreds place and number is larger than 1000.
                    //    numWordsList.Add("and");
                    //}
                    if (tensPlace > 1)
                    {
                        numWordsList.Add(tensList[tensPlace]);

                        if (onesPlace >= 1)
                        {
                            numWordsList.Add(onesList[onesPlace]);
                        }
                    }

                    else if (tensPlace == 1)
                    {
                        if (onesPlace >= 1)
                        {
                            numWordsList.Add(teensList[onesPlace]);
                        }

                        else
                        {
                            numWordsList.Add(tensList[tensPlace]);
                        }
                    }

                    else if (onesPlace >= 1)
                    {
                        numWordsList.Add(onesList[onesPlace]);
                    }

                    if (currentGroup >= 1 && (hundredsPlace + tensPlace + onesPlace) > 0)
                    {
                        numWordsList.Add(thousandsList[currentGroup]);
                    }
                }
            }

            string numWords = "";
            int numItemsInList = numWordsList.Count;
            for (int arrayIndex = 0; arrayIndex < numItemsInList; arrayIndex++)
            {
                if (arrayIndex < (numItemsInList - 1))
                {
                numWords += numWordsList[arrayIndex] + " ";
                }
                else
                {
                    numWords += numWordsList[arrayIndex];
                }
            }


                return numWords;
        }
    }
}
