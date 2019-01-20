using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCalculator
{
    public class AddCalculator
    {
        public int Add(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                return 0;
            }
            return GetSum(numbers);
        }

        /// <summary>
        /// Get sum of given numbers
        /// </summary>
        /// <param name="numbers">ex: 1,2,3</param>
        /// <returns></returns>
        private static int GetSum(string numbers)
        {
            string[] strSeperator = { ",", "\n" };
            int result = 0;
            if (!string.IsNullOrEmpty(numbers))
            {
                string strNumbers = numbers.Replace("\\n", ",");

                //Split the string and convert it to integer list
                var lstNumbers = strNumbers.Split(strSeperator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                //Validate if any negative numbers present in the list
                ValidateNumbers(lstNumbers);

                result = lstNumbers.Sum();
            }
            return result;
        }

        /// <summary>
        /// Validates if any negative numbers present in the list
        /// </summary>
        /// <param name="numbersList">ex:1,-2,3</param>
        private static void ValidateNumbers(List<int> numbersList)
        {
            if (numbersList.Any(x => x < 0))
            {
                var negativeNumbers = string.Join(",", numbersList.Where(x => x < 0).Select(x => x.ToString()).ToArray());                
                Console.WriteLine("negatives not allowed " + " " + negativeNumbers);
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {            
            Console.WriteLine("Please enter the input");
            string numbers = Console.ReadLine();

            //Create object and invoke the add method
            int result = new AddCalculator().Add(numbers);

            Console.WriteLine("The result is " + " " + result);
            Console.ReadLine();
        }
    }
}
